using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Piece : IPiece
    {
        public Piece(Symbol symbol, string pos)
        {
            this.Symbol = symbol;
            this.Position = pos;
        }

        public Status Status { get ; set ; }
        public Symbol Symbol { get ; set ; }

        public string Position { get; set; }

        public void Move(int destination)
        {
            throw new NotImplementedException();
        }
        
        public IEnumerable<int> NormalMoves(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
