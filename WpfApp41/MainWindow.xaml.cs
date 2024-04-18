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
using TeacherApp;



namespace WpfApp41
{

    public partial class MainWindow : Window
    {
        bool isReg = false;

        public Student[] students = new Student[100];
        public Teacher[] teachers = new Teacher[100];
        public Tests[] tests = new Tests[100];
        int id_stud = 0;
        int id_teach = 0;
        public MainWindow()
        {
            InitializeComponent();
            
            // Добавление первых пользователей
            students[0] = new Student(id_stud, "student", "1");
            teachers[0] = new Teacher(id_teach, "admin", "admin");
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
                            StudentWindow studentWindow = new StudentWindow(new Student(students[i].id, username, password));
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
                            TeacherApp.MainWindow teacherWindow = new TeacherApp.MainWindow(students, teachers, tests);
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
                    SwitchToStudentLogin_Click(null, null);

            }
            catch
            {
                MessageBox.Show("Оба или одно из полей не заполнено. Введите данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
