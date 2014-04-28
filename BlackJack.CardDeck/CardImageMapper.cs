﻿using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using System.Collections.Generic;
using System.Drawing;

namespace BlackJack.CardDeck
{
    public class CardImageMapper : ICardImageMapper<PlayingCard>
    {
        public IEnumerable<PlayingCard> MapCardImages(IEnumerable<PlayingCard> cards)
        {
            foreach (var playingCard in cards)
            {
                object o = Properties.Resources
                    .ResourceManager
                    .GetObject(playingCard.GetAssociatedImageName());

                if (o != null)
                    playingCard.Image = o as Image;
            }

            return cards;
        }
    }
}
