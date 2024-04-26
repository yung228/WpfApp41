using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lib;
namespace TeacherApp
{
    
    public partial class AddEditTeacherWindow : Window
    {
        public Teacher teacher = new Teacher();
        public AddEditTeacherWindow(Teacher user)
        {
            InitializeComponent();
            teacher = user;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            teacher.username = loginTextBox.Text;
            teacher.password = passwordBox.Password;
        }
    }
}
