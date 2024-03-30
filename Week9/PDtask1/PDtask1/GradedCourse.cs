using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask1
{
    internal class GradedCourse
    {
        private string coursename;
        private int grade;

        public GradedCourse(string coursename, int grade)
        {
            this.coursename = coursename;
            this.grade = grade;

        }
        public bool passed()
        {

            if(grade>=2)
            {
                return true;
            }

            else { return false; }
        }
        public string getName()
        {
            return coursename;
        }
        public int getGrade()
        {
            return grade;
        }
        public void setName(string name)
        {
            coursename = name;
        }
        public void setGrade(int graded)
        {
            grade = graded;
        }
    }
}
