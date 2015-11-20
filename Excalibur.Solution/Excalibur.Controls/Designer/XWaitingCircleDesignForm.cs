using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Excalibur.Controls.Designer
{
    public partial class XWaitingCircleDesignForm : Form
    {
        public XWaitingCircleDesignForm()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            waitingCircle1.NumberOfSpokes =(int) numericUpDown1.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            waitingCircle1.Speed = (trackBar1.Maximum - trackBar1.Value+trackBar1.Minimum) * 20;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            waitingCircle1.ColockWise = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            waitingCircle1.Activate = checkBox2.Checked;
        }

        private void WaitingCircleDesignForm_Load(object sender, EventArgs e)
        {
            int val=trackBar1.Maximum + trackBar1.Minimum - (waitingCircle1.Speed / 20);
            trackBar1.Value = Math.Min(trackBar1.Maximum, Math.Max(trackBar1.Minimum, val));
            checkBox1.Checked = waitingCircle1.ColockWise;
            checkBox2.Checked = waitingCircle1.Activate;
            numericUpDown1.Value = waitingCircle1.NumberOfSpokes;
        }
    }
}
