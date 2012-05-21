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
        protected ISession Session { get; set; }
        public NHibernateData()
        {
            Session = new NHibernateHelper().GetSession();
        }
        public void CreateStudentData(UserData studentInfo)
        {
            Session.Save(studentInfo);
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
