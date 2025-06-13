using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME_CARO
{
    public partial class Form1 : Form
    {
        #region properties
        ChessBoardManager chessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();
            chessBoard = new ChessBoardManager(PnlChessBoard);

            chessBoard.DrawChessBoard();
        }

       
    }
}
