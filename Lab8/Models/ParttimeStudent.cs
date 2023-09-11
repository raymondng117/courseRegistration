using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }
        public ParttimeStudent (string name) : base (name) {

            Type = Types.PartTime;
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new ArgumentException("can not exceed 3 courses.");
            }
            else if (selectedCourses.Sum(course => course.WeeklyHours) <= 0)
            {
                throw new ArgumentException("You need to select at least one course.");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $" {Id} - {Name} (Part time)";
        }

    }
}