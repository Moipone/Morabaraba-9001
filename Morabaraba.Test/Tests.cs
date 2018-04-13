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
            Board b = new Board();
            int blackCount = 0, whiteCount = 0;
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
                if (t.condition != null) flag = true; 
            }
            Assert.That(!flag);
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
