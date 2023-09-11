using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class CoopStudent : Student
    {
        static public int MaxWeeklyHours {  get; set; }
        static public int MaxNumOfCourses { get; set; }
        public CoopStudent (string name) : base (name) { 
        

        }
    }
}