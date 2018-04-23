using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku_Demo
{
    //manager game code in this, refactor
    class Game
    {
        private Board board = new Board();
        //private bool isBlack = true; 簡化成PieceType
        private PieceType currentPlayer = PieceType.BLACK;

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                //this.Controls.Add(piece); 目前沒在視窗裡面撰寫,故要回傳piece出去給form去call

                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                    currentPlayer = PieceType.BLACK;

                return piece;
            }

            return null;
            //change to up list of Game class
            //this.Controls.Add(new BlackPiece(e.X, e.Y));
            //isBlack = true;
        }

        //TODO: how to check winner when board is putted five counts
        private void CheckWinner()
        {

        }
    }
}
