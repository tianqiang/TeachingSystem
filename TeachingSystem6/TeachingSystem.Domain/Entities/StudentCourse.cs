using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
    public class StudentCourse
    {
        public String Account { get; set; }
        public String Number { get; set; }
        public String CourseName { get; set; }
        public String CommentToTeacher { get; set; }
        public String CommentToStudent { get; set; }
        public int Score { get; set; }
        public int KeyNum { get; set; }
        public int State { get; set; }

        public StudentCourse() { }
        public StudentCourse(string account, string number, string courseName,
            string commentToTeacher, int score, int keyNum, string commentToStudent,int state)
        {
            KeyNum = keyNum;
            Number = number;
            Account = account;
            CourseName = courseName;
            CommentToTeacher = commentToTeacher;
            Score = score;
            CommentToStudent = commentToStudent;
            State = state;
        }
    }
}
