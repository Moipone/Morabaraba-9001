using System;
using System.Collections.Generic;
using System.Text;


namespace Morabaraba.Classes
{
    class LegalMoves : ILegalMoves
    {
        public bool isValidPlace(string pos, IBoard board)
        {
            //throw new NotImplementedException();
            if (isValidPos(pos, board))
            {
                if (board.getTile(pos).cond == null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isValidMove(string currPos, string posMoveTo, IBoard board, IPlayer player)
        {
            //throw new NotImplementedException();
            if (isValidPos(currPos, board) && isValidPos(posMoveTo, board))
            {
                if (isOwnTile(currPos,player, board.getTile(currPos) ))
                {
                    if (board.getNeighbourCells(currPos).Contains(posMoveTo))
                    {
                        if (board.getTile(posMoveTo).cond == null)
                        {
                            return true;
                        }
                    }
                }
                
            }
            return false;
        }

        public bool isValidFly(string currPos, string posMoveTo, IBoard board, IPlayer player)
        {
            //throw new NotImplementedException();
            if (isValidPos(currPos, board) && isValidPos(posMoveTo,board))
            {
                if (isOwnTile(currPos, player, board.getTile(currPos)))
                {
                    if (board.getTile(posMoveTo).cond == null)
                    {
                        return true;
                    }
                }
            }   
            
            return false;
        }

        public bool isValidPos(string pos, IBoard board)
        {
            //throw new NotImplementedException();
            pos = pos.ToLower();
            if (!board.allPositions().Contains(pos))
            {
                return false;
            }
            else return true;

        }

        public bool isOwnTile(string pos, IPlayer player, ITile tile)
        {
            //throw new NotImplementedException();
            if (tile.cond.Symbol == player.symbol)
            {
                return true;
            }
            return false;
        }

        public bool isValidMove(string currPos, string posMoveTo, IBoard board)
        {
            throw new NotImplementedException();
        }

        public bool isValidFly(string currPos, string posMoveTo, IBoard board)
        {
            throw new NotImplementedException();
        }

        public bool canShoot(IPlayer player, IBoard booard)
        {
            throw new NotImplementedException();
        }
    }
}
