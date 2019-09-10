using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace PracP2
{
  public partial class BlackjackForm : Form
  {
        Deck deck = new Deck();
        Hand humanHand = new Hand( );
        Hand computerHand = new Hand();
    //#############################################################################################
    //# Instance variables
    /// <summary>
    /// Random number generator, used to generate cards.
    /// </summary>
    private Random randomGenerator = new Random();

   // private Card playerCard1;
        Card plaYerCard1 ;
        //private Card playerCard2;
        Card plaYerCard2;

       // private Card dealerCard1;
        Card dealeRCard1 ;
       // private Card dealerCard2;
        Card dealeRCard2;

        int pTotal = 0;
        int dTotal = 0;
      //  List<Card> playersHand = new List<Card>();
        
       List<Card> playerHandList = new List<Card>();
      //  List<Card> dealersHand = new List<Card>();
       List<Card> dealerHandList = new List<Card>();
    //#############################################################################################
    //# Constants
    /// <summary>
    /// Total number of cards
    /// </summary>
    private const int NUM_CARDS = 52;
    /// <summary>
    /// Maximum points allowed before going bust
    /// </summary>
    private const int BLACKJACK = 21;
    /// <summary>
    /// Initial amount of money available to the player (to implement betting).
    /// </summary>
    private const int START_MONEY = 100;
       

    //#############################################################################################
    //# Constructor
    public BlackjackForm()
    {
      InitializeComponent();
      // Prevent the user from resising the form
      MinimumSize = MaximumSize = Size;
            textBoxMoneyLeft_.Text = 100.ToString();
            
        }

      

        //#############################################################################################
        //# Event Handlers
        private void buttonDealFirstCard_Click(object sender, EventArgs e)
        {

            // Generate 4 new random cards
            // playerCard1 = new Card(randomGenerator.Next(NUM_CARDS));
            //  playerCard2 = new Card(randomGenerator.Next(NUM_CARDS));
            plaYerCard1 = deck.DealCard();
            plaYerCard2 = deck.DealCard();  
           // dealerCard1 = new Card(randomGenerator.Next(NUM_CARDS));
            dealeRCard1 = deck.DealCard();
            dealeRCard2 = deck.DealCard();
            //  dealerCard2 = new Card(randomGenerator.Next(NUM_CARDS));


            playerHandList.Add(plaYerCard1);
            playerHandList.Add(plaYerCard2);

            //HAND OBJECT
            humanHand.AddToList(plaYerCard1);
            humanHand.AddToList(plaYerCard2);


            // playersHand.Add(playerCard1);
            // playersHand.Add(playerCard2);
          
            //adding card to hand class list HAND OBJECT
           
           // dealersHand.Add(dealerCard1);
            dealerHandList.Add(dealeRCard1);
          //  dealersHand.Add(dealerCard2);
            dealerHandList.Add(dealeRCard2);

            computerHand.AddToList(dealeRCard1);
            computerHand.AddToList(dealeRCard2);
            // Display the first card to player and dealer
            //textBoxPlayerCard1_.Text = playerCard1.ToString();
            //textBoxDealerCard1_.Text = dealerCard1.ToString();
            //foreach (Card c in playersHand)
            //{
            //    if (playersHand.IndexOf(c) % 2 == 0)
            //    {
                    listBox1.Items.Add("First hand is " + plaYerCard1.ToString());

            //    }
            //    else if (playersHand.IndexOf(c) % 2 != 0)
            //    {
            //        listBox1.Items.Add("Second hand is " + c.ToString());
            //    }
            //}

            pTotal = humanHand.Total;
          //  pTotal = playerCard1.Points + playerCard2.Points;
            //listBox1.Items.Add("Total points: " + pTotal);
            //playersHand.Clear();

            //foreach (Card c in dealersHand)
            //{
            //    if (dealersHand.IndexOf(c) % 2 == 0)
            //    {
                    listBox2.Items.Add("First hand is " + dealeRCard1.ToString());
            //}
            //else if (dealersHand.IndexOf(c) % 2 != 0)
            //{
            //    listBox2.Items.Add("Second hand is " + c.ToString());
            //}

            //}
            dTotal = computerHand.Total;
           // dTotal = dealerCard1.Points + dealerCard2.Points; 
            //if (dTotal < 15)
            //{
            //    Card extraDealerCard = new Card(randomGenerator.Next(NUM_CARDS));
            //    dTotal += extraDealerCard.Points;
            //    dealersHand.Add(extraDealerCard);
            //    listBox2.Items.Add("EXTRA CARD IS " + extraDealerCard.ToString());
            //}
            //listBox2.Items.Add("Total points: " + dTotal);
            //dealersHand.Clear();
            // Clear the second card and totals
            //      textBoxPlayerCard2_.Text = "";
            //textBoxPlayerTotal_.Text = "";
            //textBoxDealerCard2_.Text = "";
            //textBoxDealerTotal_.Text = "";
          

            }

    private void buttonDealSecondCard_Click(object sender, EventArgs e)
    {
            try
            {
                listBox1.Items.Add(plaYerCard2.ToString());
                listBox2.Items.Add(dealeRCard2.ToString());
                if (dTotal < 15)
                {
                    Card extraDealerCard = new Card(randomGenerator.Next(NUM_CARDS));
                    dTotal += extraDealerCard.Points;
                    computerHand.listOfCards.Add(extraDealerCard);
                    listBox2.Items.Add("EXTRA CARD IS " + extraDealerCard.ToString());
                }
                listBox2.Items.Add("Total points: " + dTotal);
                computerHand.listOfCards.Clear();
                listBox1.Items.Add("Total points: " + pTotal);



                //      //display second two cards and total
                //      textBoxPlayerCard2_.Text = playerCard2.ToString();
                //textBoxDealerCard2_.Text = dealerCard2.ToString();



                //textBoxPlayerTotal_.Text = playerTotal.ToString();
                //textBoxDealerTotal_.Text = dealerTotal.ToString();

                if (pTotal > 21 || pTotal < dTotal)
                {
                    textBoxMoneyLeft_.Text = (int.Parse(textBoxMoneyLeft_.Text) - int.Parse(textBoxBet_.Text)).ToString();
                    textBoxBet_.Text = "";
                }
                else if (pTotal > dTotal || dTotal > 21)
                {
                    textBoxMoneyLeft_.Text = (int.Parse(textBoxMoneyLeft_.Text) + int.Parse(textBoxBet_.Text)).ToString();
                    textBoxBet_.Text = "";
                }


                if (pTotal > BLACKJACK)
                { // Player bust: loses even if dealer bust.
                    LoseGame();
                }
                else if (dTotal > BLACKJACK || pTotal > dTotal)
                {
                    MessageBox.Show("You win!");
                }
                else if (pTotal == dTotal)
                {
                    MessageBox.Show("You tie!");
                }
                else
                { // Player total less than dealer, and dealer did not bust.
                    LoseGame();

                }
                if (int.Parse(textBoxMoneyLeft_.Text) < 0)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("ensure youve added a valid bet");
            }
    }

    private void buttonQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    //#############################################################################################
    //# Private Methods
    private void LoseGame()
    {
      MessageBox.Show("You lose!");
    }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                int moneyAvailable = int.Parse(textBoxMoneyLeft_.Text);
                int betAmount = int.Parse(textBoxBet_.Text);

                if (betAmount > moneyAvailable)
                {
                    MessageBox.Show("enter valid bet amount");
                }
    
            }
           catch
            {
                MessageBox.Show("enter valid bet amount");
            }
        }

        private void labelPlayerCard1__Click(object sender, EventArgs e)
        {

        }

        private void buttonExtra_Click(object sender, EventArgs e)
        {
            Card playerExtraCard = new Card(randomGenerator.Next(NUM_CARDS));
            pTotal += playerExtraCard.Points;
            listBox1.Items.Add("EXTRA card is " +playerExtraCard.ToString());
        
        
        
        }

        private void BlackjackForm_Load(object sender, EventArgs e)
        {

        }
    }
}
