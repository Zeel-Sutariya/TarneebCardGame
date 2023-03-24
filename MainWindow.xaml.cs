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

namespace Tarneeb_Card_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedMode = "";
            if (easyRadioButton.IsChecked == true)
            {
                selectedMode = "Easy";
            }
            else if (mediumRadioButton.IsChecked == true)
            {
                selectedMode = "Medium";
            }
            else if (hardRadioButton.IsChecked == true)
            {
                selectedMode = "Hard";
            }

            /*GameScreen win1 = new GameScreen();
            win1.Show();*/
            Tester win1 = new Tester();
            win1.Show();
            if (win1.IsEnabled)
            {
                playButton.IsEnabled = false;
            }
            else
            {
                playButton.IsEnabled = true;
            }
            //win1.GameMode.Content = selectedMode;
        }

        private void RulesButton_Click(object sender, RoutedEventArgs e)
        {
            Rules win1 = new Rules(); 
            win1.Show();
            if (win1.IsEnabled)
            {
                rulesButton.IsEnabled = false;
            }
            else
            {
                rulesButton.IsEnabled = true;
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
