using System.Collections.Generic;
using System.Linq;

namespace Chess.Business
{
    public class Castle
    {
        public IPiece King { get; set; }
        public IPiece Rook { get; set; }
        public List<IField> Fields { get; private set; }
        public List<IField> MiddleFields { get; private set; }

        public Castle(Board board, string king, string rook, params string[] fields)
        {
            var totren = board.GetField(rook);
            var konign = board.GetField(king);

            King = konign.Piece;
            Rook = totren.Piece;
            MiddleFields = fields.Select(f => board.GetField(f)).ToList();
            Fields = new List<IField>();
            Fields.AddRange(MiddleFields);
            Fields.Add(konign);
            Fields.Add(totren);
        }

        public static Castle ShortWhiteCastle(Board board)
        {
            return new Castle(board, "e1", "h1", "f1", "g1");
        }

        public static Castle ShortBlackCastle(Board board)
        {
            return new Castle(board, "e8", "h8", "f8", "g8");
        }

        public static Castle LongWhiteCastle(Board board)
        {
            return new Castle(board, "e1", "h1", "b1", "c1", "d1");
        }

        public static Castle LongBlackCastle(Board board)
        {
            return new Castle(board, "e8", "a8", "b8", "c8", "d8");
        }
    }
}