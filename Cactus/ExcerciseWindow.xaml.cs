using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cactus
{
    /// <summary>
    /// Логика взаимодействия для ExcerciseWindow.xaml
    /// </summary>
    public partial class ExcerciseWindow : Window
    {
        private ILogic logic;
        private int id;

        public ExcerciseWindow(ILogic logic, ExcerciseView excercise)
        {
            InitializeComponent();
            this.logic = logic;
            id = excercise != null ? excercise.Id : 0; 

            if (excercise != null)
            {
                textBoxTitle.Text = excercise.Title;
                textBoxQuestion.Text = excercise.Question;
                textBoxAnswer.Text = excercise.Answer;
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxTitle.Text) ||
                    string.IsNullOrWhiteSpace(textBoxQuestion.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAnswer.Text))
                {
                    throw new Exception("Не все поля заполнены.");
                }

                ExcerciseBinding model = new ExcerciseBinding
                {
                    Id = id,
                    Title = textBoxTitle.Text,
                    Question = textBoxQuestion.Text,
                    Answer = textBoxAnswer.Text
                };

                if (id == 0)
                {
                    logic.Create(model);
                }
                else
                {
                    logic.Update(model);
                }

                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
