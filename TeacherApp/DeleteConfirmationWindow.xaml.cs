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

namespace TeacherApp
{
    /// <summary>
    /// Логика взаимодействия для DeleteConfirmationWindow.xaml
    /// </summary>
    public partial class DeleteConfirmationWindow : Window
    {
        bool isBool;
        public DeleteConfirmationWindow(bool a)
        {

            InitializeComponent();
        }

        //Ето просто затычки
        //ps: У меня почему то не работает бд, поетому только так

        private void yesButton(object sender, RoutedEventArgs e)
        {
            isBool = true;
            Close();
        }
        private void noButton(object sender, RoutedEventArgs e)
        {
            isBool = false;
            Close();
        }
    }
}
