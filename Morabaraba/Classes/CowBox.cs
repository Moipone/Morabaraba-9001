using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba.Classes
{
    class CowBox : ICowBox
    {
        IBoard board;
        IPlayer player1;
        IPlayer player2;
        public CowBox(IBoard board, IPlayer player1, IPlayer player2)
        {
            this.board = board;
            this.player1 = player1;
            this.player2 = player2;

        }
        public int cowsRemainingOnBoard(Symbol sym)
        {
            int cows = 0;
            for(int i =0; i < board.allPositions().Count; i++)
            {
                Tile t = board.board[i];
                if(t != null && sym == t.cond.Symbol)
                {
                    cows++;
                }
            }
            return cows;
        }

        public int remainingCows(Symbol sym)
        {
            if (sym == Symbol.BL) return 0;

            if(sym == player1.symbol)
            {
                return player1.cowLives;
            }
            else
            {
                return player2.cowLives;
            }
        }

        public ITile takeCow(Symbol sym)
        {
            throw new NotImplementedException();
        }
    }
}
