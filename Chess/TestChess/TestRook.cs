using Chess.Business;
using NUnit.Framework;
using System;

namespace TestChess
{
    public class TestRook
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
            var rook = Board.GetField('a', 1).Piece;
            
            Assert.AreEqual(0, rook.CanMoveTo().Count);
        }

        [Test]
        public void Test8Moves()
        {
            var rook = Board.GetField('a', 1).Piece;

            rook.PlaceOn(Board.GetField('e', 5));
            Assert.AreEqual(11, rook.CanMoveTo().Count);
        }
    }
}