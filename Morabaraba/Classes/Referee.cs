using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        public bool IsDraw(IBoard board, ICowBox cow)
        {
            throw new NotImplementedException();
        }

        public bool isvalidenemy(Player player, string pos)
        {
            throw new NotImplementedException();
        }

        public bool isValidFly(string to, string from)
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
            throw new NotImplementedException();
        }

        public IPlayer Winner()
        {
            throw new NotImplementedException();
        }
    }
}
