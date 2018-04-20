using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Tile : ITile
    {
        public string pos { get ; set; }
        public IPiece cond { get ; set ; }
    }
}
