﻿using Morabaraba.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Referee : IReferee
    {
        IBoard board;

        ICowBox cowBox;
        Symbol currentPlayer;

        public bool mill { get; set; }

        public Referee(IBoard board, Symbol player)
        {
            this.board = board;
            this.currentPlayer = player;
            mill = false;
            cowBox = new CowBox(board);
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
        public bool isMill(IPlayer player)
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
                            // player1.millsFormed.Add(board.mills[i]);
                            mill = true;
                            return mill;
                        }
                    }
                }
                if (millCount == 3 && !player.millsFormed.Contains(board.mills[i]))
                {
                    player.millsFormed.Add(board.mills[i]);
                    mill = true;
                    return mill;
                }
            }
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
            if (isValidPlace(pos, player))
            {
                Tile t = new Tile(pos, new Piece(player.symbol, pos));
                board.updateTile(t);
            }
            else Console.WriteLine("Invalid move, please make a valid move");
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

        public bool canShoot(IPlayer player, ILegalMoves move, IBoard board)
        {
            return move.canShoot(player, board);
        }
    }
}
