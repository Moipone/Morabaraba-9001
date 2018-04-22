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
        List<IPiece> Pieces(IBoard board, Symbol sym, ITile tile);
        List<List<string>> millsFormed { get; set; }

        void setBoard(IBoard board);
        bool place(string pos, IBoard board, IReferee referee);
        bool move(string from, string to, IBoard board, IReferee referee);
        bool fly(string from, string to, IBoard board, IReferee referee);
        bool loses { get; set; }
        int cowLives { get; set; }
        void Shoot(IPlayer player, IReferee referee, string position);


    }
}
