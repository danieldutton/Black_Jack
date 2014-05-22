using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJack.CardDeck.Interfaces
{
    public interface ICardImageMapper<T> where T : Control
    {
        IEnumerable<T> MapCardImages(IEnumerable<T> plainCards);
    }
}
