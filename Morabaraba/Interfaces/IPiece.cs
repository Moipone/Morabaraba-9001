using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public enum Symbol { CB, CW,BL }
    public interface IPiece
    {
        Status Status { get; set; }
        Symbol Symbol { get; set; }
        string Position { get; set; }
       
    }
}
