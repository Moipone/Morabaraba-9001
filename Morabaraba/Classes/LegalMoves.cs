using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba.Classes
{
    class LegalMoves : Interfaces.ILegalMoves
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

        public bool isValidMove(string currPos, string posMoveTo, IBoard board)
        {
            //throw new NotImplementedException();
            if (isValidPos(currPos, board) && isValidPos(posMoveTo, board))
            {
                if (board.getNeighbourCells(currPos).Contains(posMoveTo))
                {
                    if (board.getTile(posMoveTo).cond == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool isValidFly(string currPos, string posMoveTo, IBoard board)
        {
            //throw new NotImplementedException();
            if (isValidPos(currPos, board) && isValidPos(posMoveTo,board))
            {
                if (board.getTile(posMoveTo).cond == null)
                {
                    return true;
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
    }
}
