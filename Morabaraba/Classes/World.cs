using Morabaraba.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Morabaraba
{
    public class World : IWorld
    {
      

        public World(IPlayer p1, IPlayer p2)
        {
            this.player1 = p1;
            this.player2 = p2;
            this.board = new Board();
            referee = new Referee(board, Symbol.CW);
            legalMoves = new LegalMoves();
        }

       /* public World(IPlayer player1, IPlayer player2, IReferee referee)
        {
            this.board = new Board();
            this.player1 = player1;
            this.player2 = player2;
            this.referee = referee;
        }*/

        public IBoard board { get ; set ; }
        public IPlayer player1 { get; set ; }
        public IPlayer player2 { get ; set ; }
        public IReferee referee { get ; set ; }
        public ILegalMoves legalMoves { get; set; }
        public string mapSym(int ind)
        {
            if (ind > board.board.Count || ind < 0) return "";
            Symbol symbol = board.board[ind].cond.Symbol;
            if (symbol == Symbol.BL) return "O";
            if (symbol == Symbol.CW) return "W";
            return "B";
        }
        public void printBoard(string message)
        {
            Console.Clear();
            Tile[] cells = board.board.ToArray();
            string dis =
  $@"
      1   2  3   4   5  6   7
  A   {mapSym(0)}----------{mapSym(1)}----------{mapSym(2)}
  |   | '.       |        .'|
  B   |   {mapSym(3)}------{mapSym(4)}------{mapSym(5)}   |
  |   |   |'.    |    .'|   |
  C   |   |  {mapSym(6)}---{mapSym(7)}---{mapSym(8)}  |   |
  |   |   |  |       |  |   |
  D   {mapSym(9)}---{mapSym(10)}--{mapSym(11)}       {mapSym(12)}--{mapSym(13)}---{mapSym(14)}
  |   |   |  |       |  |   |
  E   |   |  {mapSym(15)}---{mapSym(16)}---{mapSym(17)}  |   |
  |   |   |.'    |    '.|   |
  F   |   {mapSym(18)}------{mapSym(19)}------{mapSym(20)}   |
  |   |.'        |       '. |
  G   {mapSym(21)}----------{mapSym(22)}----------{mapSym(23)} ";

            string wLives = "" + (player1.cowLives);
            string bLives = "" + player2.cowLives;
            Console.WriteLine("White player has {0} pieces to place.\nBlack player has {1} pieces to place\n", wLives, bLives);
            Console.WriteLine(dis);
            Console.WriteLine("\n" + message);
        }
    }
}

