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
        public Tests test = new Tests();
        public AddEditTestWindow(Tests tests)
        {
            InitializeComponent();
            test = tests;
            testNameTextBox.Text = test.name;
        }

        private void Save_Test(object sender, RoutedEventArgs e)
        {
            test.name = testNameTextBox.Text;
            Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if(test.name == "")
            {
                test.id = -1;
            }
            Close();
        }
    }
}
