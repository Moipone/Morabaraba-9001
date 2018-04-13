using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface ITile
    {
        string position { get; set; }
        IPiece condition { get; set; }
    }
}
