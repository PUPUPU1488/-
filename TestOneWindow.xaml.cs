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
    /// Логика взаимодействия для TestOneWindow.xaml
    /// </summary>
    public partial class TestOneWindow : Window
    {
        private readonly Facade facade = new Facade();
        private List<int> generatedNumbers;
        private const double intervalSeconds = 2.0;
        public TestOneWindow()
        {
            InitializeComponent();
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!Int32.TryParse(CountInput.Text, out int count) || count < 5 || count > 9)
            {
                ErrorLabel.Content = "Ошибка! Введите целое число от 5 до 9.";
                ErrorLabel.Visibility = Visibility.Visible; // Показываем ошибку на экране
                return;
            }
            ErrorLabel.Visibility = Visibility.Collapsed;
            generatedNumbers = facade.GenerateNumbers(count);

            AnswerInput.Text = "";
            ResultLabel.Content = "Запоминайте числа...";
            await facade.ShowNumbersAsync(generatedNumbers, intervalSeconds, (string val) => DisplayBlock.Content = val);
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
                ErrorLabel.Content = "Ошибка! Поле ввода ответа пустое.";
                ErrorLabel.Visibility = Visibility.Visible;
                return;
            }
            ErrorLabel.Visibility = Visibility.Collapsed;
            (double coefficient, int correctCount) result = facade.CalculateResult(generatedNumbers, AnswerInput.Text);
            ResultLabel.Content = "Правильно: " + result.correctCount + " из " 
                + generatedNumbers.Count + ". Коэффициент C = " + result.coefficient.ToString("F1");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}