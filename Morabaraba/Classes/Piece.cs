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


        public Symbol Symbol { get; set; }

        public string Position { get; set; }
    }
}
