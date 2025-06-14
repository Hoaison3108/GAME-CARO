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

            NewGame();
        }

        #region methods
        void EndGame()
        {
            TmCoolDown.Stop();
            PnlChessBoard.Enabled = false;
            mnuMenuUndo.Enabled = false;
            MessageBox.Show( "Game Over");
        }

        void NewGame()
        {
            PrgCoolDown.Value = 0;
            TmCoolDown.Stop();
            mnuMenuUndo.Enabled = true;
            chessBoard.DrawChessBoard();
        }

        void Undo()
        {
            chessBoard.undo();
        }

        void Quit()
        {
            Application.Exit();
        }

        void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            TmCoolDown.Start();
            PrgCoolDown.Value = 0;
        }

        void ChessBoard_EndedGame(object sender, EventArgs e)
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

        private void mnuMenuNew_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void mnuMenuUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void mnuMenuQuit_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No)
                return;
            Application.Exit();

            e.Cancel = true; // Prevent the form from closing immediately
        }
        #endregion
    }
}
