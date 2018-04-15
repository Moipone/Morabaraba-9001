using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        public int CowLives = 12;

        public Player(Symbol symbol)
        {
            this.symbol = symbol;
            millsFormed = new List<List<string>>();
            LastPosPlayer = new List<string>();
            Phase = Phase.placing;
        }
        public Symbol symbol { get; set; }
        public Phase Phase { get; set; }
        public List<string> LastPosPlayer { get ; set ; }
        public List<List<string>> millsFormed { get; set; }
      

        public List<Piece> Pieces(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
