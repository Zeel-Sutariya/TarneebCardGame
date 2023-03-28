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

        List<Button> bidButtons = new List<Button>();
        public Tester()
        {
            InitializeComponent();
        }

        StackPanel player1StackPanel = new StackPanel();
        StackPanel player2StackPanel = new StackPanel();
        StackPanel player3StackPanel = new StackPanel();
        StackPanel player4StackPanel = new StackPanel();
        Label lblBid = new Label();
        Label lblHighestBid = new Label();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            DisplayCards();
            DisplayBid();
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            Round.Children.Remove(lblBid);
            Round.Children.Remove(Bid);
            Button clickedButton = sender as Button;
            string buttonName = clickedButton.Name;
            clickedButton.IsEnabled = false;
            //MessageBox.Show("Button " + buttonName + " was clicked! " + Convert.ToString(this.Background));

            Card card = (Card)clickedButton.Tag;
            card.isFaceUp = true;

            clickedButton.Content = SetCardImage(card);

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
            StackPanel parentStackPanel = FindParent<StackPanel>(clickedButton);
            // Remove the button from the StackPanel
            parentStackPanel.Children.Remove(clickedButton);

            // Add the button to grid2
            int margin = 100;
            if(card.cardOwner == 1)
            {
                clickedButton.Margin = new Thickness(0, margin, 0, 0);
            }
            else if(card.cardOwner == 2){
                clickedButton.Margin = new Thickness(margin, 2 * margin, 0, 0);
            }
            else if(card.cardOwner == 3){
                clickedButton.Margin = new Thickness(0, 0, 0, margin);
            }
            else if(card.cardOwner == 4){
                clickedButton.Margin = new Thickness(0, 2 * margin, 2 * margin, 0);
            }

            Round.Children.Add(clickedButton);
            Grid.SetColumn(clickedButton, 0);
            Grid.SetRow(clickedButton, 0);

        }
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
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
                card.cardOwner = 1;
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

                button.Content = SetCardImage(card);


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
                card.cardOwner = 2;
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

                button.Content = SetCardImage(card);


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
                card.cardOwner = 3;
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

                button.Content = SetCardImage(card);


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
                card.cardOwner = 4;
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
                
                button.Content = SetCardImage(card);


                x++;
                player4StackPanel.Children.Add(button);
            }
            player4StackPanel.Margin = new Thickness(0, 100, 0, 0);
            Player4.Children.Add(player4StackPanel);
        }

        public Image SetCardImage(Card card)
        {
            Image myImage = new Image
            {
                Source = new BitmapImage(new Uri(card.getImagePath(), UriKind.RelativeOrAbsolute)),
                Stretch = Stretch.Fill
            };
            return myImage;
        }


        public void DisplayBid()
        {
            lblBid.Name = "lblBid";
            lblBid.Content = "BID";
            lblBid.FontWeight = FontWeights.Bold;
            lblBid.FontSize = 44;
            lblBid.HorizontalAlignment = HorizontalAlignment.Center;
            lblBid.VerticalAlignment = VerticalAlignment.Bottom;
            Bid.Children.Add(lblBid);
            Grid.SetRow(lblBid, 0);
            Grid.SetColumn(lblBid, 4);

            lblHighestBid.Name = "lblHighestBid";
            lblHighestBid.Content = "Highest Bid : ";
            lblHighestBid.FontWeight = FontWeights.Bold;
            lblHighestBid.FontSize = 24;
            lblHighestBid.HorizontalAlignment = HorizontalAlignment.Center;
            lblHighestBid.VerticalAlignment = VerticalAlignment.Center;
            Bid.Children.Add(lblHighestBid);
            Grid.SetRow(lblHighestBid, 1);
            Grid.SetColumn(lblHighestBid, 3);
            Grid.SetColumnSpan(lblHighestBid, 3);
            int x = 1;
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 7; j++)
                {

                    Button btnBid = new Button();
                    if (i == 2 && j == 7)
                    {
                        btnBid.Name = "btnPass" + x.ToString();
                        btnBid.Content = "Pass";
                        btnBid.Width = 50;
                        btnBid.Height = 50;
                        btnBid.Click += PassButton_Click;
                        Bid.Children.Add(btnBid);
                    }
                    else 
                    {
                        btnBid.Name = "btnBid" + x.ToString();
                        btnBid.Content = x.ToString();
                        btnBid.Width = 50;
                        btnBid.Height = 50;
                        btnBid.Click += BidButton_Click;
                        Bid.Children.Add(btnBid);
                    }
                    
                    
                    Grid.SetColumn(btnBid, j);
                    Grid.SetRow(btnBid, i + 1);
                    x++;
                    bidButtons.Add(btnBid);
                }
            }

        }

        private void BidButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonContent = Convert.ToString(clickedButton.Content);
            lblHighestBid.Content = "Highest Bid : " + buttonContent;

            int x = 1;
            foreach (Button button in bidButtons)
            {
                button.IsEnabled = false;
                if (x == Convert.ToInt64(buttonContent))
                {
                    break;
                }
                x++;
            }
        }

        private void PassButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button is under constructions!");
        }

        /* ------------- AI PART ---------------
        public Card SelectCardToPlay(List<Card> playedCards, List<Card> aiHand, List<Card> currentTrick, GameMode gameMode)
        {
            // Determine the legal plays (i.e., the cards in the AI player's hand that can legally be played in the current trick)
            List<Card> legalPlays = GetLegalPlays(aiHand, currentTrick);

            // If there is only one legal play, play it
            if (legalPlays.Count == 1)
            {
                return legalPlays[0];
            }

            // If there are multiple legal plays, use the AI player's strategy to select the best one
            switch (gameMode)
            {
                case GameMode.Easy:
                    // In easy mode, the AI player simply plays the highest-ranked legal card in its hand
                    return legalPlays.OrderByDescending(card => card.Rank).First();

                case GameMode.Medium:
                // In medium mode, the AI player uses a heuristic to evaluate the strength of its cards and the likelihood of winning the trick
                // TODO: implement medium mode strategy

                case GameMode.Hard:
                // In hard mode, the AI player uses a more sophisticated heuristic to evaluate the strength of its cards and the likelihood of winning the trick
                // TODO: implement hard mode strategy

                default:
                    throw new ArgumentException("Invalid game mode specified.");
            }
        }

        private List<Card> GetLegalPlays(List<Card> hand, List<Card> trick)
        {
            // TODO: implement logic to determine the legal plays for the AI player's hand in the current trick
            throw new NotImplementedException();
        }
        */
    }
}
