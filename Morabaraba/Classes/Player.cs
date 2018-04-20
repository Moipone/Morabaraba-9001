using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        public Symbol symbol { get ; set; }
        public Phase Phase { get ; set ; }
        public List<string> LastPosPlayed { get ; set ; }
        public List<List<string>> millsFormed { get; set; }
        public bool loses { get; set ; }
        public int cowLives { get ; set ; }

        public List<Piece> Pieces(IBoard board)
        {
            throw new NotImplementedException();
        }

        public bool place(string pos, IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
