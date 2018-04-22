using System.Collections.Generic;

namespace Morabaraba
{
    public interface ICowBox
    {
        void takeCow(Symbol sym);
        void placeCow(Symbol sym);
        int remainingCows(IPlayer sym);
        List<string> playerPiecesPositions(IPlayer player);
        int cowsRemainingOnBoard(Symbol sym);
    }
}