using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Media;
using SnakeFirst.Properties;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace SnakeFirst
{
    public partial class FormGame : Form
    {
        #region Constructor

        #region Variables

        private int _score;

        private bool _gameover;

        private int _direction = 2; // 0 = down, 1 = left, 2 = right, 3 = up

        private readonly List<SnakePart> _snake = new List<SnakePart>();

        private readonly List<SnakePart> _bombList = new List<SnakePart>();

        private const int TileWidth = 32;
        private const int TileHeight = 32;

        private SnakePart _food;
        private SnakePart _bomb;

        private readonly Timer _gameLoop = new Timer();
        private readonly Timer _snakeLoop = new Timer();
        private Timer _time = new Timer();

        private float _snakeRate = 2;

        private int _cor;

        private int _tx;
        private int _ty;

        private bool _sGame;

        private MediaPlayer _fSound;
        private int _n;


        #endregion

        public FormGame()
        {
            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            InitializeComponent();


            _gameLoop.Tick += Update;
            _snakeLoop.Tick += UpdateSnake;
            _gameLoop.Interval = 1000/60;
            _snakeLoop.Interval = (int) (1000/_snakeRate);
            _gameLoop.Start();
            _snakeLoop.Start();
            _sGame = false;

            PlayMusic();
        }

        #endregion

        #region Form Events

        private void formGame_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
            if (e.KeyCode == Keys.Enter)
            {
                StartGame();
            }
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
            _sGame = true;
           

            _gameover = false;
            _snakeRate = 2;
            _snakeLoop.Interval = (int) (1000/_snakeRate);
            _snake.Clear();
            _direction = 2;
            _score = 0;

            _bombList.Clear();
            var head = new SnakePart(10, 8);
            _snake.Add(head);
            _snake.Add(new SnakePart(9, 8));
            _snake.Add(new SnakePart(8, 8));
            _snake.Add(new SnakePart(7, 8));
           

            GenerateFoodandBomb();
            
        }

        #region Music

        private void PlayMusic()
        {
            _fSound = new MediaPlayer();
            _fSound.Open(new Uri("mus.wav", UriKind.Relative));
            _fSound.Play();
        }

        private static void PlaySoundFromResourceApple()
        {
            Assembly.GetExecutingAssembly();
            var playersSoundPlayer = new SoundPlayer("apple.wav");
            playersSoundPlayer.Play();
        }

        private static void PlaySoundFromResourceBomb()
        {
            Assembly.GetExecutingAssembly();
            var playersSoundPlayer = new SoundPlayer("bomb.wav");
            playersSoundPlayer.Play();
            
        }
        #endregion
        private void GenerateFoodandBomb()
        {
           
            var maxTileW = pbCanvas.Size.Width/TileWidth;
            var maxTileH = pbCanvas.Size.Height/TileHeight;


            _n = 0;
            
                var valid = false;
                while (!valid)
                {
                    var random = new Random();
                    var fx = random.Next(0, maxTileW);
                    var fy = random.Next(0, maxTileH);

                    var bx = random.Next(0, maxTileW);
                    var by = random.Next(0, maxTileH);

                    var b2x = random.Next(0, maxTileW);
                    var b2y = random.Next(0, maxTileH);

                    var b3x = random.Next(0, maxTileW);
                    var b3y = random.Next(0, maxTileH);

                var overlap = false;
                    for (var i = 0; i < _snake.Count - 1; i++)
                    {
                        var sx = _snake[i].X;
                        var sy = _snake[i].Y;


                        if ((fx == sx && fy == sy) || (bx == sx && by == sy) || (b2x == sx && b2y == sy) || (b3x == sx && b3y == sy))
                        {
                            overlap = true;
                            break;
                        }

                    }
                for (var q = 0; q < _bombList.Count -1 ; q++)
                {
                    var qx = _bombList[q].X;
                    var qy = _bombList[q].Y;


                    if ((fx == qx && fy == qy))
                    {
                        overlap = true;
                        break;
                    }

                }
                if (!overlap)
                    {

                    _food = new SnakePart(fx, fy);
                    _bomb = new SnakePart(bx, by);
                    if (складнийToolStripMenuItem.Checked)
                    {
                       

                        _bombList.Add(_bomb);
                        _bombList.Add(new SnakePart(b2x, b2y));
                        _bombList.Add(new SnakePart(b3x, b3y));

                    }
                    if (середнійToolStripMenuItem.Checked) {
                        
                    _bombList.Add(new SnakePart(b2x, b2y));
                        _bombList.Add(_bomb);
                    }
                    if (легкийToolStripMenuItem.Checked)
                    {
                        

                        _bombList.Add(_bomb);

                    }
                    


                    valid = true;
                    }
                }
            
            


        }

        

        private void Update(object sender, EventArgs e)
        {
            if (_gameover)
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
                    if (_snake.Count < 2 || _snake[0].X == _snake[1].X)
                        _direction = 1;
                }
                else if (Input.Press(Keys.Right))
                {
                    if (_snake.Count < 2 || _snake[0].X == _snake[1].X)
                        _direction = 2;
                }
                else if (Input.Press(Keys.Up))
                {
                    if (_snake.Count < 2 || _snake[0].Y == _snake[1].Y)
                        _direction = 3;
                }
                else if (Input.Press(Keys.Down))
                {
                    if (_snake.Count < 2 || _snake[0].Y == _snake[1].Y)
                        _direction = 0;
                }
            }
            pbCanvas.Invalidate();
        }


        private void UpdateSnake(object sender, EventArgs e)
        {
            if (!_gameover)
            {
                for (var i = _snake.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        switch (_direction)
                        {
                            case 0:
                                _snake[0].Y++;
                                break;
                            case 1:
                                _snake[0].X--;
                                break;
                            case 2:
                                _snake[0].X++;
                                break;
                            case 3:
                                _snake[0].Y--;
                                break;
                        }

                        // Check for out of boounds
                        var maxTileW = pbCanvas.Size.Width / TileWidth;
                        var maxTileH = pbCanvas.Size.Height / TileHeight;
                        var head = _snake[0];
                        if (head.X >= maxTileW || head.X < 0 || head.Y >= maxTileH || head.Y < 0)
                            GameOver();

                        // Check for collision with body
                        for (var j = 1; j < _snake.Count; j++)
                        {
                            if (head.X == _snake[j].X && head.Y == _snake[j].Y)
                                GameOver();
                        }

                        // Check for collision with BOMBs
                        foreach (SnakePart _bomb_chk in _bombList) { 
                        if (head.X == _bomb_chk.X && head.Y == _bomb_chk.Y)
                        {
                                PlaySoundFromResourceBomb();
                                
                            GameOver();
                        }
                    }

                            // Check for collision with _food
                            if (head.X == _food.X && head.Y == _food.Y)
                        {
                            PlaySoundFromResourceApple();
                            var xcor = 0; // corecct x, + 1 or -1
                            var ycor = 0; // corecct x, + 1 or -1
                            switch (_cor)
                            {
                                case 1:
                                    xcor = 1;
                                    break;
                                case 2:
                                    xcor = -1;
                                    break;
                                case 3:
                                    ycor = +1;
                                    break;
                                case 0:
                                    ycor = -1;
                                    break;
                            }
                            var part = new SnakePart(_snake[_snake.Count - 1].X + xcor,
                                _snake[_snake.Count - 1].Y + ycor);
                            _snake.Add(part);

                            GenerateFoodandBomb();

                            if (складнийToolStripMenuItem.Checked)
                            {
                                _score=_score + 3;
                            }

                            if (середнійToolStripMenuItem.Checked)
                            {
                                _score = _score + 2;
                            }

                            if (легкийToolStripMenuItem.Checked)
                            {
                                _score++;
                            }

                            if (_snakeRate < 30)
                            {
                                _snakeRate++;
                                _snakeLoop.Interval = (int) (1000 / _snakeRate);

                            }
                        }
                    }
                    else
                    {
                        _snake[i].X = _snake[i - 1].X;
                        _snake[i].Y = _snake[i - 1].Y;
                    }
                }
            }
        }

        private void Draw(Graphics canvas)
        {
            if (_gameover || !_sGame)
            {
                var recf = new Rectangle(125, 1, 600, 500);
                canvas.DrawImage(Resources.Snake_final, recf);
            }
            else
            {
                LScore.Text = Resources.formGame_Draw__Score__ + _score;

                for (var i = 0; i < _snake.Count; i++)
                {
                    var segment = _snake[i];

                    var segx = segment.X;
                    var segy = segment.Y;
                    var tilex = segment.X*TileWidth;
                    var tiley = segment.Y*TileHeight;


                    if (i == 0)
                    {
                        // Head; Determine the correct image
                        var nseg = _snake[i + 1]; // Next segment
                        if (segy < nseg.Y)
                        {
                            // Up
                            _tx = 3;
                            _ty = 0;
                        }
                        else if (segx > nseg.X)
                        {
                            // Right
                            _tx = 4;
                            _ty = 0;
                        }
                        else if (segy > nseg.Y)
                        {
                            // Down
                            _tx = 4;
                            _ty = 1;
                        }
                        else if (segx < nseg.X)
                        {
                            // Left
                            _tx = 3;
                            _ty = 1;
                        }
                    }
                    else if (i == _snake.Count - 1)
                    {
                        // Tail; Determine the correct image
                        var pseg = _snake[i - 1]; // Prev segment
                        if (pseg.Y < segy)
                        {
                            // Up
                            _tx = 3;
                            _ty = 2;
                            _cor = 3;
                        }
                        else if (pseg.X > segx)
                        {
                            // Right
                            _tx = 4;
                            _ty = 2;
                            _cor = 2;
                        }
                        else if (pseg.Y > segy)
                        {
                            // Down
                            _tx = 4;
                            _ty = 3;
                            _cor = 0;
                        }
                        else if (pseg.X < segx)
                        {
                            // Left
                            _tx = 3;
                            _ty = 3;
                            _cor = 1;
                        }
                    }

                    else
                    {
                        // Body; Determine the correct image
                        var pseg = _snake[i - 1]; // Previous segment
                        var nseg = _snake[i + 1]; // Next segment
                        if (pseg.X < segx && nseg.X > segx || nseg.X < segx && pseg.X > segx)
                        {
                            // Horizontal Left-Right
                            _tx = 1;
                            _ty = 0;
                        }
                        else if (pseg.X < segx && nseg.Y > segy || nseg.X < segx && pseg.Y > segy)
                        {
                            // Angle Left-Down
                            _tx = 2;
                            _ty = 0;
                        }
                        else if (pseg.Y < segy && nseg.Y > segy || nseg.Y < segy && pseg.Y > segy)
                        {
                            // Vertical Up-Down
                            _tx = 2;
                            _ty = 1;
                        }
                        else if (pseg.Y < segy && nseg.X < segx || nseg.Y < segy && pseg.X < segx)
                        {
                            // Angle Top-Left
                            _tx = 2;
                            _ty = 2;
                        }
                        else if (pseg.X > segx && nseg.Y < segy || nseg.X > segx && pseg.Y < segy)
                        {
                            // Angle Right-Up
                            _tx = 0;
                            _ty = 1;
                        }
                        else if (pseg.Y > segy && nseg.X > segx || nseg.Y > segy && pseg.X > segx)
                        {
                            // Angle Down-Right
                            _tx = 0;
                            _ty = 0;
                        }
                    }
                    var rec = new Rectangle(_tx*64, _ty*64, 64, 64);

                    canvas.DrawImage(Resources.snake_graphics1.Clone(rec, PixelFormat.Format32bppArgb), tilex, tiley,
                        TileWidth, TileHeight);
                }

                var recf = new Rectangle(0 * 64, 3 * 64, 64, 64);
                canvas.DrawImage(Resources.snake_graphics1.Clone(recf, PixelFormat.Format32bppArgb), _food.X * TileWidth,
                    _food.Y * TileHeight, TileWidth, TileHeight);


                foreach (SnakePart bombs in _bombList)
                {
                    var recf2 = new Rectangle(0, 0, 64, 64);
                    canvas.DrawImage(Resources.Bomb64.Clone(recf2, PixelFormat.Format32bppArgb), bombs.X * TileWidth,
                        bombs.Y * TileHeight, TileWidth, TileHeight);
                }
                
            }
        }


        private
            void GameOver()
        {
            _gameover = true;
            DataRecords.Score = _score.ToString();
            new PlayerInfo().ShowDialog();
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

        private void pbCanvas_Click(object sender, EventArgs e)
        {
        }

        private void recordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Records().ShowDialog();
        }

        private void легкийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            середнійToolStripMenuItem.CheckState = CheckState.Unchecked;
            складнийToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        private void середнійToolStripMenuItem_Click(object sender, EventArgs e)
        {
            легкийToolStripMenuItem.CheckState = CheckState.Unchecked;
            складнийToolStripMenuItem.CheckState = CheckState.Unchecked;
        }

        private void складнийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            легкийToolStripMenuItem.CheckState = CheckState.Unchecked;
            середнійToolStripMenuItem.CheckState = CheckState.Unchecked;
        }
    }
}
