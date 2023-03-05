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
                    Console.Clear();
                    Screen.PrintBoard(chessGame.Board);

                    Console.WriteLine("");
                    Console.Write("Enter initial position: ");
                    Position initialPosition = Screen.ReadChessPosition().ToPosition();

                    Console.Write("Enter final position: ");
                    Position finalPosition = Screen.ReadChessPosition().ToPosition();

                    chessGame.ExecuteMovement(initialPosition, finalPosition);

                }

            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
