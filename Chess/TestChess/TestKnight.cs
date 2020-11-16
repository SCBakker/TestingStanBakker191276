using Chess.Business;
using NUnit.Framework;
using System;

namespace TestChess
{
    public class TestKnight
    {
        private Board Board { get; set; }

        [SetUp]
        public void Setup()
        {
            Board = new Board();
        }

        [Test]
        public void TestStartPosition()
        {
            Board.StartNewGame();
            var knight = Board.GetField('b', 8).Piece;
            Assert.AreEqual(2, knight.CanMoveTo().Count);
        }

        [Test]
        public void Test8Moves()
        {
            var knight = new Knight(Colour.Black);
            knight.PlaceOn(Board.GetField('d', 3));

        }
    }
}