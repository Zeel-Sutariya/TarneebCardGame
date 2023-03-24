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

        StackPanel player1StackPanel = new StackPanel();
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
                To = Round.ActualWidth / 2 - clickedButton.ActualWidth / 2,
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
            cards = deck.TakeCards(13);
            int x = 0;
            List<Button> buttons = new List<Button>();

            //StackPanel player1StackPanel = new StackPanel();
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
