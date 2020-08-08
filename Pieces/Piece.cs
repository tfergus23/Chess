using System;
using System.Collections.Generic;
using Chess.Board;

namespace Chess.Pieces
{
    abstract class Piece
    {
        public int x;
        public int y;
        public PieceType type;
        public Player player;
        public Boolean firstTurn = true;

        public PieceType getPieceType()
        {
            return type;
        }

        public Player getPlayer()
        {
            return player;
        }


        //Returns a linked list of valid Coordinates that the piece can be moved to on the given board with the following restrictions
        //  1. It will not give a coordinate that is out of bounds
        //  2. It will not allow pieces to move through each other (with the exception of the knight)
        //  3. It will not allow your king to be in check by the end of the move.
        public abstract LinkedList<Coordinate> getValidMoves(GameBoard board);

        //Same as getValidMoves but doesn't worry about putting the King in check. (1 and 2 but not 3). Used only by the King to check for check.
        public abstract LinkedList<Coordinate> getUntestedMoves(GameBoard board);

        public abstract String ImagePath();
    }
}
