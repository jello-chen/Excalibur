namespace Excalibur.Controls.Sample
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.xWaitingCircle1 = new Excalibur.Controls.XWaitingCircle();
            this.xPageControl1 = new Excalibur.Controls.XPageControl();
            this.xListBox1 = new Excalibur.Controls.XListBox();
            this.xButton1 = new Excalibur.Controls.XButton();
            this.xAppContainer1 = new Excalibur.Controls.XAppContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(318, 235);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(478, 210);
            this.dataGridView1.TabIndex = 4;
            // 
            // xWaitingCircle1
            // 
            this.xWaitingCircle1.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            this.xWaitingCircle1.HotSpokeColor = System.Drawing.Color.DarkGray;
            this.xWaitingCircle1.InnerRadius = 13.5F;
            this.xWaitingCircle1.Location = new System.Drawing.Point(145, 202);
            this.xWaitingCircle1.Name = "xWaitingCircle1";
            this.xWaitingCircle1.Size = new System.Drawing.Size(77, 64);
            this.xWaitingCircle1.Speed = 80;
            this.xWaitingCircle1.SpokeColor = System.Drawing.Color.DimGray;
            this.xWaitingCircle1.StartCap = System.Drawing.Drawing2D.LineCap.Triangle;
            this.xWaitingCircle1.TabIndex = 5;
            this.xWaitingCircle1.Text = "xWaitingCircle1";
            this.xWaitingCircle1.Thickness = 3F;
            // 
            // xPageControl1
            // 
            this.xPageControl1.BackColor = System.Drawing.Color.Transparent;
            this.xPageControl1.Location = new System.Drawing.Point(309, 467);
            this.xPageControl1.Name = "xPageControl1";
            this.xPageControl1.PageIndex = 1;
            this.xPageControl1.PageSize = 20;
            this.xPageControl1.RecordCount = 0;
            this.xPageControl1.Size = new System.Drawing.Size(493, 32);
            this.xPageControl1.TabIndex = 3;
            this.xPageControl1.PageIndexChanged += new System.EventHandler<Excalibur.Controls.PageIndexChangedEventArgs>(this.xPageControl1_PageIndexChanged);
            // 
            // xListBox1
            // 
            this.xListBox1.ContentFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xListBox1.FormattingEnabled = true;
            this.xListBox1.Location = new System.Drawing.Point(13, 13);
            this.xListBox1.Name = "xListBox1";
            this.xListBox1.SelectedItemBackColor = System.Drawing.Color.Gray;
            this.xListBox1.Size = new System.Drawing.Size(413, 172);
            this.xListBox1.TabIndex = 2;
            this.xListBox1.TimeFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xListBox1.TitleFont = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // xButton1
            // 
            this.xButton1.ActiveOnMouseEnter = true;
            this.xButton1.BackColor = System.Drawing.SystemColors.Control;
            this.xButton1.BackColorActive = System.Drawing.Color.Red;
            this.xButton1.BackColorDisable = System.Drawing.Color.Transparent;
            this.xButton1.BackColorInvert = System.Drawing.Color.MediumVioletRed;
            this.xButton1.BackColorInvertActive = System.Drawing.Color.Green;
            this.xButton1.BackgroundImageActive = null;
            this.xButton1.BackgroundImageDisable = null;
            this.xButton1.BackgroundImageInvert = null;
            this.xButton1.BackgroundImageInvertActive = null;
            this.xButton1.ButtonTitle = "Button";
            this.xButton1.ClickToInvert = false;
            this.xButton1.IsInvert = false;
            this.xButton1.Location = new System.Drawing.Point(13, 207);
            this.xButton1.Name = "xButton1";
            this.xButton1.Size = new System.Drawing.Size(64, 24);
            this.xButton1.TabIndex = 1;
            this.xButton1.TitleColor = System.Drawing.Color.Maroon;
            this.xButton1.ToolTipText = "Button";
            this.xButton1.Click += new System.EventHandler(this.xButton1_Click);
            // 
            // xAppContainer1
            // 
            this.xAppContainer1.AppFilename = "calc.exe";
            this.xAppContainer1.AutoStart = true;
            this.xAppContainer1.Location = new System.Drawing.Point(445, 11);
            this.xAppContainer1.Name = "xAppContainer1";
            this.xAppContainer1.Size = new System.Drawing.Size(351, 176);
            this.xAppContainer1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(814, 539);
            this.Controls.Add(this.xWaitingCircle1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.xPageControl1);
            this.Controls.Add(this.xListBox1);
            this.Controls.Add(this.xButton1);
            this.Controls.Add(this.xAppContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XAppContainer xAppContainer1;
        private XButton xButton1;
        private XListBox xListBox1;
        private XPageControl xPageControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private XWaitingCircle xWaitingCircle1;

    }
}

