using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJack.CardDeck.Interfaces
{
    public interface IResourceImageMapper<T> where T : PictureBox
    {
        List<T> MapCardImages(List<T> cards);
    }
}
