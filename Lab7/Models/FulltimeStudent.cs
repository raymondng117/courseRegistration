using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class FulltimeStudent : Student
    {
        static public int MaxWeeklyHours { get; set; }
        public FulltimeStudent (string name) : base (name) {
        
            
        }
    }
}