using System.Collections.Generic;
using System.Linq;
using Chess.Models;

namespace Chess.Business
{
    public class Knight : Piece
    {
        public Knight(Colour colour) : base(colour)
        {
        }

        public override decimal Value => 3;

        public override PieceType Type => PieceType.Knight;

        public override List<IField> CanMoveTo()
        {
            var fields = new List<IField>();

            var knightJumpDownLeftBigField = Position.GetField(Direction.KnightJumpDownLeftBig);
            var knightJumpDownLeftSmallField = Position.GetField(Direction.KnightJumpDownLeftSmall);
            var knightJumpDownRightBigField = Position.GetField(Direction.KnightJumpDownRightBig);
            var knightJumpDownRightSmallField = Position.GetField(Direction.KnightJumpDownRightSmall);
            var knightJumpUpLeftBigField = Position.GetField(Direction.KnightJumpUpLeftBig);
            var knightJumpUpLeftSmallField = Position.GetField(Direction.KnightJumpUpLeftSmall);
            var knightJumpUpRightBigField = Position.GetField(Direction.KnightJumpUpRightBig);
            var knightJumpUpRightSmallField = Position.GetField(Direction.KnightJumpUpRightSmall);

            if (Colour == Colour.White)
            {
                if (knightJumpDownLeftBigField != null)
                {
                    if (knightJumpDownLeftBigField.Piece != null)
                    {
                        if (knightJumpDownLeftBigField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpDownLeftBigField);
                    }
                    else
                    {
                        fields.Add(knightJumpDownLeftBigField);
                    }
                }
                if (knightJumpDownLeftSmallField != null)
                {
                    if (knightJumpDownLeftSmallField.Piece != null)
                    {
                        if (knightJumpDownLeftSmallField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpDownLeftSmallField);
                    }
                    else
                    {
                        fields.Add(knightJumpDownLeftSmallField);
                    }
                }
                if (knightJumpDownRightBigField != null)
                {
                    if (knightJumpDownRightBigField.Piece != null)
                    {
                        if (knightJumpDownRightBigField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpDownRightBigField);
                    }
                    else
                    {
                        fields.Add(knightJumpDownRightBigField);
                    }
                }
                if (knightJumpDownRightSmallField != null)
                {
                    if (knightJumpDownRightSmallField.Piece != null)
                    {
                        if (knightJumpDownRightSmallField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpDownRightSmallField);
                    }
                    else
                    {
                        fields.Add(knightJumpDownRightSmallField);
                    }
                }
                if (knightJumpUpLeftBigField != null)
                {
                    if (knightJumpUpLeftBigField.Piece != null)
                    {
                        if (knightJumpUpLeftBigField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpUpLeftBigField);
                    }
                    else
                    {
                        fields.Add(knightJumpUpLeftBigField);
                    }
                }
                if (knightJumpUpLeftSmallField != null)
                {
                    if (knightJumpUpLeftSmallField.Piece != null)
                    {
                        if (knightJumpUpLeftSmallField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpUpLeftSmallField);
                    }
                    else
                    {
                        fields.Add(knightJumpUpLeftSmallField);
                    }
                }
                if (knightJumpUpRightBigField != null)
                {
                    if (knightJumpUpRightBigField.Piece != null)
                    {
                        if (knightJumpUpRightBigField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpUpRightBigField);
                    }
                    else
                    {
                        fields.Add(knightJumpUpRightBigField);
                    }
                }
                if (knightJumpUpRightSmallField != null)
                {
                    if (knightJumpUpRightSmallField.Piece != null)
                    {
                        if (knightJumpUpRightSmallField.Piece.Colour != Colour.White)
                            fields.Add(knightJumpUpRightSmallField);
                    }
                    else
                    {
                        fields.Add(knightJumpUpRightSmallField);
                    }
                }
            }
            if (Colour != Colour.Black) return fields;
            if (knightJumpDownLeftBigField != null && (knightJumpDownLeftBigField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpDownLeftBigField);
            if (knightJumpDownLeftSmallField != null && (knightJumpDownLeftSmallField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpDownLeftSmallField);
            if (knightJumpDownRightBigField != null && (knightJumpDownRightBigField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpDownRightBigField);
            if (knightJumpDownRightSmallField != null && (knightJumpDownRightSmallField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpDownRightSmallField);
            if (knightJumpUpLeftBigField != null && (knightJumpUpLeftBigField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpUpLeftBigField);
            if (knightJumpUpLeftSmallField != null && (knightJumpUpLeftSmallField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpUpLeftSmallField);
            if (knightJumpUpRightBigField != null && (knightJumpUpRightBigField?.Piece?.Colour ?? Colour.White) == Colour.White)
                fields.Add(knightJumpUpRightBigField);
            if (knightJumpUpRightSmallField == null) return fields;
            if (knightJumpUpRightSmallField.Piece == null) {fields.Add(knightJumpUpRightSmallField); return fields;}
            if (knightJumpUpRightSmallField.Piece.Colour != Colour.Black) fields.Add(knightJumpUpRightSmallField);
            return fields;
        }
    }
}