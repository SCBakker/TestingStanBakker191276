using Chess.Models;
using System.Collections.Generic;
using System.Linq;

namespace Chess.Business
{
    public class ChessService
    {
        public IBoard Board { get; set; }

        public void StartNewGame()
        {
            Board = new Board();
            Board.StartNewGame();
        }

        public List<Row> GetAllFields
        {
            get
            {
                return Board.GetAllFields().GroupBy(f => f.Vertical).Select(g => new Row
                    {
                        Number = g.Key, Fields = g.Select(f => (Field) f)
                            .OrderBy(f => f.Horizontal).ToList()}).OrderByDescending(r => r.Number).ToList();
            }
        }

        public List<string> CanMoveTo(string selectedField)
        {
            var field = Board.GetField(selectedField);
            return field.Piece.CanMoveTo().Where(f => Board.TestMoveForCreatingChecked(field, f)).Select(f => f.Position).ToList();
        }

        public (bool succes, bool IsChecked) MovePiece(string from, string to)
        {
            return (Board.MovePiece(from, to), Board.IsChecked(PlayingNow));
        }


        public Colour PlayingNow => Board.PlayingNow;
    }
}