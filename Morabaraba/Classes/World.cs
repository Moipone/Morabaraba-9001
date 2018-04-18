using System;
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
        int draw = 0;
        int b = 0, w = 0;
        bool flag = false;

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
                Thread.Sleep(1500);
                ValidPos = false;
                return;
            }
            ValidPos = true;
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
            while (player1.cowLives > 0 || player2.cowLives > 0 || mill)
            {
                if (!mill)
                {
                    pos = Console.ReadLine();
                    validatePos(pos);
                    if (!ValidPos) placingPhase();
                }
                if (board.getTile(pos) == null)
                {
                    Console.WriteLine("Invalid move!");
                    runPlay();
                    continue;
                }
                Symbol enemy = board.getTile(pos).cond.Symbol;
                if(enemy != currentPlayer && enemy != Symbol.BL)
                {
                    Console.WriteLine("Invalid move");
                    Thread.Sleep(1500);
                    runPlay();
                    continue;
                }
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
                        //Thread.Sleep(1500);
                        continue;
                    }
                    if (enemy == currentPlayer && enemy != Symbol.BL)
                    {
                        Console.WriteLine("You can't destroy your own player!!!" + "  Please choose an enemy piece!");
                        //Thread.Sleep(1500);
                        continue;
                    }
                    if (!isNotAvailablePieces(getPlayer(enemy)))
                    {
                        if (isInMillPos(tmpPos, getPlayer(enemy)))
                        {
                            Console.WriteLine("You can't shoot a piece in a mill. There are still available pieces to shoot");
                            //Thread.Sleep(1500);
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
                    if (flag) continue;
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
                placingCheck1(pos);
            }
            else
            {
                placingCheck2(pos);
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

        private void placingCheck1(string pos)
        {

            if (board.getTile(pos).cond.Symbol != Symbol.BL && board.getTile(pos).cond.Symbol != currentPlayer && !shift)
            {
                Console.WriteLine("You can't play there, that's an invalid move");
                Console.WriteLine("Where would you like to play");
                Thread.Sleep(1500);
                flag = true;
                return;

            }
            Play(pos, getPlayer(currentPlayer));
            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (getPlayer(currentPlayer).LastPosPlayed.Contains(pos))
                getPlayer(currentPlayer).LastPosPlayed.Remove(pos);

            getPlayer(currentPlayer).LastPosPlayed.Add(pos);
            getPlayer(currentPlayer).cowLives--;
            flag = false;
        }

        

        private void placingCheck2(string pos)
        {
            if (board.getTile(pos).cond.Symbol == currentPlayer)
            {
                Console.WriteLine("You can't play there, that's an invalid move");
                Console.WriteLine("Where would you like to play");
                Thread.Sleep(1500);
                flag = true;
                return;
            }
            if (board.getTile(pos).cond.Symbol != Symbol.BL && !shift)
            {
                Console.WriteLine("You can't play there, that's an invalid move");
                Console.WriteLine("Where would you like to play");
                Thread.Sleep(1500);
                flag = true;
                return;
            }
            Play(pos, getPlayer(currentPlayer));
            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (getPlayer(currentPlayer).LastPosPlayed.Contains(pos))
                getPlayer(currentPlayer).LastPosPlayed.Remove(pos);

            getPlayer(currentPlayer).LastPosPlayed.Add(pos);
            getPlayer(currentPlayer).cowLives--;
            flag = false;

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
        public void playerLoses(Symbol sym)
        {
            if (getPlayerPieces(getPlayer(sym)).Count < 3)
            {
                switchPlayer();
                Console.WriteLine("{0} won!, would you like to play again ? Y/N",currentPlayer);
                string ans = Console.ReadLine();
                if (ans == "Y")
                {
                    clearBoard();
                    board = new Board();
                    World world = new World(new Player(Symbol.CW), new Player(Symbol.CB));
                    printBoard(string.Format("Where would you like to play {0}", currentPlayer));
                    getPlayer(sym).loses = true;
                    return;
                }
            }
        }
        private void checkPhases(IPlayer player1, IPlayer player2)
        {
            //Check if there's no cows left to place, check if there's still more than 3 cows on each side to be on moving phase
            int whitePieces = getPlayerPieces(player1).Count;
            int blackPieces = getPlayerPieces(player2).Count;

            if ((player1.cowLives == 0 && player2.cowLives == 0) && (whitePieces > 3) && (blackPieces > 3))
            {
                if (currentPlayer == Symbol.CW) movingPhase();
                else movingPhase();
            }
            if ((player1.cowLives == 0 && player2.cowLives == 0) && (whitePieces == 3) && (blackPieces > 3))
            {
                player2.Phase = Phase.flying;
                if (currentPlayer == Symbol.CW) return;
                else movingPhase();
            }
            if ((player1.cowLives == 0 && player2.cowLives == 0) && (blackPieces == 3) && (whitePieces > 3))
            {
                player1.Phase = Phase.flying;
                if (currentPlayer == Symbol.CB) return;
                else movingPhase();
            }

            //Both players are now flying.......................................................
            if ((player1.cowLives == 0 && player2.cowLives == 0) && (whitePieces == 3) && (blackPieces == 3))
            {
                player1.Phase = Phase.flying;
                player2.Phase = Phase.flying;
                return;

            }
        }
        private void updateFlying(string pos, string moveTo)
        {
            //Remove the old piece from the board
            turnBlank(pos);
            //Remove the broken mill of the old piece
            RemoveBrokenMill(pos, getPlayer(currentPlayer));
            //Update board
            addPiece(moveTo, getPlayer(currentPlayer));
            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (getPlayer(currentPlayer).LastPosPlayed.Contains(moveTo))
                getPlayer(currentPlayer).LastPosPlayed.Remove(moveTo);
            //Add the new position to player
            getPlayer(currentPlayer).LastPosPlayed.Add(moveTo);

        }

        private void flyMoves(string pos, string moveTo)
        {
            
            Tile tl = board.getTile(pos);
            Tile two = board.getTile(moveTo);
            if (tl.cond.Symbol == Symbol.BL)
            {
                Console.WriteLine("You can't move a blank spot");
                flag = true;
                Thread.Sleep(1500);
                return;
            }
            if (tl.cond.Symbol != currentPlayer)
            {
                Console.WriteLine("You can't move your oponents piece");
                flag = true;
                Thread.Sleep(1500);
                return;
            }
            if (two.cond.Symbol != Symbol.BL)
            {
                Console.WriteLine("You can't move your oponents piece\nPlease move your own piece!");
                flag = true;
                Thread.Sleep(1500);
                return;
            }
            if (two.cond.Symbol == Symbol.BL && moveTo == two.pos)
            {
                // Update the board and game 


                updateFlying(pos, moveTo);
                isMill();
                if (mill)
                {
                    string read = Console.ReadLine();
                    validatePos(read);
                    if (!ValidPos) flyMoves(pos, moveTo);

                    Tile t = board.getTile(read);
                    if (getPlayer(currentPlayer).symbol == t.cond.Symbol)
                    {
                        Console.WriteLine("You can't shoot your own player");
                        Thread.Sleep(1500);
                        flyMoves(pos, moveTo);
                    }
                    //Remove piece
                    turnBlank(read);
                    clearBoard();
                    switchPlayer();
                    printBoard(string.Format("Which peace would you like to move {0}", currentPlayer));
                    return;
                }
            }
            else
            {

                Console.WriteLine(string.Format("To which free space would you like to move {0} ? ", currentPlayer));
                Thread.Sleep(1500);
                return;
            }
        }
        private void flyingPhase()
        {
            string play = "Which piece would you like to move ?";
            int bP = getPlayerPieces(player1).Count;
            int wP = getPlayerPieces(player2).Count;
            if (wP == 3) player1.Phase = Phase.flying;
            if (bP == 3) player2.Phase = Phase.flying;
            while (true)
            {

                flyingHelper();
                clearBoard();
                printBoard(play);

                string pos = Console.ReadLine();

                validatePos(pos);
                if (!ValidPos) continue;

                checkPhases(getPlayer(Symbol.CB), getPlayer(Symbol.CW));
                if (currentPlayer == Symbol.CW && getPlayer(Symbol.CW).Phase == Phase.moving)
                {
                    switchPlayer();
                    continue;
                }

                if (currentPlayer == Symbol.CB && getPlayer(Symbol.CB).Phase == Phase.moving)
                {
                    switchPlayer();
                    continue;
                }

                Console.WriteLine("Where you would you like to move ? {0}", currentPlayer);
                string moveTo = Console.ReadLine();

                validatePos(moveTo);
                if (!ValidPos) continue;

                flyMoves(pos, moveTo);

                playerLoses(Symbol.CB);
                if (getPlayer(Symbol.CB).loses) return;
                playerLoses(Symbol.CW);
                if (getPlayer(Symbol.CW).loses) return;
            }


        }


        public void movingPhase()
        {
            string play = $@"Which piece would you like to move ? {currentPlayer}";
            while (true)
            {
                movingHelper();
                clearBoard();
                printBoard(play);

                string pos = Console.ReadLine();
                validatePos(pos);
                if (!ValidPos) movingPhase();

                checkValidMove(pos);
                if (flag) movingPhase();

                Console.WriteLine("Where you would you like to move ? {0}", currentPlayer);
                string moveTo = Console.ReadLine();

                validatePos(moveTo);
                if (!ValidPos) movingPhase();

                shiftMoves(pos, moveTo);
                int bPieces = getPlayerPieces(player1).Count;
                int wPieces = getPlayerPieces(player2).Count;
                if (bPieces == 3 || wPieces == 3) break;

            }


        }

        private void shiftMoves(string pos, string moveTo)
        {
            Tile tl = board.getTile(pos);
            Tile two = board.getTile(moveTo);
            if (tl.cond.Symbol == Symbol.BL)
            {
                Console.WriteLine("You can't move a blank spot");
                flag = true;
                Thread.Sleep(1500);
                return;
            }
            if (tl.cond.Symbol != currentPlayer)
            {
                Console.WriteLine("You can't move your oponents piece");
                flag = true;
                Thread.Sleep(1500);
                return;
            }
            if (two.cond.Symbol != Symbol.BL)
            {
                Console.WriteLine("You can't move your oponents piece\nPlease move your own piece!");
                flag = true;
                Thread.Sleep(1500);
                return;
            }
            List<string> neighBours = board.getNeighbourCells(pos);
            if (neighBours.Contains(moveTo))
            {
                if (two.cond.Symbol == Symbol.BL && moveTo == two.pos && tl.cond.Symbol != Symbol.BL)
                {
                    //Remove the old piece from the board
                    turnBlank(pos);
                    //Remove the broken mill of the old piece
                    RemoveBrokenMill(pos, getPlayer(currentPlayer));
                    //Update board

                    addPiece(moveTo, getPlayer(currentPlayer));
                    //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
                    if (getPlayer(currentPlayer).LastPosPlayed.Contains(moveTo))
                        getPlayer(currentPlayer).LastPosPlayed.Remove(moveTo);
                    //Add the new position to player
                    getPlayer(currentPlayer).LastPosPlayed.Add(moveTo);
                    isMill();
                    if (mill)
                    {
                        Console.WriteLine("Where you would you like to move ? {0}", currentPlayer);
                        string read = Console.ReadLine();
                        validatePos(read);
                        if (!ValidPos) shiftMoves(pos, moveTo);

                        Tile t = board.getTile(read);
                        if (getPlayer(currentPlayer).symbol == t.cond.Symbol)
                        {
                            Console.WriteLine("You can't shoot your own player");
                            Thread.Sleep(1500);
                            shiftMoves(pos, moveTo);
                        }
                        //Remove piece
                        turnBlank(read);
                        clearBoard();
                        switchPlayer();
                        printBoard(string.Format("Which peace would you like to move {0}", currentPlayer));
                        flag = false;
                        return;
                    }
                    else
                    {
                        clearBoard();
                        switchPlayer();
                        printBoard(string.Format("Which peace would you like to move {0}", currentPlayer));
                    }
                    return;
                }
            }
            else
            {
                int indx = getPlayer(currentPlayer).LastPosPlayed.Count - 1;
                Console.WriteLine(string.Format("To which adjacent, free space would you like to move {0} ? ", getPlayer(currentPlayer).LastPosPlayed[indx]));
                flag = true;
                return;
            }

        }

        private void checkValidMove(string pos)
        {
            Symbol enemy = board.getTile(pos).cond.Symbol;
            if (enemy == Symbol.BL)
            {
                Console.WriteLine("You can't move a blank spot");
                Thread.Sleep(1500);
                flag = true;
                return;
            }
            if (enemy != currentPlayer && enemy != Symbol.BL)
            {
                Console.WriteLine("You can't move your own player!!!  Please choose an enemy piece!");
                Thread.Sleep(1500);
                //Something went wrong, redo by attempting again
                flag = true;
                return;
            }
            flag = false;

        }

        private void movingHelper()
        {
            throw new NotImplementedException();
        }

        private void addPiece(string moveTo, IPlayer player)
        {
            board.updateTile(new Tile(moveTo, new Piece(player.symbol, moveTo)));
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

