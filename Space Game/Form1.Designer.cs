namespace Space_Game
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1Score = new System.Windows.Forms.Label();
            this.player2Score = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.subtitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1Score
            // 
            this.player1Score.BackColor = System.Drawing.Color.Transparent;
            this.player1Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.player1Score.ForeColor = System.Drawing.Color.White;
            this.player1Score.Location = new System.Drawing.Point(1, 525);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(231, 75);
            this.player1Score.TabIndex = 0;
            this.player1Score.Text = "player1Score";
            this.player1Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player2Score
            // 
            this.player2Score.BackColor = System.Drawing.Color.Transparent;
            this.player2Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.player2Score.ForeColor = System.Drawing.Color.White;
            this.player2Score.Location = new System.Drawing.Point(516, 525);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(235, 75);
            this.player2Score.TabIndex = 0;
            this.player2Score.Text = "player2Score";
            this.player2Score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // title
            // 
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(217, 201);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(317, 156);
            this.title.TabIndex = 0;
            this.title.Text = "SPACE RACE";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // subtitle
            // 
            this.subtitle.BackColor = System.Drawing.Color.Transparent;
            this.subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.subtitle.ForeColor = System.Drawing.Color.White;
            this.subtitle.Location = new System.Drawing.Point(217, 307);
            this.subtitle.Name = "subtitle";
            this.subtitle.Size = new System.Drawing.Size(317, 134);
            this.subtitle.TabIndex = 0;
            this.subtitle.Text = "Press ESC to Exit or Space to Play";
            this.subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(750, 600);
            this.Controls.Add(this.subtitle);
            this.Controls.Add(this.title);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player1Score);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "k";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1Score;
        private System.Windows.Forms.Label player2Score;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label subtitle;
    }
}

