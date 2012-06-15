using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
   public class Course
    {
       public String Name { get; set; }
       public String Teacher { get; set; }
       public String Place { get; set; }
       public String Number { get; set; }
       public String Content { get; set; }
       public String Time { get; set; }
       public String PreCourse { get; set; }
       public String Majoy { get; set; }
       public String Type { get; set; }
       public String TestType { get; set; }
       public int MaxNum { get; set; }
       public int Score { get; set; }

       public Course() { }
       public Course(string name, string teacher, string place, string number,
           string content, string time, string preCourse, string major, string type,
           string testType, int maxNum, int score)
       {
           Name = name;
           Teacher = teacher;
           Place = place;
           Number = number;
           Content = content;
           Time = time;
           preCourse = PreCourse;
           Majoy = major;
           Type = type;
           TestType = testType;
           MaxNum = maxNum;
           Score = score;
       }
    } 
}
