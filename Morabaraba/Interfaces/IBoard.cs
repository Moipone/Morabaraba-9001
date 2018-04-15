using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IBoard
    {
        List<List<string>> mills { get; set; }
        List<Tile> board { get; set; }

        List<Tile> generateBoard();

        void updateTile(Tile tile);
        List<List<string>> allPossibleMills();

        Tile getTile(string pos);

        List<string> allPositions();

     
        List<string> getNeighbourCells(string pos);
    }
}
