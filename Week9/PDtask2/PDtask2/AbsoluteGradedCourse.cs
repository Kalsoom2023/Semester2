using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask2
{
    internal class AbsoluteGradedCourse:Course
    {
        
        private int marks;
        private string grade;
        public AbsoluteGradedCourse(string coursename, int marks, string grade) : base(coursename)
        {
            
            this.marks = marks;
            this.grade = grade;
        }
        public bool passed()
        {

            if (grade == "F")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public string getName()
        {
            return coursename;
        }
        public string getGrade()
        {
            return grade;
        }
        public int setMarks()
        {
            return marks;
        }
        public void setName(string name)
        {
            coursename = name;
        }
        public void setGrade(string graded)
        {
            grade = graded;
        }
        public void setMarks(int mark)
        {
            marks = mark;
        }


    }
}
