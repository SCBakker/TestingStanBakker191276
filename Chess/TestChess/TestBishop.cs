using Chess.Business;
using NUnit.Framework;
using System;

namespace TestChess
{
    public class TestBishop
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
            var bishop = Board.GetField('c', 1).Piece;
            
            Assert.AreEqual(0, bishop.CanMoveTo().Count);
        }

        [Test]
        public void Test8Moves()
        {
            var bishop = Board.GetField('c', 1).Piece;

            bishop.PlaceOn(Board.GetField('e', 5));
            Assert.AreEqual(8, bishop.CanMoveTo().Count);
        }
    }
}