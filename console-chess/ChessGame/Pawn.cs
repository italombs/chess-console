﻿using board;

namespace ChessGame
{
    internal class Pawn : Piece
    {
        public Pawn(Color color, Board board) : base(color, board) { }

        public override string ToString()
        {
            return "P";
        }
    }
}