using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJack.CardDeck.Interfaces
{
    public interface ICardImageMapper<T> where T : PictureBox
    {
        IEnumerable<T> MapCardImages(IEnumerable<T> cards);
    }
}
