using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Экзамен
{
    public class Facade
    {
        private Random random = new Random();

        public List<int> GenerateNumbers(int count)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(0, 101));
            }
            return numbers;
        }

        public async Task ShowNumbersAsync(List<int> numbers, double secondsPerNumber, Action<string> updateUiAction)
        {
            foreach (int num in numbers)
            {
                updateUiAction(num.ToString());
                await Task.Delay(TimeSpan.FromSeconds(secondsPerNumber));
                updateUiAction("");
                await Task.Delay(200);
            }
        }

        public (double coefficient, int correctCount) CalculateResult(List<int> generated, string userInput)
        {
            string[] splitText = userInput.Split(new char[] { ' ', ',' });
            List<int> userNumbers = new List<int>();
            foreach (string s in splitText)
            {
                if (Int32.TryParse(s, out int val))
                {
                    userNumbers.Add(val);
                }
                else
                {
                    userNumbers.Add(-1); //Ошибка парсинга (буква вместо цифры)
                }
            }

            int correctCount = 0;
            for (int i = 0; i < Math.Min(generated.Count, userNumbers.Count); i++)
            {
                if (generated[i] == userNumbers[i])
                {
                    correctCount++;
                }
            }
            double coefficient = (double)correctCount / 5.0;
            return (coefficient, correctCount);
        }
    }
}