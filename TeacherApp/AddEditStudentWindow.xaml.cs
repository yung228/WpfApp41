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
    
    public partial class AddEditStudentWindow : Window
    {
        public Student user;
        public AddEditStudentWindow(Student student)
        {
            InitializeComponent();
            user = student;
            loginTextBox.Text = "Student1";
        }

        private void Save_Client(object sender, RoutedEventArgs e)
        {
            user.username = loginTextBox.Text;
            user.password = passwordBox.Password;
            MessageBox.Show("Изменения сохранены успешно!");
            Close();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
