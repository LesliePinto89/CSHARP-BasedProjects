using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackProject
{
    class Player : IHuman
    {
        private List<ICard> playerCards;
        private static bool hitMe = false;
        private int sum;

        public static Boolean PlayerHitted() {
            return hitMe;
        }

        public int getCurrentScore() {
            return sum;
        }

        public Player() {
            playerCards = new List<ICard>();
            StartGame();
        }

        public void StartGame()
        {
            ICard aCard = Deck.GetCard();
            Console.WriteLine($"Your card: {aCard.CardName()}");
            AddCards(aCard);
            CalculateScore();
        }

        public void AddCards(ICard card)
        {
            playerCards.Add(card);
        }

        public List<ICard> GetTotalCards()
        {
            return playerCards;
        }

        public int CalculateScore() {
            sum = 0;
            foreach (ICard card in playerCards)
            {
                sum += card.CardValue();
            }
            return sum;
        }

        public int Hit()
        {
            sum =  AddCardsTotal(sum);
            return sum;
        }

        public int AddCardsTotal(int value) {
            ICard aCard = Deck.GetCard();
            Console.WriteLine($"Your card: {aCard.CardName()}");
            AddCards(aCard);
            value += aCard.CardValue();
            hitMe = true;
            return value;     
        }

        public int MoreCards(int number)
        {   
            int increasingSum = 0;
            for (int i = 0; i < number; i++)
            {
                increasingSum = AddCardsTotal(increasingSum);
            }
            return increasingSum + sum;
        }
    }
}
