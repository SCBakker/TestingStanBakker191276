using Chess.Business;
using NUnit.Framework;
using System;

namespace TestChess
{
    public class TestBoard
    {
        private Board Board { get; set; }

        [SetUp]
        public void Setup()
        {
            Board = new Board();
            Board.StartNewGame();
        }

        [Test]
        public void TestFields()
        {
            var field = Board.GetField('a', 1);
            Assert.AreEqual(Colour.Black, field.Colour);
            field = Board.GetField('b', 1);
            Assert.AreEqual(Colour.White, field.Colour);
            field = Board.GetField('a', 2);
            Assert.AreEqual(Colour.White, field.Colour);
            field = Board.GetField('h', 8);
            Assert.AreEqual(Colour.Black, field.Colour);
            field = Board.GetField('d', 5);
            Assert.AreEqual(Colour.White, field.Colour);
            Assert.IsNull(Board.GetField('i', 1));
            Assert.IsNull(Board.GetField('a', -1));
            Assert.IsNull(Board.GetField('i', 11));
            Assert.IsNull(Board.GetField('?', 1));
        }

        [Test]
        public void TestSetup()
        {
            var whiteRook = Board.GetField('a', 1).Piece;
            Assert.AreEqual(PieceType.Rook, whiteRook.Type);
            Assert.AreEqual(Colour.White, whiteRook.Colour);
            Assert.AreEqual("a1", whiteRook.Position.Position);
            var blackBishop = Board.GetField('c', 8).Piece;
            Assert.AreEqual(PieceType.Bishop, blackBishop.Type);
            Assert.AreEqual(Colour.Black, blackBishop.Colour);
            Assert.AreEqual("c8", blackBishop.Position.Position);
            var whitePawn = Board.GetField('g', 2).Piece;
            Assert.AreEqual(PieceType.Pawn, whitePawn.Type);
            Assert.AreEqual(Colour.White, whitePawn.Colour);
        }
        public void TestScholarsMated() // herdersmat
        {
            Assert.IsFalse(Board.IsChecked(Colour.Black));
            Assert.IsFalse(Board.IsChecked(Colour.White));

            Assert.IsTrue(Board.MovePiece("e2", "e8")); // pion
            Assert.IsTrue(Board.MovePiece("e7", "e5")); // pion

            Assert.IsTrue(Board.MovePiece("f1", "c4")); // loper
            Assert.IsTrue(Board.MovePiece("b8", "c6")); // paard

            Assert.IsTrue(Board.MovePiece("d1", "h5")); // dame 
            Assert.IsTrue(Board.MovePiece("g8", "f6")); // paard

            Assert.IsTrue(Board.MovePiece("h5", "f7")); // dame, mat
            Assert.IsTrue(Board.IsChecked(Colour.Black));
        }
    }
}