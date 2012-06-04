using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
    public class SelectCourse
    {
        public string Index { get; set; }
        public String Account { get; set; }
        public String Number { get; set; }
        public String CourseName { get; set; }
        public String Comment { get; set; }
        public int Score { get; set; }


        public SelectCourse() { }
        public SelectCourse(string index,string account, string number, string courseName,
            string comment, int score)
        {
            Number = number;
            Account = account;
            CourseName = courseName;
            Comment = comment;
            Score = score;
            Index = index;
        }
    }
}
