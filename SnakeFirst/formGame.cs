using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SnakeFirst
{
    public partial class formGame : Form
    {
        #region Constructor
        #region Variables
        int score = 0;
        bool gameover = false;
        int direction = 2; // 0 = down, 1 = left, 2 = right, 3 = up
        List<SnakePart> snake = new List<SnakePart>();
        const int tile_width = 32;
        const int tile_height = 32;
        SnakePart food;
        Timer gameLoop = new Timer();
        Timer snakeLoop = new Timer();
        float snakeRate = 2.0f;
        private int cor = 0;

        int tx = 0;
        int ty = 0;
        #endregion

        #region Image
        Image ball;
        
//        Image bodyright;
//        Image bodydown;
//        Image bodyup;
//        Image bodyleft;
        #endregion


        public formGame()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            InitializeComponent();
//            bodyright = Properties.Resources.body;
//            bodydown = Properties.Resources.body2;
//            bodyup = Properties.Resources.body3;
//            bodyleft = Properties.Resources.body4;
//
//            headdown = Properties.Resources.headdown;
//            headup = Properties.Resources.headup;
//            headleft = Properties.Resources.headleft;
//            headright = Properties.Resources.headright;

            ball = Properties.Resources.body;
            gameLoop.Tick += new EventHandler(Update);
            snakeLoop.Tick += new EventHandler(UpdateSnake);
            gameLoop.Interval = 1000 / 60;
            snakeLoop.Interval = (int) (1000 / snakeRate);
            gameLoop.Start();
            snakeLoop.Start();
            StartGame();
        }
        #endregion


        #region Form Events
        private void formGame_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);

        }

        private void formGame_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }


        private void pbCanvas_Paint(object sender, PaintEventArgs e)
        {
          
            Draw(e.Graphics);
        }
        #endregion

        #region Game Logic
        private void StartGame()
        {
            snakeRate = 2.0f;
            gameover = false;
            snakeLoop.Interval = (int)(1000 / snakeRate);
            snake.Clear();
            direction = 2;
            score = 0;
            SnakePart head = new SnakePart(10, 8);
            snake.Add(head);
            snake.Add(new SnakePart(9,8));
            snake.Add(new SnakePart(8, 8));
            snake.Add(new SnakePart(7, 8));
            GenerateFood();
        }

        private void GenerateFood()
        {
            int max_tile_w = pbCanvas.Size.Width / tile_width;
            int max_tile_h = pbCanvas.Size.Height / tile_height;
           

            bool valid = false;
            while (!valid)
            {
                Random random = new Random();
                int ax = random.Next(0, max_tile_w);
                int ay = random.Next(0, max_tile_h);

                bool Overlap = false;
                for (int i = 0; i > snake.Count - 1; i++)
                {
                    int sx = snake[i].X;
                    int sy = snake[i].Y;


                    if (ax == sx && ay == sy)
                    {
                        Overlap = true;
                        break;
                    }
                }

                if (!Overlap)
                {
                    food = new SnakePart(ax, ay);
                    valid = true;
                }

                

            }
        }

        private void Update(object sender, EventArgs e)
        {
            if (gameover)
            {
                if (Input.Press(Keys.Enter))
                {
                    StartGame();
                }
            }
            else
            {
                if (Input.Press(Keys.Left))
                {
                    if (snake.Count < 2 || snake[0].X == snake[1].X)
                        direction = 1;
                }
                else if(Input.Press(Keys.Right))
                {
                    if (snake.Count < 2 || snake[0].X == snake[1].X)
                        direction = 2;
                }
                else if (Input.Press(Keys.Up))
                {
                    if (snake.Count < 2 || snake[0].Y == snake[1].Y)
                        direction = 3;
                }
                else if (Input.Press(Keys.Down))
                {
                    if (snake.Count < 2 || snake[0].Y == snake[1].Y)
                        direction = 0;
                }
            }
            pbCanvas.Invalidate();
        }


        
        private void UpdateSnake(object sender, EventArgs e)
        {
            if (!gameover)
            {
                for (int i = snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (direction)
                        {
                            case 0:
                                snake[0].Y++;
                                break;
                            case 1:
                                snake[0].X--;
                                break;
                            case 2:
                                snake[0].X++;
                                break;
                            case 3:
                                snake[0].Y--;
                                break;
                        }

                        // Check for out of boounds
                        int max_tile_w = pbCanvas.Size.Width / tile_width;
                        int max_tile_h = pbCanvas.Size.Height / tile_height;
                        SnakePart head = snake[0];
                        if (head.X >= max_tile_w || head.X < 0 || head.Y >= max_tile_h || head.Y < 0)
                            GameOver();

                        // Check for collision with body
                        for (int j = 1; j < snake.Count; j++)
                            if (head.X == snake[j].X && head.Y == snake[j].Y)
                                GameOver();

                        // Check for collision with food
                        if (head.X == food.X && head.Y == food.Y)
                        {
                            int xcor = 0; // corecct X, + 1 or -1
                            int ycor = 0; // corecct X, + 1 or -1
                            switch (cor)
                            {
                                case 1:
                                    xcor = 1;
                                    break;
                                case 2:
                                    xcor = -1;
                                    break;
                                case 3:
                                    ycor = + 1;
                                    break;
                                case 0:
                                    ycor = - 1;
                                    break;
                            }
                            SnakePart part = new SnakePart(snake[snake.Count - 1].X + xcor , snake[snake.Count - 1].Y + ycor  );
                            snake.Add(part);
                            
                            GenerateFood();
                            score++;
                            if(snakeRate < 30)
                            {
                                snakeRate++;
                                snakeLoop.Interval = (int) (1000 / snakeRate);
                            }
                        }

                    }
                    else
                    {
                        snake[i].X = snake[i - 1].X;
                        snake[i].Y = snake[i - 1].Y;
                    }
                }

            }

        }

        private void Draw(Graphics canvas)
        {
            Font font = this.Font;
            if (gameover)
            {
                SizeF message = canvas.MeasureString("Gameover", font);
                canvas.DrawString("Gameover", font, Brushes.White, new PointF(160 - message.Width/2, 100));
                message = canvas.MeasureString("Final Score" + score.ToString(), font);
                canvas.DrawString("Final Score " + score.ToString(), font, Brushes.White,
                    new PointF(160 - message.Width/2, 120));
                message = canvas.MeasureString("Press Enter to Start a New Game", font);
                canvas.DrawString("Press Enter to Start a New Game", font, Brushes.White,
                    new PointF(160 - message.Width/2, 140));


            }
            else
            {
                canvas.DrawString("Score " + score.ToString(), font, Brushes.Black, new PointF(4, 4));
                for (int i = 0; i < snake.Count; i++)
                {
                    SnakePart segment = snake[i];
                    
                    var segx = segment.X;
                    var segy = segment.Y;
                    var tilex = segment.X*tile_width;
                    var tiley = segment.Y*tile_height;

                    

                     
                    if (i == 0)
                    {
                        // Head; Determine the correct image
                        var nseg = snake[i + 1]; // Next segment
                        if (segy < nseg.Y)
                        {
                            // Up
                            tx = 3;
                            ty = 0;
                        }
                        else if (segx > nseg.X)
                        {
                            // Right
                            tx = 4;
                            ty = 0;
                        }
                        else if (segy > nseg.Y)
                        {
                            // Down
                            tx = 4;
                            ty = 1;
                        }
                        else if (segx < nseg.X)
                        {
                            // Left
                            tx = 3;
                            ty = 1;
                        }
                    }
                    else if (i == snake.Count - 1)
                    {
                        // Tail; Determine the correct image
                        var pseg = snake[i - 1]; // Prev segment
                        if (pseg.Y < segy)
                        {
                            // Up
                            tx = 3;
                            ty = 2;
                            cor = 3;
                        }
                        else if (pseg.X > segx)
                        {
                            // Right
                            tx = 4;
                            ty = 2;
                            cor = 2;
                        }
                        else if (pseg.Y > segy)
                        {
                            // Down
                            tx = 4;
                            ty = 3;
                            cor = 0;
                        }
                        else if (pseg.X < segx)
                        {
                            // Left
                            tx = 3;
                            ty = 3;
                            cor = 1;
                        }
                    }

                    else
                    {
                        // Body; Determine the correct image
                        var pseg = snake[i - 1]; // Previous segment
                        var nseg = snake[i + 1]; // Next segment
                        if (pseg.X < segx && nseg.X > segx || nseg.X < segx && pseg.X > segx)
                        {
                            // Horizontal Left-Right
                            tx = 1;
                            ty = 0;
                        }
                        else if (pseg.X < segx && nseg.Y > segy || nseg.X < segx && pseg.Y > segy)
                        {
                            // Angle Left-Down
                            tx = 2;
                            ty = 0;
                        }
                        else if (pseg.Y < segy && nseg.Y > segy || nseg.Y < segy && pseg.Y > segy)
                        {
                            // Vertical Up-Down
                            tx = 2;
                            ty = 1;
                        }
                        else if (pseg.Y < segy && nseg.X < segx || nseg.Y < segy && pseg.X < segx)
                        {
                            // Angle Top-Left
                            tx = 2;
                            ty = 2;
                        }
                        else if (pseg.X > segx && nseg.Y < segy || nseg.X > segx && pseg.Y < segy)
                        {
                            // Angle Right-Up
                            tx = 0;
                            ty = 1;
                        }
                        else if (pseg.Y > segy && nseg.X > segx || nseg.Y > segy && pseg.X > segx)
                        {
                            // Angle Down-Right
                            tx = 0;
                            ty = 0;
                        }

                        
                    }
                    Rectangle rec = new Rectangle(tx * 64, ty * 64, 64, 64);
                    
                    canvas.DrawImage(Properties.Resources.snake_graphics.Clone(rec, System.Drawing.Imaging.PixelFormat.Format32bppArgb), tilex, tiley, tile_width, tile_height);

                    
                }
                Rectangle recf = new Rectangle(0 * 64, 3 * 64, 64, 64);
                canvas.DrawImage(Properties.Resources.snake_graphics.Clone(recf, System.Drawing.Imaging.PixelFormat.Format32bppArgb), food.X * tile_width, food.Y * tile_height, tile_width, tile_height);

                
            }
            
        }


        private
            void GameOver()
        {
            gameover = true;
        }

        
        #endregion

        private void extToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }
    }
}
