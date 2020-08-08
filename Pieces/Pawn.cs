using System;
using System.Collections.Generic;
using Chess.Board;

namespace Chess.Pieces
{
    class Pawn : Piece
    {



        public Pawn(int x, int y, Player playerNum)
        {
            this.x = x;
            this.y = y;
            type = PieceType.Pawn;
            player = playerNum;
        }

        public override LinkedList<Coordinate> getValidMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();

            if (this.getPlayer() == Player.Player1)
            {
                if (y + 1 <= 7)
                    
                {
                    //Standard Move
                    if (!board.isOccupied(x, y + 1))
                    {
                        if (board.movePieceTest(x, y, x, y+1)) result.AddLast(new Coordinate(x, y + 1));
                        if (y + 2 <= 7 && !board.isOccupied(x, y+2) && firstTurn)
                        {
                            if (board.movePieceTest(x, y, x, y+2)) result.AddLast(new Coordinate(x, y + 2));
                        }
                    }
                    //Up-Left Capture
                    if (inBounds(x - 1, y + 1) && board.isOccupied(x-1, y + 1) && board.getSpace(x-1, y+1).getPlayer() == Player.Player2)
                    {
                        if (board.movePieceTest(x, y, x-1, y+1)) result.AddLast(new Coordinate(x - 1, y + 1));
                    }
                    //Up-Right Capture
                    if (inBounds(x + 1, y + 1) && board.isOccupied(x+1, y + 1) && board.getSpace(x+1, y+1).getPlayer() == Player.Player2)
                    {
                        if (board.movePieceTest(x, y, x+1, y+1)) result.AddLast(new Coordinate(x + 1, y + 1));
                    }
                    //Up-Right enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x+1 && board.enPassant.y == y + 1)
                    {
                        if (board.movePieceTest(x, y, x + 1, y + 1)) result.AddLast(new Coordinate(x + 1, y + 1));
                    }
                    //Up-Left enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x - 1 && board.enPassant.y == y + 1)
                    {
                        if (board.movePieceTest(x, y, x - 1, y + 1)) result.AddLast(new Coordinate(x - 1, y + 1));
                    }
                }
            }
            else
            {
                if (y - 1 >= 0)

                {
                    //Standard Move
                    if (!board.isOccupied(x, y - 1))
                    {
                        if (board.movePieceTest(x, y, x, y-1)) result.AddLast(new Coordinate(x, y - 1));
                        if (y - 2 >= 0 && !board.isOccupied(x, y - 2) && firstTurn)
                        {
                            if (board.movePieceTest(x, y, x, y-2)) result.AddLast(new Coordinate(x, y - 2));
                        }
                    }
                    //Down-Left Capture
                    if (inBounds(x-1,y-1) && board.isOccupied(x - 1, y - 1) && board.getSpace(x - 1, y - 1).getPlayer() == Player.Player1)
                    {
                        if (board.movePieceTest(x, y, x-1, y-1)) result.AddLast(new Coordinate(x - 1, y - 1));
                    }
                    //Down-Right Capture
                    if (inBounds(x + 1, y - 1) && board.isOccupied(x + 1, y - 1) && board.getSpace(x + 1, y - 1).getPlayer() == Player.Player1)
                    {
                        if (board.movePieceTest(x, y, x+1, y-1)) result.AddLast(new Coordinate(x + 1, y - 1));
                    }
                    //Down-Right enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x + 1 && board.enPassant.y == y - 1)
                    {
                        if (board.movePieceTest(x, y, x + 1, y - 1)) result.AddLast(new Coordinate(x + 1, y - 1));
                    }
                    //Down-Left enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x - 1 && board.enPassant.y == y - 1)
                    {
                        if (board.movePieceTest(x, y, x - 1, y - 1)) result.AddLast(new Coordinate(x - 1, y - 1));
                    }

                }
            }


            return result;

        }

        public override LinkedList<Coordinate> getUntestedMoves(GameBoard board)
        {
            LinkedList<Coordinate> result = new LinkedList<Coordinate>();

            if (this.getPlayer() == Player.Player1)
            {
                if (y + 1 <= 7)

                {
                    //Standard Move
                    if (!board.isOccupied(x, y + 1))
                    {
                        result.AddLast(new Coordinate(x, y + 1));
                        if (y + 2 <= 7 && !board.isOccupied(x, y + 2) && firstTurn)
                        {
                            result.AddLast(new Coordinate(x, y + 2));
                        }
                    }
                    //Up-Left Capture
                    if (inBounds(x - 1, y + 1) && board.isOccupied(x - 1, y + 1) && board.getSpace(x - 1, y + 1).getPlayer() == Player.Player2)
                    {
                        result.AddLast(new Coordinate(x - 1, y + 1));
                    }
                    //Up-Right Capture
                    if (inBounds(x + 1, y + 1) && board.isOccupied(x + 1, y + 1) && board.getSpace(x + 1, y + 1).getPlayer() == Player.Player2)
                    {
                        result.AddLast(new Coordinate(x + 1, y + 1));
                    }
                    //Up-Right enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x + 1 && board.enPassant.y == y + 1)
                    {
                        result.AddLast(new Coordinate(x + 1, y + 1));
                    }
                    //Up-Left enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x - 1 && board.enPassant.y == y + 1)
                    {
                        result.AddLast(new Coordinate(x - 1, y + 1));
                    }
                }
            }
            else
            {
                if (y - 1 >= 0)

                {
                    //Standard Move
                    if (!board.isOccupied(x, y - 1))
                    {
                        result.AddLast(new Coordinate(x, y - 1));
                        if (y - 2 >= 0 && !board.isOccupied(x, y - 2) && firstTurn)
                        {
                            result.AddLast(new Coordinate(x, y - 2));
                        }
                    }
                    //Down-Left Capture
                    if (inBounds(x - 1, y - 1) && board.isOccupied(x - 1, y - 1) && board.getSpace(x - 1, y - 1).getPlayer() == Player.Player1)
                    {
                        result.AddLast(new Coordinate(x - 1, y - 1));
                    }
                    //Down-Right Capture
                    if (inBounds(x + 1, y - 1) && board.isOccupied(x + 1, y - 1) && board.getSpace(x + 1, y - 1).getPlayer() == Player.Player1)
                    {
                        result.AddLast(new Coordinate(x + 1, y - 1));
                    }
                    //Down-Right enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x + 1 && board.enPassant.y == y - 1)
                    {
                        result.AddLast(new Coordinate(x + 1, y - 1));
                    }
                    //Down-Left enPassant Capture
                    if (board.enPassant != null && board.enPassant.x == x - 1 && board.enPassant.y == y - 1)
                    {
                        result.AddLast(new Coordinate(x - 1, y - 1));
                    }

                }
            }


            return result;

        }
        public override string ImagePath()
        {
            if (player == Player.Player1)
            {
                
                return @"/Images/Pieces/white_pawn.png";
            }
            else
            {
                return @"/Images/Pieces/black_pawn.png";
            }
        }

        private static Boolean inBounds(int x, int y)
        {
            return x < 8 && x >= 0 && y < 8 && y >= 0;
        }
    }
}
