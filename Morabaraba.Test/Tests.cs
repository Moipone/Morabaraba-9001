using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using NSubstitute;

namespace Morabaraba.Test
{
    [TestFixture]
    public class Class1
    {
        //"a1", "a4","a7",
        //                       "b2","b4","b6",
        //                       "c3", "c4", "c5",
        //                       "d1", "d2", "d3",
        //                       "d5", "d6","d7",
        //                       "e3","e4","e5",
        //                       "f2","f4", "f6",
        //                       "g1", "g4","g7"};


        static public object[] userInput =
        {
            new object [] {1, new string[] { "a1" }     },
            new object [] {2, new string[] { "b4" }     },
            new object [] {3, new string[] { "b6" }     },
            new object [] {4, new string[] { "c3" }     },
            new object [] {5, new string[] { "c4" }     },
            new object [] {6, new string[] { "c5" }     },
            new object [] {7, new string[] { "d1" }     },
            new object [] {8, new string[] { "d2" }     },
            new object [] {9, new string[] { "d3" }     },
            new object [] {10, new string[] { "d5" }     },
            new object [] {11, new string[] { "d6" }     },
            new object [] {12, new string[] { "d7" }     },
            new object [] {13, new string[] { "e3" }     },
            new object [] {14, new string[] { "e4" }     },
            new object [] {15, new string[] { "e5" }     },
            new object [] {16, new string[] { "f2" }     },
            new object [] {17, new string[] { "f4" }     },
            new object [] {18, new string[] { "f6" }     },
            new object [] {19, new string[] { "g1" }     },
            new object [] {20, new string[] { "g4" }     },
            new object [] {21, new string[] { "g7" }     },
            new object [] {22, new string[] { "b2" }     },
            new object [] {23, new string[] { "a4" }     },
            new object [] {24, new string[] { "a7" }     },

        };

        static public object[] lineOfThree =
        {
            new object [] { new string[] { "a1", "a4", "a7" } },
            new object [] { new string[] { "a1", "d1", "g1" } },
            new object [] { new string[] { "a7", "b6", "c5" } },
            new object [] { new string[] { "c3", "c4", "c5" } },
            new object [] { new string[] { "b2", "d2", "f2" } },
            new object [] { new string[] { "c3", "d3", "e3" } },
            new object [] { new string[] { "e4", "f4", "g4" } },
            new object [] { new string[] { "e5", "f6", "g7" } },
            new object [] { new string[] { "e3", "f2", "g1" } },
            new object [] { new string[] { "b2", "b4", "b6" } },
            new object [] { new string[] { "a1", "b2", "c3" } },
            new object [] { new string[] { "a4", "b4", "c4" } },
            new object [] { new string[] { "a7", "d7", "g7" } },
            new object [] { new string[] { "d1", "d2", "d3" } },
            new object [] { new string[] { "d5", "d6", "d7" } },
            new object [] { new string[] { "b6", "d6", "f6" } },
            new object [] { new string[] { "f2", "f4", "f6" } },
            new object [] { new string[] { "g1", "g4", "g7" } },
            new object [] { new string[] { "e3", "e4", "e5" } },
            new object [] { new string[] { "c5", "d5", "e5" } },
        };


        static public object[] neighBours =
       {
            new object [] {"a1", new string[] { "d1", "b2", "a4" }     },
            new object [] {"a4", new string[] { "a1", "a7", "b4" }     },
            new object [] {"a7", new string[] { "d7", "a4", "b6" }     },

            new object [] {"b2", new string[] { "a1", "b4", "c3", "d2" }     },
            new object [] {"b4", new string[] { "b2", "b6", "a4", "c4" }    },
            new object [] {"b6", new string[] { "b4", "c5", "d6", "a7" }    },

            new object [] {"c3", new string[] { "b2", "c4", "d3"       }    },
            new object [] {"c4", new string[] { "c3", "b4", "c5"       }    },
            new object [] {"c5", new string[] { "c4", "d5", "b6"       }    },

            new object [] {"d1", new string[] { "a1", "g1", "d2"       }    },
            new object [] {"d2", new string[] { "d1", "f2", "d3", "b2" }    },
            new object [] {"d3", new string[] { "d2", "e3", "c3"       }    },

            new object [] {"d5", new string[] { "e5", "d6", "c5"       }    },
            new object [] {"d6", new string[] { "d5", "f6", "b6", "d7" }    },
            new object [] {"d7", new string[] { "d6", "g7", "a7"       }    },

            new object [] {"e3", new string[] { "d3", "f2", "e4"       }    },
            new object [] {"e4", new string[] { "e3", "f4", "e5"       }    },
            new object [] {"e5", new string[] { "e4", "f6", "d5"       }    },

            new object [] {"f2", new string[] { "g1", "f4", "e3", "d2" }    },
            new object [] {"f4", new string[] { "f2", "g4", "f6", "e4" }    },
            new object [] {"f6", new string[] { "f4", "g7", "d6", "e5" }    },

            new object [] {"g1", new string[] { "d1", "g4", "f2"       }    },
            new object [] {"g4", new string[] { "g1", "f4", "g7"       }    },
            new object [] {"g7", new string[] { "g4", "f6", "d7"       }    },

            new object [] {"", new string [] {}}
        };


        //[Test]
        //[TestCaseSource(nameof(lineOfThree))]
        //public void AMillIsLineOfSameThree(string pos, string[] MillOfPos)
        //{

