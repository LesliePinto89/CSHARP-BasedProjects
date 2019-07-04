using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackProject
{
    class Dealer : IHuman
    {
        private List<ICard> dealerCards;
        private int sum;

        public Dealer()
        {
            dealerCards = new List<ICard>();
            StartGame();
        }

        public int getCurrentScore()
        {
            return sum;
        }

        public void StartGame()
        {
            ICard aCard = Deck.GetCard();
            Console.WriteLine($"Dealer's card: {aCard.CardName()}");
            AddCards(aCard);
            CalculateScore();
        }

        public void AddCards(ICard card)
        {
            dealerCards.Add(card);
        }

        public List<ICard> GetTotalCards()
        {
            return dealerCards;
        }

        public int Hit()
        {
             return AddCardsTotal(sum);
        }

        public int AddCardsTotal(int value)
        {
            ICard aCard = Deck.GetCard();
            Console.WriteLine($"Dealers card: {aCard.CardName()}");
            AddCards(aCard);
            value += aCard.CardValue();
            return value;
        }

        public int CalculateScore()
        {
            sum = 0;
            foreach (ICard card in dealerCards)
            {
                sum += card.CardValue();
            }
            return sum;
        }
    }
}
