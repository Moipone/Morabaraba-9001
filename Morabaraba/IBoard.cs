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

        void updateBoard(Tile tile);
        List<List<string>> allPossibleMills();

        List<string> getNeighbourCells(string pos);
    }
}
