using PDtask2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask2
{
    internal class Project
    {
        private string projectname;
        public AbsoluteGradedCourse Course1;
        public AbsoluteGradedCourse Course2;
        public GradedCourse Course3;
        public GradedCourse Course4;
        public List <Course> Courses=new List<Course>();

        public Project(string projectname, AbsoluteGradedCourse Course1, AbsoluteGradedCourse Course2, GradedCourse Course3, GradedCourse Course4)
        {
            this.projectname = projectname;
            this.Course1 = Course1;
            this.Course2 = Course2;
            this.Course3 = Course3;
            this.Course4 = Course4;
        }
        public void addinlist(Course course)
        {
            Courses.Add(course);
        }


        public bool Passed()
        {
            int passed = 0;
            if (Course1.passed())
            {
                passed += 1;
            }
            if (Course2.passed())
            {
                passed += 1;
            }
            if (Course3.passed())
            {
                passed += 1;
            }
            if (Course4.passed())
            {
                passed += 1;
            }

            if (passed >= 3)
                return true;
            else
            {
                return false;
            }
        }
    }
}
