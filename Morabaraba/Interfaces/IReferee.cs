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
        Symbol currentPlayer { get; set; }
        //void Play(string pos, IPlayer player);
        bool isValidPlace(string position, IPlayer player);
        bool isValidMove(string to, string from, IPlayer player);
        bool isValidFly(string to, string from, IPlayer player);
        bool isvalidenemy(IPlayer player, string pos);

        bool canShoot(IPlayer player, string position);

        void switchPlayer();

        bool isValidDestroy(IPlayer player, string pos);
        bool isAvailablePieces(IPlayer player);
        bool isInMillPos(string pos, IPlayer player);
    }
}
