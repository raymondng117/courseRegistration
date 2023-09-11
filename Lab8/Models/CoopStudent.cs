using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }
        public CoopStudent (string name) : base (name) {

            Type = Types.Coop;
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {

            if (selectedCourses.Sum(course => course.WeeklyHours) > MaxWeeklyHours || selectedCourses.Count> MaxNumOfCourses)
            {
                throw new ArgumentException("can not exceed 4 hours and 2 courses.");
            }
            else if (selectedCourses.Sum(course => course.WeeklyHours) <= 0) 
            {
                throw new ArgumentException("You need to select at least one course.");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $" {Id} - {Name} (Coop)";
        }
    }
}