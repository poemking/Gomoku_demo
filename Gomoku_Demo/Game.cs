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

        private PieceType winner = PieceType.NONE;
        public PieceType Winner { get { return winner; } }
        public int[,] countPieceRecord = new int[3, 3]; //紀錄八個方向相同顏色棋子個數

        public bool CanBePlaced(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x, y, currentPlayer);
            if (piece != null)
            {
                CheckWinner(); //檢查是否現在下棋的人獲勝

                //this.Controls.Add(piece); 目前沒在視窗裡面撰寫,故要回傳piece出去給form去call
                //交換選手
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
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;

            //檢查八個不同方向
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    //排除中間的情況
                    if (xDir == 0 && yDir == 0)
                        continue; //略過迴圈剩下部分,直接跳到下次迴圈開始

                    //紀錄現在看到幾顆相同棋子
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir; //棋子中心點+count(幾顆棋子)*xDir(座標方向)=目標棋子
                        int targetY = centerX + count * yDir; //棋子中心點+count(幾顆棋子)*xDir(座標方向)=目標棋子

                        //檢查顏色是否相同
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }

                    //檢查是否看到五顆棋子,但無法處理五顆連線的中間bug,下面增加isWinnerExist方法解決
                    //if (count == 5)
                    // winner = currentPlayer;

                    //解決最後棋子下在五顆連線的中間，而不是邊邊時無法判斷勝利的 bug
                    countPieceRecord[xDir + 1, yDir + 1] = count - 1; //xyDir 從-1開始,為了讓[,]_idx從0開始而+1的

                    if (isWinnerExist(countPieceRecord))
                        winner = currentPlayer;

                }
            }
        }

        //check winner exist or not
        private bool isWinnerExist(int[,] record)
        {
            int result1 = record[0, 1] + record[2, 1]; // 橫   →
            int result2 = record[1, 0] + record[1, 2]; // 直   ↓
            int result3 = record[0, 2] + record[2, 0]; // 斜   ↙
            int result4 = record[0, 0] + record[2, 2]; // 反斜 ↘

            if (result1 == 4 || result2 == 4 || result3 == 4 || result4 == 4)
            {
                // winner exist
                return true;
            }

            return false;
        }
    }
}
