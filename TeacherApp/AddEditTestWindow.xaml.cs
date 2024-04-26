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
namespace TeacherApp
{
    /// <summary>
    /// Логика взаимодействия для AddEditTestWindow.xaml
    /// </summary>
    public partial class AddEditTestWindow : Window
    {
        public List<Tests> test = new List<Tests>();
        public AddEditTestWindow(List<Tests> tests)
        {
            InitializeComponent();
            test = tests;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            test.Add(new Tests{ name = testNameTextBox.Text });
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
