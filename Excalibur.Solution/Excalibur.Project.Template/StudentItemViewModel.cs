using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excalibur.Framework;

namespace Excalibur.Project.Template
{
    public class StudentItemViewModel:NotifyPropertyChangeOnUIThread
    {
        private Student student;

        public Student Student
        {
            get { return student; }
            set
            {
                student = value;
                NotifyPropertyChanged("Student");
            }
        }

        public void Edit()
        {
            
        }
    }
}
