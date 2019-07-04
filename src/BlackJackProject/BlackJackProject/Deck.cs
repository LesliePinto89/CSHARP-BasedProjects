using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace BlackJackProject
{
     class Deck
    {
        private static List<ICard> fiftyTwo;
        private static Random cardChosen = new Random();
        private static int cardLimit;
        private static ICard pickedCard;

        public Deck() {
            PopulateDeck();
        }

        public void PopulateDeck() {
            fiftyTwo = new List<ICard>();
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(1), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(2), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(3), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(4), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(5), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(6), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(7), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(8), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(9), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new CountCard(10), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new FaceCard("Queen"), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new FaceCard("King"), 4));
            fiftyTwo.AddRange(Enumerable.Repeat(new Ace(), 4));
            cardLimit = fiftyTwo.Count;
            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            Random rng = new Random();
            int n = fiftyTwo.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                ICard value = fiftyTwo[k];
                fiftyTwo[k] = fiftyTwo[n];
                fiftyTwo[n] = value;
            }
        }

        public static ICard GetCard() {
            int outOfDeck = cardChosen.Next(1, cardLimit);
            pickedCard = fiftyTwo[outOfDeck];
            RemoveCard(pickedCard);
            --cardLimit;
            return pickedCard;
        }

        public static void RemoveCard(ICard removeCard) {
            fiftyTwo.Remove(removeCard);
        }
    }
}
