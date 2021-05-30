using Core;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Cactus
{
    /// <summary>
    /// Логика взаимодействия для ConfigTestWindow.xaml
    /// </summary>
    public partial class ConfigTestWindow : Window
    {
        private ILogic logic;

        public ConfigTestWindow(ILogic logic)
        {
            InitializeComponent();

            this.logic = logic;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcerciseBinding model = null;
                int count = int.MaxValue;

                if (!string.IsNullOrWhiteSpace(textBoxTheme.Text))
                {
                    model = new ExcerciseBinding { Title = textBoxTheme.Text };
                }

                if (!string.IsNullOrWhiteSpace(textBoxCount.Text))
                {
                    count = int.Parse(textBoxCount.Text);
                }

                List<ExcerciseView> list = logic.Read(model);

                TestWindow window = new TestWindow(list, count);
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
