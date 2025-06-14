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
            chessBoard = new ChessBoardManager(PnlChessBoard, TxtPlayerName, PicMark);
            chessBoard.EndedGame += ChessBoard_EndedGame;
            chessBoard.PlayerMarked += ChessBoard_PlayerMarked;


            PrgCoolDown.Step = Cons.COOL_DOWN_STEP;
            PrgCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            PrgCoolDown.Value = 0;

            TmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            chessBoard.DrawChessBoard();

            TmCoolDown.Start();
        }

        void EndGame()
        {
            TmCoolDown.Stop();
            PnlChessBoard.Enabled = false;
            MessageBox.Show( "Game Over");
        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            TmCoolDown.Start();
            PrgCoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
        }
        private void TmCoolDown_Tick(object sender, EventArgs e)
        {
            PrgCoolDown.PerformStep();

            if (PrgCoolDown.Value >= PrgCoolDown.Maximum)
            { 
                EndGame();
            }
        }
    }
}
