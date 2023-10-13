using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class SpecialCard : ICard
    {
        public string Value { get; set; }

        public SpecialCard(string val) { 
            this.Value = val;
        }
    }
}
