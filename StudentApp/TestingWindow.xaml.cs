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
    /// <summary>
    /// Логика взаимодействия для TestingWindow.xaml
    /// </summary>
    public partial class TestingWindow : Window
    {
        public int mark = 0;
        int quest_Count = 0;
        public List<Questions> questions = new List<Questions>();
        public List<Answers> answers = new List<Answers>();
        public TestingWindow(List<Questions> a, List<Answers> b)
        {
            questions = a;
            answers = b;
            ProgresBar.Maximum = questions.Count;
            Question.Text = questions[0].quest;
            for(int i = 0; i < answers.Count; i++)
            {
                Answ.Items.Add(answers[i].name);
                if(answers[i].question.id != 0)
                {
                    break;
                }
            }
            InitializeComponent();
        }
        private void ForwardClicked(object sender, System.Windows.RoutedEventArgs e)
        {
           if(questions[quest_Count].whatIsRight == Answ.SelectedIndex)
            {
                mark += questions[quest_Count].score;
            }
            quest_Count++;
            if(quest_Count == questions.Count)
            {
                MainWindow testingWindow = new MainWindow(mark);
                testingWindow.Show();
                Close();

            }
            Question.Text = questions[1].quest;
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].question.id == quest_Count)
                {
                    Answ.Items.Add(answers[i].name);
                }
                
                
            }
            
        }

        private void Answ_MouseDown(object sender, MouseButtonEventArgs e)
        {
            But.IsEnabled = true;
        }
    }
}
