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
            board = generateBoard();
            mills = allPossibleMills();
        }

        public List<List<string>> mills { get; set ; }
        public List<Tile> board { get ; set; }

        public List<List<string>> allPossibleMills()
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
        public Tile getTile(string pos)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (board[i].pos == pos) return board[i];
            }
            return null;
        }
        public List<Tile> generateBoard()
        {
            List<Tile> board = new List<Tile>();
            for (int i = 0; i < positions.Length; i++)
            {
                Tile t = new Tile(positions[i], new Piece(Symbol.BL,positions[i]));
                board.Add(t);
            }
            return board;
        }

        public List<string> getNeighbourCells(string pos)
        {

            switch (pos)
            {
                case "a1": return new string[] { "d1", "b2", "a4" }.ToList();
                case "a4": return new string[] { "a1", "a7", "b4" }.ToList();
                case "a7": return new string[] { "d7", "a4", "b6" }.ToList();

                case "b2": return new string[] { "a1", "b4", "c3", "d2" }.ToList();
                case "b4": return new string[] { "b2", "b6", "a4", "c4" }.ToList();
                case "b6": return new string[] { "b4", "c5", "d6", "a7" }.ToList();

                case "c3": return new string[] { "b2", "c4", "d3" }.ToList();
                case "c4": return new string[] { "c3", "b4", "c5" }.ToList();
                case "c5": return new string[] { "c4", "d5", "b6" }.ToList();

                case "d1": return new string[] { "a1", "g1", "d2" }.ToList();
                case "d2": return new string[] { "d1", "f2", "d3", "b2" }.ToList();
                case "d3": return new string[] { "d2", "e3", "c3" }.ToList();

                case "d5": return new string[] { "e5", "d6", "c5" }.ToList();
                case "d6": return new string[] { "d5", "f6", "b6", "d7" }.ToList();
                case "d7": return new string[] { "d6", "g7", "a7" }.ToList();

                case "e3": return new string[] { "d3", "f2", "e4" }.ToList();
                case "e4": return new string[] { "e3", "f4", "e5" }.ToList();
                case "e5": return new string[] { "e4", "f6", "d5" }.ToList();

                case "f2": return new string[] { "g1", "f4", "e3", "d2" }.ToList();
                case "f4": return new string[] { "f2", "g4", "f6", "e4" }.ToList();
                case "f6": return new string[] { "f4", "g7", "d6", "e5" }.ToList();

                case "g1": return new string[] { "d1", "g4", "f2" }.ToList();
                case "g4": return new string[] { "g1", "f4", "g7" }.ToList();
                case "g7": return new string[] { "g4", "f6", "d7" }.ToList();
            }
            return new List<string>();
        }
       
        public void updateBoard(Tile tile)
        {
            List<Tile> board2 = board.ToList();
            for (int i = 0; i < board.ToList().Count; i++)
            {
                if (board2[i].pos == tile.pos)
                {
                    board2.Insert(i, tile);
                    board2.Remove(board2[i + 1]);
                    break;
                }
            }
        }
    }
}
