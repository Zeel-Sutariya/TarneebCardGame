using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using Cards;
using UsingCards;
using Size = System.Windows.Size;

namespace Tarneeb_Card_Game
{
    /// <summary>
    /// Interaction logic for Tester.xaml
    /// </summary>
    public partial class GameScreen : Window
    {

        //List<Card> roundCards = new List<Card>();
        public int gameScore;
        List<Button> bidButtons = new List<Button>();
        Round round = new Round();
        Match match;
        int currentBid = 0;
        int currentPlayer = 1;
        StackPanel player1StackPanel = new StackPanel();
        StackPanel player2StackPanel = new StackPanel();
        StackPanel player3StackPanel = new StackPanel();
        StackPanel player4StackPanel = new StackPanel();
        Label lblBid = new Label();
        Label lblHighestBid = new Label();

        Team team01 = new Team("Player 1", "Player3");
        Team team02 = new Team("player 2", "Player4");
        Card currentRoundCard = new Card();
        public GameScreen()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

            //while(gameScore <31)
            {
                match = new Match();
                DisplayCards();
                DisplayBid();
                if (currentPlayer == 1)
                {
                    WaitForPlayerMoveAsync();
                    // while loop untill button is clicked

                }
                if(currentPlayer == 2)
                {
                    MakeBidAsync(e);
                }
                //CardButton_Click(sender, e);
                //MessageBox.Show(Convert.ToString(AI.PlaceBid(match.player1, 6, "Hard")));
            }
        }
        ManualResetEvent buttonClickedEvent = new ManualResetEvent(false);
        public void WaitForPlayerMoveAsync()
        {
            MessageBox.Show("Your Turn!");
            //buttonClickedEvent.WaitOne();


        }

