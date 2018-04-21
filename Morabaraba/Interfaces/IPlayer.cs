﻿using System;
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
        List<IPiece> Pieces(IBoard board, Symbol sym);
        List<List<string>> millsFormed { get; set; }

        bool place(string pos, IBoard board);
        bool loses { get; set; }
        int cowLives { get; set; }
        
    }
}
