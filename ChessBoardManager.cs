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
        

        private List<Player> player;
        public List<Player> Player
        {
            get { return player; }
            set { player = value; }
        }

        private int CurrentPlayer; // Lưu chỉ số của người chơi hiện tại (0 hoặc 1)

        private TextBox playerName;
        public TextBox PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        private PictureBox playerMark;
        public PictureBox PlayerMark
        {
            get { return playerMark; }
            set { playerMark = value; }
        }

        #endregion

        #region Initialize Constructor
        public ChessBoardManager(Panel ChessBoard, TextBox PlayerName, PictureBox Mark)
        {
           this.ChessBoard = ChessBoard;
           this.PlayerName = PlayerName;
           this.PlayerMark = Mark;
           this.Player = new List<Player>()
            {
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\images.png")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\pngtree-the-o-symbol-has-a-black-outline-and-white-background-vector-png-image_7059301.png"))
            };
           this.CurrentPlayer = 0; // Bắt đầu với người chơi đầu tiên

            ChangePlayer(); // Cập nhật tên và hình ảnh của người chơi đầu tiên
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
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch
                    };

                    btn.Click += btn_Click;

                    ChessBoard.Controls.Add(btn);

                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0; // Reset width for the next row
                oldButton.Height = 0; // Reset height for the next row

            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button; //ép kiểu sender về Button

            if (btn.BackgroundImage != null) // Kiểm tra xem ô đã có hình ảnh chưa
                return; // Nếu đã có hình ảnh, không cho phép đánh dấu lại
            
            Mark(btn); // Đánh dấu ô với hình ảnh của người chơi hiện tại

            ChangePlayer(); // Chuyển sang người chơi tiếp theo
        }

        private void Mark(Button btn)
        {
            btn.BackgroundImage = player[CurrentPlayer].Mask; // Gán hình ảnh của người chơi hiện tại

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1; // Chuyển sang người chơi tiếp theo
        }

        private void ChangePlayer()
        {
            
            PlayerName.Text = Player[CurrentPlayer].Name; // Cập nhật tên người chơi hiện tại
            
            PlayerMark.Image = Player[CurrentPlayer].Mask; // Cập nhật hình ảnh người chơi hiện tại
        }

        #endregion
    }
     
    }
