using Lab6.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class Student
    {
        public int Id { get; }
        public string Name { get; }

        public enum Types
        {
            Student,
            PartTime,
            FullTime,
            Coop
        }

        public Types Type { get; protected set; } = Types.Student;


        public List<Course> RegisteredCourses { get; }

        public Student(string name) 
        {
            Random studentId = new Random();
            Name = name;
            Id = studentId.Next(100000, 1000000);
            RegisteredCourses = new List<Course>();
        }


        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }

        public int TotalWeeklyHours() 
        {
            int TotalWeeklyHours = 0;

            foreach (Course course in RegisteredCourses)
            {
                TotalWeeklyHours += course.WeeklyHours;
            }

            return TotalWeeklyHours;
        }

    }
}