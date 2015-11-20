using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excalibur.Framework;
using Excalibur.Project.Template.Extensions;

namespace Excalibur.Project.Template
{
    public class ShellViewModel : NotifyPropertyChangeOnUIThread
    {
        private StudentDataContext dataContext = new StudentDataContext();

        private Student queryItem;

        public Student QueryItem
        {
            get
            {
                if(queryItem == null)
                    queryItem = new Student();
                return queryItem;
            }
            set
            {
                queryItem = value; 
                NotifyPropertyChanged("QueryItem");
            }
        }

        private List<Student> studentList;

        public List<Student> StudentList
        {
            get
            {
                if (studentList == null)
                    studentList = dataContext.GetStudentList();
                return studentList;
            }
            set
            {
                studentList = value;
                NotifyPropertyChanged("StudentList");
            }
        }

        public void StudentList_SelectedChanged(object sender)
        {
            var dgv = sender as DataGridView;
            var model = dgv.CurrentRow.DataBoundItem as Student;
            if (model != null)
                MessageBox.Show(model.ID.ToString());
        }
        

        public ShellViewModel()
        {
            
        }

        public void Query()
        {
            StudentList = dataContext.GetStudentList(QueryItem);
        }
    }
}
