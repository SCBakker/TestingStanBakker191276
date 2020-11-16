using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Models;

namespace Chess.Business
{
    public class Board : IBoard
    {
        public Dictionary<(char horizontal, int vertical), IField> Fields { get; set; }
        public IPiece WhiteKing { get; set; }
        public IPiece BlackKing { get; set; }
        public Colour PlayingNow { get; set; }
        public IEnumerable<IPiece> AllPieces => this.Fields.Values.Select(f => f.Piece).Where(p => p != null).ToList();
        public IEnumerable<IPiece> AllPiecesOfColour(Colour colour) => AllPieces.Where(p => p.Colour == colour).ToList();

        public const string Letters = "abcdefgh";

        public Board()
        {
            SetupFields();
        }

        public void StartNewGame()
        {
            SetupPieces();
            PlayingNow = Colour.White;
        }

        public IField GetField(char horizontal, int vertical)
        {
            var lower = horizontal.ToString().Single();
            return CheckCoordinates(lower, vertical) ? Fields[(lower, vertical)] : null;
        }

        public IField GetField(string coordinate)
        {
            var (horizontal, vertical) = StringToCoordinates(coordinate);
            var lower = horizontal.ToString().Single();

            return CheckCoordinates(lower, vertical) ? Fields[(lower, vertical)] : null;
        }

        public bool CheckCoordinates(char letter, int number)
        {
            return letter <= 'h' && letter >= 'a' && number > 0 && number < 9;
        }

        public bool IsChecked(Colour colour)
        {
            return colour == Colour.White
                ? AllPiecesOfColour(Colour.Black).SelectMany(p => p.CanMoveTo()).Contains(this.WhiteKing.Position)
                : AllPiecesOfColour(Colour.White).SelectMany(p => p.CanMoveTo()).Contains(this.BlackKing.Position);
        }

        public bool TestMoveForCreatingChecked(IField from, IField to)
        {
            var clone = Clone();
            var piece = clone.GetField(from.Horizontal, from.Vertical).Piece;
            return piece.MoveTo(clone.GetField(to.Horizontal, to.Vertical))
                && !clone.IsChecked(piece.Colour);
        }

        public bool MovePiece(string from, string to)
        {
            var (horizontal, vertical) = StringToCoordinates(from);
            var source = GetField(horizontal, vertical);
            var piece = source.Piece;
            (horizontal, vertical) = StringToCoordinates(to);
            var target = GetField(horizontal, vertical);

            if (piece == null || piece.Colour != PlayingNow || !piece.CanMoveTo().Contains(target) || !TestMoveForCreatingChecked(source, target))
            {
                return false;
            }

            PlayingNow = PlayingNow == Colour.White ? Colour.Black : Colour.White;
            return piece.MoveTo(target);
        }

        public (char letter, int number) StringToCoordinates(string coordinate)
        {
            return (coordinate[0], int.Parse(coordinate[1].ToString()));
        }

        public bool IsCastleAllowed(Colour colour, Direction direction)
        {
            Castle castle;
            switch (colour, direction)
            {
                case (Colour.White, Direction.Left):
                    castle = Castle.LongWhiteCastle(this);
                    break;
                case (Colour.White, Direction.Right):
                    castle = Castle.ShortWhiteCastle(this);
                    break;
                case (Colour.Black, Direction.Left):
                    castle = Castle.LongBlackCastle(this);
                    break;
                case (Colour.Black, Direction.Right):
                    castle = Castle.ShortBlackCastle(this);
                    break;
                default:
                    return false;
            }
            return !(!(castle.King is King king) || king.HasMoved || !(castle.Rook is Rook rook) || rook.HasMoved || castle.MiddleFields.Select(f => f.Piece).Any(p => p != null))
                && !castle.Fields.Any(f => AllPiecesOfColour(colour == Colour.White ? Colour.Black : Colour.White).SelectMany(p => p.CanMoveTo()).Contains(f));
        }

