using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME_CARO
{
    public class ChessBoardManager
    {

        #region properties
        private Panel ChessBoard { get; set; }

        #endregion

        #region Initialize
        public ChessBoardManager(Panel ChessBoard)
        {
           this.ChessBoard = ChessBoard;
        }

        #endregion

        #region methods
        public void DrawChessBoard()
        {
            Button oldButton = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDHT; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y)
                    };

                    ChessBoard.Controls.Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0; // Reset width for the next row
                oldButton.Height = 0; // Reset height for the next row

            }
        }

        #endregion


    }
     
    }
