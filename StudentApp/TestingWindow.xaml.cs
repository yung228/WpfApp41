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
using System.Windows.Shapes;
using Lib;
namespace StudentApp
{
    public partial class TestingWindow : Window
    {
        public List<Marks> mark = new List<Marks>();
        int quest_Count = 0;
        public List<Questions> questions = new List<Questions>();
        public List<Answers> answers = new List<Answers>();
        public Student student = new Student();
        public TestingWindow(List<Questions> a, List<Answers> b, Student stud, List<Marks> marks)
        {
            mark = marks;
            InitializeComponent();
            questions = a;
            answers = b;
            ProgresBar.Maximum = questions.Count;
            Question.Text = questions[0].quest;
            for(int i = 0; i < answers.Count; i++)
            {
                if (answers[i].question.id != 1)
                {
                    break;
                }
                Answ.Items.Add(answers[i].name);
                
            }
            mark.Add(new Marks { mark = 0, student = student });
            student = stud;
        }
        private void ForwardClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            if(Answ.SelectedItem != null)
            {
                
                if (questions[quest_Count].whatIsRight == Answ.SelectedIndex)
                {
                    mark[mark.Count-1].mark += questions[quest_Count].score;
                }
                quest_Count++;
                if (quest_Count == questions.Count)
                {
                    //testingWindow.Show();
                    Close();

                }
                else
                {
                    ProgresBar.Value++;
                    Answ.Items.Clear();
                    Question.Text = questions[quest_Count].quest;
                    for (int i = 0; i < answers.Count; i++)
                    {
                        if (answers[i].question.id == quest_Count)
                        {
                            Answ.Items.Add(answers[i].name);
                        }
                    }
                }
                
                
            }
            else
            {
                MessageBox.Show("Выберите какой-нибудь ответ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
