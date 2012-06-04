using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
    public class ShowStudentCourse
    {
        public string Account { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public string Major { get; set; }
        public string Comment { get; set; }

        public ShowStudentCourse(string account,string name,string college,string major,string comment)
        {
            Account = account;
            Name = name;
            College = college;
            Major = major;
            Comment = comment;
        }
    }
}
