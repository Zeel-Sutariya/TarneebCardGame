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

        List<Card> player1 = new List<Card>();
        List<Card> player2 = new List<Card>();
        List<Card> player3 = new List<Card>();
        List<Card> player4 = new List<Card>();
        public Tester()
        {
            InitializeComponent();
            DisplayCards();
        }

        StackPanel player1StackPanel = new StackPanel();
        StackPanel player2StackPanel = new StackPanel();
        StackPanel player3StackPanel = new StackPanel();
        StackPanel player4StackPanel = new StackPanel();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonName = clickedButton.Name;
            clickedButton.IsEnabled = false;
            //MessageBox.Show("Button " + buttonName + " was clicked! " + Convert.ToString(this.Background));

            // Get the position of the button
            System.Windows.Point position = clickedButton.TranslatePoint(new System.Windows.Point(0, 0), this);

            // Animate the button to move from grid1 to grid2
            DoubleAnimation animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                From = position.X,
                To = Round.ActualWidth,
                EasingFunction = new QuadraticEase()
            };

            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, clickedButton);
            Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));
            storyboard.Begin(this);

            // Remove the button from the StackPanel
            player1StackPanel.Children.Remove(clickedButton);

            // Add the button to grid2
            int marginTop = 150;
            clickedButton.Margin = new Thickness(0, marginTop, 0, 0);
            Round.Children.Add(clickedButton);
            Grid.SetColumn(clickedButton, 0);
            Grid.SetRow(clickedButton, 0);

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
            //Grid Test = new Grid();
            Deck deck = new Deck();
            deck.Shuffle();
            player1 = deck.Sort(deck.TakeCards(13)); 
            player2 = deck.Sort(deck.TakeCards(13));
            player3 = deck.Sort(deck.TakeCards(13));
            player4 = deck.Sort(deck.TakeCards(13));


            // Sort the cards by suit, and then by rank
            //var sortedCards = player1.OrderBy(c => c.Suit).ThenBy(c => c.CardNumber);

            // Store the sorted cards back into the cards list
            //player1 = sortedCards.ToList();
            //player2 = sortedCards.ToList();
            //player3 = sortedCards.ToList();
            //player4 = sortedCards.ToList();

            
            DisplayPlayer1();
            DisplayPlayer2();
            DisplayPlayer3();
            DisplayPlayer4();
        }

        public void DisplayPlayer1()
        {
            int x = 0;
            //StackPanel player1StackPanel = new StackPanel();
            player1StackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            player1StackPanel.Orientation = Orientation.Horizontal;
            foreach (Card card in player1)
            {
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = true;
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
                    Source = new BitmapImage(new Uri(card.getImagePath(), UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
                button.Content = myImage;


                x++;
                player1StackPanel.Children.Add(button);
            }
            Player1.Children.Add(player1StackPanel);
        }

        public void DisplayPlayer2()
        {
            player2StackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            player2StackPanel.Orientation = Orientation.Vertical;
            int x = 0;
            foreach (Card card in player2)
            {
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = false;


                button.Margin = new Thickness(0, 0, 0, -120);
                
                button.Click += CardButton_Click;

                var rotateTransform = new RotateTransform(-90);
                button.RenderTransform = rotateTransform;
                Image myImage = new Image
                {
                    Source = new BitmapImage(new Uri(card.getImagePath(), UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
                button.Content = myImage;


                x++;
                player2StackPanel.Children.Add(button);
            }
            player2StackPanel.Margin = new Thickness(0, 100, 0, 0);
            Player2.Children.Add(player2StackPanel);
        }

        public void DisplayPlayer3()
        {
            int x = 0;
            //StackPanel player1StackPanel = new StackPanel();
            player3StackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            player3StackPanel.Orientation = Orientation.Horizontal;
            foreach (Card card in player3)
            {
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = false;
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
                    Source = new BitmapImage(new Uri(card.getImagePath(), UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
                button.Content = myImage;


                x++;
                player3StackPanel.Children.Add(button);
            }
            Player3.Children.Add(player3StackPanel);
        }

        public void DisplayPlayer4()
        {
            player4StackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            player4StackPanel.Orientation = Orientation.Vertical;
            int x = 0;
            foreach (Card card in player4)
            {
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = false;

             

                button.Margin = new Thickness(0, 0, 0, -120);
                
                button.Click += CardButton_Click;

                var rotateTransform = new RotateTransform(-90);
                button.RenderTransform = rotateTransform;
                Image myImage = new Image
                {
                    Source = new BitmapImage(new Uri(card.getImagePath(), UriKind.RelativeOrAbsolute)),
                    Stretch = Stretch.Fill
                };
                button.Content = myImage;


                x++;
                player4StackPanel.Children.Add(button);
            }
            player4StackPanel.Margin = new Thickness(0, 100, 0, 0);
            Player4.Children.Add(player4StackPanel);
        }


    }
}
