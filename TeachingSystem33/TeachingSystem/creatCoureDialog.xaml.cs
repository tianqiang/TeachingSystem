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

namespace TeachingSystem
{
    /// <summary>
    /// creatClassDialog.xaml 的交互逻辑
    /// </summary>
    public partial class creatClassDialog : Window
    {
        private NHibernateData course = null;
        public creatClassDialog()
        {
            InitializeComponent();
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
            course = new NHibernateData();
            if (null != course.GetCourseByNum(number.Text))
            {
                MessageBox.Show("已经存在该课程编码");
            }
        }
    }
}
