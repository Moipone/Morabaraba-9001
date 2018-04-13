using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {
        public string symbol { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Phase { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<string> getLastPosPlayer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IEnumerable<string> millsFormed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
