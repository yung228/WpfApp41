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
    public class Students
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string group_name { get; set; }
    }
    public class Test
    {
        public int id { get; set; }
        public string name { get; set; }
        public string created_by { get; set; }
        public string created_time { get; set; } //DateTime
    }
    public partial class MainWindow : Window
    {
        public List<Tests> test = new List<Tests>();
        public List<Teacher> teacher_user = new List<Teacher>();
        public MainWindow(List <Student> students, List<Teacher> teachers, List<Tests> tests, List<Group> groups, List<Questions> questions, List<Answers> answers, List<Marks> marks)
        {
            List<Students> studentt = new List<Students>();
            List<Test> testt = new List<Test>();
            teachers.Add(new Teacher { id=0, username="teacher1", password="74390485" }); //Кастильный тест
            studentt.Add(new Students { id = 0, username = "student1", password = "94375235", group_name = "Group1" }); //Кастильный тест
            testt.Add(new Test { id = 0, name = "Test1", created_by = "teacher1", created_time = "2024.2.20" });
            InitializeComponent();
            //TestListView.Items.Add(tests[0].name + "(Creator" + tests[0].teacher.username + ")");
            //test = tests;
            TestListView.ItemsSource = testt;
            TeacherListView.ItemsSource = teachers;
            StudentsListView.ItemsSource = studentt;
        }

        private void Create_New_Test(object sender, RoutedEventArgs e)
        {
            
            AddEditTestWindow addTest = new AddEditTestWindow(test);
            addTest.ShowDialog();
            TestListView.Items.Add(test[test.Count]);
        }
        private void Edit_Choised_Test(object sender, RoutedEventArgs e) // Кастиль исправить
        {
            AddEditTestWindow editTest = new AddEditTestWindow(test);
            editTest.ShowDialog();
            TestListView.Items.Add(test[test.Count]);
        }
        private void Delete_Choised_Test(object sender, RoutedEventArgs e) // Кастиль исправить
        {
            DeleteConfirmationWindow delTest = new DeleteConfirmationWindow();
            delTest.ShowDialog();
            //TestListView.Items.Add(test[test.Count]);
        }




        private void Create_New_Teacher(object sender, RoutedEventArgs e)
        {
            Teacher user = (Teacher)TeacherListView.SelectedItem;
            AddEditTeacherWindow editWindow = new AddEditTeacherWindow(user);
            editWindow.ShowDialog();
            TeacherListView.SelectedItem = user;
        }
        private void Edit_Choised_Teacher(object sender, RoutedEventArgs e)
        {
            teacher_user.Add(new Teacher());
            Teacher user = teacher_user[teacher_user.Count-1];
            AddEditTeacherWindow editWindow = new AddEditTeacherWindow(user);
            editWindow.ShowDialog();
            if(user != null)
            {
                TeacherListView.Items.Add(user);
                teacher_user.Add(user);
            }
            
        }




        private void Delete_Choised_Teacher(object sender, RoutedEventArgs e) //Добавить удаление из бд и везде
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
