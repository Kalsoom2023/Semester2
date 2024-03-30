using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDtask2
{
    internal class Course
    {
        protected string coursename;
        public Course(string coursename)
        {
            this.coursename = coursename;
        }

        public void setName(string name)
        {
            coursename = name;
        }
        public string getName()
        {
            return coursename;
        }
    }


}
