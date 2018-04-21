using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IReferee
    {
        bool mill { get; set; }
        IPlayer Winner(IPlayer p1, IPlayer p2);
        bool IsDraw(IBoard board);
        void Play(string pos, IPlayer player);
        bool isValidPlace(string position);
        bool isValidMove(string to, string from, IPlayer player);
        bool isValidFly(string to, string from, IPlayer player);
        bool isvalidenemy(IPlayer player, string pos);
        bool canShoot(IPlayer player);

    }
}
