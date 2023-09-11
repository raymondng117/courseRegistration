using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class ParttimeStudent : Student
    {
        static public int MaxNumOfCourses {  get; set; }
        public ParttimeStudent (string name) : base (name) {
        
            
        }
    }
}