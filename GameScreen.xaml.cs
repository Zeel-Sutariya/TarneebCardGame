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
        List<Button> trumpButtons = new List<Button>();
        Round round = new Round();
        Match match;
        int currentBid = 0;
        int currentPlayer = 1;
        int currentTrump = 0;
        string trumpCard;
        StackPanel player1StackPanel = new StackPanel();
        StackPanel player2StackPanel = new StackPanel();
        StackPanel player3StackPanel = new StackPanel();
        StackPanel player4StackPanel = new StackPanel();
        Label lblBid = new Label();
        Label lblHighestBid = new Label();
        int pass = 0;
        Label selectTrump = new Label();
        Team team01 = new Team("Player 1", "Player3");
        Team team02 = new Team("player 2", "Player4");
        Card currentRoundCard = new Card();
        public GameScreen()
        {
            InitializeComponent();
        }
        /*
         * In Function 1 put func2
         * In func2 put func3
         * In func3 put func4
         * and in dunc4 put Function 1
         * And the function 1 will be called in load event.
         */

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;

            //while(gameScore <31)
            {
                match = new Match();
                DisplayCards();
                DisplayBid();
                DisplayScore();
                if (currentPlayer == 1)
                {
                    HumanBidTurn();
                    // xWhile loop untill button is clicked

                }
                //DisplayTrump();
            }
        }
        public void HumanBidTurn()
        {
            MessageBox.Show("Your Turn!");

        }

        public void AIBidTurn() 
        {
            thinkTime();
            int selectBid = 0;
            MessageBox.Show("AI Bidding");
            if(currentPlayer == 2)
            {
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player2, currentBid+1, gameMode.Content.ToString()));
                string buttonName = "btnBid" + selectBid.ToString();

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
            }
            else if(currentPlayer == 3)
            {
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player3, currentBid + 1, gameMode.Content.ToString()));
                string buttonName = "btnBid" + selectBid.ToString();

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
            }
            else if (currentPlayer == 4)
            {
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player4, currentBid + 1, gameMode.Content.ToString()));
                string buttonName = "btnBid" + selectBid.ToString();

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
            }
        }

        public void HumanTrumpTurn()
        {
            MessageBox.Show("Your Turn!");
        } 
        public void AITrumpTurn()
        {
            if (currentPlayer == 2)
            {
                currentTrump = AI.selectTrump(match.player2, gameMode.Content.ToString());
                string buttonName = "btnTrump" + currentTrump.ToString();

                Button mybutton = trumpButtons.ElementAt(currentTrump-1);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                MessageBox.Show(Convert.ToString(currentTrump));
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
            }
            else if (currentPlayer == 3)
            {
                currentTrump = AI.selectTrump(match.player3, gameMode.Content.ToString());
                string buttonName = "btnTrump" + currentTrump.ToString();

                Button mybutton = trumpButtons.ElementAt(currentTrump - 1);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                MessageBox.Show(Convert.ToString(currentTrump));
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
            }
            else if (currentPlayer == 4)
            {
                currentTrump = AI.selectTrump(match.player4, gameMode.Content.ToString());
                string buttonName = "btnTrump" + currentTrump.ToString();

                Button mybutton = trumpButtons.ElementAt(currentTrump - 1);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                MessageBox.Show(Convert.ToString(currentTrump));
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
            }
        }

        private void CardButton_Click(object sender, RoutedEventArgs e)
        {
            // Removing Bid GRID from Round Grid.
            Round.Children.Remove(Bid);
            Round.Children.Remove(selectTrump);

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
        #region FindParent
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is T))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as T;
        }
        #endregion

        #region FindParent CardList
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
        #endregion

        #region Display Cards
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
        #endregion

        #region Display Player 1
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
        #endregion

        #region Display Player 2
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
                button.IsEnabled = false;

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
        #endregion

        #region Display Player 3
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
                button.IsEnabled = false;
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
        #endregion

        #region Display PLayer 4
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
                button.IsEnabled = false;
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
        #endregion

        #region SetCardImage
        public Image SetCardImage(Card card)
        {
            Image myImage = new Image
            {
                Source = new BitmapImage(new Uri(card.getImagePath(), UriKind.RelativeOrAbsolute)),
                Stretch = Stretch.Fill
            };
            return myImage;
        }
        #endregion

        #region SetTrumpImage
        public Image SetTrumpImage(String imagePath)
        {
            Image myImage = new Image
            {
                Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)),
                Stretch = Stretch.Fill
            };
            return myImage;
        }
        #endregion
        public async void ShowMatchHighestBid()
        {
            // For match - showing final bid here
            System.Windows.Shapes.Rectangle highestBidBorder = new System.Windows.Shapes.Rectangle();
            highestBidBorder.Width = Round.Width;
            highestBidBorder.Height = Round.Height;
            highestBidBorder.Stroke = Brushes.Aqua;
            highestBidBorder.StrokeThickness = 3;
            highestBidBorder.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            highestBidBorder.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            highestBidBorder.Height = 60;
            highestBidBorder.Width = 60;
            highestBidBorder.Margin = new System.Windows.Thickness(20, 35, 120, 0);
            test.Children.Add(highestBidBorder);
            Grid.SetColumn(highestBidBorder, 0);
            Grid.SetRow(highestBidBorder, 0);
            Grid.SetColumnSpan(highestBidBorder, 2);

            Label matchHighestBid = new Label();
            matchHighestBid.Name = "matchHighestBid";
            matchHighestBid.Content = currentBid;
            matchHighestBid.FontSize = 36;
            matchHighestBid.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            matchHighestBid.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            if (currentPlayer == 1 || currentPlayer == 3)
            {
                // If player 1 or 3 wins
                highestBidBorder.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 88, 3, 255));
                matchHighestBid.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 88, 3, 255));
            }
            else
            {
                // else
                highestBidBorder.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 3, 3));
                matchHighestBid.Foreground = Brushes.Red;
            }
            highestBidBorder.Opacity = 0.25;
            matchHighestBid.Margin = new System.Windows.Thickness(20, 35, 127, 0);
            test.Children.Add(matchHighestBid);
            Grid.SetColumn(matchHighestBid, 0);
            Grid.SetRow(matchHighestBid, 0);
            Grid.SetColumnSpan(matchHighestBid, 2);

            selectTrump.Name = "selectTrump";
            selectTrump.Content = "SELECT TRUMP";
            selectTrump.FontFamily = new FontFamily("ROG Fonts");
            selectTrump.FontSize = 64;
            selectTrump.HorizontalAlignment = HorizontalAlignment.Center;
            selectTrump.VerticalAlignment = VerticalAlignment.Center;
            Round.Children.Add(selectTrump);
            Grid.SetColumn(selectTrump, 0);
            Grid.SetRow(selectTrump, 0);
            await DisplayTrump();

            if (currentPlayer == 1)
            {
                HumanTrumpTurn();
            }
            else
            {
                AITrumpTurn();
            }
        }
        public void DisplayBid()
        {
          
            // Making for Round - bidding take place here.
            System.Windows.Shapes.Rectangle bidBorder = new System.Windows.Shapes.Rectangle();
            bidBorder.Width = Round.Width;
            bidBorder.Height = Round.Height;
            bidBorder.Stroke = Brushes.Aqua;
            bidBorder.StrokeThickness = 3;
            Round.Children.Add(bidBorder);

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

        public async Task DisplayTrump()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            Round.Children.Remove(selectTrump);
            System.Windows.Shapes.Rectangle trumpBorder = new System.Windows.Shapes.Rectangle();
            trumpBorder.Width = Trump.Width;
            trumpBorder.Height = Trump.Height;
            trumpBorder.Stroke = Brushes.Aqua;
            trumpBorder.StrokeThickness = 3;
            TrumpSelect.Children.Add(trumpBorder);

            int x = 0;
            for (int j = 1; j <= 4; j++)
            {

                Button btnTrump = new Button();
               
               
                btnTrump.Name = "btnTrump" + j.ToString();
                btnTrump.Content = j.ToString();
                btnTrump.Tag = j.ToString();
                btnTrump.Width = 100;
                btnTrump.Height = 100;
                btnTrump.Click += TrumpButton_Click;
                Trump.Children.Add(btnTrump);
                //Grid.SetColumn(btnTrump, x);
                //Grid.SetRow(btnTrump, x);
                
                x++;
                trumpButtons.Add(btnTrump);
                
            }
            Grid.SetColumn(trumpButtons[0], 0);
            Grid.SetRow(trumpButtons[0], 0);
            Grid.SetColumn(trumpButtons[1], 0);
            Grid.SetRow(trumpButtons[1], 1);
            Grid.SetColumn(trumpButtons[2], 1);
            Grid.SetRow(trumpButtons[2], 1);
            Grid.SetColumn(trumpButtons[3], 1);
            Grid.SetRow(trumpButtons[3], 0);
            trumpButtons[0].Content = SetTrumpImage("/Images/club.png");
            trumpButtons[1].Content = SetTrumpImage("/Images/diamond.png");
            trumpButtons[2].Content = SetTrumpImage("/Images/heart.png");
            trumpButtons[3].Content = SetTrumpImage("/Images/spades.png");
           
            

        }

        public void DisplayScore()
        {
            Grid Score = new Grid();
            Score.Name = "Score";
            test.Children.Add(Score);
            Grid.SetRow(Score, 0);
            Grid.SetColumn(Score, 0);

            Score.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            Score.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            System.Windows.Shapes.Rectangle ScoreUs = new System.Windows.Shapes.Rectangle();
            ScoreUs.Name = "ScoreUs";
            ScoreUs.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            ScoreUs.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ScoreUs.Height = 100;
            ScoreUs.Width = 60;
            ScoreUs.Margin = new System.Windows.Thickness(13, 15, 0, 0);
            ScoreUs.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 88, 3, 255));
            ScoreUs.Opacity = 0.25;

            System.Windows.Shapes.Rectangle ScoreThem = new System.Windows.Shapes.Rectangle();
            ScoreThem.Name = "ScoreThem";
            ScoreThem.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            ScoreThem.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            ScoreThem.Height = 100;
            ScoreThem.Width = 60;
            ScoreThem.Margin = new System.Windows.Thickness(72, 15, 0, 0);
            ScoreThem.Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 3, 3));
            ScoreThem.Opacity = 0.25;

            Label lblUs = new Label();
            lblUs.Content = "US";
            lblUs.FontWeight = System.Windows.FontWeights.Bold;
            lblUs.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            lblUs.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            lblUs.Margin = new System.Windows.Thickness(28, 18, 0, 0);
            lblUs.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 88, 3, 255));
            lblUs.FontSize = 16;

            Label lblThem = new Label();
            lblThem.Content = "THEM";
            lblThem.FontWeight = System.Windows.FontWeights.Bold;
            lblThem.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            lblThem.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            lblThem.Margin = new System.Windows.Thickness(74, 18, 0, 0);
            lblThem.Foreground = Brushes.Red;
            lblThem.FontSize = 16;

            Score.Children.Add(ScoreUs);
            Score.Children.Add(ScoreThem);
            Score.Children.Add(lblUs);
            Score.Children.Add(lblThem);
        }

        public void thinkTime()
        {
            Random rnd = new Random();
            int time = rnd.Next(4000, 8000);

            //Thread.Sleep(time);
        }

        private void BidButton_Click(object sender, RoutedEventArgs e)
        {

            
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
            if (pass < 3 && currentBid < 13)
            {
                currentPlayer++;
                if (currentPlayer > 4)
                {
                    currentPlayer = 1;
                }
                if (currentPlayer != 1)
                {
                    AIBidTurn();
                }
            }
            else
            {
                Round.Children.Remove(Bid);
                MessageBox.Show("Final Bid is " + currentBid);
                ShowMatchHighestBid();
            }
        }

        private void TrumpButton_Click(object sender, RoutedEventArgs e)
        {


            Button clickedButton = sender as Button;
            string buttonContent = Convert.ToString(clickedButton.Tag);
            
            currentTrump = Convert.ToInt32(buttonContent);
            

            if(currentTrump == 1)
            {
                trumpCard = "Club";
            }
            else if (currentTrump == 2)
            {
                trumpCard = "Diamond";
            }
            else if (currentTrump == 3)
            {
                trumpCard = "Heart";
            }
            else
            {
                trumpCard = "Spade";
            }

            TrumpSelect.Children.Remove(Trump);
            MessageBox.Show("The trump is " + trumpCard);
                //ShowMatchHighestBid();
            
        }

        private void PassButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pass btn Clicked");
            pass++;
            currentPlayer++;
            if (pass >= 3)
            {
                Round.Children.Remove(Bid);
                //Thread.Sleep(3000);
                MessageBox.Show("Final Bid is " + currentBid);
                pass = 0;
                ShowMatchHighestBid();
            }
            else
            {
                if (currentPlayer > 4)
                {
                    currentPlayer = 1;
                }
                if (currentPlayer != 1)
                {
                    AIBidTurn();
                }
            }
            
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
