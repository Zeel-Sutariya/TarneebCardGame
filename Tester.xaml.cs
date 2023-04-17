using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Tester : Window
    {
        //List<Card> roundCards = new List<Card>();
        Deck deck = new Deck();
        public int gameScore;
        public List<Button> deckCards = new List<Button>();
        List<Button> bidButtons = new List<Button>();
        List<Button> trumpButtons = new List<Button>();
        Round round;
        Match match;
        int NumberOfRounds = 0;
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
        int turn = 1;
        Label selectTrump = new Label();
        Team team01 = new Team("Player 1", "Player3");
        Team team02 = new Team("player 2", "Player4");
        string chosenCard = "";
        Card currentRoundCard = new Card();
        List<Card> legalCards = new List<Card>();
        public Tester()
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

            StartMatch();
            if(gameScore >=31)
            {
                //MessageBox.Show("Game is WON by ...");
            }
            else if(NumberOfRounds >=13)
            {
                //Round.Children.Clear();
                NumberOfRounds = 0;
                //StartMatch();
            }
             
        }
        private void StartMatch()
        {
            currentPlayer = 1;
            match = new Match();
            round = new Round();
            DisplayCards();
            DisplayBid();
            DisplayScore();
            if (currentPlayer == 1)
            {
                HumanBidTurn();

            }
        }
        public void HumanBidTurn()
        {
            MessageBox.Show("Your Turn!");
            //MessageBox.Show(deck.Cards.ToString());
        }

        public void AIBidTurn()
        {
            thinkTime();
            int selectBid = 0;
            //MessageBox.Show("AI Bidding");
            if (currentPlayer == 2)
            {
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player2, currentBid + 1, gameMode.Content.ToString()));
                string buttonName = "btnBid" + selectBid.ToString();

                Button mybutton = bidButtons.ElementAt(selectBid - 7);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                //MessageBox.Show(Convert.ToString(selectBid));
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
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player3, currentBid + 1, gameMode.Content.ToString()));
                string buttonName = "btnBid" + selectBid.ToString();

                Button mybutton = bidButtons.ElementAt(selectBid - 7);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                //MessageBox.Show(Convert.ToString(selectBid));
                if (mybutton != null)
                {
                    // Click the button programmatically
                    mybutton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    // Button not found
                    // Handle the error
                    //MessageBox.Show("button not found");
                }
            }
            else if (currentPlayer == 4)
            {
                selectBid = Convert.ToInt32(AI.PlaceBid(match.player4, currentBid + 1, gameMode.Content.ToString()));
                string buttonName = "btnBid" + selectBid.ToString();

                Button mybutton = bidButtons.ElementAt(selectBid - 7);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                //MessageBox.Show(Convert.ToString(selectBid));
                if (mybutton != null)
                {
                    // Click the button programmatically
                    mybutton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    // Button not found
                    // Handle the error
                    //MessageBox.Show("button not found");
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

                Button mybutton = trumpButtons.ElementAt(currentTrump - 1);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                //MessageBox.Show(Convert.ToString(currentTrump));
                if (mybutton != null)
                {
                    // Click the button programmatically
                    mybutton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    // Button not found
                    // Handle the error
                    //MessageBox.Show("button not found");
                }
            }
            else if (currentPlayer == 3)
            {
                currentTrump = AI.selectTrump(match.player3, gameMode.Content.ToString());
                string buttonName = "btnTrump" + currentTrump.ToString();

                Button mybutton = trumpButtons.ElementAt(currentTrump - 1);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                //MessageBox.Show(Convert.ToString(currentTrump));
                if (mybutton != null)
                {
                    // Click the button programmatically
                    mybutton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                }
                else
                {
                    // Button not found
                    // Handle the error
                    //MessageBox.Show("button not found");
                }
            }
            else if (currentPlayer == 4)
            {
                currentTrump = AI.selectTrump(match.player4, gameMode.Content.ToString());
                string buttonName = "btnTrump" + currentTrump.ToString();

                Button mybutton = trumpButtons.ElementAt(currentTrump - 1);
                //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                //MessageBox.Show(Convert.ToString(currentTrump));
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

        public void HumanCardSelect()
        {
            //turn++;
            MessageBox.Show("Your Turn!");
            //currentPlayer++;

        }
        public void AICardSelect()
        {
            //turn++;
            if (turn <= 4)
            {
                if (round.roundCards.Count == 0)
                {
                    if (currentPlayer == 2)
                    {
                        //MessageBox.Show("Current Player: " + currentPlayer.ToString());
                        //MessageBox.Show("Turn: " + turn.ToString());
                        chosenCard = AI.PlayCard(match.player2, "", round.roundCards, currentTrump, gameMode.Content.ToString());
                        string buttonName = chosenCard;
                        int index = deckCards.FindIndex(button => button.Name == buttonName);
                        Button mybutton = deckCards.ElementAt(index);
                        //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                        MessageBox.Show(Convert.ToString(chosenCard));
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
                    else if (currentPlayer == 3 && turn <= 4)
                    {
                        //MessageBox.Show("Current Player: " + currentPlayer.ToString());
                        //MessageBox.Show("Turn: " + turn.ToString());
                        chosenCard = AI.PlayCard(match.player3, "", round.roundCards, currentTrump, gameMode.Content.ToString());
                        string buttonName = chosenCard;
                        int index = deckCards.FindIndex(button => button.Name == buttonName);
                        Button mybutton = deckCards.ElementAt(index);
                        //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                        MessageBox.Show(Convert.ToString(chosenCard));
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
                    else if (currentPlayer == 4 && turn <= 4)
                    {
                        //MessageBox.Show("Current Player: " + currentPlayer.ToString());
                        //MessageBox.Show("Turn: " + turn.ToString());

                        //currentPlayer = 1;
                        chosenCard = AI.PlayCard(match.player4, "", round.roundCards, currentTrump, gameMode.Content.ToString());
                        string buttonName = chosenCard;
                        int index = deckCards.FindIndex(button => button.Name == buttonName);
                        Button mybutton = deckCards.ElementAt(index);
                        //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                        MessageBox.Show(Convert.ToString(chosenCard));
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
                else
                {
                    if (currentPlayer == 2)
                    {
                        //MessageBox.Show("**Current Player: " + currentPlayer.ToString());
                        //MessageBox.Show("Turn: " + turn.ToString());
                        chosenCard = AI.PlayCard(match.player2, currentRoundCard.Suit.ToString(), round.roundCards, currentTrump, gameMode.Content.ToString());
                        string buttonName = chosenCard;
                        int index = deckCards.FindIndex(button => button.Name == buttonName);
                        Button mybutton = deckCards.ElementAt(index);
                        //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                        MessageBox.Show(Convert.ToString(chosenCard));
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
                    else if (currentPlayer == 3 && turn <= 4)
                    {
                        //MessageBox.Show("**Current Player: " + currentPlayer.ToString());
                        //MessageBox.Show("Turn: " + turn.ToString());
                        chosenCard = AI.PlayCard(match.player3, currentRoundCard.Suit.ToString(), round.roundCards, currentTrump, gameMode.Content.ToString());
                        string buttonName = chosenCard;
                        int index = deckCards.FindIndex(button => button.Name == buttonName);
                        Button mybutton = deckCards.ElementAt(index);
                        //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                        MessageBox.Show(Convert.ToString(chosenCard));
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
                    else if (currentPlayer == 4 && turn <= 4)
                    {
                        //MessageBox.Show("**Current Player: " + currentPlayer.ToString());
                        //MessageBox.Show("Turn: " + turn.ToString());

                        //currentPlayer = 1;
                        chosenCard = AI.PlayCard(match.player4, currentRoundCard.Suit.ToString(), round.roundCards, currentTrump, gameMode.Content.ToString());
                        string buttonName = chosenCard;
                        int index = deckCards.FindIndex(button => button.Name == buttonName);
                        Button mybutton = deckCards.ElementAt(index);
                        //MessageBox.Show(Convert.ToString(Bid.FindName(buttonName) as Button));
                        MessageBox.Show(Convert.ToString(chosenCard));
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
                
            }
            else
            {
                //MessageBox.Show("Round Winner is " + round.RoundWinner().ToString());
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
            if (card.cardOwner == 1)
            {
                clickedButton.Margin = new Thickness(0, margin, 0, 0);
            }
            else if (card.cardOwner == 2)
            {
                clickedButton.Margin = new Thickness(margin, 2 * margin, 0, 0);
            }
            else if (card.cardOwner == 3)
            {
                clickedButton.Margin = new Thickness(0, 0, 0, margin);
            }
            else if (card.cardOwner == 4)
            {
                clickedButton.Margin = new Thickness(0, 2 * margin, 2 * margin, 0);
            }

            match.player1.Remove(card);
            round.roundCards.Add(card);
            Round.Children.Add(clickedButton);
            Grid.SetColumn(clickedButton, 0);
            Grid.SetRow(clickedButton, 0);
            if (currentRoundCard.cardOwner == 0)
            {
                SetLegalPlays(card);
            }
            else
            {
                SetLegalPlays(currentRoundCard);
            }


            turn++;

            currentPlayer++;
            //MessageBox.Show("33Current Player: " + currentPlayer.ToString() + " Turn: " + turn.ToString() + " x: " + x.ToString() );
            if (currentPlayer > 4)
            {
                currentPlayer = 1;
            }
            // 1
            if (turn <= 4)
            {
                //MessageBox.Show(currentPlayer.ToString());

                if (currentPlayer == 1)
                {

                    HumanCardSelect();
                }
                else if (currentPlayer != 1)
                {
                    AICardSelect();
                }


                //MessageBox.Show("!!Winner is ");
            }
            else
            {
                int currentRoundWinner = round.RoundWinner();
                currentPlayer = currentRoundWinner;
                MessageBox.Show("Winner is Player " + currentRoundWinner.ToString());
                NumberOfRounds++;
                ResetRoundVariables();
                if (NumberOfRounds <= 13)
                {
                    if (currentPlayer == 1)
                    {
                        //MessageBox.Show("Your Turn!");
                        HumanCardSelect();
                    }
                    else
                    {
                        AICardSelect();

                    }
                }

            }
        }

        public void ResetRoundVariables()
        {
            round.roundCards.Clear();
            UnSetLegalPlays();
            Round.Children.Clear();
            RoundBorder();
            ShowSelectedTrumpImage();
            turn = 1;
            currentRoundCard.cardOwner = 0;
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
                deckCards.Add(button);
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
                deckCards.Add(button);
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
                deckCards.Add(button);
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
                deckCards.Add(button);
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
            FadeAnimation(selectTrump, 0, 2);
            Round.Children.Add(selectTrump);
            Grid.SetColumn(selectTrump, 0);
            Grid.SetRow(selectTrump, 0);
            await DisplayTrumpCardsBoxForTrumpSelection();

            TrumpTurnLogic();
        }

        public void TrumpTurnLogic()
        {
            if (currentPlayer == 1)
            {
                HumanTrumpTurn();
            }
            else
            {
                AITrumpTurn();
            }
        }

        public void RoundBorder()
        {

            // Making for Round - bidding take place here.
            System.Windows.Shapes.Rectangle roundBorder = new System.Windows.Shapes.Rectangle();
            roundBorder.Width = Round.Width;
            roundBorder.Height = Round.Height;
            roundBorder.Stroke = Brushes.Aqua;
            roundBorder.StrokeThickness = 3;
            Round.Children.Add(roundBorder);
        }
        Grid Bid;
        public void DisplayBid()
        {
            // Create a new Grid
            Bid = new Grid();
            Bid.Name = "Bid";
            Bid.ShowGridLines = false;

            // Add RowDefinitions to the Grid
            for (int i = 0; i < 4; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(3, GridUnitType.Star);
                Bid.RowDefinitions.Add(row);
            }

            RowDefinition lastRow = new RowDefinition();
            lastRow.Height = new GridLength(1, GridUnitType.Star);
            Bid.RowDefinitions.Add(lastRow);

            // Add ColumnDefinitions to the Grid
            for (int i = 0; i < 9; i++)
            {
                ColumnDefinition column = new ColumnDefinition();
                if (i == 0 || i == 8)
                {
                    column.Width = new GridLength(1, GridUnitType.Star);
                }
                else
                {
                    column.Width = new GridLength(3, GridUnitType.Star);
                }
                Bid.ColumnDefinitions.Add(column);
            }

            // Add the Grid to a parent element (e.g. a Window)
            Round.Children.Add(Bid);
            RoundBorder();
            lblBid.Name = "lblBid";
            lblBid.Content = "BID";
            lblBid.FontWeight = FontWeights.Bold;
            lblBid.FontSize = 44;
            lblBid.HorizontalAlignment = HorizontalAlignment.Center;
            lblBid.VerticalAlignment = VerticalAlignment.Bottom;
            this.Bid.Children.Add(lblBid);
            Grid.SetRow(lblBid, 0);
            Grid.SetColumn(lblBid, 4);

            lblHighestBid.Name = "lblHighestBid";
            lblHighestBid.Content = "Highest Bid : ";
            lblHighestBid.FontWeight = FontWeights.Bold;
            lblHighestBid.FontSize = 24;
            lblHighestBid.HorizontalAlignment = HorizontalAlignment.Center;
            lblHighestBid.VerticalAlignment = VerticalAlignment.Center;
            this.Bid.Children.Add(lblHighestBid);
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
                    this.Bid.Children.Add(btnBid);
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
                    this.Bid.Children.Add(btnBid);
                    Grid.SetColumn(btnBid, x);
                    Grid.SetRow(btnBid, 2);
                }


                x++;
                bidButtons.Add(btnBid);

            }

        }

        private void FadeAnimation(UIElement element, int from, int to)
        {
            // Create a new DoubleAnimation to fade in the element
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromSeconds(1)
            };

            // Create a new Storyboard and add the opacity animation to it
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(opacityAnimation);

            // Set the target property of the opacity animation to the element's Opacity property
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));

            // Set the target of the opacity animation to the element
            Storyboard.SetTarget(opacityAnimation, element);

            // Start the storyboard
            storyboard.Begin((FrameworkElement)element);
        }

        public async Task DisplayTrumpCardsBoxForTrumpSelection()
        {

            FadeAnimation(selectTrump, 3, 0);
            await Task.Delay(TimeSpan.FromSeconds(1));
            Round.Children.Remove(selectTrump);

            FadeAnimation(Trump, 0, 1);


            //System.Windows.Shapes.Rectangle trumpBorder = new System.Windows.Shapes.Rectangle();
            //trumpBorder.Width = Trump.Width;
            //trumpBorder.Height = Trump.Height;
            //trumpBorder.Stroke = Brushes.Aqua;
            //trumpBorder.StrokeThickness = 3;
            //TrumpSelect.Children.Add(trumpBorder);

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

            //Thread.Sleep(3000);
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
            ContinueBidding();
        }

        public void ContinueBidding()
        {
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
                MessageBox.Show("Final Bid is " + currentBid + ", Won by Player " + currentPlayer);
                ShowMatchHighestBid();
            }
        }

        public void ShowSelectedTrumpImage()
        {
            String trumpCardImagePath = "";
            if (currentTrump == 1)
            {
                trumpCard = "Club";
                trumpCardImagePath = "/Images/club.png";
            }
            else if (currentTrump == 2)
            {
                trumpCard = "Diamond";
                trumpCardImagePath = "/Images/diamond.png";
            }
            else if (currentTrump == 3)
            {
                trumpCard = "Heart";
                trumpCardImagePath = "/Images/heart.png";
            }
            else
            {
                trumpCard = "Spade";
                trumpCardImagePath = "/Images/spades.png";
            }
            Image myImage = new Image
            {

                Source = new BitmapImage(new Uri(trumpCardImagePath, UriKind.RelativeOrAbsolute)),
                Stretch = Stretch.Uniform
            };
            Round.Children.Add(myImage);
        }
        private void TrumpButton_Click(object sender, RoutedEventArgs e)
        {


            Button clickedButton = sender as Button;
            string buttonContent = Convert.ToString(clickedButton.Tag);

            currentTrump = Convert.ToInt32(buttonContent);



            TrumpSelect.Children.Remove(Trump);
            //MessageBox.Show("The trump is " + trumpCard);
            //ShowMatchHighestBid();
            ShowSelectedTrumpImage();
            if (currentPlayer == 1)
            {
                HumanCardSelect();
            }
            else if (currentPlayer == 2)
            {
                AICardSelect();
            }
            else if (currentPlayer == 3)
            {
                AICardSelect();
            }
            else if (currentPlayer == 4)
            {
                AICardSelect();
            }
        }

        private void PassButton_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Pass btn Clicked");
            pass++;
            currentPlayer++;
            if (pass >= 3 && currentBid > 0)
            {
                if (currentPlayer > 4)
                {
                    currentPlayer = 1;
                }
                Round.Children.Remove(Bid);
                //Thread.Sleep(3000);
                MessageBox.Show("Final Bid is " + currentBid + ", Won by Player " + currentPlayer);
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

        private void UnSetLegalPlays()
        {
            foreach (Card card1 in match.player1)
            {
                Button btn = card1.ParentButton;

                btn.IsEnabled = true;
            }
            if (legalCards.Count > 0)
            {
                foreach (Card card1 in legalCards)
                {
                    Button btn = card1.ParentButton;
                    btn.Margin = new Thickness(0, 0, 0, 0);
                }
            }
        }

        private void SetLegalPlays(Card card)
        {

            legalCards.Clear();
            int x = 0;
            currentRoundCard = card;
            List<Card> parent = FindParentCardList(card);
            foreach (Card card1 in match.player1)
            {
                Button btn = card1.ParentButton;
                if (card1.Suit == card.Suit)
                {
                    x++;
                    legalCards.Add(card1);
                    btn.Margin = new Thickness(0, 0, 0, 20);
                    btn.IsEnabled = true;
                }
                else if (card1.Suit == currentRoundCard.Suit)
                {
                    btn.IsEnabled = true;
                }
                else
                {
                    btn.IsEnabled = false;
                }

            }
            if (legalCards.Count == 0)
            {
                UnSetLegalPlays();
            }
        }



    }
}
