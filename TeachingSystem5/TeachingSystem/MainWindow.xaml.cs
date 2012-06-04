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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TeachingSystem.Data;
using TeachingSystem.Domain.Entities;
using NHibernate;

namespace TeachingSystem
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private NHibernateData user = null;
        private UserData userInfo = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region
        /// <summary>
        /// 让窗口可以拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        /// <summary>
        /// 在窗口被激活时候创建用于链接数据库的对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onActived(object sender, EventArgs e)
        {
            user = new NHibernateData();
        }
        /// <summary>
        /// 关闭登录窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onLogOn(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(accountNum.Text) || String.IsNullOrEmpty(password.Password))
                message.Text = "帐号或密码不能为空！！！";

            else if (user == null || null == (userInfo = user.GetUserDataByNum(accountNum.Text)))
                message.Text = "不存在该帐号！！！";
            else if (userInfo.Password != password.Password)
                message.Text = "密码不正确！！！";
            else
            {
                if (userInfo.Role == "教师")
                {
                    TeacherWindow teacherWindow = new TeacherWindow(accountNum.Text);
                    teacherWindow.Show();
                    this.Close();
                }
                else
                {
                    StudentWindow studentWindow = new StudentWindow();
                    studentWindow.Show();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 打开注册界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onRegister(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            registerWindow.Show();         
        }
    }
}
