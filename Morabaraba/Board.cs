using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Morabaraba
{
    public class Board : IBoard
    {
        private string[] positions =
                        {"a1", "a4","a7",
                               "b2","b4","b6",
                               "c3", "c4", "c5",
                               "d1", "d2", "d3",
                               "d5", "d6","d7",
                               "e3","e4","e5",
                               "f2","f4", "f6",
                               "g1", "g4","g7"};
        public Board()
        {
        }

        public IEnumerable<IEnumerable<string>> mills { get; set ; }
        public IEnumerable<Tile> board { get ; set; }

        public IEnumerable<IEnumerable<string>> allPossibleMills()
        {
            List<List<string>> possibleMills = new List<List<string>>();

            List<string> one = new string[] { "a1", "a4", "a7" }.ToList();
            List<string> two = new string[] { "a1", "d1", "g1" }.ToList();
            List<string> three = new string[] { "a7", "b6", "c5" }.ToList();

            List<string> four = new string[] { "c3", "c4", "c5" }.ToList();
            List<string> five = new string[] { "b2", "d2", "f2" }.ToList();
            List<string> six = new string[] { "c3", "d3", "e3" }.ToList();

            List<string> seven = new string[] { "e4", "f4", "g4" }.ToList();
            List<string> eight = new string[] { "e5", "f6", "g7" }.ToList();
            List<string> nine = new string[] { "e3", "f2", "g1" }.ToList();

            List<string> ten = new string[] { "b2", "b4", "b6" }.ToList();
            List<string> eleven = new string[] { "a1", "b2", "c3" }.ToList();
            List<string> twelve = new string[] { "a4", "b4", "c4" }.ToList();

            List<string> thirtheen = new string[] { "a7", "d7", "g7" }.ToList();
            List<string> fourteen = new string[] { "d1", "d2", "d3" }.ToList();
            List<string> fifteen = new string[] { "d5", "d6", "d7" }.ToList();

            List<string> sixteen = new string[] { "b6", "d6", "f6" }.ToList();
            List<string> seventeen = new string[] { "f2", "f4", "f6" }.ToList();
            List<string> eighteen = new string[] { "g1", "g4", "g7" }.ToList();

            List<string> nineteen = new string[] { "e3", "e4", "e5" }.ToList();
            List<string> twenty = new string[] { "c5", "d5", "e5" }.ToList();

            possibleMills.Add(one);
            possibleMills.Add(two);
            possibleMills.Add(three);
            possibleMills.Add(four);
            possibleMills.Add(five);

            possibleMills.Add(six);
            possibleMills.Add(seven);
            possibleMills.Add(eight);
            possibleMills.Add(nine);
            possibleMills.Add(ten);

            possibleMills.Add(eleven);
            possibleMills.Add(twelve);
            possibleMills.Add(thirtheen);
            possibleMills.Add(fourteen);
            possibleMills.Add(fifteen);

            possibleMills.Add(sixteen);
            possibleMills.Add(seventeen);
            possibleMills.Add(eighteen);
            possibleMills.Add(nineteen);
            possibleMills.Add(twenty);

            return possibleMills;
        }

        public void generateBoard()
        {
            board = new List<Tile>();
            for (int i = 0; i < positions.Length; i++)
            {
                Tile t = new Tile(positions[i], new Piece());
                board.Append(t);
            }
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
