using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracP2
{
    class Deck
    {
        public List<Card> deckOfCards;
         List<Card> usedCards;
        Random rand = new Random();
     
        public Deck()
        {
            
            deckOfCards = new List<Card>();
       
            List<string> cards = new List<string> { "Spades", "Hearts", "Clubs", "Diamonds" };
            

            for (int j = 0; j <= 3; j++)
            {
                // suit = cards[j];
                for (int i = 1; i < 14; i++)
                {
                    Card c = new Card(i, cards[j]);
                    //rand.Next(52);
                    deckOfCards.Add(c);
                }
            }
         
           



            }

        public Card DealCard()
        {
            usedCards = new List<Card>();
            //rand.Next(52);
            int index = rand.Next(52);
            return deckOfCards[index];


            usedCards.Add(deckOfCards[index]);
            deckOfCards.RemoveAt(index);

        }
        }
    }

