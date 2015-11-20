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
    [DefaultEvent("PageIndexChanged"), DefaultProperty("RecordCount"), Description("Pager Control")]
    public partial class XPageControl : UserControl
    {
        private int mPageSize = 20;
        private int mPageIndex = 1;
        private int mRecordCount;
        public event EventHandler<PageIndexChangedEventArgs> PageIndexChanged; 

        [Category("Data"), Description("Page Size")]
        public int PageSize
        {
            get
            {
                return this.mPageSize;
            }
            set
            {
                if (value < 1)
                {
                    value = 1;
                }
                this.mPageSize = value;
                this.SetPagerText();
                this.SetBtnEnabled();
            }
        }

        [Category("Data"), Description("Current Page Index,min value is 1")]
        public int PageIndex
        {
            get
            {
                return this.mPageIndex;
            }
            set
            {
                this.mPageIndex = value;
                if (this.mPageIndex > this.PageCount)
                {
                    this.mPageIndex = this.PageCount;
                }
                if (this.mPageIndex < 1)
                {
                    this.mPageIndex = 1;
                }
                this.SetPagerText();
                this.SetBtnEnabled();
            }
        }

        [Category("Data"), Description("Total record count")]
        public int RecordCount
        {
            get
            {
                return this.mRecordCount;
            }
            set
            {
                this.mRecordCount = value;
                if (this.mPageIndex > this.PageCount)
                {
                    this.mPageIndex = this.PageCount;
                }
                this.SetPagerText();
                this.SetBtnEnabled();
            }
        }

        [Category("Data"), Description("Total page count")]
        public int PageCount
        {
            get
            {
                if (this.mRecordCount <= this.PageSize)
                {
                    return 1;
                }
                return (this.RecordCount - 1) / this.PageSize + 1;
            }
        }

        public XPageControl()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 1;
        }

        private void SetBtnEnabled()
        {
            this.btnFirst.Enabled = true;
            this.btnPrev.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;
            if (this.PageIndex == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPrev.Enabled = false;
            }
            if (this.PageIndex == this.PageCount)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }

        private void SetPagerText()
        {
            this.lblPager.Text = string.Format("{0}/{1},{2}", this.PageIndex.ToString(), this.PageCount.ToString(), this.RecordCount.ToString());
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.PageIndex = 1;
            if (this.PageIndexChanged != null)
            {
                PageIndexChanged(this, new PageIndexChangedEventArgs() {PageIndex = this.PageIndex});
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.PageIndex = this.PageCount;
            if (this.PageIndexChanged != null)
            {
                PageIndexChanged(this, new PageIndexChangedEventArgs() { PageIndex = this.PageIndex });
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.PageIndex++;
            if (this.PageIndexChanged != null)
            {
                PageIndexChanged(this, new PageIndexChangedEventArgs() { PageIndex = this.PageIndex });
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.PageIndex--;
            if (this.PageIndexChanged != null)
            {
                PageIndexChanged(this, new PageIndexChangedEventArgs() { PageIndex = this.PageIndex });
            }
        }

        private void btnJump_Click(object sender, EventArgs e)
        {
            try
            {
                int pageIndex = int.Parse(this.txtToPageIndex.Text);
                this.PageIndex = pageIndex;
                if (this.PageIndexChanged != null)
                {
                    PageIndexChanged(this, new PageIndexChangedEventArgs() { PageIndex = this.PageIndex });
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtToPageIndex_KeyPress(object sender, KeyPressEventArgs e)
        {  
            if (e.KeyChar != 8 && e.KeyChar != 13 && !char.IsNumber(e.KeyChar)) e.Handled = true;
            if (((TextBox)sender).Text.Length == 0)
            {
                e.Handled = true;
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var perpageCount = 20;
            if (int.TryParse(this.comboBox1.Text, out perpageCount))
            {
                this.PageSize = perpageCount;
                this.PageIndex = 1;
                if (PageIndexChanged != null) 
                    PageIndexChanged(this, new PageIndexChangedEventArgs() { PageIndex = this.PageIndex });
            }
        }
    }

    /// <summary>
    /// PageIndexChanged Event Args
    /// </summary>
    public class PageIndexChangedEventArgs : EventArgs
    {
        public int PageIndex { get; set; }
    }
}
