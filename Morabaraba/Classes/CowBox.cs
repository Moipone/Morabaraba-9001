using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba.Classes
{
    class CowBox : ICowBox
    {
        IBoard board;

        private int blackcowsBox = 12;
        private int whitecowsBox = 12;
        private int blackcowsBoard = 0;
        private int whitecowsBoard = 0;

        public CowBox(IBoard board)
        {
            this.board = board;
            

        }
        //public int cowsRemainingOnBoard(Symbol sym)
        //{
        //    int cows = 0;
        //    for(int i =0; i < board.allPositions().Count; i++)
        //    {
        //        Tile t = board.board[i];
        //        if(t != null && sym == t.cond.Symbol)
        //        {
        //            cows++;
        //        }
        //    }
        //    return cows;
        //}
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
        //public int remainingCows(IPlayer player)
        //{
        //    return player.cowLives;
        //}

        public void takeCow(Symbol sym)
        {
            if (sym == Symbol.CB) { blackcowsBox = blackcowsBox-1; }
            else if (sym == Symbol.CW) { whitecowsBox = whitecowsBox-1; }
            //throw new NotImplementedException();
        }

        public void placeCow(Symbol sym)
        {
            if (sym == Symbol.CB) { blackcowsBoard = blackcowsBoard+1; }
            else if (sym == Symbol.CW) { whitecowsBoard = whitecowsBoard+1; }
            //throw new NotImplementedException();
        }

        public int getcowsInBox(Symbol sym)
        {
            //throw new NotImplementedException();
            if (sym == Symbol.CB)
            {
                return blackcowsBox;
            }
            else return whitecowsBox;
        }

        public int getcowsOnBoard(Symbol sym)
        {
            //throw new NotImplementedException();
            if (sym == Symbol.CB)
            {
                return blackcowsBoard;
            }
            else return whitecowsBoard;
        }

        public void removeCowsFromBoard(Symbol sym)
        {
            if (sym == Symbol.CB) { blackcowsBoard = blackcowsBoard + 1; }
            else if (sym == Symbol.CW) { whitecowsBoard = whitecowsBoard + 1; }
        }
    }
}
