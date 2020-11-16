using System.Collections.Generic;
using System.Linq;
using Chess.Models;

namespace Chess.Business
{
    public class Bishop : Piece
    {
        public Bishop(Colour colour) : base(colour)
        {
        }

        public override decimal Value => 3;

        public override PieceType Type => PieceType.Bishop;

        public override List<IField> CanMoveTo()
        {
            var velden = new List<IField>();
            {
                IField volgendVeld = Position;
                for (int i = 0; i < 7; i++)
                {
                    volgendVeld = volgendVeld.GetField(Direction.Upleft);
                    if (volgendVeld == null)
                    {
                        break;
                    }
                    if (volgendVeld != null && volgendVeld.Piece == null)
                    {
                        velden.Add(volgendVeld);
                    }
                    if (volgendVeld?.Piece == null || volgendVeld.Piece.Colour == Colour)
                    {
                        continue;
                    }
                    if(!velden.Contains(volgendVeld)) velden.Add(volgendVeld);
                    break;
                }
                volgendVeld = Position;

                for (int i = 0; i < 7; i++)
                {
                    volgendVeld = volgendVeld.GetField(Direction.Upright);
                    if (volgendVeld == null)
                    {
                        break;
                    }
                    if (volgendVeld != null && volgendVeld.Piece == null)
                    {
                        velden.Add(volgendVeld);
                    }
                    if (volgendVeld?.Piece == null || volgendVeld.Piece.Colour == Colour)
                    {
                        continue;
                    }
                    if (!velden.Contains(volgendVeld)) velden.Add(volgendVeld);
                    break;
                }
                volgendVeld = Position;

                for (int i = 0; i < 7; i++)
                {
                    volgendVeld = volgendVeld.GetField(Direction.Downright);
                    if (volgendVeld == null)
                    {
                        break;
                    }
                    if (volgendVeld != null && volgendVeld.Piece == null)
                    {
                        velden.Add(volgendVeld);
                    }
                    if (volgendVeld?.Piece == null || volgendVeld.Piece.Colour == Colour)
                    {
                        continue;
                    }
                    if (!velden.Contains(volgendVeld)) velden.Add(volgendVeld);
                    break;
                }
                volgendVeld = Position;

                for (int i = 0; i < 7; i++)
                {
                    volgendVeld = volgendVeld.GetField(Direction.Downleft);
                    if (volgendVeld == null)
                    {
                        break;
                    }
                    if (volgendVeld != null && volgendVeld.Piece == null)
                    {
                        velden.Add(volgendVeld);
                    }
                    if (volgendVeld?.Piece == null || volgendVeld.Piece.Colour == Colour)
                    {
                        continue;
                    }
                    if (!velden.Contains(volgendVeld)) velden.Add(volgendVeld);
                    break;
                }
                return velden;
            }
        }
    }
}
