using System;
using System.Collections.Generic;
using Chess.Pieces;

namespace Chess.Board
{
    //Object meant to represent an entire gamestate.
    class GameBoard
    {
        Piece[,] board;
        public Coordinate enPassant;
        public Coordinate promotionTarget;
        Player turn;

        public Boolean player1Check;
        public Boolean player2Check;
        Boolean testing = false;

        King player1King;
        King player2King;

        //Game Over
        public Boolean gameOver = false;
        public Player winner;


        public GameBoard()
        {
            player1Check = false;
            player2Check = false;
            turn = Player.Player1;
            enPassant = null;
            promotionTarget = null;
            player1King = new King(4, 0, Player.Player1);
            player2King = new King(4, 7, Player.Player2);
            gameOver = false;
            board = new Piece[8,8]
            
            {
                //Set the entire board with pieces (Standard Board)
                { new Rook(0, 0, Player.Player1), new Pawn(0, 1, Player.Player1), null, null, null, null, new Pawn(0, 6, Player.Player2), new Rook(0, 7, Player.Player2) },
                { new Knight(1, 0, Player.Player1), new Pawn(1, 1, Player.Player1), null, null, null, null, new Pawn(1, 6, Player.Player2), new Knight(1, 7, Player.Player2) },
                { new Bishop(2, 0, Player.Player1), new Pawn(2, 1, Player.Player1), null, null, null, null, new Pawn(2, 6, Player.Player2), new Bishop(2, 7, Player.Player2) },
                { new Queen(3, 0, Player.Player1), new Pawn(3,1, Player.Player1), null, null, null, null, new Pawn(3,6, Player.Player2), new Queen(3,7,Player.Player2) },
                { player1King, new Pawn(4,1, Player.Player1), null, null, null, null, new Pawn(4, 6, Player.Player2), player2King },
                { new Bishop(5, 0, Player.Player1), new Pawn(5, 1, Player.Player1), null, null, null, null, new Pawn(5, 6, Player.Player2), new Bishop(5, 7, Player.Player2) },
                { new Knight(6, 0, Player.Player1), new Pawn(6, 1, Player.Player1), null, null, null, null, new Pawn(6, 6, Player.Player2), new Knight(6, 7, Player.Player2) },
                { new Rook(7, 0, Player.Player1), new Pawn(7, 1, Player.Player1), null, null, null, null, new Pawn(7, 6, Player.Player2), new Rook(7, 7, Player.Player2) }

            };
        }
        //Moves a piece from one space to another
        public void movePiece(int currX, int currY, int destX, int destY)
        {
            if (gameOver) return;

            Piece current = board[currX, currY];

            if (current.firstTurn) current.firstTurn = false;

            //Pawn special cases
            if (current.getPieceType() == PieceType.Pawn)
            {
                if (current.player == Player.Player1)
                {
                    //en passant opportunity created
                    if (destY == currY + 2)
                    {
                        current.x = destX;
                        current.y = destY;
                        board[destX, destY] = current;
                        board[currX, currY] = null;
                        enPassant = new Coordinate(destX, destY - 1);
                        endOfTurn();
                        return;
                    }
                    //en passant opportunity taken
                    if (enPassant != null && destX == enPassant.x && destY == enPassant.y)
                    {
                        current.x = destX;
                        current.y = destY;
                        board[destX, destY] = current;
                        board[currX, currY] = null;
                        board[destX, destY - 1] = null;
                        enPassant = null;
                        endOfTurn();
                        return;
                    }

                    //Promotion
                    if (destY == 7)
                    {
                        promotionTarget = new Coordinate(destX, destY);
                        board[currX, currY] = null;
                        return;
                        //GUI has to end the turn
                    }
                }
                if (current.player == Player.Player2)
                {
                    //en passant opportunity created
                    if (destY == currY - 2)
                    {
                        current.x = destX;
                        current.y = destY;
                        board[destX, destY] = current;
                        board[currX, currY] = null;
                        enPassant = new Coordinate(destX, destY + 1);
                        endOfTurn();
                        return;
                    }
                    //en passant opportunity taken
                    if (enPassant != null && destX == enPassant.x && destY == enPassant.y)
                    {
                        current.x = destX;
                        current.y = destY;
                        board[destX, destY] = current;
                        board[currX, currY] = null;
                        board[destX, destY + 1] = null;
                        enPassant = null;
                        endOfTurn();
                        return;
                    }

                    //Promotion
                    if (destY == 0)
                    {
                        promotionTarget = new Coordinate(destX, destY);
                        board[currX, currY] = null;
                        return;
                        //GUI has to end the turn
                    }
                }
            }
            enPassant = null;
            promotionTarget = null;

            //Castling special case
            if (current.getPieceType() == PieceType.King)
            {
                //right
                if (destX == currX + 2)
                {
                    //Move Rook
                    Piece rook = board[7, currY];
                    rook.x -= 2;
                    rook.firstTurn = false;
                    board[5, currY] = rook;
                    board[7, currY] = null;

                    //Move King
                    current.x += 2;
                    board[6, currY] = current;
                    board[4, currY] = null;
                    endOfTurn();
                    return;
                }

                //left
                if (destX == currX - 2)
                {
                    //Move Rook
                    Piece rook = board[0, currY];
                    rook.x = rook.x + 3;
                    rook.firstTurn = false;
                    board[3, currY] = rook;
                    board[0, currY] = null;

                    //Move King
                    current.x -= 2;
                    board[2, currY] = current;
                    board[4, currY] = null;
                    endOfTurn();
                    return;
                }
            }

            //Standard Case

            current.x = destX;
            current.y = destY;
            board[destX, destY] = current;
            board[currX, currY] = null;

            endOfTurn();
        }
        //Function that checks everything that
        public void endOfTurn()
        {
            //Player 1 Check
            if (!player1King.amISafe(this)) player1Check = true;
            else player1Check = false;

            //Player 2 Check
            if (!player2King.amISafe(this)) player2Check = true;
            else player2Check = false;

            //Checkmate
            if (!this.testing) //movePieceTest shouldn't check for checkmate
            {
                if (this.player1CheckMate())
                {
                    endGame(Player.Player2);
                    return;
                }
                if (this.player2CheckMate())
                {
                    endGame(Player.Player1);
                    return;
                }

                //Swap Turns
                if (turn == Player.Player1) turn = Player.Player2;
                else if (turn == Player.Player2) turn = Player.Player1;
            }
        }

