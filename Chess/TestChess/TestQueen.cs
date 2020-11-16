using Chess.Business;
using NUnit.Framework;
using System;

namespace TestChess
{
    public class TestQueen
    {
        private Board Board { get; set; }

        [SetUp]
        public void Setup()
        {
            Board = new Board();
            Board.StartNewGame();
        }

        [Test]
        public void TestStartPosition()
        {
            var queen = Board.GetField('d', 1).Piece;
            
            Assert.AreEqual(0, queen.CanMoveTo().Count);
        }

        [Test]
        public void Test8Moves()
        {
            var queen = Board.GetField('d', 1).Piece;

            queen.PlaceOn(Board.GetField('e', 5));
            Assert.AreEqual(19, queen.CanMoveTo().Count);
        }
    }
}