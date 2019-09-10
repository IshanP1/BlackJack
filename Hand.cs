using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PracP2
{
    class Hand
    {
        int points = 0;
        public List<Card> listOfCards;

        public Hand()
        {
            listOfCards = new List<Card>();
           
        }

        public void AddToList(Card card)
        {
            listOfCards.Add(card);
        }

        public int Total
        {
           
            get
                
                {
                points = 0;
                foreach (Card c in listOfCards)
                {
                
                    points += c.Number;
                }

                return points;
                  

            }
        }
    }
}
