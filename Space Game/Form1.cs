using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Space_Game
{
    public partial class Form1 : Form
    {
        SoundPlayer won = new SoundPlayer(Properties.Resources._258142__tuudurt__level_win);
        SoundPlayer reset = new SoundPlayer(Properties.Resources._249561__surn_thing__lose);
        SoundPlayer ding = new SoundPlayer(Properties.Resources._345297__scrampunk__itemize);

        Rectangle sship1 = new Rectangle(280, 550, 10, 40);
        Rectangle sship2 = new Rectangle(480, 550, 10, 40);

        int p1score = 0;
        int p2score = 0;

        string gamestate = "waiting";

        int shipSpeed = 6;
        bool upDown = false;
        bool down = false;
        bool wDown = false;
        bool sDown = false;

        List<Rectangle> asteroids1 = new List<Rectangle>();
        List<Rectangle> asteroids2 = new List<Rectangle>();

        int asteroidSize = 10;
        int asteroidSpeed = 8;

        List<string> asteroidColours = new List<string>();
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;
        int safeZone = 50;



        public Form1()
        {
            InitializeComponent();
            player1Score.Text = "";
            player2Score.Text = "";
        }
        public void GameStart()
        {
            gameTimer.Enabled = true;
            gamestate = "running";

            p1score = 0;
            p2score = 0;
            asteroids1.Clear();
            asteroids2.Clear();

        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {


            //move the player 1
            if (wDown == true)
            {
                sship1.Y -= shipSpeed;
            }
            if (sDown == true)
            {
                sship1.Y += shipSpeed;
            }
            //move player 2
            if (upDown == true)
            {
                sship2.Y -= shipSpeed;
            }
            if (down == true)
            {
                sship2.Y += shipSpeed;
            }

            // move  the asteroids right
            for (int i = 0; i < asteroids1.Count(); i++)
            {
                //find the new postion of y based on speed 
                int x = asteroids1[i].X + asteroidSpeed;

                //replace the rectangle in the list with updated one using new y 
                asteroids1[i] = new Rectangle(x, asteroids1[i].Y, asteroidSize, asteroidSize);
            }
            //move the asteroids left
            for (int i = 0; i < asteroids2.Count(); i++)
            {
                //find the new postion of y based on speed 
                int x = asteroids2[i].X - asteroidSpeed;

                //replace the rectangle in the list with updated one using new y 
                asteroids2[i] = new Rectangle(x, asteroids2[i].Y, asteroidSize, asteroidSize);
            }
            //create a random value from 1 to 10 
            randValue = randGen.Next(0, 11);
            //if the randvalue is under 3 run the code inside the if statement
            if (randValue < 2)
            {
                int y = randGen.Next(40, this.Height - asteroidSize - safeZone * 2);
                asteroids1.Add(new Rectangle(10, y, asteroidSize, asteroidSize));
            }
            if (randValue < 2)
            {
                int y = randGen.Next(40, this.Height - asteroidSize - safeZone * 2);
                asteroids2.Add(new Rectangle(740, y, asteroidSize, asteroidSize));
            }
            //create a for loop and inside the for loop check if the asteroid has went over the border, and if so, remove the asteroid
            for (int i = 0; i < asteroids1.Count(); i++)
            {
                if (asteroids1[i].X > this.Width)
                {
                    asteroids1.RemoveAt(i);
                }
            }
            for (int i = 0; i < asteroids1.Count(); i++)
            {

                if (asteroids2[i].X < 0)
                {
                    asteroids2.RemoveAt(i);
                }
            }
            //check to see if either of the players had reached the other side
            for (int i = 0; i < asteroids1.Count(); i++)
            {
                if (sship1.Y < 0)
                {
                    ding.Play();
                    p1score += 1;
                    player1Score.Text = $"{p1score}";

                    sship1.X = 280;
                    sship1.Y = 550;


                }
                if (sship2.Y < 0)
                {
                    ding.Play();
                    p2score += 1;
                    player2Score.Text = $"{p2score}";
                    sship2.Y = 480;
                    sship2.Y = 550;

                }
            }
            //checks to see if the ships has collided with the asteroids
            for (int i = 0; i < asteroids2.Count(); i++)
            {
                if (sship2.IntersectsWith(asteroids2[i]))
                {
                    reset.Play();
                    sship2.X = 480;
                    sship2.Y = 550;

                }
                if (sship1.IntersectsWith(asteroids2[i]))
                {

                    sship1.X = 280;
                    sship1.Y = 550;

                }
            }
            for (int i = 0; i < asteroids1.Count(); i++)
            {
                if (sship1.IntersectsWith(asteroids1[i]))
                {
                    reset.Play();
                    sship1.X = 280;
                    sship1.Y = 550;
                }



                if (sship2.IntersectsWith(asteroids1[i]))
                {
                    reset.Play();
                    sship2.X = 480;
                    sship2.Y = 550;
                }

                //checks to see if either of the payers have gotten the score of 3
                if (p1score == 3)
                {
                    gamestate = "over";
                    won.Play();
                    gameTimer.Enabled = false;
                }
                else if (p2score == 3)
                {
                    gamestate = "over";
                    won.Play();
                    gameTimer.Enabled = false;
                }



               
            }
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    down = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space:

                    if (gamestate == "waiting" || gamestate == "over")
                    {
                        GameStart();
                    }
                    break;
                case Keys.Escape:
                    if (gamestate == "waiting" || gamestate == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            if (gamestate == "waiting")
            {
                title.Text = "SPACE RACE";
                subtitle.Text = "Press Space Bar To Start or Escape to Exit";
                player1Score.Text = $"";
                player2Score.Text = $"";
            }
            else if (gamestate == "running")

            {

                // draw text at top 

                title.Text = $"";
                subtitle.Text = $"";
                player1Score.Text = $"{p1score}";

                player2Score.Text = $"{p2score}";

                //draw the asteriods right side
                for (int i = 0; i < asteroids1.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, asteroids1[i]);
                }
                //draw the asteriods for the left side
                for (int i = 0; i < asteroids2.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, asteroids2[i]);
                }
                //draw  player 1
                e.Graphics.FillRectangle(whiteBrush, sship1);

                //draw  player 2
                e.Graphics.FillRectangle(whiteBrush, sship2);

            }
            else if (gamestate == "over")
            {
                player1Score.Text = "";

                player2Score.Text = "";


                if (p1score == 3)
                {


                    title.Text = "Player 1 Wins";
                    subtitle.Text = "Press Space Bar to Start or Escape to Exit";



                }
                else if (p2score == 3)
                {


                    title.Text = "Player 2 Wins";
                    subtitle.Text = "Press Space Bar to Start or Escape to Exit";

                }


            }

        }
    }



}
