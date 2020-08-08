using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Pieces;

namespace Chess.Board
{
    class RookCoord
    {
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
