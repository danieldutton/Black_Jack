using System.Collections.Generic;

namespace BlackJack.Utility.Interfaces
{
    public interface IShuffler<T>
    {
        Queue<T> Shuffle(IEnumerable<T> itemsToShuffle);
    }
}
