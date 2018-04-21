using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku_Demo
{
    //建立抽象class為了建立出黑棋跟白棋而已,防止人家實作piece
    abstract class Piece : PictureBox 
    {
        private static readonly int IMAGE_WIDTH = 50;

        public Piece(int x, int y)
        {

            this.BackColor = Color.Transparent;
            this.Location = new Point(x - IMAGE_WIDTH / 2, y - IMAGE_WIDTH / 2);
            this.Size = new Size(IMAGE_WIDTH, IMAGE_WIDTH);
        }
    }
}
