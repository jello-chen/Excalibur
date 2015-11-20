namespace Excalibur.Project.Template
{
    partial class ShellView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.QueryItem_ID = new System.Windows.Forms.TextBox();
            this.QueryItem_Name = new System.Windows.Forms.TextBox();
            this.QueryItem_Age = new System.Windows.Forms.TextBox();
            this.StudentList = new System.Windows.Forms.DataGridView();
            this.Query = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Query);
            this.groupBox1.Controls.Add(this.QueryItem_Age);
            this.groupBox1.Controls.Add(this.QueryItem_Name);
            this.groupBox1.Controls.Add(this.QueryItem_ID);
            this.groupBox1.Controls.Add(this.lblAge);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 45);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quey";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(295, 20);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 12);
            this.lblAge.TabIndex = 2;
            this.lblAge.Text = "Age:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(151, 21);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(16, 21);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 12);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID:";
            // 
            // QueryItem_ID
            // 
            this.QueryItem_ID.Location = new System.Drawing.Point(46, 15);
            this.QueryItem_ID.Name = "QueryItem_ID";
            this.QueryItem_ID.Size = new System.Drawing.Size(78, 21);
            this.QueryItem_ID.TabIndex = 3;
            // 
            // QueryItem_Name
            // 
            this.QueryItem_Name.Location = new System.Drawing.Point(192, 15);
            this.QueryItem_Name.Name = "QueryItem_Name";
            this.QueryItem_Name.Size = new System.Drawing.Size(78, 21);
            this.QueryItem_Name.TabIndex = 4;
            // 
            // QueryItem_Age
            // 
            this.QueryItem_Age.Location = new System.Drawing.Point(330, 14);
            this.QueryItem_Age.Name = "QueryItem_Age";
            this.QueryItem_Age.Size = new System.Drawing.Size(78, 21);
            this.QueryItem_Age.TabIndex = 5;
            // 
            // StudentList
            // 
            this.StudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StudentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StudentList.Location = new System.Drawing.Point(0, 45);
            this.StudentList.Name = "StudentList";
            this.StudentList.RowTemplate.Height = 23;
            this.StudentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.StudentList.Size = new System.Drawing.Size(546, 245);
            this.StudentList.TabIndex = 1;
            // 
            // Query
            // 
            this.Query.Location = new System.Drawing.Point(445, 14);
            this.Query.Name = "Query";
            this.Query.Size = new System.Drawing.Size(75, 23);
            this.Query.TabIndex = 6;
            this.Query.Text = "Query";
            this.Query.UseVisualStyleBackColor = true;
            // 
            // ShellView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StudentList);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShellView";
            this.Size = new System.Drawing.Size(546, 290);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StudentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox QueryItem_ID;
        private System.Windows.Forms.TextBox QueryItem_Age;
        private System.Windows.Forms.TextBox QueryItem_Name;
        private System.Windows.Forms.DataGridView StudentList;
        private System.Windows.Forms.Button Query;
    }
}
