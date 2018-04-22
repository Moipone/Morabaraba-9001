using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface ILegalMoves
    {
        bool isValidPlace(string pos, IPlayer player);
        bool isValidMove(string currPos, string posMoveTo, IPlayer player);
        bool isValidFly(string currPos, string posMoveTo, IPlayer player);
        bool isValidPos(string pos);
        bool isInMillPos(string pos, IPlayer player);
        bool isOwnTile(string pos, IPlayer player);
        bool ismill(IBoard board, IPlayer player);
    }
}
