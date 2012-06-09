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

        public override string ToString()
        {
            string[] weekSpan = Week.Split(',');
            string[] timeSpan = TimeSpan.Split(',');
            return String.Format("该课上课周数为:{0}到{1}\n上课时间为：{2} {3} ~ {4}节",weekSpan[0],weekSpan[1],Day,timeSpan[0],timeSpan[1]);
        }
    }
}
