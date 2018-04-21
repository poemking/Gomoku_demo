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
        private Board board = new Board();
        //private bool isBlack = true; 簡化成PieceType
        private PieceType nextPieceType = PieceType.BLACK; 

        public Form1()
        {
            InitializeComponent();
            Height = Properties.Resources.board.Height;
            Width = Properties.Resources.board.Width;
            //MinimizeBox = false;
            MaximizeBox = false;
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            //FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece piece = board.PlaceAPiece(e.X, e.Y, nextPieceType);
            if (piece != null)
            {
                this.Controls.Add(piece);

                if (nextPieceType == PieceType.BLACK)
                    nextPieceType = PieceType.WHITE;
                else if (nextPieceType == PieceType.WHITE)
                    nextPieceType = PieceType.BLACK;
            }
            //change to up list
            //this.Controls.Add(new BlackPiece(e.X, e.Y));
            //isBlack = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
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
