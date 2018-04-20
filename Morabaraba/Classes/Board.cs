using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morabaraba
{
    public class Board : IBoard
    {
        public List<List<string>> mills => throw new NotImplementedException();

        public List<Tile> board => throw new NotImplementedException();

        public List<string> allPositions()
        {
            throw new NotImplementedException();
        }

        public List<List<string>> allPossibleMills()
        {
            throw new NotImplementedException();
        }

        public List<Tile> generateBoard()
        {
            throw new NotImplementedException();
        }

        public List<string> getNeighbourCells(string pos)
        {
            throw new NotImplementedException();
        }

        public Tile getTile(string pos)
        {
            throw new NotImplementedException();
        }

        public bool isValid(string pos)
        {
            throw new NotImplementedException();
        }

        public void updateTile(Tile tile)
        {
            throw new NotImplementedException();
        }
    }
}
