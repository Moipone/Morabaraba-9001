using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public interface IReferee
    {
        IPlayer Winner();
        bool IsDraw(int turns);
        void Play(string pos, Player player);
        bool isValidPlace(string position);
        bool isValidMove(string to, string from);
        bool isValidFly(string to, string from);
        bool isvalidenemy(Player player, string pos);


    }
}