        // does the move, checks if the king is safe, undoes the move, and returns true if the king was safe. Returns false if not.
        public Boolean movePieceTest(int currX, int currY, int destX, int destY)
        {
            Piece current = this.getSpace(currX, currY);
            
            //Clone the board as well as the attributes of the moving piece
            GameBoard oldBoard = this.getClone();
            int oldX = current.x;
            int oldY = current.y;
            Boolean oldFirstTurn = current.firstTurn;

            LinkedList<Rook> rooks = this.getRooks();
            LinkedList<RookCoord> rookCoords = new LinkedList<RookCoord>();

            //Because castling can move the rooks as well, keep a reference to all the rooks as well as their attributes before the move to later undo the move.
            foreach(Rook rook in rooks)
            {
                rookCoords.AddLast(new RookCoord(rook, new Coordinate(rook.x, rook.y), rook.firstTurn));
            }

            this.testing = true; //Set testing to true so movePiece doesn't check for checkmate and end the game.
            this.movePiece(currX, currY, destX, destY);
            this.testing = false;

            //Check if the player's king is safe, undo the move, then return true or false.
            if (current.getPlayer() == Player.Player1)
            {
                if (player1Check)
                {
                    /*----- Undoing the Move -----*/
                    this.setClone(oldBoard);
                    current.x = oldX;
                    current.y = oldY;
                    current.firstTurn = oldFirstTurn;

                    foreach(RookCoord rc in rookCoords)
                    {
                        rc.rook.x = rc.coord.x;
                        rc.rook.y = rc.coord.y;
                        rc.rook.firstTurn = rc.firstTurn;
                    }
                    /*---------------------------*/

                    return false;
                }
            }
            else
            {
                if (player2Check)
                {
                    /*----- Undoing the Move -----*/
                    this.setClone(oldBoard);
                    current.x = oldX;
                    current.y = oldY;
                    current.firstTurn = oldFirstTurn;

                    foreach (RookCoord rc in rookCoords)
                    {
                        rc.rook.x = rc.coord.x;
                        rc.rook.y = rc.coord.y;
                        rc.rook.firstTurn = rc.firstTurn;
                    }
                    /*---------------------------*/

                    return false;

                }
            }
            /*----- Undoing the Move -----*/
            this.setClone(oldBoard);
            current.x = oldX;
            current.y = oldY;
            current.firstTurn = oldFirstTurn;

            foreach (RookCoord rc in rookCoords)
            {
                rc.rook.x = rc.coord.x;
                rc.rook.y = rc.coord.y;
                rc.rook.firstTurn = rc.firstTurn;
            }
            /*---------------------------*/

            return true;
        }


