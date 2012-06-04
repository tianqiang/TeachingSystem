using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TeachingSystem.Data;
using TeachingSystem.Domain.Entities;

namespace TeachingSystem
{
    /// <summary>
    /// TeacherWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherWindow : Window
    {
        private NHibernateData data = new NHibernateData();
        private UserData teacher = null;
        private string accountNum;
        private string num;
        private List<string> content = new List<string>();
        private List<string> number = new List<string>();
        private int selectIndex = 0;
        
        public TeacherWindow(string account)
        {
            InitializeComponent();
            accountNum = account;
        }
        /// <summary>
        /// 教师创建新课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onCreateNewClass(object sender, RoutedEventArgs e)
        {
            creatClassDialog newClass = new creatClassDialog(accountNum,teacher.Name);
            newClass.Owner = this;
            newClass.ShowDialog();
            init();
        }

        private void onActivated(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 显示选择这门课程的学生信息
        /// </summary>
        /// <param name="index"></param>
        private void showStudentOfCourse(int index)
        {
            IList<SelectCourse> selectCourseList =
                data.GetSelectCourse("from SelectCourse where Number =" + "'" + number[index] + "'");

            List<ShowStudentCourse> student = new List<ShowStudentCourse>();
            foreach (SelectCourse s in selectCourseList)
            {
                UserData user = data.GetUserDataByNum(s.Account);
                student.Add(new ShowStudentCourse(s.Account,user.Name,user.College,user.Major,s.Comment));
            }
            studentCourse.ItemsSource = student;
        }

        private void onSelected(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            courseContent.Text = content[list.SelectedIndex];
            showStudentOfCourse(list.SelectedIndex);
            //列出该课程的选修学生
        }

        private void init()
        {
            //显示已经创建的课程
            IList<Course> list = data.GetCourse("from Course where Account = " + accountNum);
            List<string> courseName = new List<string>();
            number.Clear();
            content.Clear();
            courseName.Clear();

            if (null != list)
            {
                string time = "";
                foreach (Course c in list)
                {
                    try
                    {
                      time = data.GetTimeDataByNum(c.Number).ToString();
                    }catch(Exception e){}
                    number.Add(c.Number);
                    content.Add(c.ToString() + time);
                    courseName.Add(c.Name);
                }
                courseList.ItemsSource = courseName;

                //显示列表第一项课程的详细信息
                courseContent.Text = content[0];
                showStudentOfCourse(0);
            }
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            //修改标题
            teacher = data.GetUserDataByNum(accountNum);
            if (teacher != null)
            {
                this.Title = "欢迎" + teacher.Name + "老师登录教学系统！";
            }
            else
            {
                this.Title = "无法连接数据库！";
            }
            init();
        }

        private void onStudentSelectChanged(object sender, SelectionChangedEventArgs e)
        {
            selectIndex = (sender as ListView).SelectedIndex;
            Button button = sender as Button;
            MessageBox.Show("是否要删除第" + selectIndex + "行");
        }
    }
}
