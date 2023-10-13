using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class MiddleStack
    {
        public Stack<ICard> Stack = new Stack<ICard>();
        
        public void AddToMiddle(ICard c)
        {
            Stack.Push(c);
        }

        public Stack<ICard> TakeMiddleStack()
        {
            Stack<ICard> copy = new Stack<ICard>(new Stack<ICard>(Stack));
            Stack.Clear();
            return copy;
        }

        public string OutputMiddleStack()
        {
            string r = "";
            foreach(ICard c in Stack) { r += c.Value.ToString() + " "; }
            return r;
        }
    }
}
