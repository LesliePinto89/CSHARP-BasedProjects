using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackProject
{
    class Ace : ICard
    {
        private readonly int aceValue = 1;
        private readonly string aceName = "Ace";

        public Ace() {
        }
        public int CardValue() {
            return aceValue;
        }
        public string CardName()
        {
            return aceName;
        }

    }
}
