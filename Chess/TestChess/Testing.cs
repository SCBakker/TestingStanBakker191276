using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Chess.Business;
using Chess.Models;
using NUnit.Framework;

namespace TestChess
{
    public class TestSchaakregels
    {
        private Board Board { get; set; }

        [SetUp]
        public void Setup()
        {
            Board = new Board();
            Board.StartNewGame();
        }


        [Test]
        public void TestRandBord()
        {

            Assert.False(Board.MovePiece("h8", "h9")); // kunnen stukken van het bord af?
            Assert.False(Board.MovePiece("a8", "a9"));
            Assert.False(Board.MovePiece("a1", "a0"));
            Assert.False(Board.MovePiece("h2", "i2"));
        }
        [Test]
        public void EigenKleurSlaan()
        {
            Assert.IsFalse(Board.MovePiece("d1", "d2")); // queen slaat pawn eigen kleur. (Wit)
            Assert.IsFalse(Board.MovePiece("d8", "d7")); // queen slaat pawn eigen kleur. (Zwart)
        }

        [Test]
        public void TestRokade()
        {
            // Rokade test voor witte stukken
            var whitekoning = Board.GetField('e', 1).Piece; // positie op bord
            var Whiterook = Board.GetField('h', 1).Piece;
            Board.MovePiece("f1", "d3"); // stukken worden weg gehaald zodat het niet in de weg staat
            Board.MovePiece("g8", "f6");
            Board.MovePiece("g1", "f3");
            Board.MovePiece("b7", "b6");
            Assert.IsTrue(Board.MovePiece("e1", "g1"));
            var whitekoning2 = Board.GetField('g', 1).Piece; // check of de stukken zijn verplaatst
            Assert.AreEqual(PieceType.King, whitekoning2.Type);
            var Whiterook2 = Board.GetField('h', 1).Piece;
            Assert.AreEqual(PieceType.Rook, Whiterook2.Type);

            // Rokade test voor zwarte stukken
            var zwartekoning = Board.GetField('e', 8).Piece; // positie op bord
            var zwarterook = Board.GetField('h', 8).Piece;
            //Board.MovePiece("A2", "A3"); // stukken worden weg gehaald zodat het niet in de weg staat
            Board.MovePiece("f8", "d6"); // stukken worden weg gehaald zodat het niet in de weg staat
            Board.MovePiece("g1", "f3");
            Board.MovePiece("g8", "f6");
            Board.MovePiece("b2", "b4");
            Assert.IsTrue(Board.MovePiece("e8", "g8"));
            var zwartekoning2 = Board.GetField('g', 8).Piece; // check of de stukken zijn verplaatst
            Assert.AreEqual(PieceType.King, zwartekoning2.Type);
            var zwarterook2 = Board.GetField('f', 8).Piece;
            Assert.AreEqual(PieceType.Rook, zwarterook2.Type);
            
        }

        [Test]
        public void TestZelfSchaakZetten()
        {
            // wit zet zichzelf schaak
            Board.MovePiece("e2", "e4"); 
            Board.MovePiece("d7", "d5");
            Board.MovePiece("h2", "h4");
            Board.MovePiece("c8", "g4");
            Assert.False(Board.MovePiece("e1", "e2")); // Koning zou zichzelf nu schaak zetten.
            
            // zwart zet zichzelf schaak
            Board.MovePiece("d2", "d4");
            Board.MovePiece("e7", "e5");
            Board.MovePiece("c1", "g5");
            Assert.False(Board.MovePiece("e8", "e7")); // koning zou zichzelf nu schaak zetten
        }
    }
}
