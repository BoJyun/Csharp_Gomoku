using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gomoku
{
    class WhitePiece: Piece
    {
        public WhitePiece(int x, int y) : base(x, y)  //base ，如果你的基底類別裡有Construct且有指定需要初始參數的，那你的衍生類別裡就要由base 傳入
        {
            this.Image = Properties.Resources.white;
        }

        public override PieceType GetPieceType()
        {
            return PieceType.WHITE;
        }

    }
}
