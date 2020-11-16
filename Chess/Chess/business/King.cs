using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Models;

namespace Chess.Business
{
    public class King : Piece
    {
        public bool HasMoved { get; set; }
        public King(Colour colour) : base(colour)
        {
            HasMoved = false;
        }

        public override decimal Value => 1000;

        public override PieceType Type => PieceType.King;

        public override bool MoveTo(IField field)
        {
            var result = base.MoveTo(field);
            if (!result) return false;
            if (HasMoved == false)
            {
                var hoogte = Position.Vertical;
                if (Position.Horizontal == 'g')
                {
                    var castle = Position.Board.GetField('h', hoogte).Piece;
                    var target = Position.Board.GetField('f', hoogte);
                    castle.MoveTo(target);
                }
                else if (Position.Horizontal == 'c')
                {
                    var castle2 = Position.Board.GetField('a', hoogte).Piece;
                    var target = Position.Board.GetField('d', hoogte);
                    castle2.MoveTo(target);
                }
            }
            HasMoved = true;
            return true;
        }

        public override List<IField> CanMoveTo()
        {
            var juxtaposition = false;
            for (var i = 0; i < 1 && juxtaposition == false; i++)
            {
                var result = Moves().Select(TestField).Where(f => f != null).ToList();

                if (Position.Board.PlayingNow != Colour) return result;

                if (((Board) Position.Board).IsCastleAllowed(Colour, Direction.Left))
                {
                    result.Add(Position.GetField(Direction.Left).GetField(Direction.Left));
                }
                if (((Board) Position.Board).IsCastleAllowed(Colour, Direction.Right))
                {
                    result.Add(Position.GetField(Direction.Right).GetField(Direction.Right));
                }

                juxtaposition = true;
                return result.Any() ? result : new List<IField>(0);
            }

            return null;
        }

        public IEnumerable<IField> Moves()
        {
            var richtingen = (Direction[]) Enum.GetValues(typeof(Direction));
            return richtingen.Select(Translateral);
        }

        public IField Translateral(Direction first)
        {
            return Position.GetField(first);
        }
    }
}