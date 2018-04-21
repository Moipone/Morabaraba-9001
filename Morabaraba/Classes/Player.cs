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

        public List<IPiece> Pieces(IBoard board, Symbol sym)
        {
            List<IPiece> pieces = new List<IPiece>();
             for( int i = 0; i < board.allPositions().Count; i++)
            {
               Tile t =  board.board[i];
                if (t.cond != null && t.cond.Symbol == sym)
                    pieces.Add(t.cond);
            }
            return pieces;
        }

        public bool place(string pos, IBoard board)
        {
            return false;
        }
    }
}
