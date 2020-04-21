using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gomoku
{
    class BlackPiece:Piece  //BlackPiece繼承了 Piece，而Piece又繼承了PiceureBox，所以BlackPiece同時有Piece和PictureBox的屬性
    {
        public BlackPiece(int x,int y):base(x,y)  //base ，如果你的基底類別裡有Construct且有指定需要初始參數的，那你的衍生類別裡就要由base 傳入
        {
            this.Image = Properties.Resources.black;
        }

        public override PieceType GetPieceType()
        {
            return PieceType.BLACK;
        }
    }
}
