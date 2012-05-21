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
using System.Text.RegularExpressions;
using TeachingSystem.Domain.Entities;

namespace TeachingSystem
{
    /// <summary>
    /// RegisterWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private const int MaxLength = 15;
        private NHibernateData database = null;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void onSubmit(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(name.Text) ||
                String.IsNullOrEmpty(email.Text) ||
                String.IsNullOrEmpty(account.Text) ||
                String.IsNullOrEmpty(college.Text) ||
                String.IsNullOrEmpty(major.Text) ||
                String.IsNullOrEmpty(role.Text) ||
                String.IsNullOrEmpty(sex.Text) ||
                String.IsNullOrEmpty(password.Password) ||
                String.IsNullOrEmpty(comfirmPassword.Password))
            {
                MessageBox.Show("某些必填选项没有填！！！");
                return;
            }
            //将新用户存进数据库
            UserData user = new UserData(account.Text, role.Text, name.Text, nickName.Text,
                password.Password, sex.Text, major.Text, college.Text, email.Text);
            if (null != database)
            {
                database.Close();
                database = new NHibernateData();
            }
            database.CreateStudentData(user);

            this.Close();
        }


        private void onClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NameValidate(TextBlock tip, TextBox userName)
        {
            //验证名字
            if (String.IsNullOrEmpty(userName.Text))
            {
                tip.Text = "名字不能为空！！！";
                userName.Background = new SolidColorBrush(Colors.Red);
            }
            else if (userName.Text.Length > MaxLength)
            {
                tip.Text = "名字长度超过了15个字符！！！";
                userName.Text = "";
                userName.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Color background = new Color();
                background.A = 0xbb;
                background.R = 0xbb;
                background.B = 0xbb;
                background.G = 0xbb;
                userName.Background = new SolidColorBrush(background);
                tip.Text = "☑通过";
            }
        }

        private void onNameInput(object sender, RoutedEventArgs e)
        {
           NameValidate(nameTips, name);
        }

        private void onNickNameInput(object sender, RoutedEventArgs e)
        {
            NameValidate(nickNameTips, nickName);
        }

        private void inputAccount(object sender, RoutedEventArgs e)
        {
            string regex = @"[0-9]+";
            Regex onlyNum = new Regex(regex);
            database = new NHibernateData();

            if (String.IsNullOrEmpty(account.Text))
            {
                accoutTips.Text = "帐号不能为空！！！";
                account.Background = new SolidColorBrush(Colors.Red);
            }
            else if (!onlyNum.IsMatch(account.Text))
            {
                accoutTips.Text = "帐号只能为全数字";
                account.Text = "";
                account.Background = new SolidColorBrush(Colors.Red);
            }
            else if (null != (database.GetUserDataByNum(account.Text)))
            {
                accoutTips.Text = "这个帐号已经注册过了！！！";
                account.Text = "";
                account.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Color background = new Color();
                background.A = 0xbb;
                background.R = 0xbb;
                background.B = 0xbb;
                background.G = 0xbb;
                account.Background = new SolidColorBrush(background);
                accoutTips.Text = "☑通过";
            }
        }

        private void onInputEmail(object sender, RoutedEventArgs e)
        {
            string regex = @"^\w+@\w*.\w+";
            Regex emailRexgex = new Regex(regex);
            if (String.IsNullOrEmpty(email.Text))
            {
                emailTips.Text = "邮件不能为空！！！";
                email.Background = new SolidColorBrush(Colors.Red);
            }
            else if (!emailRexgex.IsMatch(email.Text))
            {
                emailTips.Text = "邮件格式不对！！！";
                email.Text = "";
                email.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Color background = new Color();
                background.A = 0xbb;
                background.R = 0xbb;
                background.B = 0xbb;
                background.G = 0xbb;
                email.Background = new SolidColorBrush(background);
                emailTips.Text = "☑通过";
            }
        }

        private void PasswordValidate(TextBlock tip,PasswordBox passwordText,bool isComfirmPassword)
        {
            string regex = @"^[0-9a-zA-Z]+$";
            Regex passwordRexgex = new Regex(regex);
            if (String.IsNullOrEmpty(passwordText.Password))
            {
                tip.Text = "密码不能为空！！！";
                passwordText.Background = new SolidColorBrush(Colors.Red);
            }
            else if (!passwordRexgex.IsMatch(passwordText.Password))
            {
                tip.Text = "密码格式包含了除数字与字母以外的字符！！！";
                passwordText.Background = new SolidColorBrush(Colors.Red);
                passwordText.Password = "";
            }
            else if (isComfirmPassword && password.Password != comfirmPassword.Password)
            {
                tip.Text = "两次输入的密码不一致！！！";
                passwordText.Background = new SolidColorBrush(Colors.Red);
                passwordText.Password = "";
            }
            else
            {
                Color background = new Color();
                background.A = 0xbb;
                background.R = 0xbb;
                background.B = 0xbb;
                background.G = 0xbb;
                passwordText.Background = new SolidColorBrush(background);
                tip.Text = "☑通过";
            }
        }

        private void onInputPassword(object sender, RoutedEventArgs e)
        {
            PasswordValidate(passwordTips,password,false);
        }

        private void onInPutComfirmPassword(object sender, RoutedEventArgs e)
        {
            PasswordValidate(comfirmPasswordTips, comfirmPassword, true);  
        }
    }
}