        public void MakeBidAsync(RoutedEventArgs e) {
            int selectBid = 0;
            MessageBox.Show("AI Bidding");
            if(currentPlayer != 1)
            {
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player2, currentBid, "Easy"));
                string buttonName = "btnBid" + selectBid.ToString();
                //Button myButton = (Button)Bid.FindName(buttonName);
                Button mybutton = bidButtons.ElementAt(selectBid - 7);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                MessageBox.Show(Convert.ToString(selectBid));
                if (mybutton != null)
                {
                    // Click the button programmatically
                    mybutton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    // Button not found
                    // Handle the error
                    MessageBox.Show("button not found");
                }
                //BidButton_Click(mybutton, e);
            }
        }
        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            // Removing Bid GRID from Round Grid.
            Round.Children.Remove(Bid);

            Button clickedButton = sender as Button;
            string buttonName = clickedButton.Name;
            clickedButton.IsEnabled = false;
            //MessageBox.Show("Button " + buttonName + " was clicked! " + Convert.ToString(this.Background));

            Card card = (Card)clickedButton.Tag;
            card.isFaceUp = true;

            clickedButton.Content = SetCardImage(card);

            
            StackPanel parentStackPanel = FindParent<StackPanel>(clickedButton);

            // Remove the button from the StackPanel
            parentStackPanel.Children.Remove(clickedButton);

            
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

            round.roundCards.Add(card);
            if (round.roundCards.Count > 3) {
                MessageBox.Show(Convert.ToString(round.RoundWinner()));
            }

            // Add the button to Round GRID
            Round.Children.Add(clickedButton);
            Grid.SetColumn(clickedButton, 0);
            Grid.SetRow(clickedButton, 0);
            if(currentRoundCard.cardOwner == 0)
            {
                List<Card> legal = SetLegalPlays(card);
            }
            else
            {
                List<Card> legal = SetLegalPlays(currentRoundCard);
            }
                
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

        private List<Card> FindParentCardList(Card card)
        {

            if (card.cardOwner == 1)
            {
                return match.player1;
            }
            else if (card.cardOwner == 2)
            {
                return match.player2;
            }
            else if (card.cardOwner == 3)
            {
                return match.player3;
            }
            else
            {
                return match.player4;
            }

        }

        //private DoubleAnimation CreateAnimation(double fromValue, double toValue)
        //{
        //    DoubleAnimation animation = new DoubleAnimation();
        //    animation.From = fromValue;
        //    animation.To = toValue;
        //    animation.Duration = new Duration(TimeSpan.FromSeconds(1));
        //    return animation;
        //}
        public void DisplayCards()
        {
            //Grid Test = new Grid();
            Deck deck = new Deck();
            deck.Shuffle();
            match.player1 = deck.Sort(deck.TakeCards(13)); 
            match.player2 = deck.Sort(deck.TakeCards(13));
            match.player3 = deck.Sort(deck.TakeCards(13));
            match.player4 = deck.Sort(deck.TakeCards(13));

            
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
            foreach (Card card in match.player1)
            {
                card.cardOwner = 1;
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = true;
                card.ParentButton = button;
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
            foreach (Card card in match.player2)
            {
                card.cardOwner = 2;
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = true;
                card.ParentButton = button;


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
            foreach (Card card in match.player3)
            {
                card.cardOwner = 3;
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = true;
                card.ParentButton = button;
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
            foreach (Card card in match.player4)
            {
                card.cardOwner = 4;
                Button button = new Button();
                button.Name = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber);
                button.Content = Convert.ToString(card.Suit) + Convert.ToString(card.CardNumber); // Set the button's content to the card's name
                button.Tag = card; // Assign the card object to the button's Tag property
                button.Width = 85;
                button.Height = 140;
                card.isFaceUp = true;
                card.ParentButton = button;
             

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
            System.Windows.Shapes.Rectangle rectangle = new System.Windows.Shapes.Rectangle();
            rectangle.Width = Round.Width;
            rectangle.Height = Round.Height;
            rectangle.Stroke = Brushes.Aqua;
            rectangle.StrokeThickness = 3;
            Round.Children.Add(rectangle);

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

            for (int j = 7; j <= 14; j++)
            {

                Button btnBid = new Button();
                if (j == 14)
                {
                    btnBid.Name = "btnBid" + j.ToString();
                    btnBid.Content = "Pass";
                    btnBid.Width = 150;
                    btnBid.Height = 30;
                    btnBid.Click += PassButton_Click;
                    Bid.Children.Add(btnBid);
                    Grid.SetColumn(btnBid, 3);
                    Grid.SetRow(btnBid, 3);
                    Grid.SetColumnSpan(btnBid, 3);
                }
                else 
                {
                    btnBid.Name = "btnBid" + j.ToString();
                    btnBid.Content = j.ToString();
                    btnBid.Width = 50;
                    btnBid.Height = 50;
                    btnBid.Click += BidButton_Click;
                    Bid.Children.Add(btnBid);
                    Grid.SetColumn(btnBid, x);
                    Grid.SetRow(btnBid, 2);
                }
                    
                
                x++;
                bidButtons.Add(btnBid);
                
            }

        }

        private void BidButton_Click(object sender, RoutedEventArgs e)
        {

            //bidButtonClickedTcs.SetResult(true);
            //buttonClickedEvent.Set();
            currentPlayer++;
            Button clickedButton = sender as Button;
            string buttonContent = Convert.ToString(clickedButton.Content);
            lblHighestBid.Content = "Highest Bid : " + buttonContent;
            currentBid = Convert.ToInt32(buttonContent);
            int x = 7;


            foreach (Button button in bidButtons)
            {
                button.IsEnabled = false;
                if (x == Convert.ToInt64(buttonContent))
                {
                    break;
                }
                x++;
            }
            if(currentPlayer >4) 
            { 
                currentPlayer = 1; 
            }
            if(currentPlayer != 1)
            {
                MakeBidAsync(e);
            }
        }

        private void PassButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This button is under constructions!");
        }


        private List<Card> SetLegalPlays(Card card)
        {
            currentRoundCard = card;
            List<Card> list = new List<Card>();
            List<Card> parent = FindParentCardList(card);
            foreach (Card card1 in match.player1) 
            {
                Button btn = card1.ParentButton;
                if (card1.Suit == card.Suit)
                {
                    list.Add(card1);
                    btn.Margin = new Thickness(0, 0, 0, 20);
                }
                else
                {
                    btn.IsEnabled = false;
                }
            
            }
            foreach (Card card1 in match.player2)
            {
                Button btn = card1.ParentButton;
                if (card1.Suit == card.Suit)
                {
                    list.Add(card1);
                }
                else
                {
                    btn.IsEnabled = false;
                }

            }
            foreach (Card card1 in match.player3)
            {
                Button btn = card1.ParentButton;
                if (card1.Suit == card.Suit)
                {
                    list.Add(card1);
                }
                else
                {
                    btn.IsEnabled = false;
                }

            }
            foreach (Card card1 in match.player4)
            {
                Button btn = card1.ParentButton;
                if (card1.Suit == card.Suit)
                {
                    list.Add(card1);
                }
                else
                {
                    btn.IsEnabled = false;
                }

            }
            return list;
        }


        /* ------------- AI PART --------------- *
        public Card SelectCardToPlay(List<Card> playedCards, List<Card> aiHand, List<Card> currentTrick, string gameMode)
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
        /**/
    }
}
