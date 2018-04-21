using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba.Classes
{
    class CowBox : ICowBox
    {
        IBoard board;
  
        public CowBox(IBoard board)
        {
            this.board = board;
            

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
        public List<string> playerPiecesPositions(IPlayer player)
        {
            List<string> positions = new List<string>();
            for (int i = 0; i < board.board.Count; i++)
            {
                Tile t = board.board[i];
                if (t.cond.Symbol == player.symbol) positions.Add(t.pos);

            }
            return positions;
        }  //This method checks whether there's any pieces that's not in a mill
        public int remainingCows(IPlayer player)
        {
            return player.cowLives;
        }

        public ITile takeCow(Symbol sym)
        {
            throw new NotImplementedException();
        }
    }
}
