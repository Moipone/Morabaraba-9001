using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface ILegalMoves
    {
        bool isValidPlace(string pos, IBoard board);
        bool isValidMove(string currPos, string posMoveTo, IBoard board);
        bool isValidFly(string currPos, string posMoveTo, IBoard board);
        bool isValidPos(string pos, IBoard board);
        bool isOwnTile(string pos, IPlayer player, ITile tile);
    }
}