        public void SetupFields()
        {
            var numbers = Enumerable.Range(1, 8);
            Fields = Letters.SelectMany(l => numbers.Select(c => (l, c)))
                .Select(x => (IField)new Field(this, x.l, x.c))
                .ToDictionary(f => (f.Horizontal, f.Vertical), f => f);
        }

        public void SetupPieces()
        {
            var pawn = CreatePiece(Colour.White, PieceType.Pawn);
            var castle = CreatePiece(Colour.White, PieceType.Rook);
            var knight = CreatePiece(Colour.White, PieceType.Knight);
            var bishop = CreatePiece(Colour.White, PieceType.Bishop);
            var queeny = CreatePiece(Colour.White, PieceType.Queen);
            var king = CreatePiece(Colour.White, PieceType.King);

            foreach (var letter in Letters)
            {
                pawn.PlaceOn(Fields[(letter, 2)], Colour.White);
                pawn.PlaceOn(Fields[(letter, 7)], Colour.Black);
            }

            castle.PlaceOn(Fields[('a', 1)], Colour.White);
            castle.PlaceOn(Fields[('h', 1)], Colour.White);
            castle.PlaceOn(Fields[('a', 8)], Colour.Black);
            castle.PlaceOn(Fields[('h', 8)], Colour.Black);

            knight.PlaceOn(Fields[('b', 1)], Colour.White);
            knight.PlaceOn(Fields[('g', 1)], Colour.White);
            knight.PlaceOn(Fields[('b', 8)], Colour.Black);
            knight.PlaceOn(Fields[('g', 8)], Colour.Black);

            bishop.PlaceOn(Fields[('c', 1)], Colour.White);
            bishop.PlaceOn(Fields[('f', 1)], Colour.White);
            bishop.PlaceOn(Fields[('c', 8)], Colour.Black);
            bishop.PlaceOn(Fields[('f', 8)], Colour.Black);

            queeny.PlaceOn(Fields[('d', 1)], Colour.White);
            queeny.PlaceOn(Fields[('d', 8)], Colour.Black);

            king.PlaceOn(Fields[('e', 1)], Colour.White);
            king.PlaceOn(Fields[('e', 8)], Colour.Black);

            BlackKing = GetField("e8").Piece;
            WhiteKing = GetField("e1").Piece;
        }

        public List<IField> GetAllFields()
        {
            return Fields.Values.ToList();
        }

        public Board Clone()
        {
            var bord = new Board();
            var allPieces = AllPieces;
            foreach (var piece in allPieces)
            {
                var newPiece = CreatePiece(piece.Colour, piece.Type);
                switch (piece)
                {
                    case King king:
                        ((King)newPiece).HasMoved = king.HasMoved;
                        break;
                    case Rook rook:
                        ((Rook)newPiece).HasMoved = rook.HasMoved;
                        break;
                }

                var volgendVeld = bord.GetField(piece.Position.Horizontal, piece.Position.Vertical);
                newPiece.PlaceOn(volgendVeld);
            }
            bord.WhiteKing = bord.GetField(WhiteKing.Position.Position).Piece;
            bord.BlackKing = bord.GetField(BlackKing.Position.Position).Piece;
            return bord;
        }

        // factorymethod om stukken te maken.
        // De method krijgt de kleur en het soort stuk mee en bepaald dan zelf welke implementatie van IPiece teruggegeven moet worden.
        public static IPiece CreatePiece(Colour colour, PieceType type)
        {
            return type switch
            {
                PieceType.Pawn => (IPiece) new Pawn(colour),
                PieceType.Rook => new Rook(colour),
                PieceType.Knight => new Knight(colour),
                PieceType.Bishop => new Bishop(colour),
                PieceType.Queen => new Queen(colour),
                PieceType.King => new King(colour),
                _ => throw new Exception("type doe not exist"),
            };
        }
    }
}