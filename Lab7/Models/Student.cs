using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab7.Models
{
    public class Student
    {

        public int Id { get; }
        public string Name { get; }

        public Student(string name) 
        {
            Random studentId = new Random();

            Name = name;
            Id = studentId.Next(100000, 1000000);
        }

    }
}