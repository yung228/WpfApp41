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
namespace StudentApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Student user;
        public List<Tests> test;
        public List<Group> group;
        public List<Questions> question;
        public List<Answers> answer;
        public List<Marks> mark;
        public MainWindow(Student student, List<Tests> tests, List<Group> groups, List<Questions> questions, List<Answers> answers, List<Marks> marks)
        {
            user = student;
            test = tests;
            group = groups;
            question = questions;
            answer = answers;
            mark = marks;
            Login_Name.Text = user.username;
            InitializeComponent();

        }
        public MainWindow(int mark)
        {
            Marker.Text = Convert.ToString(mark);
            InitializeComponent();
        }
        private void EditUser(object sender, RoutedEventArgs e)
        {
            StudentEditor editWindow = new StudentEditor(user);
            editWindow.ShowDialog();
            Login_Name.Text = user.username;
        }
        private void Close_But(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Test_Open(object sender, RoutedEventArgs e)
        {
            Tests current_test = test[group[user.group.id].id];
            List<Questions> que = new List<Questions>();
            for (int i = 0; i < question.Count; i++)
            {
                if (question[i].test.id == current_test.id)
                {
                    que.Add(question[i]);
                }
            }
            List<Answers> answ = new List<Answers>();
            for(int i = 0; i < que.Count; i++)
            {
                for(int j = 0; j < answer.Count; j++)
                {
                    if (answer[j].question.id == que[i].id)
                    {
                        answ.Add(answer[j]);
                    }
                }
            }
            TestingWindow testingWindow = new TestingWindow(que,answ);
            testingWindow.Show();
        }
    }
}
