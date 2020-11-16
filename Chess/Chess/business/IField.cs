namespace Chess.Business
{
    public interface IField
    {
        IBoard Board { get; }
        Colour Colour { get; }
        char Horizontal { get; }
        int Vertical { get; }
        bool IsEmpty { get; }
        IPiece Piece { get; set; }
        string Position { get; }
        IField GetField(Direction direction);
    }
}