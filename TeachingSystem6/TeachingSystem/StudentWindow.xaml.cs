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
    /// StudentWindow.xaml 的交互逻辑
    /// </summary>
    public partial class StudentWindow : Window
    {
        private IList<StudentCourse> studentCourse = null;
        private UserData student = null;
        private NHibernateData data = new NHibernateData();
        private string accountNum = null;

        public StudentWindow(string account)
        {
            InitializeComponent();
            accountNum = account;
        }

        private void onDalete(object sender, RoutedEventArgs e)
        {
            
        }

        private void onSelect(object sender, RoutedEventArgs e)
        {

        }

        private void cell(string content,int row,int col)
        {
            Border border = new Border();
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(1);
            TextBlock block = new TextBlock();
            block.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            block.Margin = new Thickness(5);
            block.Text = content;
            block.TextWrapping = TextWrapping.Wrap;
            block.Foreground = new SolidColorBrush(Colors.DarkRed);
            grid.Children.Add(block);
            Grid.SetColumn(block, col);
            Grid.SetRow(block,row);
            grid.Children.Add(border);
            Grid.SetColumn(border, col);
            Grid.SetRow(border, row);
        }

        private void buildCourseList(IList<StudentCourse> studentCourse)
        {
            //上课时间
            List<string> timeList = new List<string>();
            timeList.Add("");
            timeList.Add("1节 08:00-08:50");
            timeList.Add("2节 09:00-09:50");
            timeList.Add("3节 10:10-11:00");
            timeList.Add("4节 11:10-12:00");
            timeList.Add("5节 12:30-13:20");
            timeList.Add("6节 13:20-14:20");
            timeList.Add("7节 14:30-15:20");
            timeList.Add("8节 15:30-16:20");
            timeList.Add("9节 16:30-17:20");
            timeList.Add("10节 17:30-18:20");
            timeList.Add("11节 19:00-19:50");
            timeList.Add("12节 20:00-20:50");
            timeList.Add("13节 21:00-21:50");

            for (int i = 0; i < timeList.Count; i++)
            {
                cell(timeList[i], 0, i);
            }

            //写周数
            timeList.Clear();
            timeList.Add("");
            timeList.Add("周一");
            timeList.Add("周二");
            timeList.Add("周三");
            timeList.Add("周四");
            timeList.Add("周五");
            timeList.Add("周六");
            timeList.Add("周日");

            for (int i = 0; i < timeList.Count; i++)
            {
                cell(timeList[i], i, 0);
            }

            //生成课表
            for (int i = 0; i < studentCourse.Count; i++)
            { 
            }
        }

        private void onLoad(object sender, RoutedEventArgs e)
        {
            //修改标题
            student = data.GetUserDataByNum(accountNum);
            if (student != null)
            {
                this.Title = "欢迎" + student.Name + "同学登录教学系统！";
            }
            else
            {
                this.Title = "无法连接数据库！";
            }
            
            //得到该学生已经选好的课程信息
            studentCourse = data.GetSelectCourse("from StudentCourse where Account =" + "'" + accountNum + "'");
            //初始化基本的课程表
            buildCourseList(studentCourse);


        }

        private void onSave(object sender, RoutedEventArgs e)
        {

        }

        private void onCanSelectCourseChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void onSelectedCourseChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