        public LinkedList<Piece> getPlayer1Pieces()
        {
            LinkedList<Piece> result = new LinkedList<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i, j].getPlayer() == Player.Player1)
                        result.AddLast(board[i, j]);
                }
            }
            return result;
        }

        public LinkedList<Piece> getPlayer2Pieces()
        {
            LinkedList<Piece> result = new LinkedList<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i, j].getPlayer() == Player.Player2)
                        result.AddLast(board[i, j]);
                }
            }
            return result;
        }

        public LinkedList<Piece> getAllPieces()
        {
            LinkedList<Piece> result = new LinkedList<Piece>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                        result.AddLast(board[i, j]);
                }
            }
            return result;
        }


        public LinkedList<Rook> getRooks()
        {
            LinkedList<Rook> result = new LinkedList<Rook>();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i,j].getPieceType() == PieceType.Rook)
                        result.AddLast((Rook)board[i, j]);
                }
            }
            return result;
        }

        public Boolean player1CheckMate()
        {
            foreach (Piece piece in this.getPlayer1Pieces())
            {
                if (!(piece.getValidMoves(this).Count == 0))
                {
                    return false;
                }
            }
            return true;
        }


        public Boolean player2CheckMate()
        {
            foreach (Piece piece in this.getPlayer2Pieces())
            {
                if (!(piece.getValidMoves(this).Count == 0))
                {
                    return false;
                }
            }
            return true;
        }

        public void endGame(Player winner)
        {
            gameOver = true;
            this.winner = winner;
        }

        public Piece getSpace(int x, int y)
        {
            return board[x, y];
        }

        public void setSpace(int x, int y, Piece target)
        {
            board[x, y] = target;
        }

        public Player whosTurn()
        {
            return turn;
        }

        public Boolean isOccupied(int x, int y)
        {
            return board[x, y] != null;
        }

        private GameBoard getClone()
        {
            GameBoard result = new GameBoard
            {
                enPassant = this.enPassant,
                promotionTarget = this.promotionTarget,
                turn = this.turn,
                player1Check = this.player1Check,
                player2Check = this.player2Check,
                player1King = this.player1King,
                player2King = this.player2King,
                gameOver = this.gameOver,
                winner = this.winner
            };
            Piece[,] newBoard = new Piece[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j= 0; j < 8; j++)
                {
                    newBoard[i, j] = this.board[i, j];
                }
            }

            result.board = newBoard;

            return result;
        }

        private void setClone(GameBoard clone)
        {
            this.board = clone.board;
            this.enPassant = clone.enPassant;
            this.promotionTarget = clone.promotionTarget;
            this.turn = clone.turn;
            this.player1Check = clone.player1Check;
            this.player2Check = clone.player2Check;
            this.player1King = clone.player1King;
            this.player2King = clone.player2King;
            this.gameOver = clone.gameOver;
            this.winner = clone.winner;
        }
    }
}
