using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class World : IWorld
    {
        public World(IPlayer p1, IPlayer p2)
        {
            this.player1 = p1;
            this.player2 = p2;
            board = new Board();
        }

        public IBoard board { get ; set ; }
        public IPlayer player1 { get ; set; }
        public IPlayer player2 { get; set; }
        public IReferee referee { get ; set ; }

        public string mapSym(int ind)
        {
            if (ind > board.board.Count || ind < 0) return "";
            Symbol symbol = board.board[0].cond.Symbol;
            if (symbol == Symbol.BL) return "O";
            if (symbol == Symbol.CW) return "W";
            return "B";
        }
        // Fix the broken mill
        // Fix the a
        // This method removes a piece, it was in a mill and was either shot or eliminated
        public void RemoveBrokenMill(string pos, Player player)
        {
            Tile t = board.getTile(pos);
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos) && t.cond.Symbol == Symbol.BL)
                {
                    player.millsFormed.Remove(player.millsFormed[i]);

                }
            }

        }
        ///<summary> 
        ///Given a list of mills and a position, check if that position exists in that mill.
        /// </summary>
        //A Method to check if a piece is currently in a mill
        public bool isInMillPos(string pos, Player player)
        {
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos)) return true;
            }
            return false;
        }
        public List<string> getPlayerPieces(Player player)
        {
            List<string> positions = new List<string>();
            for (int i = 0; i < board.board.Count; i++)
            {
                Tile t = board.board[i];
                if (t.cond.Symbol == player.symbol) positions.Add(t.pos);

            }
            return positions;
        }  //This method checks whether there's any pieces that's not in a mill

        //This method checks whether there's any pieces that's not in a mill
        public bool isNotAvailablePieces(Player player)
        {
            List<string> list = getPlayerPieces(player);
            bool isNotAvailable = false;
            foreach (string str in list)
            {
                isNotAvailable = isInMillPos(str, player);
                if (!isNotAvailable) return false;
            }
            return true;
        }
        public void PlayAllPhases()
        {
            printBoard(" Where would you like to play?");
            placingPhase();
            movingPhase();
            flyingPhase();
        }

        private void flyingPhase()
        {
            throw new NotImplementedException();
        }

        private void movingPhase()
        {
            throw new NotImplementedException();
        }

        private void placingPhase()
        {
            throw new NotImplementedException();
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

            Console.WriteLine(dis);
            Console.WriteLine("\n"+message);
        }
    }
}

