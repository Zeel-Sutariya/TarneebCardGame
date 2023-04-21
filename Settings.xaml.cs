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
using static Tarneeb_Card_Game.GameScreen;

namespace Tarneeb_Card_Game
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private MediaPlayer mediaPlayer;
        public Settings()
        {
            InitializeComponent();
        }

        public Settings(MediaPlayer mediaPlayer)
        {
            InitializeComponent();

            this.mediaPlayer = mediaPlayer;
        }
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        public double VolumeValue
        {
            get { return volumeSlider.Value; }
            set { volumeSlider.Value = value; }
        }

        public bool IsMusicEnabled
        {
            get { return musicCheckBox.IsChecked ?? false; }
            set { musicCheckBox.IsChecked = value; }
        }

        private void Setting_Loaded(object sender, RoutedEventArgs e)
        {
            Binding binding = new Binding();
            binding.Source = volumeSlider;
            binding.Path = new PropertyPath("Wallpaper.mp3");
        }
        public double GetSliderValue()
        {
            
            return volumeSlider.Value;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
