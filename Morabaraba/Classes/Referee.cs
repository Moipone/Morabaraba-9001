using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        World world;


        public Referee(World world)
        {
            this.world = world;
        }

        public bool IsDraw(int turns)
        {
            //throw new NotImplementedException();
            //Board b = new Board();
            bool occupied = true;
            Symbol s = new Symbol();
            Player p1 = new Player(s);
            Player p2 = new Player(s);

            ///1.If players are both flying for 10 turns each without a mill, its a draw and the game is over 
            if (p1.cowLives == 3 && p2.cowLives == 3 && turns == 20) { return true; }

            ///2. The game ends in the placing phase, none of the players made a mill. Board is fully occupied s none of the players can move
            foreach (Tile t in world.board.board)
            {
                if (t.cond == null) occupied = false;
            }

            if (occupied == true)
            {
                if (p1.cowLives == 0 && p1.cowLives == 0) { return true; }
            }

            return false;
        }

        public bool isvalidenemy(Player player, string pos)
        {
            throw new NotImplementedException();
        }

        public bool isValidFly(string to, string from) //new
        {
            throw new NotImplementedException();
        }

        public bool isValidMove(string to, string from)
        {
            throw new NotImplementedException();
        }

        public bool isValidPlace(string position)
        {
            throw new NotImplementedException();
        }

        public void Play(string pos, Player player)
        {

            Piece piece = new Piece(player.symbol, pos);
            Tile t = new Tile(pos, piece);


            if (player.cowLives > 0)
            {
                world.board.updateTile(t);

            }

        }
        public IPlayer Winner()
        {
            //throw new NotImplementedException();
            Board b = new Board();
            Symbol s = new Symbol();
            Player p1 = new Player(s);
            Player p2 = new Player(s);

            if (p1.cowLives == 2 && p2.cowLives > 2)
            {
                return p2;
            }
            else return p1;
        }
    }
}
