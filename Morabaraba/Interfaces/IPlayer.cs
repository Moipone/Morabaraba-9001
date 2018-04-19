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
        List<string> LastPosPlayed { get; set; }
        List<Piece> Pieces(IBoard board);
        List<List<string>> millsFormed { get; set; }

        bool loses { get; set; }
        int cowLives { get; set; }
        ///bool loses { get; set; }
    }
}
