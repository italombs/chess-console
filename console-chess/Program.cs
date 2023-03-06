using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using board;
using chessGame;

namespace console_chess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame chessGame = new ChessGame();

                while (!chessGame.EndGame)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintBoard(chessGame.Board);

                        Console.WriteLine();
                        Console.WriteLine("Move: " + chessGame.Move);
                        Console.WriteLine("Wainting player: " + chessGame.CurrentPlayerColor);

                        Console.WriteLine();
                        Console.Write("Enter initial position: ");
                        Position initialPosition = Screen.ReadChessPosition().ToPosition();

                        chessGame.ValidateStartingPosition(initialPosition);

                        bool[,] possiblesMoves = chessGame.Board.GetPiece(initialPosition).PossiblesMoves();

                        Console.Clear();
                        Screen.PrintBoard(chessGame.Board, possiblesMoves);

                        Console.WriteLine();
                        Console.Write("Enter final position: ");
                        Position finalPosition = Screen.ReadChessPosition().ToPosition();

                        chessGame.ValidateDestinationPosition(initialPosition, finalPosition);

                        chessGame.ExecuteMove(initialPosition, finalPosition);
                    }
                    catch (BoardException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
