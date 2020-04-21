using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;  // 拉入此函示庫，才能用picturebox
using System.Drawing;

namespace Gomoku
{
    abstract class Piece:PictureBox           //可以繼承 Picturebox的屬性與能力，這樣才能把旗子放上去
    {
        private static readonly int IMAGE_WIDTH = 50;

        public Piece(int x, int y)
        {
            this.BackColor = Color.Transparent; //取得C#內建的顏色特性，可google msdn color
            this.Location = new Point(x- IMAGE_WIDTH/2, y- IMAGE_WIDTH/2);  //建立起使位置；Location 的型別是 Point 
            this.Size = new Size(50, 50); //size 代表寬跟高
            
        }

        public abstract PieceType GetPieceType(); //棋子自己還不知道自己之後會繼承黑棋還白棋，所以用abstract method，本物件也要加abstract
                                                  //abstract method 可以把實際的工作轉交給繼承的class來定義
    }
}
