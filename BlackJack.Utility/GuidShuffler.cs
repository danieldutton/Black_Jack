using BlackJack.Utility.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Utility
{
    public class GuidShuffler<T> : IShuffler<T>
    {
        public Queue<T> Shuffle(IEnumerable<T> itemsToShuffle)
        {
            IOrderedEnumerable<T> shuffledItems = itemsToShuffle
                .OrderBy(a => Guid.NewGuid());

            return new Queue<T>(shuffledItems);
        }
    }
}
