using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Board : IBoard
    {
        public IEnumerable<IEnumerable<string>> mills { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<Tile> board { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IEnumerable<string>> allPossibleMills()
        {
            throw new NotImplementedException();
        }

        public void generateBoard()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> getNeighbourCells(string pos)
        {
            throw new NotImplementedException();
        }

        public void updateBoard(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}
