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
        public void CreateSelectCourse(StudentCourse s)
        {
            Session.Save(s);
        }
        public void UpdateData(object data)
        {
            Session.Update(data);
            Session.Flush();
        }
        public void DeleteData(object sc)
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(sc);
                    tx.Commit();
                }
                catch (HibernateException)
                {
                    tx.Rollback();
                }
            }
        }
        public object GetDataByKey(string key)
        {
            return Session.Get<object>(key);
        }
        public StudentCourse GetSelectCourseDataByNum(int number)
        {
            return Session.Get<StudentCourse>(number);
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
        public IList<string> GetStringValue(string query)
        {
            return Session.CreateQuery(query).List<string>();
        }
        public IList<Course> GetCourse(string query)
        {
            return Session.CreateQuery(query).List<Course>();
        }
        public IList<StudentCourse> GetSelectCourse(string query)
        {
            return Session.CreateQuery(query).List<StudentCourse>();
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
