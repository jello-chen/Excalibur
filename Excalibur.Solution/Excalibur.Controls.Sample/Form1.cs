using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excalibur.Controls.Sample
{
    public partial class Form1 : Form
    {
        public List<Student> Students { get; set; }
        public Form1()
        {
            InitializeComponent();

            #region XListBox
            Image image1 = Image.FromFile(@"Resources\Images\image1.png");
            Image image2 = Image.FromFile(@"Resources\Images\image2.png");
            Image image3 = Image.FromFile(@"Resources\Images\image3.png");
            xListBox1.Items.Add(new XListBoxItem("1", image1, "李雷", "去吃饭咯", "11:00"));
            xListBox1.Items.Add(new XListBoxItem("2", image2, "比尔", "又下雨了，不开森", "昨天"));
            xListBox1.Items.Add(new XListBoxItem("3", image3, "韩梅梅", "我的电话：13012138866", "11月15日")); 
            #endregion

            #region XPagerControl
            Students = new List<Student>();
            for (int i = 0; i < 100; i++)
            {
                Students.Add(new Student { ID = i, Name = "jello" + i });
            }
            Bind(1); 
            #endregion

        }

        private void xButton1_Click(object sender, EventArgs e)
        {
            this.xButton1.IsInvert = !this.xButton1.IsInvert;
        }

        void Bind(int pageIndex)
        {
            var pageSize = this.xPageControl1.PageSize;
            var ds = Students.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            this.dataGridView1.DataSource = ds;
            this.xPageControl1.RecordCount = Students.Count;
            if (this.xPageControl1.RecordCount <= 0)
                xPageControl1.PageIndex = 0;
            else
                xPageControl1.PageIndex = pageIndex;
        }

        private void xPageControl1_PageIndexChanged(object sender, PageIndexChangedEventArgs e)
        {
            Bind(e.PageIndex);
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
