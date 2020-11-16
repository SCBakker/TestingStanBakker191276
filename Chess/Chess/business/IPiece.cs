using System.Collections.Generic;

namespace Chess.Business
{
    public interface IPiece
    {
        Colour Colour { get; }
        string Name { get; }
        IField Position { get; set; }
        PieceType Type { get; }
        decimal Value { get; }
        List<IField> CanMoveTo();
        bool MoveTo(IField field);
        bool PlaceOn(IField field, Colour? colour = null);
        void Remove();
    }
}