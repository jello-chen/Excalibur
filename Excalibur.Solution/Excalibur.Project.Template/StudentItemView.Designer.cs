namespace Excalibur.Project.Template
{
    partial class StudentItemView
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
            this.Student_Age = new System.Windows.Forms.TextBox();
            this.Student_Name = new System.Windows.Forms.TextBox();
            this.Student_ID = new System.Windows.Forms.TextBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.Edit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Student_Age
            // 
            this.Student_Age.Location = new System.Drawing.Point(72, 88);
            this.Student_Age.Name = "Student_Age";
            this.Student_Age.Size = new System.Drawing.Size(195, 21);
            this.Student_Age.TabIndex = 11;
            // 
            // Student_Name
            // 
            this.Student_Name.Location = new System.Drawing.Point(72, 48);
            this.Student_Name.Name = "Student_Name";
            this.Student_Name.Size = new System.Drawing.Size(195, 21);
            this.Student_Name.TabIndex = 10;
            // 
            // Student_ID
            // 
            this.Student_ID.Location = new System.Drawing.Point(72, 12);
            this.Student_ID.Name = "Student_ID";
            this.Student_ID.Size = new System.Drawing.Size(195, 21);
            this.Student_ID.TabIndex = 9;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(37, 94);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(29, 12);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Age:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(31, 54);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 12);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(42, 18);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(23, 12);
            this.lblID.TabIndex = 6;
            this.lblID.Text = "ID:";
            // 
            // Edit
            // 
            this.Edit.Location = new System.Drawing.Point(72, 120);
            this.Edit.Name = "Edit";
            this.Edit.Size = new System.Drawing.Size(75, 23);
            this.Edit.TabIndex = 12;
            this.Edit.Text = "Edit";
            this.Edit.UseVisualStyleBackColor = true;
            // 
            // StudentItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 155);
            this.Controls.Add(this.Edit);
            this.Controls.Add(this.Student_Age);
            this.Controls.Add(this.Student_Name);
            this.Controls.Add(this.Student_ID);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Name = "StudentItemView";
            this.Text = "StudentItemView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Student_Age;
        private System.Windows.Forms.TextBox Student_Name;
        private System.Windows.Forms.TextBox Student_ID;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Button Edit;
    }
}