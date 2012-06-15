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

namespace TeachingSystem
{
    /// <summary>
    /// TeacherWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TeacherWindow : Window
    {
        public TeacherWindow()
        {
            InitializeComponent();
        }
<<<<<<< HEAD

        private void onCreateNewClass(object sender, RoutedEventArgs e)
        {
            creatClassDialog newClass = new creatClassDialog();
            newClass.Owner = this;
            newClass.ShowDialog();
        }
=======
>>>>>>> d5f41675679c87c4bfdea8b84da533d33e706408
    }
}
