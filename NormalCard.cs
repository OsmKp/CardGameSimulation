using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class NormalCard : ICard
    {
        public string Value { get; set; }
        public NormalCard(string val) {
        this.Value = val;
        }
    }
}
