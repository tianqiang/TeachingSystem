using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TeachingSystem.Domain.Entities;

namespace TeachingSystem.Data
{
    public class NHibernateData
    {
        public ISession Session { get; set; }
        public NHibernateData()
        {
            Session = new NHibernateHelper().GetSession();
        }
        public void CreateStudentData(UserData studentInfo)
        {
            Session.Save(studentInfo);
        }
        public object GetDataByKey(string key)
        {
            return Session.Get<object>(key);
        }
        public CompleteCourse GetCompleteCourseDataByNum(string number)
        {
            return Session.Get<CompleteCourse>(number);
        }
        public Time GetTimeDataByNum(string number)
        {
            return Session.Get<Time>(number);
        }
        public UserData GetUserDataByNum(string StudentNum)
        {
            return Session.Get<UserData>(StudentNum);
        }
        public Course GetCourseByNum(string CourseNum)
        {
            return Session.Get<Course>(CourseNum);
        }
        private IList<string> GetStringValue(string query)
        {
            return Session.CreateQuery(query).List<string>();
        }
        private IList<Course> GetCourseValue(string query)
        {
            return Session.CreateQuery(query).List<Course>();
        }
        public void Close()
        {
            Session.Close();
        }
    }
}
