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
using TeacherApp;

namespace WpfApp41
{

    public partial class MainWindow : Window
    {
        bool isReg = false;

        public List <Student> students = new List<Student>(1000);
        public List<Teacher> teachers = new List<Teacher>(1000);
        public List<Tests> tests = new List<Tests>(1000);
        public List<Group> groups = new List<Group>(1000);
        public List<Questions> questions = new List<Questions>(1000);
        public List<Answers> answers = new List<Answers>(1000);
        public List<Marks> marks = new List<Marks>(1000);
        int id_stud = 0;
        int id_teach = 0;
        public MainWindow()
        {
            
            teachers.Add(new Teacher {username = "admin", password = "admin" });
            tests.Add(new Tests {name = "Test1", teacher = teachers[0], time = new DateTime()});
            questions.Add(new Questions {quest = "What is cucumber", test = tests[0], whatIsRight = 2, score = 1 });
            answers.Add(new Answers {name = "Fruit", question = questions[0] });
            answers.Add(new Answers { name = "Meat", question = questions[0] });
            answers.Add(new Answers { name = "Vegetable", question = questions[0] });
            groups.Add(new Group { name = "First", currentTest = tests[0] });
            students.Add(new Student { username = "student", password = "1", group = groups[0] });
            using (var context = new ApplicationDbContext())
            {
                //Potom ubrat
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Student.Add(students[0]);
                context.Teacher.Add(teachers[0]);
                context.Tests.Add(tests[0]);
                context.Questions.Add(questions[0]);
                context.Answers.AddRange(answers);
                context.Groups.Add(groups[0]);
                context.SaveChanges();
            } 
            GroupPick.ItemsSource = new List<Group>{groups[0]};
            GroupPick.DisplayMemberPath = "name";
            InitializeComponent();
        }

        private void SwitchToTeacherLogin_Click(object sender, RoutedEventArgs e)
        {
            //Переключение кнопок
            Button_Student.IsEnabled = true;
            Button_Teacher.IsEnabled = false;

            // Переключаем видимость окон
            LoginGrid.Visibility = Visibility.Collapsed;
            TeacherLoginGrid.Visibility = Visibility.Visible;
            StudentRegistrationGrid.Visibility = Visibility.Collapsed; // Скрыть окно регистрации
        }

        private void SwitchToStudentLogin_Click(object sender, RoutedEventArgs e)
        {
            //Переключение кнопок

            Button_Student.IsEnabled = false;
            Button_Teacher.IsEnabled = true;

            // Переключаем видимость окон
            LoginGrid.Visibility = Visibility.Visible;
            TeacherLoginGrid.Visibility = Visibility.Collapsed;
            StudentRegistrationGrid.Visibility = Visibility.Collapsed; // Скрыть окно регистрации
        }

        private void StudentLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = StudentUsernameTextBox.Text;
            string password = StudentPasswordBox.Password;

            // Здесь можно добавить код для проверки авторизации ученика
            try
            {
                int i = 0;
                do
                {
                    if (students[i].username == username)
                    {
                        if (students[i].password == password)
                        {
                            // Открыть окно студента и закрыть основное
                            StudentApp.MainWindow studentWindow = new StudentApp.MainWindow(students[i], tests, groups, questions, answers, marks);
                            studentWindow.Show();
                            Close();
                            break;
                        }
                    }
                    i++;
                } while (i < 100 || students[i].username != "");
                if(IsActive)
                    MessageBox.Show("Студент с таким логином и таким паролем не найдено. Возможно вы ввели данные не корректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Оба или одно из полей не заполнено. Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TeacherLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = TeacherUsernameTextBox.Text;
            string password = TeacherPasswordBox.Password;
            // Здесь можно добавить код для проверки авторизации учителя
            try
            {
                int i = 0;
                do
                {

                    if (teachers[i].username == username)
                    {
                        if (teachers[i].password == password)
                        {
                            // Открыть окно учителя и закрыть основное
                            TeacherApp.MainWindow teacherWindow = new TeacherApp.MainWindow(students, teachers, tests, groups, questions, answers, marks);
                            teacherWindow.Show();
                            Close();
                            break;
                        }
                        
                    }
                    i++;
                } while (i < 100 || teachers[i].username != "") ;
                if (IsActive)
                    MessageBox.Show("Учитель с таким логином и таким паролем не найдено. Возможно вы ввели данные не корректно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Оба или одно из полей не заполнено. Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }            
        }

        private void StudentRegister_Click(object sender, RoutedEventArgs e)
        {
            // Переключаем видимость окон
            LoginGrid.Visibility = Visibility.Collapsed;
            TeacherLoginGrid.Visibility = Visibility.Collapsed;
            StudentRegistrationGrid.Visibility = Visibility.Visible;
        }

        

        
        private void StudentRegisterSubmit_Click(object sender, RoutedEventArgs e)
        {
            string username = NewStudentUsernameTextBox.Text;
            string group = NewStudentGroupTextBox.Text;
            string password = NewStudentPasswordBox.Password;

            // Здесь можно добавить код для регистрации ученика
            // Например, добавление нового пользователя в базу данных
            // После успешной регистрации можно выполнить переход к окну авторизации для учеников
            try
            {
                int i = 0;
                do
                {

                    if (students[i].username == username)
                    {
                        // Открыть окно учителя и закрыть основное
                        MessageBox.Show("Пользователя с таким логином уже существует. Создайте нового пользователя, или зайдите в старый аккаунт", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        isReg = true;

                        break;
                    }
                    
                    i++;
                } while (i < 100 || students[i].username != "");
                if(!isReg)
                    MessageBox.Show("Новый аккаунт создан", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    using (var context = new ApplicationDbContext())
                    {
                        id_stud++;
                        students.Add(new Student { username = username, password = password });
                        context.Student.Add(students[id_stud]);
                    }
                    SwitchToStudentLogin_Click(null, null);

                }
            catch
            {
                MessageBox.Show("Оба или одно из полей не заполнено. Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
