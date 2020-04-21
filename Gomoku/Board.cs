using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gomoku
{
    class Board  //關於棋盤的程式
    {
        private static readonly Point NO_MACH_NODE = new Point(-1, -1);  //若都沒有符合的點，用此代表
        private static readonly int OFFSET = 75;
        private static readonly int NODE_RADIUS = 10;
        private static readonly int NODE_DISTRANCE = 75;  //點和點之間的距離

        public static readonly int NODE_COUNT = 9; //一維方向的棋盤上只有9個點

        private Piece[,] pieces = new Piece[NODE_COUNT, NODE_COUNT]; //用來存放棋盤上的棋子
        //Piece aa = new Piece();
        private Point lastPlaceNode = NO_MACH_NODE;
        public Point LastPlaceNode { get { return lastPlaceNode; } }

        public bool CanBePlaced(int x, int y)  //提示使用者此處是否可以放旗子
        {
            //TODO:找出最近的節點(Node)
            Point nodeID = findTheCloseNode(x, y);

            //TODO:如果沒有的話，回傳false
            if (nodeID == NO_MACH_NODE)
            {
                return false;
            }

            return true;
            //TODO:若可以放旗子，改變游標提示使用者

        }

        public Piece PlaceAPiece(int x,int y,PieceType type)
        {
            //TODO:找出最近的節點(Node)
            Point nodeID = findTheCloseNode(x, y);

            //TODO:如果沒有的話，回傳false
            if (nodeID == NO_MACH_NODE)
            {
                return null;
            }

            //TODO:如果有的話，檢查是否已經有棋子存在
            if (pieces[nodeID.X, nodeID.Y] != null) //若判斷式是null，表示該位置上面有東西(棋子)
            {
                return null; //所以回傳這裡不能放東西
            }


            Point fromPos = convertToFormPosition(nodeID);
            //TODO:根據Type 產生對應的棋子
            if (type == PieceType.BLACK)
                pieces[nodeID.X, nodeID.Y] = new BlackPiece(fromPos.X, fromPos.Y);  // piece是 BlackPiece的Base class
            else if (type==PieceType.WHITE)
                pieces[nodeID.X, nodeID.Y] = new WhitePiece(fromPos.X, fromPos.Y); // 可以使用Base Class的變數來存取繼承class的物件
                                                                                   // 且如果使用base class的變數，仍可以呼叫到被override的method
            //紀錄最後下棋子的位置
            lastPlaceNode = nodeID;

            return pieces[nodeID.X, nodeID.Y];
        }  

        private Point convertToFormPosition(Point nodeId)  //把棋盤座標轉回視窗座標
        {
            Point fromPosition = new Point();
            fromPosition.X = nodeId.X * NODE_DISTRANCE + OFFSET;
            fromPosition.Y = nodeId.Y * NODE_DISTRANCE + OFFSET;

            return fromPosition;
        }

        private Point findTheCloseNode(int x,int y)  //找出最近的交叉點    //任何private 的 method 第一個字母為小寫，public 為大寫
        {
            int nodeIdX = findTheCloseNode(x);  //先檢查x軸
            if (nodeIdX == -1 || nodeIdX>= NODE_COUNT) //邊界是0~9 
                return NO_MACH_NODE;

            int nodeIdY = findTheCloseNode(y); //檢查y軸
            if (nodeIdY == -1 || nodeIdY >= NODE_COUNT)
                return NO_MACH_NODE;

            return new Point(nodeIdX, nodeIdY);  
        }

        private int findTheCloseNode(int pos)  //先判斷一維的點
        {
            if (pos < OFFSET - NODE_RADIUS)  //如果游標落在邊框外，直接回傳-1
                return -1;

            pos -= OFFSET;

            int quotient = pos / NODE_DISTRANCE;
            int remainder = pos % NODE_DISTRANCE;

            if (remainder <= NODE_RADIUS)  //因為餘數小於"點的半徑"，所以代表靠近左邊的點
            {
                return quotient;
            }
            else if (remainder >= NODE_DISTRANCE-NODE_RADIUS) //因為餘數大於"distance-右邊點的R"，所以代表靠近右邊的點
                return quotient + 1;
            else
                return -1;
        }

        public PieceType GetPieceType(int nodeIdX, int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            return pieces[nodeIdX, nodeIdY].GetPieceType();

        }
    }
}