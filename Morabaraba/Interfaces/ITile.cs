using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface ITile
    {
        string pos { get; set; }
        IPiece cond { get; set; }
    }
}
