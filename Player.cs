using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME_CARO
{
    public class Player
    {
        #region Properties
        private string name; //ctrl + R + E tạo thuộc tính Name

        public string Name 
        { 
            get => name; 
            set => name = value; 
        }

        private Image mask;
        public Image Mask 
        { 
            get => mask; 
            set => mask = value; 
        }
        #endregion

        #region Constructor
        public Player(string name, Image mask)
        {
            //this là từ khóa tham chiếu đến đối tượng hiện tại, lớp Player.
            //Name và Mask là các thuộc tính của lớp Player.
            //name và mask là các tham số được truyền vào hàm khởi tạo.
            this.Name = name;
            this.Mask = mask;
        }
        #endregion

        #region Methods
       
        
        #endregion

    }
}
