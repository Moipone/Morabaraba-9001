using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        public Referee()
        {
        }

        public bool IsDraw(int turns)
        {
            //throw new NotImplementedException();
            Board b = new Board();
            bool occupied = true;
            Symbol s = new Symbol();
            Player p1 = new Player(s);
            Player p2 = new Player(s);

            ///1.If players are both flying for 10 turns each without a mill, its a draw and the game is over 
            if (p1.CowLives == 3 && p2.CowLives == 3 && turns == 20) { return true; }

            ///2. The game ends in the placing phase, none of the players made a mill. Board is fully occupied s none of the players can move
            foreach (Tile t in b.board)
            {
                if (t.cond == null) occupied = false;
            }

            if (occupied == true)
            {
                if (p1.CowLives == 0 && p1.CowLives == 0) { return true; }
            }

            return false;

        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public IPlayer Winner()
        {
            throw new NotImplementedException();
        }
    }
}
