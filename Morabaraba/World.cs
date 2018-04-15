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
            Tile t = board.
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos) && t.cond == "blank")
                {
                    player.millsFormed.Remove(player.millsFormed[i]);

                }
            }

        }
    }
}
