using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Board;

namespace Chess.Pieces
{
    class Queen : Piece
    {
        public Queen(int x, int y, Player playerNum)
        {
            this.x = x;
            this.y = y;
            type = PieceType.Queen;
            player = playerNum;
        }

        public override LinkedList<Coordinate> getValidMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();
            int i;
            int j;
            Player enemy;
            if (this.getPlayer() == Player.Player1) enemy = Player.Player2;
            else enemy = Player.Player1;

            //up
            i = x;
            j = y + 1;
            while (j <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                j++;
            }
            //down
            i = x;
            j = y - 1;
            while (j >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                j--;
            }
            //left
            i = x - 1;
            j = y;
            while (i >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i--;
            }
            //right
            i = x + 1;
            j = y;
            while (i <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i++;
            }

            //Up Left
            i = x - 1;
            j = y + 1;
            while (i >= 0 && j <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i--;
                j++;
            }

            //Up right
            i = x + 1;
            j = y + 1;
            while (i <= 7 && j <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i++;
                j++;
            }

            //Down Left
            i = x - 1;
            j = y - 1;
            while (i >= 0 && j >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i--;
                j--;
            }

            //Down Right
            i = x + 1;
            j = y - 1;
            while (i <= 7 && j >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                if (board.movePieceTest(x, y, i, j)) result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i++;
                j--;
            }

            return result;
        }

        public override LinkedList<Coordinate> getUntestedMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();
            int i;
            int j;
            Player enemy;
            if (this.getPlayer() == Player.Player1) enemy = Player.Player2;
            else enemy = Player.Player1;

            //up
            i = x;
            j = y + 1;
            while (j <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                j++;
            }
            //down
            i = x;
            j = y - 1;
            while (j >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                j--;
            }
            //left
            i = x - 1;
            j = y;
            while (i >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i--;
            }
            //right
            i = x + 1;
            j = y;
            while (i <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i++;
            }

            //Up Left
            i = x - 1;
            j = y + 1;
            while (i >= 0 && j <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i--;
                j++;
            }

            //Up right
            i = x + 1;
            j = y + 1;
            while (i <= 7 && j <= 7)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i++;
                j++;
            }

            //Down Left
            i = x - 1;
            j = y - 1;
            while (i >= 0 && j >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i--;
                j--;
            }

            //Down Right
            i = x + 1;
            j = y - 1;
            while (i <= 7 && j >= 0)
            {
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == this.player) break;
                result.AddLast(new Coordinate(i, j));
                if (board.isOccupied(i, j) && board.getSpace(i, j).getPlayer() == enemy) break;
                i++;
                j--;
            }

            return result;
        }

        public override string ImagePath()
        {
            if (player == Player.Player1)
            {
                return @"/Images/Pieces/white_queen.png";
            }
            else
            {
                return @"/Images/Pieces/black_queen.png";
            }
        }
    }
}
