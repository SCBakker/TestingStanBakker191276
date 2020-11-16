using System;
using Chess.Business;

namespace Chess.Models
{
    // Data die de frontend nodig heeft om een veld weer te kunnen geven
    public class Field : IField
    {
        public char Letter => Horizontal;
        public Colour Colour { get; set; }
        public IPiece Piece { get; set; }

        // de horizontale coordinaat van het veld
        public char Horizontal { get; private set; }
        // de verticale coordinaat van het veld
        public int Vertical { get; private set; }
        // de coordinaten van het veld als string
        public string Position => "" + Horizontal + Vertical;
        // het stuk dat op het veld staat (als er een stuk op staat, anders null)
        public bool IsEmpty => Piece == null;
        // een pointer naar het bord waar het veld bijhoort.
        public IBoard Board { get; }

        // constructor
        internal Field(IBoard board, char letter, int number)
        {
            Board = board;
            Init(letter, number);
        }

        // hulpmethod voor de constructor om alle members te zetten
        private void Init(char letter, int number)
        {
            Horizontal = letter;
            Vertical = number;
            Colour = DetermineColour();
            return;
        }

        // dit veld kent zijn verantwoordelijkheden. Het bord hoeft hem niet te vertellen welke kleur hij heeft,
        // dat kan hij zelf wel afleiden van zijn coordinaten!
        private Colour DetermineColour()
        {
            // dus a = 1, b = 2 enz
            var aantal = Horizontal - 'a' + 1;

            // A1 is zwart, A1 is 2
            // dus als ze samen oneven zijn...
            return ((aantal + Vertical) % 2 == 1) ? Colour.White : Colour.Black;
        }

        // override ob object om het mogelijk te maken om velden met elkaar te vergelijken
        // nodig om veld als key te laten werken in een dictionary
        public override bool Equals(object obj)
        {
            return obj is Field field &&
                   Horizontal == field.Horizontal &&
                   Vertical == field.Vertical;
        }

        // override op object om velden snel te kunnen vinden in een hastable
        // nodig om veld als key te laten werken in een dictionary
        public override int GetHashCode()
        {
            return HashCode.Combine(Horizontal, Vertical);
        }

        // utility methode om gemakkelijk van een veld een buurveld te kunnen krijgen
        // heel handig om te bepalen waar een stuk naar toe kan
        public IField GetField(Direction direction)
        {
            // checks
            return direction switch
            {
                Direction.Down => Board.GetField(Horizontal, Vertical - 1),
                Direction.Downleft => Board.GetField((char)(Horizontal - 1), Vertical - 1),
                Direction.Left => Board.GetField((char)(Horizontal - 1), Vertical),
                Direction.Upleft => Board.GetField((char)(Horizontal - 1), Vertical + 1),
                Direction.Up => Board.GetField(Horizontal, Vertical + 1),
                Direction.Upright => Board.GetField((char)(Horizontal + 1), Vertical + 1),
                Direction.Right => Board.GetField((char)(Horizontal + 1), Vertical),
                Direction.Downright => Board.GetField((char)(Horizontal + 1), Vertical - 1),
                Direction.KnightJumpDownLeftBig => GetField(Direction.Downleft)?.GetField(Direction.Left),
                Direction.KnightJumpDownLeftSmall => GetField(Direction.Downleft)?.GetField(Direction.Down),
                Direction.KnightJumpDownRightBig => GetField(Direction.Downright)?.GetField(Direction.Right),
                Direction.KnightJumpDownRightSmall => GetField(Direction.Downright)?.GetField(Direction.Down),
                Direction.KnightJumpUpLeftBig => GetField(Direction.Upleft)?.GetField(Direction.Left),
                Direction.KnightJumpUpLeftSmall => GetField(Direction.Upleft)?.GetField(Direction.Up),
                Direction.KnightJumpUpRightBig => GetField(Direction.Upright)?.GetField(Direction.Right),
                Direction.KnightJumpUpRightSmall => GetField(Direction.Upright)?.GetField(Direction.Down),
                _ => null,
            };
        }
    }
}
