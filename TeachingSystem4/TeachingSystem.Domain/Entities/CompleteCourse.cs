using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
    public class CompleteCourse
    {
        public string Index { get; set; }
        public String Account { get; set; }
        public String Number { get; set; }
        public String CourseName { get; set; }
        public int Score { get; set; }


        public CompleteCourse() { }
        public CompleteCourse(string index,string account, string number, string courseName,
            int score)
        {
            Number = number;
            Account = account;
            CourseName = courseName;
            Score = score;
            Index = index;
        }
    }
}
