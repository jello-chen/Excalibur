using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excalibur.Controls
{
    [Description("Inverts status when the user clicks it accordingly"), DefaultEvent("Click"), DefaultProperty("ButtonTitle")]
    public partial class XButton : UserControl
    {
        #region Fields
        private Image mBackgroundImageActive;
        private Color mBackColorActive = Color.Transparent;
        private Image mBackgroundImageInvert;
        private Color mBackColorInvert = Color.Transparent;
        private Image mBackgroundImageInvertActive;
        private Color mBackColorInvertActive = Color.Transparent;
        private Image mBackgroundImageDisable;
        private Color mBackColorDisable = Color.Transparent;
        private Color mTitleColor = Color.Black;
        private string mButtonTitle;
        private string mToolTipText;
        private bool mActiveOnMouseEnter;
        private bool mIsInvert;
        private bool mClickToInvert;
        private bool mOriginalValueSaved;
        private Image mSavedBackgroundImage;
        private Color mSavedBackColor = Color.Empty; 
        #endregion

        #region Properties
        /// <summary>
        /// Specifies the background image of the control when actived
        /// </summary>
        [Category("Appearance"), Description("Specifies the background image of the control when actived")]
        public Image BackgroundImageActive
        {
            get
            {
                return this.mBackgroundImageActive;
            }
            set
            {
                this.mBackgroundImageActive = value;
            }
        }
        /// <summary>
        /// Specifies the backcolor of the control when actived
        /// </summary>
        [Category("Appearance"), Description("Specifies the backcolor of the control when actived")]
        public Color BackColorActive
        {
            get
            {
                return this.mBackColorActive;
            }
            set
            {
                this.mBackColorActive = value;
            }
        }
        /// <summary>
        /// Specifies the background image of the control when inverted
        /// </summary>
        [Category("Appearance"), Description("Specifies the background image of the control when inverted")]
        public Image BackgroundImageInvert
        {
            get
            {
                return this.mBackgroundImageInvert;
            }
            set
            {
                this.mBackgroundImageInvert = value;
            }
        }
        /// <summary>
        /// Specifies the backcolor of the control when inverted
        /// </summary>
        [Category("Appearance"), Description("Specifies the backcolor of the control when inverted")]
        public Color BackColorInvert
        {
            get
            {
                return this.mBackColorInvert;
            }
            set
            {
                this.mBackColorInvert = value;
            }
        }
        /// <summary>
        /// Specifies the background image of the control when inverted and actived
        /// </summary>
        [Category("Appearance"), Description("Specifies the background image of the control when inverted and actived")]
        public Image BackgroundImageInvertActive
        {
            get
            {
                return this.mBackgroundImageInvertActive;
            }
            set
            {
                this.mBackgroundImageInvertActive = value;
            }
        }
        /// <summary>
        /// Specifies the backcolor of the control when inverted and actived
        /// </summary>
        [Category("Appearance"), Description("Specifies the backcolor of the control when inverted and actived")]
        public Color BackColorInvertActive
        {
            get
            {
                return this.mBackColorInvertActive;
            }
            set
            {
                this.mBackColorInvertActive = value;
            }
        }
        /// <summary>
        /// Specifies the background image of the control when disabled
        /// </summary>
        [Category("Appearance"), Description("Specifies the background image of the control when disabled")]
        public Image BackgroundImageDisable
        {
            get
            {
                return this.mBackgroundImageDisable;
            }
            set
            {
                this.mBackgroundImageDisable = value;
            }
        }
        /// <summary>
        /// Specifies the backcolor of the control when disabled
        /// </summary>
        [Category("Appearance"), Description("Specifies the backcolor of the control when disabled")]
        public Color BackColorDisable
        {
            get
            {
                return this.mBackColorDisable;
            }
            set
            {
                this.mBackColorDisable = value;
            }
        }

        /// <summary>
        /// The control associated the text color
        /// </summary>
        [Category("Appearance"), Description("The control associated the text color")]
        public Color TitleColor
        {
            get
            {
                return this.mTitleColor;
            }
            set
            {
                this.mTitleColor = value;
                this.lblTitle.ForeColor = value;
            }
        }

        /// <summary>
        /// The control associated the text
        /// </summary>
        [Category("Data"), Description("The control associated the text"), SettingsBindable(true)]
        public string ButtonTitle
        {
            get
            {
                return this.mButtonTitle;
            }
            set
            {
                this.mButtonTitle = value;
                this.lblTitle.Text = value;
            }
        }

        /// <summary>
        /// The control associated the tooltip text
        /// </summary>
        [Category("Data"), Description("The control associated the tooltip text")]
        public string ToolTipText
        {
            get
            {
                return this.mToolTipText;
            }
            set
            {
                this.mToolTipText = value;
                this.btnToolTip.SetToolTip(this.lblTitle, this.mToolTipText);
            }
        }

        /// <summary>
        /// Indicates whether the control is actived when mouse enters
        /// </summary>
        [Category("Action"), Description("Indicates whether the control is actived when mouse enters")]
        public bool ActiveOnMouseEnter
        {
            get
            {
                return this.mActiveOnMouseEnter;
            }
            set
            {
                this.mActiveOnMouseEnter = value;
            }
        }

        private Image mCurrentBackgroundImage
        {
            set
            {
                if (value != null)
                {
                    this.BackgroundImage = value;
                }
            }
        }

        private Color mCurrentBackColor
        {
            set
            {
                if (value != Color.Empty)
                {
                    this.BackColor = value;
                }
            }
        }

        /// <summary>
        /// Indicates whether the control is inverted
        /// </summary>
        [Category("Action"), Description("Indicates whether the control is inverted")]
        public bool IsInvert
        {
            get { return mIsInvert; }
            set
            {
                this.mIsInvert = value;
                if (!this.mOriginalValueSaved)
                {
                    this.mSavedBackgroundImage = this.BackgroundImage;
                    this.mSavedBackColor = this.BackColor;
                    this.mOriginalValueSaved = true;
                }
                if (this.mIsInvert)
                {
                    this.mCurrentBackgroundImage = this.BackgroundImageInvert;
                    this.mCurrentBackColor = this.BackColorInvert;
                    return;
                }
                this.mCurrentBackgroundImage = mSavedBackgroundImage;
                this.mCurrentBackColor = mSavedBackColor;
            }
        }

        /// <summary>
        /// Indicates whether click the control leads to invert
        /// </summary>
        [Category("Action"), Description("Indicates whether click the control leads to invert")]
        public bool ClickToInvert
        {
            get
            {
                return this.mClickToInvert;
            }
            set
            {
                this.mClickToInvert = value;
            }
        }

        /// <summary>
        /// Indicates whether the control is enabled
        /// </summary>
        [Description("Indicates whether the control is enabled")]
        public new bool Enabled
        {
            get { return base.Enabled; }
            set
            {
                base.Enabled = value;
                this.IsInvert = this.mIsInvert;
                if (!value)
                {
                    this.mCurrentBackgroundImage = this.mBackgroundImageDisable;
                    this.mCurrentBackColor = this.mBackColorDisable;
                }
            }
        } 
        #endregion

        #region Constructors
        public XButton()
        {
            InitializeComponent();
            this.Load += XButton_Load;
            this.lblTitle.MouseEnter += new EventHandler(this.OnMouseEnter);
            this.lblTitle.MouseDown += new MouseEventHandler(this.OnMouseDown);
            this.lblTitle.MouseUp += new MouseEventHandler(this.OnMouseUp);
            this.lblTitle.MouseLeave += new EventHandler(this.OnMouseLeave);
            this.lblTitle.Click += new EventHandler(this.OnMouseClick);
        } 
        #endregion

        #region Event Handle
        private void OnMouseClick(object sender, EventArgs e)
        {
            if (this.mClickToInvert)
            {
                this.IsInvert = !this.IsInvert;
            }
            this.OnClick(e);
        }

        private void OnMouseLeave(object sender, EventArgs e)
        {
            if (this.mActiveOnMouseEnter)
            {
                this.SetActiveStatus(false);
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (!this.mActiveOnMouseEnter)
            {
                this.SetActiveStatus(false);
            }
            this.OnMouseUp(e);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (!this.mActiveOnMouseEnter)
            {
                this.SetActiveStatus(true);
            }
            this.OnMouseDown(e);
        }

        private void OnMouseEnter(object sender, EventArgs e)
        {
            if (this.mActiveOnMouseEnter)
            {
                this.SetActiveStatus(true);
            }
        }

        void XButton_Load(object sender, EventArgs e)
        {
            if (!this.mOriginalValueSaved)
            {
                this.mSavedBackgroundImage = this.BackgroundImage;
                this.mSavedBackColor = this.BackColor;
                this.mOriginalValueSaved = true;
            }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Set the control status when Actived
        /// </summary>
        /// <param name="active"></param>
        private void SetActiveStatus(bool active)
        {
            if (!this.Enabled)
            {
                return;
            }
            if (active)
            {
                if (!this.mIsInvert)
                {
                    this.mCurrentBackgroundImage = this.mBackgroundImageActive;
                    this.mCurrentBackColor = this.mBackColorActive;
                    return;
                }
                this.mCurrentBackgroundImage = this.mBackgroundImageInvertActive;
                this.mCurrentBackColor = this.mBackColorInvertActive;
                return;
            }
            else
            {
                if (!this.mIsInvert)
                {
                    this.mCurrentBackgroundImage = this.mSavedBackgroundImage;
                    this.mCurrentBackColor = this.mSavedBackColor;
                    return;
                }
                this.mCurrentBackgroundImage = this.mBackgroundImageInvert;
                this.mCurrentBackColor = this.mBackColorInvert;
                return;
            }
        } 
        #endregion
    }
}
