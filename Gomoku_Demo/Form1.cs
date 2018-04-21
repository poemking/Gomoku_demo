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
        private bool isBlack = true;

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
            if (isBlack)
            {
                this.Controls.Add(new BlackPiece(e.X, e.Y));
                isBlack = false;
            }
            else
            {
                this.Controls.Add(new WhitePiece(e.X, e.Y));
                isBlack = true;
            }
        }
    }
}
