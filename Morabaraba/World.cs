using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class World : IWorld
    {
        public World(IPlayer p1, IPlayer p2)
        {

        }

        public IBoard board { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPlayer player1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPlayer player2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IReferee referee { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
