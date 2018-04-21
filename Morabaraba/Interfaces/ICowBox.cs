using System.Collections.Generic;

namespace Morabaraba
{
    public interface ICowBox
    {
        ITile takeCow(Symbol sym);
        int remainingCows(IPlayer sym);
        List<string> playerPiecesPositions(IPlayer player);
        int cowsRemainingOnBoard(Symbol sym);
    }
}