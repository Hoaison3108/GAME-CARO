namespace GAME_CARO
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PnlChessBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PicAvatar = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnLan = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.PicMark = new System.Windows.Forms.PictureBox();
            this.PrgCoolDown = new System.Windows.Forms.ProgressBar();
            this.TxtPlayerName = new System.Windows.Forms.TextBox();
            this.TmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAvatar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMark)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlChessBoard
            // 
            this.PnlChessBoard.BackColor = System.Drawing.SystemColors.Control;
            this.PnlChessBoard.Location = new System.Drawing.Point(-1, 0);
            this.PnlChessBoard.Name = "PnlChessBoard";
            this.PnlChessBoard.Size = new System.Drawing.Size(781, 662);
            this.PnlChessBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.PicAvatar);
            this.panel2.Location = new System.Drawing.Point(787, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(372, 293);
            this.panel2.TabIndex = 1;
            // 
            // PicAvatar
            // 
            this.PicAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PicAvatar.BackColor = System.Drawing.SystemColors.Control;
            this.PicAvatar.Image = global::GAME_CARO.Properties.Resources.so_tai_caro_1_;
            this.PicAvatar.Location = new System.Drawing.Point(3, 4);
            this.PicAvatar.Name = "PicAvatar";
            this.PicAvatar.Size = new System.Drawing.Size(366, 286);
            this.PicAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAvatar.TabIndex = 0;
            this.PicAvatar.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.BtnLan);
            this.panel3.Controls.Add(this.txtIp);
            this.panel3.Controls.Add(this.PicMark);
            this.panel3.Controls.Add(this.PrgCoolDown);
            this.panel3.Controls.Add(this.TxtPlayerName);
            this.panel3.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(787, 299);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(372, 363);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rocket Propelled", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 in a line to win";
            // 
            // BtnLan
            // 
            this.BtnLan.Location = new System.Drawing.Point(14, 94);
            this.BtnLan.Name = "BtnLan";
            this.BtnLan.Size = new System.Drawing.Size(177, 23);
            this.BtnLan.TabIndex = 4;
            this.BtnLan.Text = "Connect Lan";
            this.BtnLan.UseVisualStyleBackColor = true;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(14, 68);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(177, 22);
            this.txtIp.TabIndex = 3;
            this.txtIp.Text = "127.0.0.1";
            // 
            // PicMark
            // 
            this.PicMark.BackColor = System.Drawing.SystemColors.Control;
            this.PicMark.Location = new System.Drawing.Point(198, 12);
            this.PicMark.Name = "PicMark";
            this.PicMark.Size = new System.Drawing.Size(163, 105);
            this.PicMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicMark.TabIndex = 2;
            this.PicMark.TabStop = false;
            // 
            // PrgCoolDown
            // 
            this.PrgCoolDown.Location = new System.Drawing.Point(14, 38);
            this.PrgCoolDown.Name = "PrgCoolDown";
            this.PrgCoolDown.Size = new System.Drawing.Size(177, 23);
            this.PrgCoolDown.TabIndex = 1;
            // 
            // TxtPlayerName
            // 
            this.TxtPlayerName.Location = new System.Drawing.Point(14, 12);
            this.TxtPlayerName.Name = "TxtPlayerName";
            this.TxtPlayerName.ReadOnly = true;
            this.TxtPlayerName.Size = new System.Drawing.Size(177, 22);
            this.TxtPlayerName.TabIndex = 0;
            // 
            // TmCoolDown
            // 
            this.TmCoolDown.Tick += new System.EventHandler(this.TmCoolDown_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 663);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnlChessBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Game Caro";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAvatar)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicMark)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlChessBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox PicAvatar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox PicMark;
        private System.Windows.Forms.ProgressBar PrgCoolDown;
        private System.Windows.Forms.TextBox TxtPlayerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnLan;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Timer TmCoolDown;
    }
}

