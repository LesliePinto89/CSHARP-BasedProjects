using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackProject
{
    class FaceCard : ICard
    {
        private readonly int faceValue = 10;
        private readonly string faceName;

        public FaceCard(string name) {
            this.faceName = name;
        }
        public int CardValue() {
            return faceValue;
        }
        public string CardName()
        {
            return faceName;
        }
    }
}
