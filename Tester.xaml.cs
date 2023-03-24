using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Cards;
using Size = System.Windows.Size;

namespace Tarneeb_Card_Game
{
    /// <summary>
    /// Interaction logic for Tester.xaml
    /// </summary>
    public partial class Tester : Window
    {

        List<Card> cards = new List<Card>();
        public Tester()
        {
            InitializeComponent();
            DisplayCards();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonName = clickedButton.Name;

            MessageBox.Show("Button " + buttonName + " was clicked!");


            // Set the starting position of the button
            clickedButton.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            TranslateTransform translation = new TranslateTransform();
            clickedButton.RenderTransform = translation;
            translation.BeginAnimation(TranslateTransform.XProperty, CreateAnimation(Player1.ActualWidth, Round.ActualWidth), HandoffBehavior.Compose);
            translation.BeginAnimation(TranslateTransform.YProperty, CreateAnimation(Player1.ActualHeight, Round.ActualHeight), HandoffBehavior.Compose);

            // Add the button to grid1
            Player1.Children.Remove(clickedButton);
            Round.Children.Add(clickedButton);

        }
        private DoubleAnimation CreateAnimation(double fromValue, double toValue)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = fromValue;
            animation.To = toValue;
            animation.Duration = new Duration(TimeSpan.FromSeconds(1));
            return animation;
        }
        public void DisplayCards()
        {
            Grid Test = new Grid();
            Deck deck = new Deck();
            cards = deck.TakeCards(13);
            int x = 0;
            List<Button> buttons = new List<Button>();

            StackPanel player1StackPanel = new StackPanel();
            player1StackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            player1StackPanel.Orientation = Orientation.Horizontal;
            foreach (Card card in cards)
            {
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                if (x == 0)
                {

                    button.Margin = new Thickness(0, 0, 0, 0);
                }
                else
                {

                    button.Margin = new Thickness(-30, 0, 0, 0);
                }
                button.Click += CardButton_Click;

                Image myImage = new Image
                {
                    Source = new BitmapImage(new Uri("/Images/cardBackRed.png", UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
                button.Content = myImage;


                x++;
                player1StackPanel.Children.Add(button);
                buttons.Add(button);
            }
            Player1.Children.Add(player1StackPanel);
            //x = 0;
            //foreach (Button btn in buttons)
            //{

            //    Grid.SetRow(btn, 0); // set the row of the button in the grid
            //    Grid.SetColumn(btn, x);

            //    Player1.Children.Add(btn);// set the column of the button in the grid
            //                              //Test.Children.Add(btn);

            //    x++;
            //}

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
