using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void ABoardHas12BlackAnd12WhitePieces()
        {
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            int blackCount = p2.cowLives, whiteCount = p1.cowLives;
            Assert.That(blackCount == 12);
            Assert.That(whiteCount == 12);
        }
        [Test]
        public void ABoardAlwaysStartsBlank()
        {
            //Start implementing this.
            Board b = new Board();
            bool flag = false;
            foreach (Tile t in b.board)
            {
                if (t.cond != null) flag = true; 
            }
            Assert.That(flag);
        }
        [Test]
        public void GameEndsWhenP1orP2Has2Cows()
        {
            //Start implementing this.
            Board b = new Board();
            bool flag = false;
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            if (p1.cowLives == 2 || p2.cowLives == 2)
            {
               flag = true;
            }
            Assert.That(flag);
        }

        [Test]
        public void DarkCowsGoFirst ()
        ///The player with the dark cows is always given a chance to go first
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void CowIsOnlyPlacedOnEmptySpace()
        ///Player should not be able to place piece on an occupied tile
        {
            //This test still has to be fixed.
            Board board = new Board();
            board.updateTile(new Tile("a1", new Piece(Symbol.CB, "a1")));
            bool occupied = false;
            Tile t = null;
            foreach (string pos in board.getPositions())
            {
                // Run a loop with all positions to check if all positions can be placed on a blank
                t = board.getTile(pos);
                if (t.cond == null)
                {
                    occupied = false;
                    break;
                }
            }
            Assert.That(!occupied);
        }

        [Test]
        public void MaxPlacementOf12()
        ///Each player is allowed to place up to 12 cows
        {
            Board b = new Board();
            bool flag = false;
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            if(p1.cowLives==12 && p2.cowLives == 12)
            {
                flag = true;
            }
            //Fix test
            Assert.That(flag);
        }

        [Test]
        public void NoMovingWhenPlacing()
        ///The moving phases of the game is locked, until the player has completed the placing phase
        {
            //Start implementing this.
            Board b = new Board();
            bool moving = true;
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            if(p1.cowLives == 0 && p2.cowLives == 0)
            {
                moving = false;
            }
            Assert.That(moving);
        }

        [Test]
        public void OnlyMoveToNeighbour()
        ///A cow can only move to a position which is adjecent to its current position 
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void MoveIsToEmptyspace()
        ///Player show only be able to move cow to an unoccupied tile
        {
            //Fix test
            bool flag = false;
            Assert.That(!flag);
        }

        [Test]
        public void MovedoesnotChangeCowAmount()
        ///Moving cow from one position to another is not the same as adding or removing a cow from the board 
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void ThreeCowsFlyAnywhere ()
        ///A player with three cows on the board can move the cows to any position
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void MillIsLineOfSameThreeCows()
        ///A mills is formed by three of the same colour cows in a line (Horizontal, vertical and diagonal)
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void MillIsNotLineOfThreeDiffCows()
        ///A mills is not formed by three different colour cows in a line (Horizontal, vertical and diagonal)
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void ConnectedSpaceNoInLine()
        ///its not a mill if Connected Spaces that cows occupy do not form a line
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void OnlyShootonMillCompletion()
        ///Shooting is only possible as soon as the mill is completed (in the same turn) 
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void CantShootCowsInMillunlessNoneElse()
        ///Player cannot shoot a cow in a mill unless all cows are in a mill
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void ShootCowsInMillIfAllAre()
        ///Player can only shoot a cow in a mill if all cows are in a mill
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void CantShootOwnCow()
        ///Player is not allowed to shoot their own cow
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void CantShootEmptySpace ()
        ///Player can only shoot at a Tile that is occupied by enemy's cow
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }

        [Test]
        public void ShotCowsRemoved()
        ///If A player shoots a cow, cow must come off board
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }



        [Test]
        public void YouwonIfenemyCantMove()
        ///If one player cant move on their turn
        {
            //Fix test
            bool flag = false;
            Assert.That(flag);
        }



        static public object[] neighBours =
        {
            //new object [] {Symbol.CB}
        };

      /*  [Test]
        [TestCaseSource(neighBours)]
        public void APieceKnowsItsNeighBours(string pos,string [] expected)
        {

        }*/
    }
}
