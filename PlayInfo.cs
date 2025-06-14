﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAME_CARO
{
   public class PlayInfo
    {
        #region Properties
        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }
        }

        private int currentPlayer;
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }
        #endregion

        #region Constructors
        public PlayInfo(Point point, int currentPlayer)
        {
            this.point = point;
            this.currentPlayer = currentPlayer;
        }

        #endregion

        #region Methods
        #endregion
    }
}
