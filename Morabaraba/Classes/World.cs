using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Morabaraba
{
    public class World : IWorld
    {
        private Player p1;
        private Player p2;

        public World(Player p1, Player p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public World(IBoard board, IPlayer player1, IPlayer player2, IReferee referee)
        {
            this.board = board;
            this.player1 = player1;
            this.player2 = player2;
            this.referee = referee;
        }

        public IBoard board { get ; set ; }
        public IPlayer player1 { get; set ; }
        public IPlayer player2 { get ; set ; }
        public IReferee referee { get ; set ; }
    }
}

