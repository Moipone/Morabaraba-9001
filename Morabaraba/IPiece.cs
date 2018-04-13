using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public enum Symbol { CB, CW }
    public interface IPiece
    {

        IEnumerable<int> NormalMoves(IBoard board);
        Status Status { get; set; }
        Symbol Symbol { get; set; }
        int Position { get; }
        void Move(int destination);
    }
}
