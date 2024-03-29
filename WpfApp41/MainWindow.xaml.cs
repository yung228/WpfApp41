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




namespace WpfApp41
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Добавляем обработчики событий GotFocus и LostFocus для текстовых полей
            TeacherUsernameTextBox.GotFocus += TextBox_GotFocus;
            TeacherUsernameTextBox.LostFocus += TextBox_LostFocus;

            StudentUsernameTextBox.GotFocus += TextBox_GotFocus;
            StudentUsernameTextBox.LostFocus += TextBox_LostFocus;

            NewStudentUsernameTextBox.GotFocus += TextBox_GotFocus;
            NewStudentUsernameTextBox.LostFocus += TextBox_LostFocus;
        }

        private void SwitchToTeacherLogin_Click(object sender, RoutedEventArgs e)
        {
            // Переключаем видимость окон
            LoginGrid.Visibility = Visibility.Collapsed;
            TeacherLoginGrid.Visibility = Visibility.Visible;
            StudentRegistrationGrid.Visibility = Visibility.Collapsed; // Скрыть окно регистрации
        }

        private void SwitchToStudentLogin_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void TeacherLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = TeacherUsernameTextBox.Text;
            string password = TeacherPasswordBox.Password;

            // Здесь можно добавить код для проверки авторизации учителя
        }

        private void StudentRegister_Click(object sender, RoutedEventArgs e)
        {
            // Переключаем видимость окон
            LoginGrid.Visibility = Visibility.Collapsed;
            TeacherLoginGrid.Visibility = Visibility.Collapsed;
            StudentRegistrationGrid.Visibility = Visibility.Visible;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "Имя пользователя")
            {
                textBox.Text = "";

            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Имя пользователя";

            }
        }
        private void StudentRegisterSubmit_Click(object sender, RoutedEventArgs e)
        {
            string username = NewStudentUsernameTextBox.Text;
            string password = NewStudentPasswordBox.Password;

            // Здесь можно добавить код для регистрации ученика
            // Например, добавление нового пользователя в базу данных
            // После успешной регистрации можно выполнить переход к окну авторизации для учеников
            SwitchToStudentLogin_Click(null, null);
        }
    }
}
