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

namespace Экзамен
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenTest1_Click(object sender, RoutedEventArgs e)
        {
            TestOneWindow test1 = new TestOneWindow();
            test1.ShowDialog();
        }

        private void btnOpenTest2_Click(object sender, RoutedEventArgs e)
        {
            TestTwoWindow test2 = new TestTwoWindow();
            test2.ShowDialog();
        }

        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}