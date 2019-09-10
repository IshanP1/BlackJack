using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracP2
{
  /// <summary>
  /// Holds a single card, with both a suit and a value
  /// </summary>
  public class Card
  {
    //#############################################################################################
    //# Instance variables
    /// <summary>
    /// The card suit.
    /// </summary>
    private string _suit;
    /// <summary>
    /// The number of the card, 1 = Ace through to 13 = King.
    /// </summary>
    private int _number;

    //#############################################################################################
    //# Constructor
    /// <summary>
    /// Creates a single card, with both a suit and a value
    /// The first 13 values are Clubs, the next 13 are Spades, then Diamonds, then Hearts.
    /// Within each suit the cards order, from 1 = Ace to 13 = King.
    /// </summary>
    /// <param name="cardNumber">A value from 0 to 51 which determines the card suit and value.</param>
    public Card(int cardNumber)
    {
      _number = cardNumber % 13 + 1;
      int suit = cardNumber / 13;
      if (suit == 0) {
        _suit = "Clubs";
      } else if (suit == 1) {
        _suit = "Spades";
      } else if (suit == 2) {
        _suit = "Diamonds";
      } else {
        _suit = "Hearts";
      }
    }

        public Card(int cardNumber, string suit)
        {
            _number = cardNumber;
            _suit = suit;
        }

        public int Number
        {
            get {
               
                    if (_number == 13 || _number == 12 || _number == 11)
                {
                    return 10;
                }
                else if (_number == 1)
                {
                    return 11;
                }
                else return _number;
                
            }
        }

    //#############################################################################################
    //# Public Methods
    /// <summary>
    /// Returns a string to describe the card value and suit, e.g., "Ace of Hearts" or "2 of Spades".
    /// </summary>
    public override string ToString()
    {
      string cardName = _number.ToString();
            if(_number == 11)
            {
                cardName = "Jack";
            }
            else if(_number == 12)
            {
                cardName = "Queen";
            }
            else if (_number ==13)
            {
                cardName = "King";
            }
            else if (_number ==1)
            {
                cardName = "Ace";
            }
      cardName += " of " + _suit;
      return cardName;
    }

    //#############################################################################################
    //# Properties
    /// <summary>
    /// The number of points the card is worth in Blackjack.
    /// An ace is worth 11. A picture card (King, Queen, Jack) is worth 10.
    /// All other cards are worth face value.
    /// </summary>
    public int Points
    {
      get
      {
                if (_number == 13 || _number == 12 || _number == 11)
                {
                    return 10;
                }
                else if (_number == 1)
                {
                    return 11;
                }
                else return _number;
        
      }
    }

  }
}
