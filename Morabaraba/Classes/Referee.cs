using Morabaraba.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        IBoard board;


        public Symbol currentPlayer { get; set; }


        public ICowBox cowBox { get; set; }
    
        ILegalMoves legalMoves;
        public bool mill { get; set; }

        public Referee(IBoard board, Symbol player)
        {
            this.board = board;
            this.currentPlayer = player;
            mill = false;
            cowBox = new CowBox(board);
            legalMoves = new LegalMoves(board, cowBox);
        }

        public bool IsDraw(IBoard board)
        {
            bool flag = true;
            foreach (Tile t in board.board)
            {
                if (t.cond.Symbol == Symbol.BL) return !flag;
            }
            return flag;
        }
        public void switchPlayer()
        {
            if (currentPlayer == Symbol.CW) currentPlayer = Symbol.CB;
            else currentPlayer = Symbol.CW;
        }
        // Fix the broken mill
        // Fix the a
        // This method removes a piece, it was in a mill and was either shot or eliminated
        public void RemoveBrokenMill(string pos, Player player)
        {
            Tile t = board.getTile(pos);
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos) && t.cond.Symbol == Symbol.BL)
                {
                    player.millsFormed.Remove(player.millsFormed[i]);

                }
            }

        }
        

        public bool isvalidenemy(IPlayer player, string pos, IBoard board)
        {
            return legalMoves.isvalidenemy(player,pos);
        }
        private bool isInMillPos(string pos, IPlayer player)
        {
             return  legalMoves.isInMillPos(pos, player);
        }
        public bool isValidFly(string to, string from, IPlayer player)
        {
            return legalMoves.isValidFly(from, to, player);
        }

        public bool isValidMove(string to, string from, IPlayer player)
        {
            return legalMoves.isValidMove(from, to, player);
        }
        public bool isValidPlace(string position, IPlayer player)
        {

            return legalMoves.isValidPlace(position, player); 

        }

        public IPlayer Winner(IPlayer p1, IPlayer p2)
        {
            int bP = cowBox.playerPiecesPositions(p1).Count;
            int wP = cowBox.playerPiecesPositions(p2).Count;

            if (bP < 3) return p1;
            if (wP < 3) return p2;

            return null;
        }

        //public void Play(string pos, IPlayer player)
        //{
        //    throw new NotImplementedException();
        //}

        public bool isValidPlace(string position)
        {
            throw new NotImplementedException();
        }

        public bool canShoot(IPlayer player, IBoard board)
        {
            return legalMoves.ismill(board, player);
        }

        public bool isvalidenemy(IPlayer player, string pos)
        {
            throw new NotImplementedException();
        }
    }
}
