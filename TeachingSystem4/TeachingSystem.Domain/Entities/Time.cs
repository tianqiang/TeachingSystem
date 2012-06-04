using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeachingSystem.Domain.Entities
{
    public class Time
    {
        public String Number { get; set; }
        public String Day { get; set; }
        public String Week { get; set; }
        public String TimeSpan { get; set; }


        public Time() { }
        public Time(string number, string day, string week, string timeSpan)
        {
            Number = number;
            Day = day;
            Week = week;
            TimeSpan = timeSpan;
        }
    }
}
