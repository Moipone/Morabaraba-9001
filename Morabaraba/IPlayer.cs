using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public enum Status { captured, active }
    public interface IPlayer
    {
        string symbol { get; set; }
        string Phase { get; set; }
        IEnumerable<string> getLastPosPlayer { get; set; }
        IEnumerable<Piece> getPieces(IBoard board);
        IEnumerable<string> millsFormed { get; set; }
    }
}
