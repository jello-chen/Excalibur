using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excalibur.Project.Template.Extensions;

namespace Excalibur.Project.Template
{
    public class StudentDataContext
    {
        private List<Student> students; 
        public StudentDataContext()
        {
            students = new List<Student>();
            for (int i = 0; i < 100; i++)
            {
                students.Add(new Student {ID = i + 1, Age = 20, Name = "jello" + (i + 1)});
            }
        }

        public List<Student> GetStudentList(Student student = null)
        {
            if (student == null)
                return students;
            else
            {
                var predicate = student.ToPredicate().Compile();
                return students.Where(predicate).ToList();
            }
        }
    }
}
