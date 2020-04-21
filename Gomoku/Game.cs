using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gomoku
{
    class Game //遊戲邏輯的任何程式碼
    {
        private Board board = new Board();

        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winner = PieceType.NONE;

        public PieceType Winner { get { return winner; } }

        public bool CanBePlaced_ForForm(int x, int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlaceAPiece_ForForm(int x, int y)
        {
            Piece piece = board.PlaceAPiece(x,y, currentPlayer);
            if (piece != null)
            {
                //檢查現在下棋的人是否獲勝
                CheckWinner();

                //交換選手
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)
                {
                    currentPlayer = PieceType.BLACK;
                }
                return piece;
            }

            return null;
        }

        private void CheckWinner()  //用當下下的那個仁與棋子來判斷是否獲勝
        {
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;
            

            //檢查八個不同方向
            for (int xDir = -1; xDir <= 1; xDir++)
            {
                for (int yDir = -1; yDir <= 1; yDir++)
                {
                    if (xDir == 0 && yDir == 0)
                        continue;

                        //紀錄現在看到幾顆相同的棋子
                    int count = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;

                        //檢查顏色是否相同，要注意是否碰到邊界
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }

                    int count2 = 0;
                    while (count2 < 5)
                    {
                        int targetX = centerX + count2 * -xDir;
                        int targetY = centerY + count2* -yDir;

                        //檢查顏色是否相同，要注意是否碰到邊界
                        if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                            targetY < 0 || targetY >= Board.NODE_COUNT ||
                            targetX == centerX|| targetY == centerY||  //因為count2初始是0，所以會導致自己判斷成自己
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        else
                            count2++;                      
                        
                    }

                    if (count +count2>= 5)
                        winner = currentPlayer;
                }
            }


            ////紀錄現在看到幾顆相同的棋子
            //int count = 1;
            //while (count < 5)
            //{
            //    int targetX = centerX + count;
            //    int targetY = centerY;

            //    //檢查顏色是否相同，要注意是否碰到邊界
            //    if (targetX < 0 || targetX >= Board.NODE_COUNT ||
            //        targetY < 0 || targetY >= Board.NODE_COUNT ||
            //        board.GetPieceType(targetX, targetY) != currentPlayer)
            //        break;

            //    count++;
            //}

            //if (count == 5)
            //    winner = currentPlayer;

        }
    }
}
