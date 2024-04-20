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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib;
using StudentApp;
namespace StudentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student user;
        public MainWindow(Student student)
        {
            user = student;
            Login_Name.Text = user.username;
            InitializeComponent();

        }
        private void EditUser(object sender, RoutedEventArgs e)
        {
            StudentEditor editWindow = new StudentEditor(user);
            editWindow.ShowDialog();
            Login_Name.Text = user.username;
        }
    }
}
