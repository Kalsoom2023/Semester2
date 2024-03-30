using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask2
{
    internal class GradedCourse:Course
    {
       
        private int grade;

        public GradedCourse(string coursename, int grade):base (coursename) 
        {
            this.coursename = coursename;
            this.grade = grade;

        }
        public bool passed()
        {

            if (grade >= 2)
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