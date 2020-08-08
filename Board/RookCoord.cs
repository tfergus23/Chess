using System;
using Chess.Pieces;

namespace Chess.Board
{
    class RookCoord
    {
        //Triple class used to store attributes of a Rook before being altered by GameBoard.MovePieceTest in order to undo the changes easily.
        public Rook rook;
        public Coordinate coord;
        public Boolean firstTurn;

        public RookCoord(Rook r, Coordinate c, Boolean f)
        {
            rook = r;
            coord = c;
            firstTurn = f;
        }
    }
}
