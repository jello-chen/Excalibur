using System;
using System.Drawing;
using System.Windows.Forms;
using Excalibur.Controls.Properties;

namespace Excalibur.Controls
{
    partial class XPageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPager = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToPageIndex = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnJump = new Excalibur.Controls.XButton();
            this.btnLast = new Excalibur.Controls.XButton();
            this.btnNext = new Excalibur.Controls.XButton();
            this.btnPrev = new Excalibur.Controls.XButton();
            this.btnFirst = new Excalibur.Controls.XButton();
            this.SuspendLayout();
            // 
            // lblPager
            // 
            this.lblPager.AutoSize = true;
            this.lblPager.ForeColor = System.Drawing.Color.Transparent;
            this.lblPager.Location = new System.Drawing.Point(3, 11);
            this.lblPager.Name = "lblPager";
            this.lblPager.Size = new System.Drawing.Size(71, 12);
            this.lblPager.TabIndex = 0;
            this.lblPager.Text = "{0}/{1},{2}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(413, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "page";
            // 
            // txtToPageIndex
            // 
            this.txtToPageIndex.Location = new System.Drawing.Point(359, 7);
            this.txtToPageIndex.MaxLength = 4;
            this.txtToPageIndex.Name = "txtToPageIndex";
            this.txtToPageIndex.Size = new System.Drawing.Size(48, 21);
            this.txtToPageIndex.TabIndex = 6;
            this.txtToPageIndex.Text = "1";
            this.txtToPageIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToPageIndex_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10",
            "20",
            "50"});
            this.comboBox1.Location = new System.Drawing.Point(107, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(35, 20);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(336, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "to";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(144, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "/ Page";
            // 
            // btnJump
            // 
            this.btnJump.ActiveOnMouseEnter = true;
            this.btnJump.BackColor = System.Drawing.Color.Transparent;
            this.btnJump.BackColorActive = System.Drawing.Color.Transparent;
            this.btnJump.BackColorDisable = System.Drawing.Color.Transparent;
            this.btnJump.BackColorInvert = System.Drawing.Color.Transparent;
            this.btnJump.BackColorInvertActive = System.Drawing.Color.Transparent;
            this.btnJump.BackgroundImage = global::Excalibur.Controls.Properties.Resources.icon_jump_normal;
            this.btnJump.BackgroundImageActive = global::Excalibur.Controls.Properties.Resources.icon_jump_active;
            this.btnJump.BackgroundImageDisable = null;
            this.btnJump.BackgroundImageInvert = null;
            this.btnJump.BackgroundImageInvertActive = null;
            this.btnJump.ButtonTitle = "";
            this.btnJump.ClickToInvert = false;
            this.btnJump.IsInvert = false;
            this.btnJump.Location = new System.Drawing.Point(448, 1);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(45, 30);
            this.btnJump.TabIndex = 8;
            this.btnJump.TitleColor = System.Drawing.Color.Black;
            this.btnJump.ToolTipText = "跳转到指定页";
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnLast
            // 
            this.btnLast.ActiveOnMouseEnter = true;
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.BackColorActive = System.Drawing.Color.Transparent;
            this.btnLast.BackColorDisable = System.Drawing.Color.Transparent;
            this.btnLast.BackColorInvert = System.Drawing.Color.Transparent;
            this.btnLast.BackColorInvertActive = System.Drawing.Color.Transparent;
            this.btnLast.BackgroundImage = global::Excalibur.Controls.Properties.Resources.icon_last_normal;
            this.btnLast.BackgroundImageActive = global::Excalibur.Controls.Properties.Resources.icon_last_active;
            this.btnLast.BackgroundImageDisable = null;
            this.btnLast.BackgroundImageInvert = null;
            this.btnLast.BackgroundImageInvertActive = null;
            this.btnLast.ButtonTitle = "";
            this.btnLast.ClickToInvert = false;
            this.btnLast.IsInvert = false;
            this.btnLast.Location = new System.Drawing.Point(300, 1);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.TitleColor = System.Drawing.Color.Black;
            this.btnLast.ToolTipText = "Last Page";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.ActiveOnMouseEnter = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BackColorActive = System.Drawing.Color.Transparent;
            this.btnNext.BackColorDisable = System.Drawing.Color.Transparent;
            this.btnNext.BackColorInvert = System.Drawing.Color.Transparent;
            this.btnNext.BackColorInvertActive = System.Drawing.Color.Transparent;
            this.btnNext.BackgroundImage = global::Excalibur.Controls.Properties.Resources.icon_next_normal;
            this.btnNext.BackgroundImageActive = global::Excalibur.Controls.Properties.Resources.icon_next_active;
            this.btnNext.BackgroundImageDisable = null;
            this.btnNext.BackgroundImageInvert = null;
            this.btnNext.BackgroundImageInvertActive = null;
            this.btnNext.ButtonTitle = "";
            this.btnNext.ClickToInvert = false;
            this.btnNext.IsInvert = false;
            this.btnNext.Location = new System.Drawing.Point(264, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.TitleColor = System.Drawing.Color.Black;
            this.btnNext.ToolTipText = "Next Page";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.ActiveOnMouseEnter = true;
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.BackColorActive = System.Drawing.Color.Transparent;
            this.btnPrev.BackColorDisable = System.Drawing.Color.Transparent;
            this.btnPrev.BackColorInvert = System.Drawing.Color.Transparent;
            this.btnPrev.BackColorInvertActive = System.Drawing.Color.Transparent;
            this.btnPrev.BackgroundImage = global::Excalibur.Controls.Properties.Resources.icon_prev_normal;
            this.btnPrev.BackgroundImageActive = global::Excalibur.Controls.Properties.Resources.icon_prev_active;
            this.btnPrev.BackgroundImageDisable = null;
            this.btnPrev.BackgroundImageInvert = null;
            this.btnPrev.BackgroundImageInvertActive = null;
            this.btnPrev.ButtonTitle = "";
            this.btnPrev.ClickToInvert = false;
            this.btnPrev.IsInvert = false;
            this.btnPrev.Location = new System.Drawing.Point(228, 1);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(30, 30);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.TitleColor = System.Drawing.Color.Black;
            this.btnPrev.ToolTipText = "Previous Page";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.ActiveOnMouseEnter = true;
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.BackColorActive = System.Drawing.Color.Transparent;
            this.btnFirst.BackColorDisable = System.Drawing.Color.Transparent;
            this.btnFirst.BackColorInvert = System.Drawing.Color.Transparent;
            this.btnFirst.BackColorInvertActive = System.Drawing.Color.Transparent;
            this.btnFirst.BackgroundImage = global::Excalibur.Controls.Properties.Resources.icon_first_normal;
            this.btnFirst.BackgroundImageActive = global::Excalibur.Controls.Properties.Resources.icon_first_active;
            this.btnFirst.BackgroundImageDisable = null;
            this.btnFirst.BackgroundImageInvert = null;
            this.btnFirst.BackgroundImageInvertActive = null;
            this.btnFirst.ButtonTitle = "";
            this.btnFirst.ClickToInvert = false;
            this.btnFirst.IsInvert = false;
            this.btnFirst.Location = new System.Drawing.Point(192, 1);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 30);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.TitleColor = System.Drawing.Color.Black;
            this.btnFirst.ToolTipText = "First Page";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // XPageControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.txtToPageIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPager);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnFirst);
            this.Name = "XPageControl";
            this.Size = new System.Drawing.Size(493, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XButton btnFirst;
        private XButton btnPrev;
        private XButton btnNext;
        private XButton btnLast;
        private Label lblPager;
        private Label label2;
        private TextBox txtToPageIndex;
        private XButton btnJump;
        private ComboBox comboBox1;
        private Label label1;
        private Label label3;
    }
}
