using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IBoard
    {
        List<List<string>> mills { get; }
        List<Tile> board { get; }

        bool isValid(string pos); 
        List<Tile> generateBoard();

        void updateTile(Tile tile);// Places a tile and checks does the necessary checks
        List<List<string>> allPossibleMills();

        Tile getTile(string pos);

        List<string> allPositions();

     
        List<string> getNeighbourCells(string pos);
    }
}
