using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku_Demo
{
    public partial class Form1 : Form
    {
        private Game game = new Game();

        public Form1()
        {
            InitializeComponent();
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Width;
            //MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            //FormBorderStyle = FormBorderStyle.FixedDialog;

            /*
             TODO:
                1.嘗試解決最後棋子下在五顆連線的中間，而不是邊邊時無法判斷勝利的 bug
                2.嘗試實作重新啟動遊戲的功能
                3.在有人快勝利時提出警告訊息
                4.想出一個方法讓白色自動下子 (例如：最簡單的作法，隨便找個讓白色隨機亂下)
             */
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = game.PlaceAPiece(e.X, e.Y);
            if (piece != null)
            {
                this.Controls.Add(piece);

                //檢查是否有人獲勝
                if (game.Winner == PieceType.BLACK)
                {
                    MessageBox.Show("黑色獲勝");
                }
                else if (game.Winner == PieceType.WHITE)
                {
                    MessageBox.Show("白色獲勝");
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (board.CanBePlaced(e.X, e.Y))
            if (game.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
