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
       public String Account { get; set; }
       public String Place { get; set; }
       public String Number { get; set; }
       public String Content { get; set; }
       public String PreCourse { get; set; }
       public String Majoy { get; set; }
       public String Type { get; set; }
       public String TestType { get; set; }
       public int MaxNum { get; set; }
       public float Score { get; set; }

       public Course() { }
       public Course(string name, string teacher,string account, string place, string number,
           string content, string preCourse, string major, string type,
           string testType, int maxNum, float score)
       {
           Name = name;
           Teacher = teacher;
           Account = account;
           Place = place;
           Number = number;
           Content = content;
           preCourse = PreCourse;
           Majoy = major;
           Type = type;
           TestType = testType;
           MaxNum = maxNum;
           Score = score;
       }

       public override string ToString()
       {
           string courseInfo = String.Format("课程：{0}\n编号为：{1}\n上课老师：{2}\n上课地点：{3}\n先修课程：{4}\n" +
           "{5}课\n选课人数上限:{6}\n学分：{7}\n考核方式：{8}\n",
               Name, Number, Teacher, Place, PreCourse,Type,MaxNum,Score,TestType);
           if (!String.IsNullOrEmpty(Majoy))
           {
               courseInfo += "只限于" + Majoy + "选修该课";
           }

           courseInfo += "\n\n课程内容简介：\n" + Content +"\n\n";
           return courseInfo;
       }
    } 
}
