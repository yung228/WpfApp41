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
namespace WpfApp41
{
    
    public partial class StudentWindow : Window
    {
        Student user;
        public StudentWindow(Student student)
        {
            InitializeComponent();
            user = student;
            StudUsername.Text = user.username;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            StudentEditor editWindow = new StudentEditor(user);
            editWindow.ShowDialog();

            StudUsername.Text = user.username;
        }
    }
}
