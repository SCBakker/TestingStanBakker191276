using System.Collections.Generic;
using Chess.Models;

namespace Chess.Business
{
    public class Pawn : Piece
    {
        public Pawn(Colour colour) : base(colour)
        {
        }

        public override decimal Value => 1;

        public override PieceType Type => PieceType.Pawn;

        public override List<IField> CanMoveTo()
        {
            var fields = new List<IField>();

            var colour = Colour.Black;
            var andere = 7;
            var startpostion = 2;
            var nogEenVeld = Position.GetField(Direction.Up);
            var richting = Direction.Up;
            var schuinrechtsveld = Position.GetField(Direction.Upright);
            var schuinlinksveld = Position.GetField(Direction.Upleft);

            if (Colour == Colour.Black)
            {
                colour = Colour.White;
                andere = 1;
                startpostion = 7;
                nogEenVeld = Position.GetField(Direction.Down);
                richting = Direction.Down;
                schuinrechtsveld = Position.GetField(Direction.Downright);
                schuinlinksveld = Position.GetField(Direction.Downleft);
            }

            if (nogEenVeld.Piece == null)
            {
                fields.Add(nogEenVeld);

                if (Position.Vertical == startpostion)
                {
                    var newfieldVertical2 = nogEenVeld.GetField(richting);
                    if (newfieldVertical2 != null && newfieldVertical2.Piece == null)
                    {
                        fields.Add(newfieldVertical2);
                    }
                }
            }

            if (schuinrechtsveld?.Piece != null)
            {
                if (schuinrechtsveld.Piece.Colour == colour)
                {
                    fields.Add(schuinrechtsveld);
                }
            }

            if (schuinlinksveld?.Piece != null)
            {
                if (schuinlinksveld.Piece.Colour == colour)
                {
                    fields.Add(schuinlinksveld);
                }
            }

            if (Position.Vertical != andere) return fields;

            var position = Position;
            this.Position = null;
            var promotion = new Queen(Colour);
            promotion.PlaceOn(position);

            return fields;
        }
    }
}