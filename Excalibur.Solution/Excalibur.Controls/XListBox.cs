using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excalibur.Controls
{
    /// <summary>
    /// ListBox Extention
    /// </summary>
    public class XListBox : ListBox
    {
        private StringFormat stringFormat;
        private Size imageSize;

        private Font titleFont = DefaultFont;
        /// <summary>
        /// Title Font
        /// </summary>
        [Description("Title Font")]
        public Font TitleFont
        {
            get { return titleFont; }
            set { titleFont = value; }
        }

        private Font contentFont = DefaultFont;

        /// <summary>
        /// Content Font
        /// </summary>
        [Description("Content Font")]
        public Font ContentFont
        {
            get { return contentFont; }
            set { contentFont = value; }
        }

        private Font timeFont = DefaultFont;

        /// <summary>
        /// Time Font
        /// </summary>
        [Description("Time Font")]
        public Font TimeFont
        {
            get { return timeFont; }
            set { timeFont = value; }
        }
        /// <summary>
        /// BackColor of the selected item
        /// </summary>
        [Description("BackColor of the selected item")]
        public Color SelectedItemBackColor { get; set; }

        /// <summary>
        /// Draw Mode
        /// </summary>
        [DefaultValue(DrawMode.OwnerDrawVariable)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DrawMode DrawMode
        {
            get
            {
                return base.DrawMode;
            }
            private set
            {
                base.DrawMode = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Font Font
        {
            get { return base.Font; }
            private set { base.Font = value; }
        }

        private int itemHeight = 66;

        [DefaultValue(66)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }

        public XListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
            imageSize = new Size(60, 60);
            this.ItemHeight = imageSize.Height + this.Margin.Vertical;
            stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Center;
            DoubleBuffered = true;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            // prevent from error Visual Designer
            if (this.Items.Count > 0)
            {
                var item = (XListBoxItem)this.Items[e.Index];
                item.DrawItem(e, this.Margin, titleFont, contentFont, timeFont, stringFormat, imageSize,
                    SelectedItemBackColor);
            }
        }
    }
    /// <summary>
    /// ListBox Item
    /// </summary>
    public class XListBoxItem
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Avatar
        /// </summary>
        public Image Avatar { get; set; }
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Time
        /// </summary>
        public string Time { get; set; }

        public XListBoxItem()
        {

        }

        public XListBoxItem(string id, Image avatar, string title, string content, string time)
        {
            this.ID = id;
            this.Avatar = avatar;
            this.Title = title;
            this.Content = content;
            this.Time = time;
        }

        public void DrawItem(DrawItemEventArgs e, Padding margin,
            Font titleFont, Font contentFont, Font timeFont, StringFormat format,
            Size imageSize, Color selectedBackColor)
        {
            if (this.Avatar == null) return;
            // if selected, mark the background differently.
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                using (var brush = new SolidBrush(selectedBackColor))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Beige, e.Bounds);
            }

            // draw some item separate line.
            e.Graphics.DrawLine(Pens.DarkGray, e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);

            // draw item image
            e.Graphics.DrawImage(this.Avatar, e.Bounds.X + margin.Left, e.Bounds.Y + margin.Top, imageSize.Width,
                    imageSize.Height);

            var timeSize = e.Graphics.MeasureString(this.Time, timeFont).ToSize();

            // calculate bounds for title text drawing
            var titleBounds = new Rectangle(e.Bounds.X + margin.Horizontal + imageSize.Width,
                e.Bounds.Y + margin.Top,
                e.Bounds.Width - margin.Right - imageSize.Width - margin.Horizontal,
                (int)titleFont.GetHeight() + 2);

            // calculate bounds for content text drawing
            var contentBounds = new Rectangle(e.Bounds.X + margin.Horizontal + imageSize.Width,
                e.Bounds.Y + (int)titleFont.GetHeight() + 2 + margin.Vertical + margin.Top,
                e.Bounds.Width - margin.Right - imageSize.Width - margin.Horizontal,
                e.Bounds.Height - margin.Bottom - (int)titleFont.GetHeight() - 2 - margin.Vertical - margin.Top);

            // calculate bounds for timeBounds text drawing
            var timeBounds = new Rectangle(e.Bounds.Width - margin.Right - 60 - margin.Horizontal,
                e.Bounds.Y + margin.Top,
                60,
                imageSize.Height);

            // draw title string
            e.Graphics.DrawString(Title, titleFont, Brushes.Black, titleBounds, format);
            e.Graphics.DrawString(Content, contentFont, Brushes.DarkGray, contentBounds, format);
            //e.Graphics.DrawString(Time, timeFont, Brushes.Black, timeBounds, format);

            // put some focus rectangle
            e.DrawFocusRectangle();
        }
    }

    /// <summary>
    /// ListBox Items Editor
    /// </summary>
    internal class ListBoxItemCollectionEditor : CollectionEditor
    {
        public ListBoxItemCollectionEditor(Type type)
            : base(type)
        {

        }

        protected override Type[] CreateNewItemTypes()
        {
            return new Type[]
            {
                typeof (XListBoxItem)
            };
        }
    }
}