        //    //IBoard board = new Board();
        //    IBoard b = Substitute.For<IBoard>();
        //    IPlayer currentPayer = Substitute.For<IPlayer>();
        //    ICowBox cows = Substitute.For<ICowBox>();
        //    //if ((b.getTile().cond.Symbol == currentPayer.symbol)) { };
        //    List<List<string>> allmills = b.allPossibleMills();

        //    //ITile tile = new Tile();

        //    //Act 

        //    //Assert
        //    Assert.AreEqual(MillOfPos, lineOfThree);


        //}

        [Test]
        public void ABoardHas12BlackAnd12WhitePiecesAtStart()
        {
            Player p1 = new Player(Symbol.CB);
            Player p2 = new Player(Symbol.CW);
            ICowBox cowBox = Substitute.For<ICowBox>();
            World world = new World(p1,p2);
            int cowB = world.cowBox.getcowsInBox(p1.symbol);
            int cowW = world.cowBox.getcowsInBox(p2.symbol);
            //int blackCount = b., whiteCount = p1.cowLives;
            Assert.That(cowB == 12);
            Assert.That(cowW == 12);
        }
        [Test]
        public void ABoardAlwaysStartsBlank()
        {
            //Start implementing this.
            Player p1 = new Player(Symbol.CB);
            Player p2 = new Player(Symbol.CW);
            ICowBox cowBox = Substitute.For<ICowBox>();
            //int blackCount = b., whiteCount = p1.cowLives;
            Assert.That(cowBox.getcowsOnBoard(p1.symbol) == 0);
            Assert.That(cowBox.getcowsOnBoard(p2.symbol) == 0);
        }
        [Test]
        public void GameEndsWhenP1orP2Has2Cows()
        {
            //Start implementing this.
            Board b = new Board();
            bool flag1 = false;
            bool flag2 = false;
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            ICowBox cowBox = Substitute.For<ICowBox>();
            //int blackCount = b., whiteCount = p1.cowLives;
            flag1 = ((cowBox.getcowsOnBoard(p1.symbol) < 3) && (((cowBox.getcowsOnBoard(p2.symbol) > 3))));
            flag2 = ((cowBox.getcowsOnBoard(p2.symbol) < 3) && (((cowBox.getcowsOnBoard(p1.symbol) > 3))));
            Assert.That(flag1);
            Assert.That(flag2);
        }

        [Test]
        public void DarkCowsGoFirst()
        ///The player with the dark cows is always given a chance to go first
        {
            //Fix test
            IBoard b = Substitute.For<IBoard>();
            Player p1 = new Player(Symbol.CB);
            Player p2 = new Player(Symbol.CW);
            Symbol currentplayertested = p1.symbol;
            Referee referee2 = new Referee(b, p1.symbol);
            Referee referee1 = new Referee(b, p2.symbol);
            IWorld world = Substitute.For<IWorld>();
            world = new World(p1, p2);
            Symbol currentplayer = world.referee.currentPlayer; 
            Assert.That( currentplayertested == currentplayer);
           
        }

        [Test]
        [TestCaseSource(nameof(userInput))]
        public void EachCowIsOnlyPlacedOnEmptySpace(int position, string [] inputs)
        ///Player should not be able to place piece on an occupied tile
        {
            //This test still has to be fixed.
            IBoard board = Substitute.For<IBoard>();
            IReferee referee = Substitute.For<IReferee>();
            Player p1 = new Player(Symbol.CB);
            Player p2 = new Player(Symbol.CW);
            board = new Board();
            IWorld world = Substitute.For<IWorld>();
            world = new World(p1, p2);
            bool occupied = true;
            foreach (string pos in inputs)
            {
                Tile tile = world.board.getTile(pos);
                if (tile.cond.Symbol == Symbol.BL)
                {
                    occupied = true;
                    Assert.That(!occupied);
                }
            }
            //Assert.That(!occupied);
        }

        [Test]
       
        public void CowIsOnlyPlacedOnEmptySpace()
        {
            Board board = new Board();
            board.updateTile(new Tile("a1", new Piece(Symbol.CB, "a1")));
            bool occupied = false;
            Tile t = null;
            foreach (string pos in board.allPositions())
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

            Player p1 = new Player(Symbol.CB);
            Player p2 = new Player(Symbol.CW);
            ICowBox cowBox = Substitute.For<ICowBox>();
            bool flag1 = false;
            bool flag2 = true;
            IBoard board = Substitute.For<IBoard>();
            IWorld world = Substitute.For<IWorld>();
            world = new World(p1, p2);
            int blackcows = cowBox.getcowsInBox(p1.symbol);
            int whitecows = cowBox.getcowsInBox(p2.symbol);
            if  (p1.Phase == Phase.moving) { if (blackcows == 0) Assert.That(false); }
            if (p2.Phase == Phase.moving) { if (blackcows == 0) Assert.That(false); }

        }

        [Test]
        public void NoMovingWhenPlacing()
        ///The moving phases of the game is locked, until the player has completed the placing phase
        {
            //Start implementing this.
            bool flag1 = false;
            bool flag2 = false;
            Board b = new Board();
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            if (p1.Phase == Phase.flying)
            {
               flag1 =  p1.Phase != Phase.moving;
            }

            if (p2.Phase == Phase.flying)
            {
                flag2 = p2.Phase != Phase.moving;
            }

            
            Assert.That(!flag1);
            Assert.That(!flag2);
        }


        [Test]
        [TestCaseSource(nameof(neighBours))]
        public void APieceKnowsItsNeighBours(string pos, string[] expected)
        {

            IBoard board = new Board();
            string[] neighb = board.getNeighbourCells(pos).ToArray();

            Assert.AreEqual(expected, neighb);

        }
    }
}
