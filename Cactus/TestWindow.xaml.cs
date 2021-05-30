using Core.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Cactus
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private List<ExcerciseView> excercises;

        private string answer;

        private int limit;
        private int all;
        private int success;

        public TestWindow(List<ExcerciseView> excercises, int limit)
        {
            InitializeComponent();

            this.excercises = excercises;

            this.limit = limit;
            all = 0;
            success = 0;

            NextExcercise();
        }

        private void NextExcercise()
        {
            if (excercises.Count > 0 && all < limit)
            {
                Random rnd = new Random();

                ExcerciseView excercise = excercises[rnd.Next(0, excercises.Count)];
                excercises.Remove(excercise);

                textBlockTitle.Text = excercise.Title;
                textBlockQuestion.Text = excercise.Question;
                answer = excercise.Answer;

                textBlockAnswer.Background = Brushes.LightGray;
                textBlockAnswer.Text = "";

                buttonCheck.IsEnabled = true;
                buttonSuccess.IsEnabled = false;
                buttonFail.IsEnabled = false;

                all++;
            }
            else
            {
                MessageBox.Show($"Правильных ответов {success} из {all}.", "Тестирование окончено", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void buttonSuccess_Click(object sender, RoutedEventArgs e)
        {
            success++;
            NextExcercise();
        }

        private void buttonFail_Click(object sender, RoutedEventArgs e)
        {
            NextExcercise();
        }

        private void buttonCheck_Click(object sender, RoutedEventArgs e)
        {
            textBlockAnswer.Background = Brushes.Transparent;
            textBlockAnswer.Text = answer;

            buttonCheck.IsEnabled = false;
            buttonSuccess.IsEnabled = true;
            buttonFail.IsEnabled = true;
        }
    }
}
