using Chess.Models;
using System.Collections.Generic;

namespace Chess.Business
{
    public interface IBoard
    {
        Colour PlayingNow { get; set; }
        bool CheckCoordinates(char letter, int number);
        IField GetField(char horizontal, int vertical);
        IField GetField(string coordinate);
        bool IsChecked(Colour colour);
        bool MovePiece(string from, string to);
        void StartNewGame();
        (char letter, int number) StringToCoordinates(string coordinate);
        bool TestMoveForCreatingChecked(IField from, IField to);
        List<IField> GetAllFields();
    }
}