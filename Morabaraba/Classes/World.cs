﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Morabaraba
{
    public class World : IWorld
    {
        Symbol currentPlayer { get; set; }
        bool ValidPos = true;
        bool mill = false;
        bool shift = false;
        string tmpPos = "";
        bool tmpFlag = false;  //controls the flow of the game
        bool switchFlag = false;
        int k = 0, z = 0;
        int t = 0;
        // Fix re-forming of mills 
        public World(IPlayer p1, IPlayer p2)
        {
            this.player1 = p1;
            this.player2 = p2;
            board = new Board();
        }

        public IBoard board { get ; set ; }
        public IPlayer player1 { get ; set; }
        public IPlayer player2 { get; set; }
        public IReferee referee { get ; set ; }

        public string mapSym(int ind)
        {
            if (ind > board.board.Count || ind < 0) return "";
            Symbol symbol = board.board[ind].cond.Symbol;
            if (symbol == Symbol.BL) return "O";
            if (symbol == Symbol.CW) return "W";
            return "B";
        }
        public void turnBlank(string pos)
        {
            board.updateTile(new Tile(pos, new Piece(Symbol.BL, pos)));
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
        public void millP1()
        {
            for (int i = 0; i < board.mills.Count; i++)
            {
                int millCount = 0;
                for (int j = 0; j < player1.LastPosPlayed.Count; j++)
                {
                    Tile one = board.getTile(player1.LastPosPlayed[j]);

                    if (board.mills[i].Contains(player1.LastPosPlayed[j]) && one.cond.Symbol == Symbol.CW)
                    {
                        millCount++;
                        if (millCount == 3 && !player1.millsFormed.Contains(board.mills[i]))
                        {
                            player1.millsFormed.Add(board.mills[i]);
                            mill = true;

                        }
                    }
                }
                if (millCount == 3 && !player1.millsFormed.Contains(board.mills[i]))
                {
                    player1.millsFormed.Add(board.mills[i]);
                    mill = true;
                    return;
                }
            }
        }
        public void millP2()
        {
            for (int i = 0; i < board.mills.Count; i++)
            {
                int millCount = 0;
                for (int j = 0; j < player2.LastPosPlayed.Count; j++)
                {
                    Tile one = board.getTile(player2.LastPosPlayed[j]);

                    if (board.mills[i].Contains(player2.LastPosPlayed[j]) && one.cond.Symbol == Symbol.CB)
                    {
                        millCount++;
                        if (millCount == 3 && !player2.millsFormed.Contains(board.mills[i]))
                        {
                            player2.millsFormed.Add(board.mills[i]);
                            mill = true;
                            return;
                        }
                    }
                    if (millCount == 3 && !player2.millsFormed.Contains(board.mills[i]))
                    {
                        player2.millsFormed.Add(board.mills[i]);
                        mill = true;
                        return;
                    }
                }
            }
        }
        //This is a method to check if a mill has been formed...
        public void isMill()
        {
            if (currentPlayer == Symbol.CW) millP1();

            else millP2();
         
        }
        public IPlayer getPlayer(Symbol symbol)
        {
            if (symbol == Symbol.CW) return player1;

            return player2;
        }
        ///<summary> 
        ///Given a list of mills and a position, check if that position exists in that mill.
        /// </summary>
        //A Method to check if a piece is currently in a mill
        public bool isInMillPos(string pos, IPlayer player)
        {
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos)) return true;
            }
            return false;
        }
        public List<string> getPlayerPieces(IPlayer player)
        {
            List<string> positions = new List<string>();
            for (int i = 0; i < board.board.Count; i++)
            {
                Tile t = board.board[i];
                if (t.cond.Symbol == player.symbol) positions.Add(t.pos);

            }
            return positions;
        }  //This method checks whether there's any pieces that's not in a mill

        //This method checks whether there's any pieces that's not in a mill
        public bool isNotAvailablePieces(IPlayer player)
        {
            List<string> list = getPlayerPieces(player);
            bool isNotAvailable = false;
            foreach (string str in list)
            {
                isNotAvailable = isInMillPos(str, player);
                if (!isNotAvailable) return false;
            }
            return true;
        }
        public void PlayAllPhases()
        {
            //printBoard(" Where would you like to play?");
         
            placingPhase();
            movingPhase();
            flyingPhase();
        }

        private void validatePos(string pos)
        {
            if(!board.allPositions().Contains(pos))
            {
                Console.WriteLine("Invalid position played, please re-enter where you'd like to play!");
                ValidPos = false;
            }
        }
        public void clearBoard()
        {
            Console.Clear();
        }
        private void runPlay()
        {
            string play = " Where would you like to play? :";
            clearBoard();
            printBoard(play);


        }
        private void placingPhase()
        {


            string play = $@"Where would you like to play  {currentPlayer} Player? :";
            clearBoard();
            printBoard(play);
            string pos = "";
            //runPlay();
            //If either of the players still have cows to place, place them
            while (player1.cowLives > 0 || player2.cowLives > 0)
            {
                if (!mill) pos = Console.ReadLine();
                if (board.getTile(pos) == null)
                {
                    Console.WriteLine("Invalid move!");
                    runPlay();
                    placingPhase();
                }
                Symbol enemy = board.getTile(pos).cond.Symbol;
                if (mill)
                {
                    clearBoard();
                    printBoard("Which enemy would you like to destroy? :");
                    string tmpPos = Console.ReadLine();

                    validatePos(tmpPos);
                    //If the position played re-try 
                    if (!ValidPos) continue;
                    enemy = board.getTile(tmpPos).cond.Symbol;
                    if (enemy == Symbol.BL)
                    {
                        Console.WriteLine("You can't destroy an empty piece");
                        Thread.Sleep(1500);
                        continue;
                    }
                    if (enemy == currentPlayer && enemy != Symbol.BL)
                    {
                        Console.WriteLine("You can't destroy your own player!!!" + "  Please choose an enemy piece!");
                        Thread.Sleep(1500);
                        continue;
                    }
                    if (!isNotAvailablePieces(getPlayer(enemy)))
                    {
                        if (isInMillPos(tmpPos, getPlayer(enemy)))
                        {
                            Console.WriteLine("You can't shoot a piece in a mill. There are still available pieces to shoot");
                            Thread.Sleep(1500);
                            continue;
                        }
                    }
                    mill = false;
                    RemovePiece(tmpPos);
                    RemoveBrokenMill(tmpPos, getPlayer(currentPlayer));
                    clearBoard();
                    printBoard(play);

                    switchPlayer();
                    play = $@"Where would you like to play  {currentPlayer} Player? :";
                }
                else
                {
                    startPlaying(pos);
                    isMill();
                    if (mill) continue;

                    switchPlayer();
                    play = $@"Where would you like to play  {currentPlayer} Player? :";
                    clearBoard();
                    printBoard(play);


                }

            }




        }

        private void startPlaying(string pos)
        {
            if (pos.Length == 0)
            {
                Console.WriteLine("Please select where you'd like to play");
                //continue;
            }

            if (currentPlayer == Symbol.CW)
            {
                helperCheck1(pos);
            }
            else
            {
                helperCheck2(pos);
            }

        }
        //This method can be used for both destroying a cow, and placing a cow
        public void Play(string pos, IPlayer player)
        {
            Tile t = new Tile(pos, new Piece(player.symbol, pos));

            if (player.cowLives > 0)
            {
                board.updateTile(t);

            }
        }

        private void helperCheck1(string pos)
        {

            if (board.getTile(pos).cond.Symbol != Symbol.BL && board.getTile(pos).cond.Symbol == currentPlayer && !shift)
            {
                Console.WriteLine("You can't play there, that's an invalid move");
                Console.WriteLine("Where would you like to play");
                pos = Console.ReadLine();

            }
            Play(pos, getPlayer(currentPlayer));
            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (getPlayer(currentPlayer).LastPosPlayed.Contains(pos))
                getPlayer(currentPlayer).LastPosPlayed.Remove(pos);

            getPlayer(currentPlayer).LastPosPlayed.Add(pos);
            getPlayer(currentPlayer).cowLives--;
        }

        

        private void helperCheck2(string pos)
        {
            if (board.getTile(pos).cond.Symbol != Symbol.BL && board.getTile(pos).cond.Symbol == currentPlayer && !shift)
            {
                Console.WriteLine("You can't play there, that's an invalid move");
                Console.WriteLine("Where would you like to play");
                pos = Console.ReadLine();
            }
            Play(pos, getPlayer(currentPlayer));
            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (getPlayer(currentPlayer).LastPosPlayed.Contains(pos))
                getPlayer(currentPlayer).LastPosPlayed.Remove(pos);

            getPlayer(currentPlayer).LastPosPlayed.Add(pos);
            getPlayer(currentPlayer).cowLives--;

        }

        private void RemoveBrokenMill(string pos, IPlayer player)
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

        private void RemovePiece(string pos)
        {
            Tile t = new Tile(pos, new Piece(Symbol.BL, pos));
            board.updateTile(t);
        }

        private void switchPlayer()
        {
            if (currentPlayer == Symbol.CW) currentPlayer = Symbol.CB;
            else currentPlayer = Symbol.CW;
        }

        private void movingPhase() 
        {
            clearBoard();
            string pos = Console.ReadLine();
            validatePos(pos);
            if (!ValidPos) return;
            
        }

        private void flyingPhase()
        {
            clearBoard();
            string pos = Console.ReadLine();
            validatePos(pos);
            if (!ValidPos) flyingPhase();
            else
            {
                turnBlank(pos);
                string moveTo = Console.ReadLine();

            }
           
        }

        /// <summary>
        /// Moving Assist methods 
        /// </summary>

        public void ControlMills(string play)
        /// Allows the player to destroy an enemy while in the movingPhase
        {  
            if (mill)
            {
                tmpFlag = true;
                if (tmpFlag)
                {
                    Console.WriteLine("Which enemy would you like to destroy");
                    shift = true;
                    return;
                }

            }
            switchPlayer();
            clearBoard();
            printBoard(play);
            t++;
            switchFlag = false;

        }

        public void RunMoving(string play)
        /// This is the backbone of the mivingPhase, it essentially implements the phase 
        {
            //Go through neighbour cells to see if there's an available position  
            bool flag = false;
            List <string> neighbours = board.getNeighbourCells(play);
            if (neighbours.Contains(play))
            {

                for (int i = 0; i<neighbours.Count; i++)
                {
                    Tile tl = board.getTile(neighbours[i]);
                    Tile two =board.getTile(tmpPos);
                    if (two.cond == null)
                    {
                        Console.WriteLine("You can't move an empty piece");
                        flag = true;
                        return;
                    }
                    if (two.cond != board.getTile(play))
                    {
                        Console.WriteLine("You can't move your oponents piece\nPlease move your own piece!");
                        flag = true;
                        return;
                    }

                    if (tl.cond == null && play == neighbours[i] && two.cond != null)
                    {


                        //Remove the old piece from the board
                        RemovePiece(tmpPos);
                        //Remove the broken mill of the old piece
                        RemoveBrokenMill(tmpPos, getPlayer(currentPlayer));
                        //Update board
                        clearBoard();
                        printBoard(tmpPos);
                        if (currentPlayer == player1.symbol)
                        {
                            printBoard(play);
                            //UpdateGUI();
                        }
                        else
                        {
                            printBoard(play);
                            //UpdateGUI();
                        }
                        //addPiece(play, getPlayer(currentPlayer));
                        //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
                        if (getPlayer(currentPlayer).LastPosPlayed.Contains(play))
                            getPlayer(currentPlayer).LastPosPlayed.Remove(play);
                        //Add the new position to player
                        getPlayer(currentPlayer).LastPosPlayed.Add(play);
                        //Check if a new mill has been formed.
                        isMill();

                        ControlMills(play);
                        return;
                    }
                }

            }
            else
            {
                int indx = getPlayer(currentPlayer).LastPosPlayed.Count - 1;
                Console.WriteLine(string.Format("To which adjacent, free space would you like to move {0} ? ",getPlayer(currentPlayer).LastPosPlayed[indx]));

                return;
            }
        }


        public void SwithControl()
        /// Validates the player's choices, and provides and proper flow of the game 
        {

        }

        public void MovingPhase()
        ///calls on the above assist methods to run the phase
        {
            string play = $@"Where would you like to play  {currentPlayer} Player? :";
        }







        public void printBoard(string message)
        {
            Console.Clear();
            Tile[] cells = board.board.ToArray();
            string dis =
  $@"
      1   2  3   4   5  6   7
  A   {mapSym(0)}----------{mapSym(1)}----------{mapSym(2)}
  |   | '.       |        .'|
  B   |   {mapSym(3)}------{mapSym(4)}------{mapSym(5)}   |
  |   |   |'.    |    .'|   |
  C   |   |  {mapSym(6)}---{mapSym(7)}---{mapSym(8)}  |   |
  |   |   |  |       |  |   |
  D   {mapSym(9)}---{mapSym(10)}--{mapSym(11)}       {mapSym(12)}--{mapSym(13)}---{mapSym(14)}
  |   |   |  |       |  |   |
  E   |   |  {mapSym(15)}---{mapSym(16)}---{mapSym(17)}  |   |
  |   |   |.'    |    '.|   |
  F   |   {mapSym(18)}------{mapSym(19)}------{mapSym(20)}   |
  |   |.'        |       '. |
  G   {mapSym(21)}----------{mapSym(22)}----------{mapSym(23)} ";

            string wLives = ""+ (player1.cowLives);
            string bLives = "" + player2.cowLives;
            Console.WriteLine("White player has {0} pieces to place.\nBlack player has {1} pieces to place\n", wLives, bLives);
            Console.WriteLine(dis);
            Console.WriteLine("\n"+message);
        }
    }
}

