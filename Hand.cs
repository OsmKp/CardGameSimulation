using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Hand
    {
        public Queue<ICard> hand  = new Queue<ICard>();

        public Hand(string cardString)
        {
            List<string> cardsList = cardString.Split(",").ToList();
            foreach (string card in cardsList)
            {

                if(int.TryParse(card, out int cardNumber))
                {
                    NormalCard cardCreated = new NormalCard(card);
                    hand.Enqueue(cardCreated);
                }
                else
                {
                    SpecialCard cardCreated = new SpecialCard(card);
                    hand.Enqueue(cardCreated);
                }
            }
        }

        public bool IsHandEmpty()
        {
           
            if (hand.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int GetHandSize()
        {
            return hand.Count;
        }

        public string OutputHand()
        {
            string r = "";
            foreach (var card in hand) { r += card.Value.ToString() + " "; }
            return r;
        }
        public void AddCards(Stack<ICard> cards)
        {
            Stack<ICard> newStack = new Stack<ICard>();
            while (cards.Count != 0)
            {
                newStack.Push(cards.Pop());
            }
            while (newStack.Count != 0)
            {
                hand.Enqueue(newStack.Pop());
            }
            
        }

        public ICard PlayCard()
        {
            ICard card =  hand.Dequeue();
            return card;
        }
    }
}
