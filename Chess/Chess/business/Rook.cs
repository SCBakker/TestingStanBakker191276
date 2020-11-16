using System.Collections.Generic;
using System.Linq;
using Chess.Models;

namespace Chess.Business
{
    public class Rook : Piece
    {
        public bool HasMoved { get; set; }
        public Rook(Colour colour) : base(colour)
        {
            HasMoved = false;
        }

        public override decimal Value => 5;

        public override PieceType Type => PieceType.Rook;

        public override List<IField> CanMoveTo()
        {
            var fields = new List<IField>();

            fields.AddRange(TestGeneral(Direction.Up));
            fields.AddRange(TestGeneral(Direction.Left));
            fields.AddRange(TestGeneral(Direction.Down));
            fields.AddRange(TestGeneral(Direction.Right));

            return fields;
        }
        public IEnumerable<IField> TestGeneral(Direction direction)
        {
            var possibleMovements = new List<IField>();
            var thisField = Position.GetField(direction);

            while (thisField != null)
            {
                possibleMovements.Add(thisField);
                thisField = thisField.GetField(direction);
            }

            return TestSpecific(possibleMovements);
        }
        public IEnumerable<IField> TestSpecific(List<IField> fields)
        {
            var options = new List<IField>();

            foreach (var field in fields)
            {
                if (field.Piece == null)
                {
                    options.Add(field);
                }
                else if (field.Piece.Colour != Colour)
                {
                    options.Add(field);
                    break;

                }
                else
                {
                    break;
                }
            }

            return options;
        }

        public override bool MoveTo(IField field)
        {
            var otherPiece = field.Piece;
            if (otherPiece != null)
            {
                field.Piece = null;
                return true;
            }
            else
            {
                field.Piece = null;
                var result = PlaceOn(field);
                if (result)
                {
                    HasMoved = true;
                }
                return result;
            }
        }
    }
}