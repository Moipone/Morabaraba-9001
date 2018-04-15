using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Piece : IPiece
    {
        public Piece()
        {

        }

        public Status Status { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Symbol Symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Position => throw new NotImplementedException();

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
