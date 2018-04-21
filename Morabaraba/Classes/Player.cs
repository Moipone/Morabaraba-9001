using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
      

        public Player(Symbol sym)
        {
            this.symbol = sym;
        }

        public Symbol symbol { get ; set; }
        public Phase Phase { get ; set ; }
        public List<string> LastPosPlayed { get ; set ; }
        public List<List<string>> millsFormed { get; set; }
        //public List<IPiece> Pieces { get; }
        public bool loses { get; set ; }
        public int cowLives { get ;  set ; }

        public List<IPiece> Pieces(IBoard board, Symbol sym, ITile tile)
        {
            List<IPiece> pieces = new List<IPiece>();
             for( int i = 0; i < board.allPositions().Count; i++)
            {
               tile =  board.board[i];
                if (tile.cond != null && tile.cond.Symbol == sym)
                    pieces.Add(tile.cond);
            }
            return pieces;
        }

        public bool place(string pos, IBoard board, IReferee referee)
        {
            return referee.isValidPlace(pos);

        }

        public bool move(string from, string to, IBoard board, IReferee referee, IPlayer player)
        {
            return referee.isValidMove(from, to, player);

        }

        public bool fly(string from, string to, IBoard board, IReferee referee, IPlayer player)
        {
            return referee.isValidFly( from, to, player);

        }

        public bool move(string from, string to, IBoard board, IReferee referee)
        {
            throw new NotImplementedException();
        }

        public bool fly(string from, string to, IBoard board, IReferee referee)
        {
            throw new NotImplementedException();
        }
    }
}
