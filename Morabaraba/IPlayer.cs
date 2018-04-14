using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public enum Status { captured, active }
    public enum Phase { placing, moving, flying}
    public interface IPlayer
    {
        Symbol symbol { get; set; }
        Phase Phase { get; set; }
        IEnumerable<string> LastPosPlayer { get; set; }
        IEnumerable<Piece> Pieces(IBoard board);
        IEnumerable<IEnumerable<string>> millsFormed { get; set; }
    }
}
