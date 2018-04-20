using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba.Interfaces
{
    public interface ILegalMoves
    {
        bool isValidPlace(string pos, IBoard board);
        bool isValidShift(string currPos, string posMoveTo, IBoard board);
    }
}
