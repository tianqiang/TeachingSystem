using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
    public class ShowStudentCourse
    {
        public string Account { get; set; }
        public string Place { get; set; }
        public string Number { get; set; }
        public string Teacher { get; set; }
        public Time Time { get; set; }
        public string CourseName { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public string Major { get; set; }
        public string CommentToTeacher { get; set; }
        public string CommentToStudent { get; set; }
        public int Score { get; set; }
        public int CourseScore { get; set; }

        public ShowStudentCourse(string account, string name, string college, string major,
            string commentToTeacher, string commentToStudent, int score)
        {         
            Account = account;
            Name = name;
            College = college;
            Major = major;
            CommentToTeacher = commentToTeacher;
            CommentToTeacher = commentToStudent;
            Score = score;
        }

        public ShowStudentCourse(string courseName, string place, string major, Time time,
           string commentToTeacher, string commentToStudent, string teacher, int CourseScore, int score)
        {
            Major = major;
            CommentToTeacher = commentToTeacher;
            CommentToTeacher = commentToStudent;
            Score = score;
        }

        public ShowStudentCourse(string courseName, string place, string number)
        {
            CourseName = courseName;
            Place = place;
            Number = number;
        }
    }
}
