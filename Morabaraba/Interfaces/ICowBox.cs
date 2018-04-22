using System.Collections.Generic;

namespace Morabaraba
{
    public interface ICowBox
    {
        void takeCow(Symbol sym);
        void placeCow(Symbol sym);
        int getcowsInBox(Symbol sym);
        int getcowsOnBoard(Symbol sym);
        List<string> playerPiecesPositions(IPlayer player);
        void removeCowsFromBoard(Symbol sym);


    }
}