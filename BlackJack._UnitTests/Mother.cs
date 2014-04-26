using BlackJack.CardDeck;
using System.Collections.Generic;

namespace BlackJack.UnitTests
{
    public static class Mother
    {
        public static IEnumerable<CardNumber> ExpectedSuitOrder()
        {
            IEnumerable<CardNumber> expected = new List<CardNumber>
            {
                CardNumber.Ace,
                CardNumber.Two,
                CardNumber.Three,
                CardNumber.Four,
                CardNumber.Five,
                CardNumber.Six,
                CardNumber.Seven,
                CardNumber.Eight,
                CardNumber.Nine,
                CardNumber.Ten,
                CardNumber.Jack,
                CardNumber.Queen,
                CardNumber.King
            };

            return expected;
        } 
    }
}
