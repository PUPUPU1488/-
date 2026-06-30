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

namespace Экзамен
{
    /// <summary>
    /// Логика взаимодействия для TestTwoWindow.xaml
    /// </summary>
    public partial class TestTwoWindow : Window
    {
        private Facade facade = new Facade();
        private List<int> generatedNumbers;
        public TestTwoWindow()
        {
            InitializeComponent();
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            generatedNumbers = facade.GenerateNumbers(20);
            AnswerInput.Text = "";
            ResultLabel.Content = "Запоминайте числа...";
            await facade.ShowNumbersAsync(generatedNumbers, 6.0, (string val) => DisplayBlock.Content = val);
            DisplayBlock.Content = "Вводите ответ!";
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            if (generatedNumbers == null)
            {
                ErrorLabel.Content = "Ошибка! Сначала запустите тест.";
                ErrorLabel.Visibility = Visibility.Visible;
                return;
            }

            if (String.IsNullOrWhiteSpace(AnswerInput.Text))
            {
                ErrorLabel.Content = "Ошибка! Вы ничего не ввели.";
                ErrorLabel.Visibility = Visibility.Visible;
                return;
            }
            ErrorLabel.Visibility = Visibility.Collapsed;
            (double coefficient, int correctCount) result = facade.CalculateResult(generatedNumbers, AnswerInput.Text);
            ResultLabel.Content = "Правильно: " + result.correctCount + " из 20. Коэффициент C = " + result.coefficient.ToString("F1");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}