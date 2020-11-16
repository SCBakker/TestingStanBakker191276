using System.Collections.Generic;
using System.Linq;
using Chess.Models;

namespace Chess.Business
{
    public class Queen : Piece
    {
        public Queen(Colour colour) : base(colour)
        {
        }

        public override decimal Value => 10;

        public override PieceType Type => PieceType.Queen;

        public override List<IField> CanMoveTo()
        {
            var fields = new[] { Direction.Down, Direction.Left, Direction.Right, Direction.Up, Direction.Downleft, Direction.Downright, Direction.Upleft, Direction.Upright };
            return fields.SelectMany(o => SerialWalk(Position, o)).Where(f => f != null).ToList();
        }
    }
}