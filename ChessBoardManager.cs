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

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private event EventHandler playerMarked; // Sự kiện khi người chơi đánh dấu ô
        public event EventHandler PlayerMarked
        {
            add { playerMarked += value; }
            remove { playerMarked -= value; }
        }

        private EventHandler endedGame; // Sự kiện khi trò chơi kết thúc
        public event EventHandler EndedGame
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }

        private Stack<PlayInfo> playTimeLine;
        public Stack<PlayInfo> PlayTimeLine
        {
            get { return playTimeLine; }
            set { playTimeLine = value; }
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
        
            playTimeLine = new Stack<PlayInfo>(); // Khởi tạo ngăn xếp để lưu trữ các nước đi
        }

        #endregion

        #region methods
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true; // Bật bảng cờ để người chơi có thể tương tác
            ChessBoard.Controls.Clear(); // Xóa tất cả các điều khiển hiện có trên bảng cờ

            playTimeLine = new Stack<PlayInfo>(); // Khởi tạo lại ngăn xếp để bắt đầu trò chơi mới

            this.CurrentPlayer = 0; // Bắt đầu với người chơi đầu tiên

            ChangePlayer(); // Cập nhật tên và hình ảnh của người chơi đầu tiên

            matrix = new List<List<Button>>(); // Khởi tạo ma trận chứa các nút

            Button oldButton = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                matrix.Add(new List<Button>()); // Thêm một hàng mới vào ma trận

                for (int j = 0; j < Cons.CHESS_BOARD_WIDHT; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString() // Lưu chỉ số hàng
                    };

                    btn.Click += btn_Click;

                    ChessBoard.Controls.Add(btn);

                    matrix[i].Add(btn); // Thêm nút vào hàng hiện tại của ma trận

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

            playTimeLine.Push(new PlayInfo(getChessPoint(btn), CurrentPlayer)); // Lưu nước đi vào ngăn xếp

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1; // Chuyển sang người chơi tiếp theo

            ChangePlayer(); // Chuyển sang người chơi tiếp theo

            if (playerMarked != null)
            {
                playerMarked(this, new EventArgs()); // Gọi sự kiện khi người chơi đánh dấu ô
            }

            if (isEndGame(btn)) // Kiểm tra điều kiện kết thúc trò chơi
            {
                endGame(); // Gọi hàm kết thúc trò chơi
            }  
        }

       public void endGame()
        {
            if (endedGame != null)
            
                endedGame(this, new EventArgs()); // Gọi sự kiện kết thúc trò chơi
        }

       public bool undo()
        {
            if (playTimeLine.Count <=  0) // Kiểm tra xem có nước đi nào để hoàn tác không
                return false; // Không thể hoàn tác
            
            PlayInfo oldPoint = playTimeLine.Pop(); // Lấy nước đi cuối cùng từ ngăn xếp
            Button btn = matrix[oldPoint.Point.Y][oldPoint.Point.X]; // Lấy nút tương ứng với nước đi đó
           
            btn.BackgroundImage = null; // Xóa hình ảnh của nút để hoàn tác nước đi
            
            if (playTimeLine.Count <= 0)
            {
                CurrentPlayer = 0; // Nếu không còn nước đi nào, đặt người chơi về người chơi đầu tiên
            }    
            else
            {
                oldPoint = playTimeLine.Peek(); // Lấy nước đi cuối cùng trong ngăn xếp
                CurrentPlayer = playTimeLine.Peek().CurrentPlayer == 1 ? 0 : 1; // Chuyển về người chơi trước đó
            }    

            ChangePlayer(); // Cập nhật tên và hình ảnh của người chơi hiện tại

            return true;
        }


        private bool isEndGame(Button btn)
        {

            return isEndHorizontal(btn) || isEndVertical(btn) || isEndDiagonal(btn) || isEndAntiDiagonal(btn);
        }

        /// <summary>
        ///     kiểm tra end game ở hàng dọc, ngang và chéo chính, chéo phụ
        
        private Point getChessPoint(Button btn)
        {

            int vertical = Convert.ToInt32(btn.Tag); // Lấy chỉ số hàng từ Tag của nút
            int horizontal = matrix[vertical].IndexOf(btn); // Lấy chỉ số cột của nút trong hàng

            Point point = new Point(horizontal, vertical);

            return point;
        }

        private bool isEndHorizontal(Button btn)
        {
            Point point = getChessPoint(btn); // Lấy tọa độ của nút

            int countLeft = 0; // Đếm số ô liên tiếp bên trái
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countLeft++; // Tăng số lượng ô liên tiếp bên trái
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            int countRight = 0; // Đếm số ô liên tiếp bên phải
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDHT; i++)
            {
                if (matrix[point.Y][i].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countRight++; // Tăng số lượng ô liên tiếp bên trái
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            return countLeft + countRight == 5; 
        }
        private bool isEndVertical(Button btn)
        {
            Point point = getChessPoint(btn); // Lấy tọa độ của nút

            int countTop = 0; // Đếm số ô liên tiếp bên trái
            for (int i = point.Y; i >= 0; i--)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countTop++; 
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            int countBottom = 0; // Đếm số ô liên tiếp bên phải
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (matrix[i][point.X].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countBottom++; 
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            return countTop + countBottom == 5;
        }

          private bool isEndDiagonal(Button btn)
        {
            Point point = getChessPoint(btn); // Lấy tọa độ của nút

            int countTop = 0; // Đếm số ô liên tiếp bên trái
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0) 
                    break; // Kiểm tra giới hạn mảng

                if (matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countTop++; 
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDHT - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X + i >= Cons.CHESS_BOARD_WIDHT) 
                    break; // Kiểm tra giới hạn mảng
                 
                if (matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countBottom++; 
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            return countTop + countBottom == 5;
        }

        private bool isEndAntiDiagonal(Button btn)
        {
            Point point = getChessPoint(btn); 

            int countTop = 0; 
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X +  i > Cons.CHESS_BOARD_WIDHT || point.Y - i < 0)
                    break; // Kiểm tra giới hạn mảng

                if (matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countTop++; 
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            int countBottom = 0; 
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDHT - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X - i < 0)
                    break; // Kiểm tra giới hạn mảng

                if (matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage) // Kiểm tra ô bên trái có cùng hình ảnh không
                {
                    countBottom++;
                }
                else
                {
                    break; // Dừng nếu gặp ô khác hình ảnh
                }
            }

            return countTop + countBottom == 5;
        }

        /// </summary>
        /// <param name="btn"></param>

        private void Mark(Button btn)
        {
            btn.BackgroundImage = player[CurrentPlayer].Mask; // Gán hình ảnh của người chơi hiện tại
        }

        private void ChangePlayer()
        {
            
            PlayerName.Text = Player[CurrentPlayer].Name; // Cập nhật tên người chơi hiện tại
            
            PlayerMark.Image = Player[CurrentPlayer].Mask; // Cập nhật hình ảnh người chơi hiện tại
        }

        #endregion
    }
     
    }
