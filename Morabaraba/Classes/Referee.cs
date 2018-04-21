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

        public bool isValidFly(string to, string from, IPlayer player)
        {
            bool flagTo = board.allPositions().Contains(to);
            bool flagFrom = board.allPositions().Contains(from);

            if(flagTo && flagFrom && player.Phase == Phase.flying)
            {
                
                int cowPieces = cowBox.playerPiecesPositions(player).Count;
                if(cowPieces == 3)
                {
                    Tile tTo = board.getTile(to);
                    Tile tFrom = board.getTile(from);
                    // The position you going to must be blank and the position going to must say its the current player
                    if(tTo.cond.Symbol == Symbol.BL && tFrom.cond.Symbol == player.symbol)
                    {
                        return true;
                    }
                }
            }
            return false;
            
        }

        public bool isValidMove(string to, string from, IPlayer player)
        {
            bool flagTo = board.allPositions().Contains(to);
            bool flagFrom = board.allPositions().Contains(from);

            if (flagTo && flagFrom && player.Phase == Phase.moving)
            {

                int cowPieces = cowBox.playerPiecesPositions(player).Count;
                if (cowPieces > 3 && player.cowLives == 0)
                {
                    Tile tTo = board.getTile(to);
                    Tile tFrom = board.getTile(from);
                    List<string> neighBours = board.getNeighbourCells(from);
                    // The position you going to must be blank and the position going to must say its the current player
                    if (neighBours.Contains(tTo.pos))
                        if (tTo.cond.Symbol == Symbol.BL && tFrom.cond.Symbol == player.symbol)
                            return true;
                }
            }
            return false;
        }
        public bool isValidPlace(string position, IPlayer player)
        {
            Tile tile = board.getTile(position);
            if (tile.cond.Symbol == Symbol.BL && cowBox.remainingCows(player) > 0) return true;

            return false;
        }

        public void playPlace(string pos, IPlayer player)
        {
            throw new NotImplementedException();
        }
        public void playMove(string to, string from, IPlayer player)
        {
            if (isValidMove(to, from, player))
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

        public bool canShoot(IPlayer player)
        {
            throw new NotImplementedException();
        }
    }
}
