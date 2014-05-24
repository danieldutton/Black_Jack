using BlackJack.Table.Interfaces;

namespace BlackJack.Players.Interfaces
{
    public interface IAutomatedCardPlayer : ICardPlayer
    {
        void FinishPlay(ICardShoe cardShoe, IBlackJackScorer cardScorer);
    }
}
