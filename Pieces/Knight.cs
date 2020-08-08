using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess.Pieces
{
    class Knight : Piece
    {
        public Knight(int x, int y, Player playerNum)
        {
            this.x = x;
            this.y = y;
            type = PieceType.Knight;
            player = playerNum;
        }

        public override LinkedList<Coordinate> getValidMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();
            int i;
            int j;

            //Right up
            i = x + 2;
            j = y + 1;
            if (i <= 7 && j <= 7 && !(board.isOccupied(i,j) && board.getSpace(i,j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }

            //Up Right
            i = x + 1;
            j = y + 2;
            if (i <= 7 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            //Up Left
            i = x - 1;
            j = y + 2;
            if (i >= 0 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            //Left Up
            i = x - 2;
            j = y + 1;
            if (i >= 0 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            //Left Down
            i = x - 2;
            j = y - 1;
            if (i >= 0 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            //Down Left
            i = x - 1;
            j = y - 2;
            if (i >= 0 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            //Down Right
            i = x + 1;
            j = y - 2;
            if (i <= 7 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            //Right Down
            i = x + 2;
            j = y - 1;
            if (i <= 7 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
            }
            return result;
        }

        public override LinkedList<Coordinate> getUntestedMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();
            int i;
            int j;

            //Right up
            i = x + 2;
            j = y + 1;
            if (i <= 7 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }

            //Up Right
            i = x + 1;
            j = y + 2;
            if (i <= 7 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            //Up Left
            i = x - 1;
            j = y + 2;
            if (i >= 0 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            //Left Up
            i = x - 2;
            j = y + 1;
            if (i >= 0 && j <= 7 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            //Left Down
            i = x - 2;
            j = y - 1;
            if (i >= 0 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            //Down Left
            i = x - 1;
            j = y - 2;
            if (i >= 0 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            //Down Right
            i = x + 1;
            j = y - 2;
            if (i <= 7 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            //Right Down
            i = x + 2;
            j = y - 1;
            if (i <= 7 && j >= 0 && !(board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player))
            {
                result.AddLast(new Coordinate(i, j));
            }
            return result;
        }

        public override string ImagePath()
        {
            if (player == Player.Player1)
            {
                return @"/Images/Pieces/white_knight.png";
            }
            else
            {
                return @"/Images/Pieces/black_knight.png";
            }
        }
    }
}
