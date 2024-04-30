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
        public List<Teacher> teacher = new List<Teacher>();
        public List<Student> student = new List<Student>();
        public List<Group> group = new List<Group>();
        public MainWindow(List <Student> students, List<Teacher> teachers, List<Tests> tests, List<Group> groups, List<Questions> questions, List<Answers> answers, List<Marks> marks)
        {
            InitializeComponent();
            TestListView.Items.Add(tests[0].name + "(Creator " + tests[0].teacher.username + ")");
            TeacherListView.Items.Add(teachers[0].username);
            StudentsListView.Items.Add(students[0].username);
            test = tests;
            teacher = teachers;
        }

        private void Create_New_Test(object sender, RoutedEventArgs e)
        {
            test.Add(new Tests());
            AddEditTestWindow addTest = new AddEditTestWindow(test[test.Count - 1]);
            addTest.ShowDialog();
            if(test[test.Count-1].id == -1)
            {
                test.Remove(test[test.Count - 1]);
            }
            else
            {
                TestListView.Items.Add(test[test.Count - 1].name);
            }
            
        }
        private void Edit_Choised_Test(object sender, RoutedEventArgs e)
        {
            AddEditTestWindow editTest = new AddEditTestWindow(test[TestListView.SelectedIndex]);
            editTest.ShowDialog();
            TestListView.Items[TestListView.SelectedIndex] = test[TestListView.SelectedIndex].name;
        }
        private void Delete_Choised_Test(object sender, RoutedEventArgs e)
        {
            bool del = false;
            DeleteConfirmationWindow delTest = new DeleteConfirmationWindow(del);
            delTest.ShowDialog();
            if (del)
            {
                test.RemoveAt(TestListView.SelectedIndex);
                TestListView.Items.RemoveAt(TestListView.SelectedIndex);
            }
        }
        private void IsSelected(object sender, RoutedEventArgs e)
        {
            if(TestListView.SelectedIndex > -1)
            {
                EditTest.IsEnabled = true;
            }
            else
            {
                EditTest.IsEnabled = false;
            }
        }



        private void Create_New_Teacher(object sender, RoutedEventArgs e)
        {
            teacher.Add(new Teacher());
            AddEditTeacherWindow editWindow = new AddEditTeacherWindow(teacher[teacher.Count-1]);
            editWindow.ShowDialog();
            if (teacher[teacher.Count - 1].id == -1)
            {
                teacher.Remove(teacher[teacher.Count - 1]);
            }
            else
            {
                TeacherListView.Items.Add(teacher[test.Count - 1].username);
            }
        }
        private void Edit_Choised_Teacher(object sender, RoutedEventArgs e)
        {
            AddEditTeacherWindow editWindow = new AddEditTeacherWindow(teacher[TeacherListView.SelectedIndex]);
            editWindow.ShowDialog();
            TeacherListView.Items[TeacherListView.SelectedIndex] = teacher[TeacherListView.SelectedIndex].username;
        }




        private void Delete_Choised_Teacher(object sender, RoutedEventArgs e)
        {
            Teacher user = (Teacher)TeacherListView.SelectedItem;
            TeacherListView.Items.Remove(user);
        }
        private void Create_New_Student(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Choised_Student(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Choised_Student(object sender, RoutedEventArgs e)
        {

        }
        private void Add_Choised_Test_To_Choised_Group(object sender, RoutedEventArgs e)
        {

        }
        private void Add_Test_Success_For_Test(object sender, RoutedEventArgs e)
        {

        }
        private void Edit_Mark(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Test_From_Student(object sender, RoutedEventArgs e)
        {

        }
        private void Add_Test_Success_For_Student(object sender, RoutedEventArgs e)
        {

        }
    }
}
