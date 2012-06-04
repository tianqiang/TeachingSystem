using TeachingSystem.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NHibernate;
using TeachingSystem.Domain.Entities;
using System.Text;

namespace TeachingSystem.Data.Test
{


    /// <summary>
    ///这是 studentDataTest 的测试类，旨在
    ///包含所有 studentDataTest 单元测试
    ///</summary>
    [TestClass()]
    public class UserDataTest
    {


        private NHibernateData target;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>


        #region 附加测试特性
        // 
        //编写测试时，还可使用以下特性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///studentData 构造函数 的测试
        ///</summary>
        [TestMethod()]
        public void dataBaseConnectTest()
        {
            // TODO: 初始化为适当的值
            target = new NHibernateData();

            UserData studentInfo = target.GetUserDataByNum("2009051729");
            string password = studentInfo.Password;
            Assert.AreEqual("051729", password);
        }

        /// <summary>
        ///测试Course表
        ///</summary>
        [TestMethod()]
        public void ConnectToCourseTest()
        {
            // TODO: 初始化为适当的值
            target = new NHibernateData();

            Course course = target.GetCourseByNum("08188888");
            string teacher = course.Teacher;
            Assert.AreEqual("周密",teacher);
        }
      
        [TestMethod()]
        public void saveDataTest()
        {
            // TODO: 初始化为适当的值
            ISession session = new NHibernateHelper().GetSession();
            target = new NHibernateData();
            UserData studentInfo = new UserData("510", "学生", "开个户", "计划公开", "45", "男", "hgh", "hj", "dghsgh");

            //存储数据
            target.CreateStudentData(studentInfo);
            UserData studentdata = target.GetUserDataByNum("510");
            string name = "";

            if(null != studentdata)
                name = studentdata.Name;
            Assert.AreEqual("开个户", name);
        }
         
    }
}
