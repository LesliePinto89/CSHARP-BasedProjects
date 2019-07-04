using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackProject
{
    class CountCard : ICard
    {
        private readonly int cardValue;
        private readonly string cardName;

        public CountCard(int cardValue) {
            if (cardValue >= 1 && cardValue <= 10)
            {
                this.cardValue = cardValue;
                this.cardName = cardValue.ToString();
            }
        }
        public int CardValue()
        {
            return cardValue;
        }

        public string CardName()
        {
            return cardName;
        }
    }
}
