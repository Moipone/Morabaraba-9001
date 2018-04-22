using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Player : IPlayer
    {

        IBoard board;
        public ICowBox cowBox { get; set; }
        public Player(Symbol sym, IBoard board)
        {
            this.symbol = sym;
            // this.board = board;
            this.LastPosPlayed = new List<string>();
            this.millsFormed = new List<List<string>>();

        }
        public Player(Symbol sym)
        {
            this.symbol = sym;
            cowLives = 12;
            this.LastPosPlayed = new List<string>();
            this.millsFormed = new List<List<string>>();
            flag = false;

        }
        public void setBoard(IBoard board)
        {
            this.board = board;
        }

        public Symbol symbol { get ; set; }
        public Phase Phase { get ; set ; }
        public List<string> LastPosPlayed { get ; set ; }
        public List<List<string>> millsFormed { get; set; }
        //public List<IPiece> Pieces { get; }
        public bool loses { get; set ; }
        public int cowLives { get ;  set ; }
        public bool flag { get ; set ; }

        public List<IPiece> Pieces(IBoard board, Symbol sym, ITile tile)
        {
            List<IPiece> pieces = new List<IPiece>();
             for( int i = 0; i < board.allPositions().Count; i++)
            {
               tile =  board.board[i];
                if (tile.cond != null && tile.cond.Symbol == sym)
                    pieces.Add(tile.cond);
            }
            return pieces;
        }

        public bool place(string pos, IBoard board, IReferee referee)
        {
            return referee.isValidPlace(pos,this);

        }

        public bool canmove(string from, string to, IBoard board, IReferee referee, IPlayer player)
        {
            return referee.isValidMove(from, to, player);

        }

        public bool fly(string from, string to, IBoard board, IReferee referee, IPlayer player)
        {
            return referee.isValidFly( from, to, player);

        }

        public bool canmove(string from, string to, IBoard board, IReferee referee)
        {
            throw new NotImplementedException();
        }

        public bool fly(string from, string to, IBoard board, IReferee referee)
        {
            throw new NotImplementedException();
        }

        public void playPlace(string pos, IPlayer player, IReferee referee)
        {
            if (referee.isValidPlace(pos,this))
            {
                Tile t = new Tile(pos, new Piece(player.symbol, pos));
                if (player.LastPosPlayed.Contains(pos)) player.LastPosPlayed.Remove(pos);

                player.LastPosPlayed.Add(pos);
                board.updateTile(t);
            }
            else Console.WriteLine("Invalid move, please make a valid move");
        }
        
        public void playMove(string to, string from, IPlayer player, IReferee referee)
        {
            if (referee.isValidMove(to, from, player))
            {
                Tile tileTo = new Tile(to, new Piece(player.symbol, to));
                Tile tileFrom = new Tile(from, new Piece(Symbol.BL, from));

                board.updateTile(tileTo);
                board.updateTile(tileFrom);
            }
            else Console.WriteLine("Invalid move, please make a valid move");
        }
        public void playFly(string to, string from, IPlayer player, IReferee referee)
        {
            if (referee.isValidFly(to, from, player))
            {
                Tile tileTo = new Tile(to, new Piece(player.symbol, to));
                Tile tileFrom = new Tile(from, new Piece(Symbol.BL, from));

                board.updateTile(tileTo);
                board.updateTile(tileFrom);
            }
            else Console.WriteLine("Invalid move, please make a valid move");
        }
        public void Shoot(IPlayer player, IReferee referee, string position)
        {

            if(referee.canShoot(player, board, position))

            if (referee.isValidDestroy(player, position))

            {
                if (!referee.isAvailablePieces(player))
                {
                    if (referee.isInMillPos(position, player)){
                        Console.WriteLine("You can't shoot a piece in a mill. There are still available pieces to shoot");
                        flag = true;
                    }

                }
                else board.updateTile(new Tile(position, new Piece(Symbol.BL, position)));
            }
            else Console.WriteLine("You can't remove your own player or shoot a blank spot!!!");
         
        }

        public bool move(string from, string to, IBoard board, IReferee referee)
        {
            throw new NotImplementedException();
        }
    }
}
