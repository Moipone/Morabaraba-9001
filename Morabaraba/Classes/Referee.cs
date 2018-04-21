using Morabaraba.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        IBoard board;
      
        ICowBox cowBox;
        public Referee (IBoard board)
        {
            this.board = board;
         
            cowBox = new CowBox(board);
        }
        public bool IsDraw(IBoard board)
        {
            return false;
        }

        public bool isvalidenemy(IPlayer player, string pos)
        {
            throw new NotImplementedException();
        }
        private bool isInMillPos(string pos, IPlayer player)
        {
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos)) return true;
            }
            return false;
        }

        public bool isValidFly(string to, string from, IPlayer player, ILegalMoves move, IBoard board)
        {
            return move.isValidFly(from, to, board);
            
        }

        public bool isValidMove(string to, string from, ILegalMoves move, IBoard board)
        {
            return move.isValidMove(from, to, board);
        }
        public bool isValidPlace(string position, ILegalMoves move, IBoard board)
        {
            return move.isValidPlace(position, board);
        }

        public void playPlace(string pos, IPlayer player)
        {
            throw new NotImplementedException();
        }
        public void playMove(string to, string from, ILegalMoves move, IBoard board,IPlayer player)
        {
            if (isValidMove(to, from,move, board))
            {
                Tile tileTo = new Tile(to, new Piece(player.symbol, to));
                Tile tileFrom = new Tile(from, new Piece(Symbol.BL, from));

                board.updateTile(tileTo);
                board.updateTile(tileFrom);
            }
            else Console.WriteLine("Invalid move, please make a valid move");
        }
        public void playFly(string to, string from, IPlayer player)
        {
            if (isValidFly(to, from, player))
            {
                Tile tileTo = new Tile(to, new Piece(player.symbol, to));
                Tile tileFrom = new Tile(from, new Piece(Symbol.BL, from));

                board.updateTile(tileTo);
                board.updateTile(tileFrom);
            }
            else Console.WriteLine("Invalid move, please make a valid move");
        }
        public IPlayer Winner(IPlayer p1, IPlayer p2)
        {
            int bP = cowBox.playerPiecesPositions(p1).Count;
            int wP = cowBox.playerPiecesPositions(p2).Count;

            if (bP < 3) return p1;
            if (wP < 3) return p2;

            return null;
        }

        public void Play(string pos, IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool isValidPlace(string position)
        {
            throw new NotImplementedException();
        }

        public bool isValidMove(string to, string from, IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool isValidFly(string to, string from, IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool canShoot(IPlayer player, ILegalMoves move, IBoard board)
        {
            return move.canShoot(player, board);
        }
    }
}
