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
<<<<<<< HEAD
        bool canShoot(IPlayer player, IBoard board, string pos);
=======
>>>>>>> c8516901157ffab8d4cbced90b212c157ad9941f

      
        void switchPlayer();

        bool canShoot(IPlayer player, string pos);
        bool isValidDestroy(IPlayer player, string pos);
        bool isAvailablePieces(IPlayer player);
        bool isInMillPos(string pos, IPlayer player);
    }
}
