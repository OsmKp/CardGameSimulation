using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Player
    {
        public Hand hand;
        public string name;

        public Player(Hand hand, string name)
        {
            this.hand = hand;
            this.name = name;
        }
        public ICard? PlayCard()
        {
            ICard card;
            if (this.HasPlayerLost() == true) { return null; }
            card = hand.PlayCard();
            return card;

        }
        public bool HasPlayerLost()
        {
            if (hand.IsHandEmpty() == true) { return true; }
            else { return false; }
        }
        public string OutputHand()
        {
            return hand.OutputHand();
        }
        public int GetHandSize()
        {
            return hand.GetHandSize();
        }

        public void AddCards(Stack<ICard> cards)
        {
            hand.AddCards(cards);
        }
    }
}
