using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gomoku
{
    public partial class Gomoku : Form    //視窗主要用於顯示
    {
       // private bool isBlack = true;

        ////private Board board = new Board();

        ////private PieceType nextPieceType = PieceType.BLACK;
        private Game game=new Game();

        public Gomoku()
        {
            InitializeComponent();

            //this.Controls.Add(new BlackPiece(10, 20));  // 把Piece加入此Gomoku視窗中；Controls代表此視窗中所具有的元件(Piece要有繼承)，用Add加入，而(10,20)代表x,y位置
           // this.Controls.Add(new WhitePiece(50, 200));
        }

        private void Gomoku_MouseDown(object sender, MouseEventArgs e) //e 事件發生時，相關的參數
        {
            //此段程式碼有簡化

            //Piece piece = board.PlaceAPiece(e.X, e.Y, nextPieceType);
            //if (piece != null)
            //{
            //    this.Controls.Add(piece);
            //    if (nextPieceType == PieceType.BLACK)
            //        nextPieceType = PieceType.WHITE;
            //    else if (nextPieceType == PieceType.WHITE)
            //    {
            //        nextPieceType = PieceType.BLACK;
            //    }
            //}
            Piece piece = game.PlaceAPiece_ForForm(e.X, e.Y);
            if (piece!=null)
                this.Controls.Add(piece);
                 //檢查是否有人獲勝
                if (game.Winner == PieceType.BLACK)
                    MessageBox.Show("黑色獲勝");
                else if (game.Winner == PieceType.WHITE)
                    MessageBox.Show("白色獲勝");
        }

        private void Gomoku_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.CanBePlaced_ForForm(e.X, e.Y))
                this.Cursor = Cursors.Hand;
            else
                this.Cursor = Cursors.Default;
        }

        
    }
}
