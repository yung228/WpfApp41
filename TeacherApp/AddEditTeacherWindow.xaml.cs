﻿using System;
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
        public Teacher user;
        public AddEditTeacherWindow(Teacher teacher)
        {
            InitializeComponent();
            user = teacher;
            loginTextBox.Text = teacher.username;
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
            user.id = -1;
            Close();
        }
    }
}
