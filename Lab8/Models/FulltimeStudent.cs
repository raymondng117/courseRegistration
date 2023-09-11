using Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; } 
        public FulltimeStudent (string name) : base (name) {

            Type = Types.FullTime;
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Sum(course => course.WeeklyHours) > MaxWeeklyHours)
            {
                throw new ArgumentException("Can not exceed 16 hours.");
            }
            else if (selectedCourses.Sum(course => course.WeeklyHours) <= 0)
            {
                throw new ArgumentException("You need to select at least one course.");
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            return $" {Id} - {Name} {Type}";
        }
    }
}