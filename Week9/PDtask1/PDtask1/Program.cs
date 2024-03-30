using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PDtask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AbsoluteGradedCourse course_1 = new AbsoluteGradedCourse("Software Engineering", 85, "A");

            AbsoluteGradedCourse course_2 = new AbsoluteGradedCourse("Database Management", 75, "B");
            GradedCourse course1 = new GradedCourse("Programming Fundamentals", 10);
            GradedCourse course2 = new GradedCourse("Algorithms and Data Structures", 7);
            AbsoluteGradedCourse course_3 = new AbsoluteGradedCourse("Research Methods", 70, "B");
            AbsoluteGradedCourse course_4 = new AbsoluteGradedCourse("Literature Review", 80, "A");
            GradedCourse course3 = new GradedCourse("Statistical Analysis", 1);
GradedCourse course4 = new GradedCourse("Research Findings Presentation", 1);

            Project project_1 = new Project("Software Development Project", course_1, course_2, course1, course2);
            Project project_2 = new Project("Research Project", course_3, course_4, course3, course4);
            Console.WriteLine(project_1.Passed());
            Console.WriteLine((project_2.Passed()));
        }
    }
}
