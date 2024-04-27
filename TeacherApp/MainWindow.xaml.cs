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
namespace TeacherApp
{
    public partial class MainWindow : Window
    {
        public List<Tests> test = new List<Tests>();
        public List<Teacher> teacher_user = new List<Teacher>();
        public MainWindow(List <Student> students, List<Teacher> teachers, List<Tests> tests, List<Group> groups, List<Questions> questions, List<Answers> answers, List<Marks> marks)
        {
            
            InitializeComponent();
            TestListBox.Items.Add(tests[0].name + "(Creator" + tests[0].teacher.username + ")");
            TeacherListBox.Items.Add(teachers[0].username);
            StudentsListBox.Items.Add(students[0].username);
            test = tests;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            AddEditTestWindow addTest = new AddEditTestWindow(test);
            addTest.ShowDialog();
            TestListBox.Items.Add(test[test.Count]);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Teacher user = (Teacher)TeacherListBox.SelectedItem;
            AddEditTeacherWindow editWindow = new AddEditTeacherWindow(user);
            editWindow.ShowDialog();
            TeacherListBox.SelectedItem = user;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            teacher_user.Add(new Teacher());
            Teacher user = teacher_user[teacher_user.Count-1];
            AddEditTeacherWindow editWindow = new AddEditTeacherWindow(user);
            editWindow.ShowDialog();
            if(user != null)
            {
                TeacherListBox.Items.Add(user);
                teacher_user.Add(user);
            }
            
        }
    }
}
