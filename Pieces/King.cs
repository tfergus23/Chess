using System;
using System.Collections.Generic;
using Chess.Board;

namespace Chess.Pieces
{
    class King : Piece
    {
        public King(int x, int y, Player playerNum)
        {
            this.x = x;
            this.y = y;
            type = PieceType.King;
            player = playerNum;
        }
        //Returns true if the King is currently not in check on the given board;
        //returns false if the king is currently in check on the given board.
        public Boolean amISafe(GameBoard board)
        {
            if (this.getPlayer() == Player.Player1)
            {
                foreach (Piece piece in board.getPlayer2Pieces())
                {
                    if (piece.getUntestedMoves(board).Contains(new Coordinate(x, y)))
                    {
                        return false;
                    }
                }
            }
            else
            {
                foreach (Piece piece in board.getPlayer1Pieces())
                {
                    if (piece.getUntestedMoves(board).Contains(new Coordinate(x, y)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override LinkedList<Coordinate> getValidMoves(GameBoard board)
        {
            LinkedList < Coordinate > result = new LinkedList<Coordinate>();

            //Up
            if (checkSpace(board, x, y +1)) result.AddLast(new Coordinate(x, y + 1));

            //Down
            if (checkSpace(board, x, y - 1)) result.AddLast(new Coordinate(x, y - 1));

            //Left
            if (checkSpace(board, x - 1, y)) result.AddLast(new Coordinate(x-1,y));

            //Right
            if (checkSpace(board, x + 1, y)) result.AddLast(new Coordinate(x + 1, y));

            //Up-Left
            if (checkSpace(board, x - 1, y + 1)) result.AddLast(new Coordinate(x - 1, y+1));

            //Up-Right
            if (checkSpace(board, x + 1, y + 1)) result.AddLast(new Coordinate(x + 1, y+1));

            //Down-Left
            if (checkSpace(board, x - 1, y - 1)) result.AddLast(new Coordinate(x - 1, y - 1));

            //Down-Right
            if (checkSpace(board, x + 1, y - 1)) result.AddLast(new Coordinate(x + 1, y - 1));

            //Castling Left
            if (this.firstTurn &&
                board.getSpace(x - 4, y) != null &&
                board.getSpace(x - 4, y).getPieceType() == PieceType.Rook &&
                board.getSpace(x - 1, y) == null && board.movePieceTest(x, y, x - 1, y) &&
                board.getSpace(x - 2,y) == null && board.movePieceTest(x, y, x - 2, y) &&
                board.getSpace(x - 3, y) == null && board.movePieceTest(x, y, x - 3, y) &&
                board.getSpace(x - 4, y).firstTurn &&
                this.amISafe(board)
            )
            {
                result.AddLast(new Coordinate(x - 2, y));
            }

            //Castling Right
            if (this.firstTurn &&
                board.getSpace(x + 3, y) != null &&
                board.getSpace(x + 3, y).getPieceType() == PieceType.Rook &&
                board.getSpace(x + 1, y) == null && board.movePieceTest(x, y, x + 1, y) &&
                board.getSpace(x + 2,y) == null && board.movePieceTest(x, y, x + 2, y) &&
                board.getSpace(x + 3, y).firstTurn &&
                this.amISafe(board)
            )
            {
                result.AddLast(new Coordinate(x + 2, y));
            }

            return result;
        }

        public override LinkedList<Coordinate> getUntestedMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();

            //Up
            if (untestedCheckSpace(board, x, y + 1)) result.AddLast(new Coordinate(x, y + 1));

            //Down
            if (untestedCheckSpace(board, x, y - 1)) result.AddLast(new Coordinate(x, y - 1));

            //Left
            if (untestedCheckSpace(board, x - 1, y)) result.AddLast(new Coordinate(x - 1, y));

            //Right
            if (untestedCheckSpace(board, x + 1, y)) result.AddLast(new Coordinate(x + 1, y));

            //Up-Left
            if (untestedCheckSpace(board, x - 1, y + 1)) result.AddLast(new Coordinate(x - 1, y + 1));

            //Up-Right
            if (untestedCheckSpace(board, x + 1, y + 1)) result.AddLast(new Coordinate(x + 1, y + 1));

            //Down-Left
            if (untestedCheckSpace(board, x - 1, y - 1)) result.AddLast(new Coordinate(x - 1, y - 1));

            //Down-Right
            if (untestedCheckSpace(board, x + 1, y - 1)) result.AddLast(new Coordinate(x + 1, y - 1));
            /*
            //Castling Left
            if (this.firstTurn &&
                board.getSpace(x - 1, y) == null && board.movePieceTest(x, y, x - 1, y) &&
                board.getSpace(x - 2, y) == null && board.movePieceTest(x, y, x - 2, y) &&
                board.getSpace(x - 3, y) == null && board.movePieceTest(x, y, x - 3, y) &&
                board.getSpace(x - 4, y) != null &&
                board.getSpace(x - 4, y).getPieceType() == PieceType.Rook &&
                board.getSpace(x - 4, y).firstTurn &&
                this.amISafe(board)
            )
            {
                result.AddLast(new Coordinate(x - 2, y));
            }

            //Castling Right
            if (this.firstTurn &&
                board.getSpace(x + 1, y) == null && board.movePieceTest(x, y, x + 1, y) &&
                board.getSpace(x + 2, y) == null && board.movePieceTest(x, y, x + 2, y) &&
                board.getSpace(x + 3, y) != null &&
                board.getSpace(x + 3, y).getPieceType() == PieceType.Rook &&
                board.getSpace(x + 3, y).firstTurn &&
                this.amISafe(board)
            )
            {
                result.AddLast(new Coordinate(x + 2, y));
            }
            */

            return result;
        }

        public override string ImagePath()
        {
            if (player == Player.Player1)
            {
                return @"/Images/Pieces/white_king.png";
            }
            else
            {
                return @"/Images/Pieces/black_king.png";
            }
        }

        private Boolean checkSpace(GameBoard board, int destX, int destY)
        {
            if (inBounds(destX, destY))
            {
                Piece dest = board.getSpace(destX, destY);
                return (dest == null || (dest != null && dest.getPlayer() != this.getPlayer())) && board.movePieceTest(x, y, destX, destY);
            }
            else
            {
                return false;
            }
        }

        private Boolean untestedCheckSpace(GameBoard board, int destX, int destY)
        {
            if (inBounds(destX, destY))
            {
                Piece dest = board.getSpace(destX, destY);
                return (dest == null || (dest != null && dest.getPlayer() != this.getPlayer()));
            }
            else
            {
                return false;
            }
        }
        

        
        private static Boolean inBounds(int x, int y)
        {
            return x <= 7 && x >= 0 && y <= 7 && y >= 0;
        }
    }
}
