using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Tile : ITile
    {
        public Tile(string pos, IPiece cond)
        {

        }

        public string position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPiece condition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
