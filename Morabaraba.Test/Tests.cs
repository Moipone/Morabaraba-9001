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
            // Fix this test
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            int blackCount = p2.CowLives, whiteCount = p1.CowLives;
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
            Assert.That(!flag);
        }
        [Test]
        public void GameEndsWhenP1orP2Has2Cows()
        {
            //Start implementing this.
            Board b = new Board();
            bool flag = false;
            Player p1 = new Player(Symbol.CW);
            Player p2 = new Player(Symbol.CB);
            if (p1.CowLives == 2 || p2.CowLives == 2)
            {
               flag = true;
            }
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
