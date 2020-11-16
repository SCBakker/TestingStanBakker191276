using Chess.Business;
using NUnit.Framework;
using System;

namespace TestChess
{
    public class TestCastle
    {
        private Board Board { get; set; }

        [SetUp]
        public void Setup()
        {
            Board = new Board();
            Board.StartNewGame();
        }

        
        [Test]
        public void TestDefault()
        {
            Assert.IsFalse(Board.IsCastleAllowed(Colour.White, Direction.Left));
            Assert.IsFalse(Board.IsCastleAllowed(Colour.White, Direction.Right));
            Assert.IsFalse(Board.IsCastleAllowed(Colour.Black, Direction.Left));
            Assert.IsFalse(Board.IsCastleAllowed(Colour.Black, Direction.Right));
            // niet crashen op onmogelijke richting
            Assert.IsFalse(Board.IsCastleAllowed(Colour.White, Direction.Upright));

            Opening();

            Assert.IsTrue(Board.IsCastleAllowed(Colour.White, Direction.Left));
            Assert.IsTrue(Board.IsCastleAllowed(Colour.White, Direction.Right));
        }

        [Test]
        public void TestKingHasMoved()
        {
            Opening();
            var testCanMoveTo = Board.GetField("e1").Piece.CanMoveTo();
            Board.MovePiece("e1", "f1"); // koning
            Assert.IsFalse(Board.IsCastleAllowed(Colour.White, Direction.Left));
            Assert.IsFalse(Board.IsCastleAllowed(Colour.White, Direction.Right));
        }

        private void Opening()
        {
            Board.MovePiece("e2", "e4"); // pion
            Board.MovePiece("e7", "e5"); // pion

            Board.MovePiece("b1", "a3"); // paard
            Board.MovePiece("g8", "f6"); // paard

            Board.MovePiece("f1", "c4"); // loper
            Board.MovePiece("f8", "c5"); // loper

            Board.MovePiece("d2", "d3"); // pion
            Board.MovePiece("d7", "d6"); // pion

            Board.MovePiece("g1", "f3"); // paard
            Board.MovePiece("b8", "c6"); // paard

            Board.MovePiece("c1", "g5"); // loper
            Board.MovePiece("c8", "g4"); // loper

            Board.MovePiece("d1", "d2"); // dame
            Board.MovePiece("d8", "d7"); // dame

            // beide roccades zijn nu mogelijk
        }
    }
}