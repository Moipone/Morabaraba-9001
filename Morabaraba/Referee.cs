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

        public bool IsDraw()
        {
            throw new NotImplementedException();
            //Board b = new Board();
            //bool result = false;
            //Symbol s = new Symbol();
            //Player p1 = new Player(s);
            //Player p2 = new Player(s);
            //int full

            //foreach (Tile t in b.board)
            //{
            //    if (t.cond != null) return false;
            //}

            //if (p1.CowLives == 0 && p2.CowLives == 0) && ()
            //{

            //}
            //foreach (Tile t in b.board)
            //{
            //    if (t.cond != null) return false;
            //}
           
            //return false;
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
