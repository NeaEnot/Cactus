using Core;
using FileImplement;
using System.Windows;

namespace Cactus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILogic logic;

        public MainWindow()
        {
            InitializeComponent();

            logic = new Logic("app");
        }

        private void ButtonStartTest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonExcercises_Click(object sender, RoutedEventArgs e)
        {
            ExcercisesWindow window = new ExcercisesWindow(logic);
            window.ShowDialog();
        }
    }
}
