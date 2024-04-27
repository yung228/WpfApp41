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
    public partial class MainWindow : Window
    {
        public Student user = new Student();
        public List<Tests> test = new List<Tests>();
        public List<Group> group = new List<Group>();
        public List<Questions> question = new List<Questions>();
        public List<Answers> answer = new List<Answers>();
        public List<Marks> mark = new List<Marks>();
        public int max_mark = 0;
        public MainWindow(Student student, List<Tests> tests, List<Group> groups, List<Questions> questions, List<Answers> answers, List<Marks> marks)
        {
            
            InitializeComponent();
            user = student;
            test = tests;
            group = groups;
            question = questions;
            answer = answers;
            mark = marks;
            Login_Name.Text = user.username;
            Marker.Text = "Оценка = 0";
        }
        public MainWindow(int marke, Student stud)
        {
            
            InitializeComponent();
            Marker.Text = "Mark = " + Convert.ToString(marke);
            mark.Add(new Marks{ mark = marke, student = stud });
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
            Tests current_test = test[0];
            List<Questions> que = new List<Questions>();
            for (int i = 0; i < question.Count; i++)
            {
                if (question[i].test.id == current_test.id)
                {
                    que.Add(question[i]);
                    max_mark += question[i].score;
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
            TestingWindow testingWindow = new TestingWindow(que, answ, user, mark);
            testingWindow.ShowDialog();
            Marker.Text = "Оценка = " + Convert.ToString(mark[mark.Count - 1].mark);
            MessageBox.Show("Ваша оценка " + Convert.ToString(mark[mark.Count - 1].mark) + " из " + Convert.ToString(max_mark), "Оценка", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
