namespace Excalibur.Framework.Controls
{
    partial class Window
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
            this.components = new System.ComponentModel.Container();
            this.MainPlaceHolder = new Excalibur.Framework.Controls.Placeholder(this.components);
            this.SuspendLayout();
            // 
            // MainPlaceHolder
            // 
            this.MainPlaceHolder.BackColor = System.Drawing.Color.Transparent;
            this.MainPlaceHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPlaceHolder.Location = new System.Drawing.Point(0, 0);
            this.MainPlaceHolder.Name = "MainPlaceHolder";
            this.MainPlaceHolder.Size = new System.Drawing.Size(628, 353);
            this.MainPlaceHolder.TabIndex = 0;
            this.MainPlaceHolder.ViewModel = null;
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 353);
            this.Controls.Add(this.MainPlaceHolder);
            this.Name = "Window";
            this.Text = "Main Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Placeholder MainPlaceHolder;
    }
}