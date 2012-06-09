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
    /// creatClassDialog.xaml 的交互逻辑
    /// </summary>
    public partial class creatClassDialog : Window
    {
        private string teacherName;
        private string accountNum;
        private NHibernateData courseData = null;
        private List<string> courseTime = new List<string>();
 
        public creatClassDialog(string _accountNum,string _teacherName)
        {
            InitializeComponent();
            teacherName = _teacherName;
            accountNum = _accountNum;
        }

        private void onQuit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void checkValue(TextBox content, string title,int maxLength)
        {
            if (String.IsNullOrEmpty(content.Text))
                MessageBox.Show(title + "不能为空！！！");
            else if (content.Text.Length > maxLength)
            {
                MessageBox.Show(title + "的长度超过了" + maxLength + "个字符");
                content.Text = "";
            }
        }

        private void onInputName(object sender, RoutedEventArgs e)
        {
            checkValue(courseName, "名字",20);
        }

        private void onInputTeacher(object sender, RoutedEventArgs e)
        {
            checkValue(teacher, "教师名字", 20);
        }

        private void onInputPlace(object sender, RoutedEventArgs e)
        {
            checkValue(place, "地点", 20);
        }

        private void onInputNumber(object sender, RoutedEventArgs e)
        {
            checkValue(number, "课程编码", 6);
            courseData = new NHibernateData();
            if (null != courseData.GetCourseByNum(number.Text))
            {
                MessageBox.Show("已经存在该课程编码");
            }
        }

        private void onInputPreCourse(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(preCourse.Text))
            {
         
            }
        }

        private string getValue(string value,string tile)
        {
            if (String.IsNullOrEmpty(value))
            {
                MessageBox.Show(tile + "不能为空");
                return null;
            }
            else
                return value;
        }

        private void saveCourseData(Course course)
        {
            courseData = new NHibernateData();
            try
            {
                courseData.Session.Save(course);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void timeSpanStore()
        {
            Time time = new Time();
            time.Day = day.Text;
            time.Number = number.Text;
            foreach (string t in courseTime)
                time.TimeSpan += t;
            time.Week = weekStart.Text + "," + weekEnd.Text;
            courseData.Session.Save(time);
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            //检查各个数据是否为空，且给各个字段赋值
            Course course = new Course();
            
            if (null == (course.Name = getValue(courseName.Text, "名字")))
                return;
            if (null == (course.Teacher = getValue(teacher.Text, "教师")))
                return;
            if (null == (course.Place = getValue(place.Text, "地方")))
                return;
            if (null == (course.Number = getValue(number.Text, "书本编号")))
                return;
            if (null == (course.Content = getValue(content.Text, "课程内容简介")))
                return;
            if (null == (course.Majoy = getValue(college.Text, "专业")))
                return;
            if (null == (course.Type = getValue(type.Text, "必修或是选修")))
                return;
            if (null == (course.TestType = getValue(testType.Text, "考试类型")))
                return;

               course.PreCourse = preCourse.Text;
            if (String.IsNullOrEmpty(maxNum.Text))
            {
                MessageBox.Show("人数上限不能为空");
                return;
            }
            else 
            {
                try
                {
                    course.MaxNum = int.Parse(maxNum.Text);
                }
                catch { 
                    MessageBox.Show("只能输入数字");
                    return;
                }
            }
            if (String.IsNullOrEmpty(score.Text))
            {
                MessageBox.Show("分数不能为空");
                return;
            }
            else
            {
                try
                {
                    course.Score = float.Parse(score.Text);
                }
                catch
                {
                    MessageBox.Show("分数只能输入数字");
                    return;
                }
            }
            
            if (String.IsNullOrEmpty(timeSpan.Text))
            {
                MessageBox.Show("尚未添加时间段！");
                return;
            }
            course.Account = accountNum;
            //创建新课程
            saveCourseData(course);
            //存储时间段
            timeSpanStore();
            //关闭新建课程的窗口
            this.Close();
        }

        private void onAddTimeSpan(object sender, RoutedEventArgs e)
        {
            string addString = courseName.Text + "\t" + timeStart.Text + "~" + timeEnd.Text + "\n";

            if (timeEnd.SelectedIndex >= timeStart.SelectedIndex && timeSpan.Text != addString)
            {
                timeSpan.Text += addString;
                courseTime.Add((timeStart.SelectedIndex + 1).ToString() + "," + (timeEnd.SelectedIndex + 1).ToString());
            }
            else
                MessageBox.Show("时间段结束时间比开始时间早，不合理");
        }

        private void onActivate(object sender, EventArgs e)
        {
            teacher.Text = teacherName;
        }
    }
}
