using System;
using System.Collections.Generic;
using System.Text;


namespace Morabaraba.Classes
{
    class LegalMoves : ILegalMoves
    {
        IBoard board;
        ICowBox cowBox;
        public LegalMoves(IBoard board, ICowBox cowBox)
        {
            this.board = board;
            this.cowBox = cowBox;
        }
        public bool isValidPlace(string pos, IPlayer player)
        {
            if (isValidPos(pos))
            {
                Tile tile = board.getTile(pos);
                if (tile.cond.Symbol == Symbol.BL && cowBox.remainingCows(player) > 0) return true;
            }

            return false;
        }

        public bool isValidMove(string to, string from, IPlayer player)
        {
            bool flagTo = isValidPos(to);
            bool flagFrom = isValidPos(from);

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

        public bool isValidFly(string to, string from, IPlayer player)
        {
            bool flagTo = isValidPos(to);
            bool flagFrom = isValidPos(from);

            if (flagTo && flagFrom && player.Phase == Phase.flying)
            {

                int cowPieces = cowBox.playerPiecesPositions(player).Count;
                if (cowPieces == 3)
                {
                    Tile tTo = board.getTile(to);
                    Tile tFrom = board.getTile(from);
                    // The position you going to must be blank and the position going to must say its the current player
                    if (tTo.cond.Symbol == Symbol.BL && tFrom.cond.Symbol == player.symbol)
                    {
                        return true;
                    }
                }
            }
            return false;

        }
        public bool isValidPos(string pos)
        {
            //throw new NotImplementedException();
            pos = pos.ToLower();
            if (!board.allPositions().Contains(pos))
            {
                return false;
            }
            else return true;

        }

        public bool isOwnTile(string pos, IPlayer player)
        {
            Tile tile = board.getTile(pos);
            //throw new NotImplementedException();
            if (tile.cond.Symbol == player.symbol)
            {
                return true;
            }
            return false;
        }
        public bool canShoot(IPlayer player, IBoard booard)
        {
            throw new NotImplementedException();
        }
        public bool isValidMove(string currPos, string posMoveTo, IBoard board)
        {
            throw new NotImplementedException();
        }
  
        public bool ismill(IBoard board, IPlayer player)
        {
            for (int i = 0; i < board.mills.Count; i++)
            {
                int millCount = 0;
                for (int j = 0; j < player.LastPosPlayed.Count; j++)
                {
                    Tile one = board.getTile(player.LastPosPlayed[j]);

                    if (board.mills[i].Contains(player.LastPosPlayed[j]) && one.cond.Symbol == Symbol.CW)
                    {
                        millCount++;
                        if (millCount == 3 && !player.millsFormed.Contains(board.mills[i]))
                        {
                            player.millsFormed.Add(board.mills[i]);
                            return true;

                        }
                    }
                }
                if (millCount == 3 && !player.millsFormed.Contains(board.mills[i]))
                {
                    player.millsFormed.Add(board.mills[i]);
                    return true;
                    
                }
   
            }
            return false;
        }
        public bool isInMillPos(string pos, IPlayer player)
        {
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos)) return true;
            }
            return false;
        }


        public bool cowsInBox(ICowBox cowBox, IPlayer player)
        {
            //throw new NotImplementedException();
            return cowBox.remainingCows(player) > 0;
        }

        public bool cowsInBox(IPlayer player)
        {
            throw new NotImplementedException();
        }

        public bool isvalidenemy(IPlayer player, string pos, ITile tile, IBoard board)
        {
            //throw new NotImplementedException();
            if (!isValidPlace(pos, player)) //takes in player not enemy
            {
                if (player.symbol != tile.cond.Symbol) return true; else return false;
            }
            return false;
            
        }

        public bool isnotEmpty(IPlayer player, string pos)
        {
            //throw new NotImplementedException();
            if (board.getTile(pos).cond.Symbol != Symbol.BL ) return true; else return false; 
        }
    }
}
