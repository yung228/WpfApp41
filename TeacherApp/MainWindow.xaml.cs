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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lib;
namespace TeacherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(List <Student> students, List<Teacher> teachers, List<Tests> tests, List<Group> groups, List<Questions> questions, List<Answers> answers, List<Marks> marks)
        {
            TestListBox.Items.Add(tests[0].name+"(Creator"+tests[0].teacher.username+")");
            TeacherListBox.Items.Add(teachers[0].username);
            StudentsListBox.Items.Add(students[0].username);
            InitializeComponent();
        }
    }
}
