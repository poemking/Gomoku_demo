using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Gomoku_Demo
{
    class Board
    {
        private static readonly int NODE_COUNT = 9;
        private static readonly Point NO_MATCH_NODE = new Point(-1, -1); //表示Board上不存在的點

        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTANCE = 75;

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT];

        //給一個座標點,找出棋盤上面現在放置什麼顏色的棋子
        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }

        public bool CanBePlaced(int x, int y)
        {
            //TODO: 找出最近的節點 (Node)
            Point nodeId = findTheClosetNode(x, y);

            //TODO: 如果沒有的話, 回傳false
            if (nodeId == NO_MATCH_NODE)
                return false;

            //TODO: 如果有的話, 檢查是否已經棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
                return false;

            return true;
        }

        public Piece PlaceAPiece(int x, int y, PieceType type)
        {
            //TODO: 找出最近的節點 (Node)
            Point nodeId = findTheClosetNode(x, y);

            //TODO: 如果沒有的話, 回傳null
            if (nodeId == NO_MATCH_NODE)
                return null;

            //TODO: 如果有的話, 檢查是否已經棋子存在
            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;
            //TODO: 根據Type 產生對應的棋子
            Point formPos = convertToFormPosition(nodeId);
            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X, formPos.Y); //X的棋盤座標轉換成視窗座標
            else if (type == PieceType.WHITE)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X, formPos.Y); //Y的棋盤座標轉換成視窗座標

            return pieces[nodeId.X, nodeId.Y]; //回傳計算出來的棋子
        }

        private Point convertToFormPosition(Point nodeId)
        {
            Point formPositon = new Point();
            formPositon.X = nodeId.X * NODE_DISTANCE + OFFSET;
            formPositon.Y = nodeId.Y * NODE_DISTANCE + OFFSET;
            return formPositon;

        }

        private Point findTheClosetNode(int x, int y)
        {
            int nodeIdX = findTheClosetNode(x);
            if (nodeIdX == -1 || nodeIdX >= NODE_COUNT) //要消除邊界0-8以上的Idx,故>=
                return NO_MATCH_NODE;

            int nodeIdY = findTheClosetNode(y);
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT) //要消除邊界0-8以上的Idx,故>=
                return NO_MATCH_NODE;

            return new Point(nodeIdX, nodeIdY); //Point 回傳時,需要記憶體回傳x,y value,所以要new出來
        }

        //把二維問題換成一維問題
        private int findTheClosetNode(int pos)
        {
            if (pos < OFFSET - NODE_RADIUS)
                return -1;

            pos -= OFFSET;

            int quotient = pos / NODE_DISTANCE;
            int remainder = pos % NODE_DISTANCE;

            if (remainder <= NODE_RADIUS)
                return quotient;
            else if (remainder >= NODE_DISTANCE - NODE_RADIUS)
                return quotient + 1;
            else
                return -1;
        }
    }
}
