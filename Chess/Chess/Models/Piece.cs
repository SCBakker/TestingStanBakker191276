using System;
using System.Collections.Generic;
using Chess.Business;

namespace Chess.Models
{
    // Data die de frontend nodig heeft om een stuk weer te kunnen geven
    public class Piece : IPiece
    {
        public virtual PieceType Type { get; set; }
        public Colour Colour { get; set; }
        public virtual decimal Value { get; }
        public string Name => Type.ToString();
        public IField Position { get; set; }

        public virtual List<IField> CanMoveTo()
        {
            return null;
        }
        public virtual bool MoveTo(IField field)
        {
            field.Piece = this;
            if (field.Piece.Position.Piece == this)
            {
                Position.Piece = null;
                Position = field;
            }

            Position.Piece = this;
            return true;
        }

        public bool PlaceOn(IField field, Colour? colour = null)
        {
            if (colour != null)
            {
                var jake = this.Type switch
                {
                    PieceType.Pawn => (IPiece)new Pawn(colour.Value),
                    PieceType.Rook => new Rook(colour.Value),
                    PieceType.Knight => new Knight(colour.Value),
                    PieceType.Bishop => new Bishop(colour.Value),
                    PieceType.Queen => new Queen(colour.Value),
                    PieceType.King => new King(colour.Value),
                    _ => throw new Exception("foutje bedankt!"),
                };
                field.Piece = jake;
                jake.Position = field;
            }
            else
            {
                field.Piece = this;
                Position = field;
            }

            return true;
        }

        public void Remove()
        {
            throw new NotImplementedException("Heb ik niet nodig");
        }

        protected Piece(Colour colour)
        {
            this.Colour = colour;
        }

        // als je recursie begrijpt is de volgende zin waar
        // als je recursie niet begrijpt is de vorige zin niet waar
        public List<IField> SerialWalk(IField field, Direction dir)
        {
            var theField = field.GetField(dir);
            if (theField == null || theField.Piece != null && theField.Piece.Colour == Colour)
            {
                return new List<IField>();
            }
            if (theField.Piece != null)
            {
                return new List<IField> { theField };
            }
            var result = SerialWalk(theField, dir);
            result.Add(theField);
            return result;
        }

        public virtual IField TestField(IField field)
        {
            return field == null || (field.Piece != null && field.Piece.Colour == this.Colour) ? null : field;
        }
    }
}