using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Tile : ITile
    {
        public Tile(string pos, IPiece cond)
        {
            this.pos = pos;
            this.cond = cond;
        }

        public string Pos()
        {

        }
        public IPiece cond { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
