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
        private List<string> content = new List<string>();
        private List<string> number = new List<string>();
        private int selectIndex = 0;
        private int courseIndex = 0;
        private List<ShowStudentCourse> student;
        private IList<StudentCourse> selectCourseList;
        private List<string> courseName;
        private IList<Course> list;

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
        private void onCreateNewCourse(object sender, RoutedEventArgs e)
        {
            creatClassDialog newClass = new creatClassDialog(accountNum,teacher.Name);
            newClass.Owner = this;
            newClass.ShowDialog();
            init(courseIndex);
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
            selectCourseList =
                data.GetSelectCourse("from StudentCourse where Number =" + "'" + number[index] + "'");

            student = new List<ShowStudentCourse>();
            if (null != student)
            {
                foreach (StudentCourse s in selectCourseList)
                {
                    UserData user = data.GetUserDataByNum(s.Account);
                    if (null != user)
                        student.Add(new ShowStudentCourse(s.Account, user.Name, user.College, user.Major, s.CommentToTeacher,s.CommentToStudent,s.Score));
                }
            }
            studentCourse.ItemsSource = student;
        }

        /// <summary>
        /// 当用户选择了已开设课程时触发的函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onSelected(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            if (-1 == list.SelectedIndex)
                list.SelectedIndex = 0;
            courseContent.Text = content[list.SelectedIndex];
            studentDisplay.Text = "下面是选修了" + courseName[list.SelectedIndex] + "的学生：";
            courseIndex = list.SelectedIndex;
            //列出该课程的选修学生
            showStudentOfCourse(list.SelectedIndex);
        }

        /// <summary>
        /// 生成开课列表
        /// </summary>
        private void buildCourseList()
        {
            foreach (string s in courseName)
            {
                DockPanel dock = new DockPanel();
                TextBlock block = new TextBlock();
                block.Text = s;
                Button deleteCourse = new Button();
                deleteCourse.Content = "删除";
                dock.Children.Add(block);
                //dock.Children.Add(deleteCourse);
            }
        }
        /// <summary>
        /// 初始化显示
        /// </summary>
        private void init(int n)
        {
            //显示已经创建的课程
            list = data.GetCourse("from Course where Account = " + accountNum);
            courseName = new List<string>();
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
                //buildCourseList();
                //显示列表第一项课程的详细信息
                courseContent.Text = content[n];
                studentDisplay.Text = "下面是选修了" + courseName[n] + "的学生：";
                showStudentOfCourse(n);
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
            init(0);
        }

        private void onStudentSelectChanged(object sender, SelectionChangedEventArgs e)
        {
            selectIndex = (sender as ListView).SelectedIndex;
        }

        private void onDalete(object sender, RoutedEventArgs e)
        {
            if (-1 != selectIndex && student.Count != 0)
            {
                if (MessageBoxResult.Yes == MessageBox.Show("是否真要剔除" + student[selectIndex].Name + "?",
                    "剔除选修该课的学生", MessageBoxButton.YesNo))
                {
                    StudentCourse s = selectCourseList[selectIndex];
                    data.DeleteData(s);
                    init(courseIndex);
                }
            }
            else
            {
                MessageBox.Show("请单击选定要剔除的学生！！！");
            }
        }

        private void onSave(object sender, RoutedEventArgs e)
        {
            NHibernateData data = new NHibernateData();
            for (int i = 0; i < student.Count; i++)
            {
                selectCourseList[i].Score = student[i].Score;
                selectCourseList[i].CommentToStudent = student[i].CommentToStudent;
                data.UpdateData(selectCourseList[i]);
            }

            MessageBox.Show("已保存");
        }

        private void onDeleteCourse(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("是否要删除" + courseName[courseIndex] + "这门课？",
                "删除课程", MessageBoxButton.YesNo))
            {
                data.DeleteData(list[courseIndex]);
                init(0);
            }
        }

    }
}
