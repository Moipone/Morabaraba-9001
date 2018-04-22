using Morabaraba.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Morabaraba
{
    public class World : IWorld
    {
        private bool shift = false;
        private int k =0;
        private int z = 0;
        private int b = 0;
        private int w = 0;

        Symbol currentPlayer { get; set; }
        public World(IPlayer p1, IPlayer p2)
        {
            this.player1 = p1;
            this.player2 = p2;
            this.board = new Board();
            p1.setBoard(board);
            p2.setBoard(board);
            cowBox = new CowBox(board);
            p1.setCowBox(cowBox);
            p2.setCowBox(cowBox);
            referee = new Referee(board, p1.symbol);
            legalMoves = new LegalMoves(board, cowBox);
            referee.currentPlayer = p1.symbol;
        }

        /* public World(IPlayer player1, IPlayer player2, IReferee referee)
         {
             this.board = new Board();
             this.player1 = player1;
             this.player2 = player2;
             this.referee = referee;
         }*/
        
        public IBoard board { get; set; }
        public IPlayer player1 { get; set; }
        public IPlayer player2 { get; set; }
        public IReferee referee { get; set; }
        public ILegalMoves legalMoves { get; set; }
        public ICowBox cowBox { get; set; }
        public string mapSym(int ind)
        {
            if (ind > board.board.Count || ind < 0) return "";
            Symbol symbol = board.board[ind].cond.Symbol;
            if (symbol == Symbol.BL) return "O";
            if (symbol == Symbol.CW) return "W";
            return "B";
        }
        public IPlayer getPlayer (Symbol symbol)
        {
            if (symbol == Symbol.CB) return player1;

            return player2;
        }
        public void clearBoard()
        {
            Console.Clear();
        }
        public void RunAllPhases()
        {
            placingPhase();
            movingPhase();
            flyingPhase();
        }
        public void placingPhase()
        {
            string play = $@"Where would you like to play  {currentPlayer} Player? :";
            clearBoard();
            printBoard(play);
            string pos = "";

            while (cowBox.getcowsInBox(Symbol.CB) > 0 || cowBox.getcowsInBox(Symbol.CW) > 0 || referee.mill)
            {
                if (!referee.mill)
                {
                    pos = Console.ReadLine();
                    if (!legalMoves.isValidPos(pos) || !legalMoves.isValidPlace(pos,getPlayer(currentPlayer))) {
                        Console.WriteLine("Invalid move!!!, please place a cow on a free space");
                        Thread.Sleep(1500);
                        continue;
                    }

                    getPlayer(currentPlayer).playPlace(pos,getPlayer(currentPlayer),referee);
                    referee.mill = (referee.canShoot(getPlayer(currentPlayer), pos));
                    if(referee.mill)
                    {
                        clearBoard();
                        printBoard($@"Which piece would you like to destroy { currentPlayer}");


                        pos = Console.ReadLine();
                        if (!legalMoves.isValidPos(pos))
                        {
                            Console.WriteLine("Invalid move!!!, Please re-enter coordinate");
                            Thread.Sleep(1500);
                            continue;
                        }
                        getPlayer(currentPlayer).Shoot(getPlayer(currentPlayer), referee, pos);
                        referee.RemoveBrokenMill(pos, getPlayer(currentPlayer));

                        if (getPlayer(currentPlayer).flag) continue;
                        referee.mill = false;
                        getPlayer(currentPlayer).flag = false;
                    }
                    referee.switchPlayer();
                    currentPlayer = referee.currentPlayer;

                    play = $@"Where would you like to play  {currentPlayer} Player? :";
                    printBoard(play);
                }
                else
                {
                    clearBoard();
                    printBoard($@"Which piece would you like to destroy { currentPlayer}");


                    pos = Console.ReadLine();
                    if (!legalMoves.isValidPos(pos))
                    {
                        Console.WriteLine("Invalid move!!!, Please re-enter coordinate");
                        Thread.Sleep(1500);
                        continue;
                    }
                    getPlayer(currentPlayer).Shoot(getPlayer(currentPlayer), referee, pos);
                    referee.RemoveBrokenMill(pos, getPlayer(currentPlayer));

                    if (getPlayer(currentPlayer).flag) continue;
                    referee.mill = false;
                    getPlayer(currentPlayer).flag = false;

                    clearBoard();
                    referee.switchPlayer();
                    currentPlayer = referee.currentPlayer;
                    play = $@"Where would you like to play  {currentPlayer} Player? :";
                    printBoard(play);
                }
            }
        }
        public void flyingHelper()
        {

            if (k == 0 && currentPlayer == Symbol.CB && getPlayer(Symbol.CB).Phase == Phase.flying)
            {
                Console.WriteLine("{0} Cows can now fly!, please select the cow you'd like to move", currentPlayer);
                Thread.Sleep(1500);
                shift = true;
                k++;
                return;
            }
            if (z == 0 && currentPlayer == Symbol.CW && getPlayer(Symbol.CW).Phase == Phase.flying)
            {
                Console.WriteLine("{0} Cows can now fly!, please select the cow you'd like to move", currentPlayer);
                shift = true;
                Thread.Sleep(1500);
                z++;
                //fly = true;
                return;
            }
            if (getPlayer(Symbol.CW).Phase == Phase.flying && getPlayer(Symbol.CB).Phase == Phase.flying)
            {
                shift = true;
            }
        }
        public void flyingPhase()
        {
            string play = $@"Which piece would you like to move ? {currentPlayer}";
            int wP = cowBox.getcowsInBox(Symbol.CW);
            int bP = cowBox.getcowsInBox(Symbol.CB);

            while (true)
            {
                flyingHelper();
                clearBoard();
                printBoard(play);
                

                string from = Console.ReadLine();
                string to = "";
                if (legalMoves.isValidPos(from))
                {
                    Console.WriteLine("Where you would you like to move ? {0}", currentPlayer);
                    to = Console.ReadLine();
                    if (!legalMoves.isValidPos(to))
                    {
                        Console.WriteLine("Invalid move please, select a valid cow");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid movve please, select a valid cow");
                    continue;
                }

                if (referee.isValidFly(to, from, getPlayer(currentPlayer)))
                {
                    getPlayer(currentPlayer).playFly(to, from, getPlayer(currentPlayer), referee);
                    clearBoard();
                    printBoard(play);
                    referee.switchPlayer();
                    currentPlayer = referee.currentPlayer;
                }
                else
                {
                    Console.WriteLine($@"Invalid move!!! {currentPlayer}, Please make a valid move");
                    Thread.Sleep(1500);
                    continue;
                }
                referee.mill = (referee.canShoot(getPlayer(currentPlayer), to));
                if (referee.mill)
                {
                    clearBoard();
                    printBoard($@"Which piece would you liket to destroy { currentPlayer}");


                    string pos = Console.ReadLine();
                    if (!legalMoves.isValidPos(pos))
                    {
                        Console.WriteLine("Invalid move!!!, Please re-enter coordinate");
                        Thread.Sleep(1500);
                        continue;
                    }
                    getPlayer(currentPlayer).Shoot(getPlayer(currentPlayer), referee, to);
                    referee.RemoveBrokenMill(to, getPlayer(currentPlayer));

                    if (getPlayer(currentPlayer).flag) continue;
                    referee.mill = false;
                    getPlayer(currentPlayer).flag = false;
                    referee.switchPlayer();
                    currentPlayer = referee.currentPlayer;

                    play = $@"Where would you like to play  {currentPlayer} Player? :";
                    printBoard(play);
                
                }
            }


        }
        
        private void checkPhases(IPlayer player1, IPlayer player2)
        {
            //Check if there's no cows left to place, check if there's still more than 3 cows on each side to be on moving phase
            int blackPieces = cowBox.getcowsOnBoard(player1.symbol);
            int whitePieces = cowBox.getcowsOnBoard(player2.symbol) ;

            if ((cowBox.getcowsInBox(Symbol.CW) == 0 && (cowBox.getcowsInBox(Symbol.CB) ==0) && (whitePieces > 3) && (blackPieces > 3)))
            {
                if (currentPlayer == Symbol.CW) movingPhase();
                else movingPhase();
            }
            if ((cowBox.getcowsInBox(Symbol.CW) == 0 && (cowBox.getcowsInBox(Symbol.CB) == 0) && (whitePieces == 3) && (blackPieces > 3)))
            {
                player2.Phase = Phase.flying;
                if (currentPlayer == Symbol.CW) return;
                else movingPhase();
            }
            if ((cowBox.getcowsInBox(Symbol.CW) == 0 && (cowBox.getcowsInBox(Symbol.CB) == 0) && (blackPieces == 3) && (whitePieces > 3)))
            {
                player1.Phase = Phase.flying;
                if (currentPlayer == Symbol.CB) return;
                else movingPhase();
            }

            //Both players are now flying.......................................................
            if ((cowBox.getcowsInBox(Symbol.CW) == 0 && (cowBox.getcowsInBox(Symbol.CB) == 0) && (whitePieces == 3) && (blackPieces == 3)))
            {
                player1.Phase = Phase.flying;
                player2.Phase = Phase.flying;
                return;

            }
        }
        private void movingHelper()
        {
            if (b == 0 && currentPlayer == Symbol.CB)
            {
                Console.WriteLine("{0} has no more cows to place!, please select the cow you'd like to move", currentPlayer);
                Thread.Sleep(1500);
                getPlayer(currentPlayer).Phase = Phase.moving;
                shift = true;
                b++;
                return;
            }
            if (w == 0 && currentPlayer == Symbol.CW)
            {
                Console.WriteLine("{0} has no more cows to place!, please select the cow you'd like to move", currentPlayer);
                getPlayer(currentPlayer).Phase = Phase.moving;
                shift = true;
                Thread.Sleep(1500);
                w++;
                //fly = true;
                return;
            }
            if (getPlayer(Symbol.CW).Phase == Phase.moving && getPlayer(Symbol.CB).Phase == Phase.moving)
            {
                shift = true;
                return;
            }

        }
        private void movingPhase()
        {
            string play = $@"Which piece would you like to move ? {currentPlayer}";
            int wP = cowBox.getcowsOnBoard(Symbol.CW);
            int bP = cowBox.getcowsOnBoard(Symbol.CB);

            while (true)
            {
                if (wP == 3 || bP == 3) break;
                movingHelper();
                clearBoard();
                printBoard(play);

                string from = Console.ReadLine();
                string to = "";
                if (legalMoves.isValidPos(from))
                {
                    Console.WriteLine("Where you would you like to move ? {0}", currentPlayer);
                    checkPhases(player1, player2);
                    if (currentPlayer == Symbol.CW && getPlayer(Symbol.CW).Phase == Phase.moving)
                    {
                        referee.switchPlayer();
                        currentPlayer = referee.currentPlayer;
                        continue;
                    }

                    if (currentPlayer == Symbol.CB && getPlayer(Symbol.CB).Phase == Phase.moving)
                    {

                        referee.switchPlayer();
                        currentPlayer = referee.currentPlayer;
                        continue;
                    }
                    to = Console.ReadLine();
                    if (!legalMoves.isValidPos(to))
                    {
                        Console.WriteLine("Invalid move please, select a valid cow");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid movve please, select a valid cow");
                    continue;
                }
                
                if (referee.isValidMove(to, from, getPlayer(currentPlayer)))
                {
                    getPlayer(currentPlayer).playMove(to, from, getPlayer(currentPlayer), referee);
                    clearBoard();
                    printBoard(play);
                    referee.switchPlayer();
                    currentPlayer = referee.currentPlayer;
                }
                else
                {
                    Console.WriteLine($@"Invalid move!!! {currentPlayer}, Please make a valid move");
                    Thread.Sleep(1500);
                    continue;
                }
                referee.mill = (referee.canShoot(getPlayer(currentPlayer), to));
                if (referee.mill)
                {
                    clearBoard();
                    printBoard($@"Which piece would you liket to destroy { currentPlayer}");


                    string pos = Console.ReadLine();
                    if (!legalMoves.isValidPos(pos))
                    {
                        Console.WriteLine("Invalid move!!!, Please re-enter coordinate");
                        Thread.Sleep(1500);
                        continue;
                    }
                    getPlayer(currentPlayer).Shoot(getPlayer(currentPlayer), referee, to);
                    referee.RemoveBrokenMill(to, getPlayer(currentPlayer));

                    if (getPlayer(currentPlayer).flag) continue;
                    referee.mill = false;
                    getPlayer(currentPlayer).flag = false;
                    referee.switchPlayer();
                    currentPlayer = referee.currentPlayer;

                    play = $@"Where would you like to play  {currentPlayer} Player? :";
                    printBoard(play);
                }

            }

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

            string wLives = "" + (cowBox.getcowsInBox(Symbol.CW));
            string bLives = "" + (cowBox.getcowsInBox(Symbol.CB));

            Console.WriteLine("White player has {0} pieces to place.\nBlack player has {1} pieces to place\n", wLives, bLives);
            Console.WriteLine(dis);
            Console.WriteLine("\n" + message);
        }
    }
}

