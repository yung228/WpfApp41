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
    public partial class StudentEditor : Window
    {
        private Student user;
        public StudentEditor(Student student)
        {
            InitializeComponent();
            user = student;
            NameTextBox.Text = user.name;
            PasswordTextBox.Text = user.password;
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            user.name = NameTextBox.Text;
            user.password = PasswordTextBox.Text;
            MessageBox.Show("Изменения сохранены успешно!");
            Close();
        }
    }
}
