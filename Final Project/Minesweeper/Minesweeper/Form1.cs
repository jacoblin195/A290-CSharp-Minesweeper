//Final Project
//A290
//Minesweeper
//Author Jacob Lin
//Created on 12/2/2017
//last edit on 12/8/2017
//Form1 class, Tile class, ThemeSetting Class




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ValueTuple;
using System.IO;
using System.Drawing.Drawing2D;
//Install-Package "System.ValueTuple"

namespace Minesweeper
{
    public partial class Form1 : Form
    {
        //Timer 
        public Timer timer = new Timer();
        int timerCounter = 0;

        //Timer Display
        PictureBox[] timeDisplay = new PictureBox[3];
        Image[] numberImages = new Image[11];

        //Score Display
        PictureBox[] MineScore = new PictureBox[3];

        //High Scores
        public LinkedList<(String, int)> highscores = new LinkedList<(String, int)>();

        //Controls other than TileGrid
        public LinkedList<Control> DefaultControls = new LinkedList<Control>();

        //List of Marked Tiles
        public LinkedList<Tile> markedTiles = new LinkedList<Tile>();

        //ThemeSetting
        public ThemeSetting themeSetting = new ThemeSetting();

        //Random number generator
        public static Random random = new System.Random();

        //Difficulty level
        public Difficulty difficulty = Difficulty.easy;

        //Tile Grid
        public Tile[,] tileGrid;

        //Horizontal gap on two sides
        public int offsetHorizontal = 100;

        //TileWidth
        public int tileWidth = 30;

        //Veritical Gap
        internal int offsetVertical = 150;

        public List<Tile> mineList;


        //Difficulty Options
        public enum Difficulty
        {
            easy, medium, hard
        }

        //Get game parameters according to the difficulty level
        private (int dimention, int mineNum) getDifficultySetting()
        {
            switch (this.difficulty)
            {
                case Difficulty.easy:
                    return (8, 10);
                case Difficulty.medium:
                    return (12, 25);
                default:
                    return (16, 40);
            }
        }


        public Form1()
        {
            InitializeComponent();

            //Timer interval 1 second
            timer.Interval = 1000;
            //Tick listener
            timer.Tick += this.onTick;

            //Timer display initial setup
            timeDisplay[0] = pictureBox_Timer1;
            timeDisplay[1] = pictureBox_Timer2;
            timeDisplay[2] = pictureBox_Timer3;

            //Score display
            MineScore[0] = pictureBox_MineLeft1;
            MineScore[1] = pictureBox_MineLeft2;
            MineScore[2] = pictureBox_MineLeft3;

            //Load Image Resources
            loadDisplayResources();

            //Add other controls to a list
            foreach (Control control in this.Controls)
            {
                this.DefaultControls.AddLast(control);
            }

            //remove maximize minimize boxes
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //Setup the game
            setup();
        }

        private void loadHighScores()
        {

            highscores = new LinkedList<(string, int)>();

            try
            {
                //load history score data from local files
                String[] lines = System.IO.File.ReadAllLines(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/highscores.txt");

                if (lines.Length < 3)
                {
                    //Incorrect format
                    throw new FormatException();
                }
                foreach (String line in lines)
                {
                    //load Scores to varaible
                    String[] items = line.Split();
                    highscores.AddLast((items[0], int.Parse(items[1])));
                }

            }
            catch (Exception e)
            {
                //Reset all scores in RAM if any exception raises
                highscores.AddLast(("Anonymous", 999));
                highscores.AddLast(("Anonymous", 999));
                highscores.AddLast(("Anonymous", 999));
            }

        }

        private void loadDisplayResources()
        {
            //load display images
            String projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            for (int i = 0; i < 11; i++)
            {
                numberImages[i] = Image.FromFile(projectDirectory + "/Assets/" + i.ToString() + ".png");
            }

        }

        public void setup()
        {

            //Remove old controls
            if (tileGrid != null)
            {
                this.Controls.Clear();
            }


            //Add other controls back to form
            foreach (Control control in DefaultControls)
            {
                this.Controls.Add(control);
            }

            //Get game setting
            (int, int) setting = this.getDifficultySetting();
            int dimension = setting.Item1;

            //Reset tileGrid
            tileGrid = new Tile[dimension, dimension];

            //Initialize game related collections
            mineList = new List<Tile>();
            markedTiles = new LinkedList<Tile>();

            //Adjust window size
            this.SetClientSizeCore(offsetHorizontal * 2 + setting.Item1 * tileWidth, this.ClientSize.Height);

            //Initialize tileGrid
            for (int i = 0; i < setting.Item1; i++)
            {
                for (int j = 0; j < setting.Item1; j++)
                {
                    tileGrid[i, j] = new Tile(i, j, this);
                    tileGrid[i, j].updateThemeSettings();

                }
            }

            //Set Mines
            for (int i = 0; i < setting.Item2; i++)
            {
                for (; ; )
                {
                    int x = (int)(random.Next(dimension));
                    int y = (int)(random.Next(dimension));
                    if (!tileGrid[y, x].isMine())
                    {
                        tileGrid[y, x].setValue(9);
                        mineList.Add(tileGrid[y, x]);
                        break;
                    }
                }
            }

            //Calculate Values
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    if (!tileGrid[i, j].isMine())
                    {
                        int count = 0;
                        for (int m = i - 1; m <= i + 1; m++)
                        {
                            for (int n = j - 1; n <= j + 1; n++)
                            {
                                if (m >= 0 && m < dimension && n >= 0 && n < dimension && tileGrid[m, n].isMine())
                                {
                                    count++;
                                }
                            }
                        }
                        tileGrid[i, j].setValue(count);
                    }
                }
            }
            //Reset Timer
            timer.Stop();
            timerCounter = 0;

            updateTimer();

            //Reset Score Display
            updateScore();

            //load high scores from local files
            loadHighScores();
            
            //locate controls dynamically according to game setting
            button_ChangeTheme.Top = tileGrid[dimension - 1, dimension - 1].Top + 50;
            button_ChangeTheme.Left = (this.ClientSize.Width - button_ChangeTheme.Width) / 2;

            button_StartOver.Left = (this.ClientSize.Width - button_StartOver.Width) / 2;

            label_Difficulty.Left = (this.ClientSize.Width - label_Difficulty.Width) / 2;
            label_Difficulty.Top = button_ChangeTheme.Top + 60;

            comboBox_DifficultySelector.Top = label_Difficulty.Top + 50;
            comboBox_DifficultySelector.Left = (this.ClientSize.Width - comboBox_DifficultySelector.Width) / 2;

            button_Quit.Top = comboBox_DifficultySelector.Top + 60;
            button_Quit.Left = (this.ClientSize.Width - button_Quit.Width) / 2;

            this.Height = button_Quit.Top + 150;

            label_Timer.Left = 50;
            label_Timer.Top = pictureBox_Timer1.Top + 80;

            label_MinesRemaining.Top = label_Timer.Top;
            label_MinesRemaining.Left = MineScore[0].Left-20;

        }

        private void updateTimer()
        {
            //hundred
            int a = timerCounter / 100;
            timeDisplay[0].Image = numberImages[a];

            //tens
            int b = (timerCounter % 100) / 10;
            timeDisplay[1].Image = numberImages[b];

            //ones
            int c = (timerCounter % 10);
            timeDisplay[2].Image = numberImages[c];
        }

        private void button_changeTheme_Click(object sender, EventArgs e)
        {
            //change appearance for all tiles
            (int, int) setting = this.getDifficultySetting();
            this.themeSetting.changeColor();
            for (int i = 0; i < setting.Item1; i++)
            {
                for (int j = 0; j < setting.Item1; j++)
                {
                    tileGrid[i, j].updateThemeSettings();
                }
            }
        }

        //Check if the player wins the game
        public bool win()
        {

            //Check if all mines are marked
            bool undiscoveredMine = false;
            foreach (Tile t in mineList)
            {
                if (t.tileStatus != Tile.TileStatus.Marked)
                {
                    undiscoveredMine = true;
                    break;
                }
            }
            return !undiscoveredMine;
        }
        internal void dig(Tile tile)
        {
            //Check winning game

            if (win())
            {
                endGame(300);
            }
            //If the tile has no mines around
            //expand digging
            if (tile.value == 0)
            {
                (int, int) setting = this.getDifficultySetting();
                int dimension = setting.Item1;

                for (int m = tile.rowNum - 1; m <= tile.rowNum + 1; m++)
                {
                    for (int n = tile.colNum - 1; n <= tile.colNum + 1; n++)
                    {
                        if (m >= 0 &&
                                m < dimension && n >= 0 &&
                                n < dimension && tileGrid[m, n] != tile &&
                                tileGrid[m, n].tileStatus == Tile.TileStatus.Normal)
                        {
                            tileGrid[m, n].dig();
                        }
                    }
                }
            }
            //end game if the player digs a tile with mine
            else if (tile.isMine())
            {
                endGame(200);
            }
        }

        public void endGame(int port)
        {
            this.timer.Stop();

            //Remove all mousedown handlers of tiles
            for (int i = 0; i < tileGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tileGrid.GetLength(1); j++)
                {
                    tileGrid[i, j].MouseDown -= tileGrid[i, j].Tile_Click;
                }
            }

            switch (port)
            {
                case 300:
                    //win game
                    winGame();
                    break;
                case 400:
                    //time's up lose game
                    if(MessageBox.Show(this, "You run out of time!", "Time's up!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                    {
                        loseGame();
                    }
                    break;
                default:
                    // lose game
                    loseGame();
                    break;
            }
        }

        private void loseGame()
        {
            //ask if start a new game
            Continue continueWindow = new Continue(this, false);
            continueWindow.Show();
        }

        private void winGame()
        {
            // show all tiles even they are not digged yet
            for (int i = 0; i < tileGrid.GetLength(0); i++)
            {
                for (int j = 0; j < tileGrid.GetLength(1); j++)
                {
                    tileGrid[i, j].endGameShow();
                }
            }

            // Check if the current score beat history scores
            foreach ((String, int) highscore in highscores)
            {
                if (timerCounter < highscore.Item2)
                {
                    //Ask the player to record his high score
                    HighScoreInput form = new HighScoreInput(this);
                    form.Show(this);
                    break;
                }
            }


        }

        public void saveNewHighScore(String name)
        {
            // Add newest high score
            highscores.AddLast((name, timerCounter));

            // Sort the high score list
            var newlist = highscores.OrderBy(i => i.Item2).ToArray();

            //File path
            String highScoreFilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/highscores.txt";

            //write the file if the file exist or not
            TextWriter tw;
            if (!File.Exists(highScoreFilePath))
            {
                File.Create(highScoreFilePath);
                tw = new StreamWriter(highScoreFilePath);
            }
            else
            {
                tw = new StreamWriter(highScoreFilePath, false);
            }
            for (int i = 0; i < 3; i++)
            {
                (String, int) temp = newlist[i];
                tw.WriteLine(temp.Item1 + " " + temp.Item2.ToString());
            }
            tw.Close();
        }
        private void onTick(Object sender, EventArgs e)
        {
            //update timer display
            timerCounter += 1;
            updateTimer();

            if (timerCounter > 999)
            {
                //Timeout
                endGame(400);
            }
        }

        internal void updateScore()
        {
            //Update score of how many mines left
            int temp = mineList.Count - markedTiles.Count;
            if (temp < 0)
            {
                MineScore[0].Image = numberImages[10];
            }
            else
            {
                MineScore[0].Image = numberImages[0];
            }

            MineScore[1].Image = numberImages[temp / 10];
            MineScore[2].Image = numberImages[temp % 10];
        }

        private void button_StartOver_Click(object sender, EventArgs e)
        {
            //Directly restart the game if the player is not playing a game
            if(timer.Enabled == false)
            {
                setup();
                return;
            }
            //Aske the player to confirm if he is currently playing a game
            if(MessageBox.Show(this,"Are you sure you want to give up this game?","Start Over",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            setup();
        }

        private void comboBox_DifficultySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Change Difficulty setting
            switch (comboBox_DifficultySelector.Text)
            {
                case "Easy":
                    this.difficulty = Difficulty.easy;
                    break;
                case "Medium":
                    this.difficulty = Difficulty.medium;
                    break;
                case "Hard":
                    this.difficulty = Difficulty.hard;
                    break;
                default:
                    this.difficulty = Difficulty.easy;
                    break;
            }
            //restart the game
            this.setup();
        }

        private void button_Quit_Click(object sender, EventArgs e)
        {
            //quit the application
            Close();
        }
    }



    public class Tile : Button
    {
        // Tile status
        public enum TileStatus
        {
            Marked,Normal,Discovered
        }

        public TileStatus tileStatus = TileStatus.Normal;

        //Location reference
        public readonly int rowNum;
        public readonly int colNum;

        //Number of mines nearby
        public int value;

        //reference to game window
        private Form1 game;
        

        public Tile(int rowNum, int colNum,Form1 game) : base()
        {
            this.game = game;

            this.colNum = colNum;
            this.rowNum = rowNum;

            //MouseDown handler
            this.MouseDown += this.Tile_Click;

            //locate the button according to location references
            this.Left = game.offsetHorizontal + colNum * game.tileWidth;
            this.Top = game.offsetVertical + rowNum * game.tileWidth;
            this.Width = game.tileWidth;
            this.Height = game.tileWidth;

            //Set Appearance
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.Black;
            this.FlatAppearance.BorderSize = 1;

            this.ForeColor = game.themeSetting.getFontColor();

            //Unfocusable
            SetStyle(ControlStyles.Selectable, false);
            game.Controls.Add(this);
            
        }

        public void Tile_Click(Object sender, EventArgs e)
        {
            //start the timer if first click
            if (!game.timer.Enabled)
            {
                game.timer.Start();
            }

            //dig on left, mark on right
            MouseEventArgs e2 = (MouseEventArgs) e;
            switch (e2.Button)
            {
                case MouseButtons.Left:
                    this.dig();
                    break;
                default:
                    this.mark();
                    break;
            }
        }

        private void mark()
        {
            //toggle mark status
            switch (this.tileStatus)
            {
                case TileStatus.Normal:
                    this.tileStatus = TileStatus.Marked;
                    game.markedTiles.AddLast(this);
                    setMarkAppearance();
                    break;
                case TileStatus.Marked:
                    this.tileStatus = TileStatus.Normal;
                    game.markedTiles.Remove(this);
                    setNormalAppearance();
                    break;
                default:
                    break;
            }

            //update score
            game.updateScore();

            //Check if termniate the game
            if (game.win())
            {
                game.endGame(300);
            }
        }

        public void setNormalAppearance()
        {
            //Set normal appearance
            this.Text = "";
            this.BackColor = game.themeSetting.getMineNormalColor();
        }

        private void setMarkAppearance()
        {
            //Set marked appearance
            this.BackColor = game.themeSetting.getMineMarkColor();
            this.Text = "M";
        }
        

        public void dig()
        {
            this.tileStatus = TileStatus.Discovered;
            
            //remove handler
            this.MouseClick -= this.Tile_Click;

            // ask game to search potential expansion
            game.dig(this);

            //Change appearance
            switch (value)
            {
                case 0:
                    this.BackColor = game.themeSetting.getTileDugColor();
                    break;
                case 9:
                    this.Text = "★";
                    this.BackColor = game.themeSetting.getMineDugColor();
                    break;
                default:
                    this.BackColor = game.themeSetting.getTileDugColor();
                    this.Text = value.ToString();
                    break;
            }
            this.FlatAppearance.MouseOverBackColor = this.BackColor;
        }

        public void updateThemeSettings()
        {
            //Change appearance if the player clicks changes theme
            this.ForeColor = game.themeSetting.getFontColor();
            this.FlatAppearance.BorderColor = game.themeSetting.getFontColor();
            switch (this.tileStatus)
            {
                case TileStatus.Normal:
                    this.BackColor = game.themeSetting.getMineNormalColor();
                    
                    break;
                case TileStatus.Marked:
                    this.BackColor = game.themeSetting.getMineMarkColor();

                    break;
                default:
                    if (value != 9)
                        this.BackColor = game.themeSetting.getTileDugColor();
                    else
                    {
                        this.BackColor = game.themeSetting.getMineDugColor();
                    }
                    this.FlatAppearance.MouseOverBackColor = this.BackColor;
                    break;
            }
        }
        
        public void setValue(int value)
        {
            this.value = value;
        }

        //if this is a mine tile
        public bool isMine()
        {
            return this.value == 9;
        }

        public void endGameShow()
        {
            //reveal undug tiles that has no mines
            switch (value)
            {
                case 9:
                    this.BackColor = game.themeSetting.getMineMarkColor();
                    this.Text = "★";
                    break;
                default:
                    this.BackColor = game.themeSetting.getTileDugColor();
                    this.Text = (value == 0) ? "" : value.ToString();
                    break;
            }
            this.FlatAppearance.MouseOverBackColor = this.BackColor;
        }

    }



    public class ThemeSetting
    {
        //Theme colorsets
        private Color[] fontColor = new Color[] {Color.Black,Color.White,Color.Black};
        private Color[] mineNormalColor = new Color[] { Color.White, Color.Black,Color.Lavender};
        private Color[] mineDugColor = new Color[] {Color.Red,Color.Red,Color.Brown};
        private Color[] tileDugColor = new Color[] { Color.LightGray,Color.Green,Color.LightGreen};
        private Color[] mineMarkColor = new Color[] {Color.Cyan,Color.Purple,Color.DarkSalmon};

        //index to switch themes
        private int index = 0;

        //Text and Border color
        public Color getFontColor()
        {
            return this.fontColor[index];
        }

        //Undug Tile Color
        public Color getMineNormalColor()
        {
            return this.mineNormalColor[index];
        }

        //Marked Tile Color
        public Color getMineMarkColor()
        {
            return this.mineMarkColor[index];
        }

        //Mine Tile Color
        public Color getMineDugColor()
        {
            return this.mineDugColor[index];
        }

        //Dug tile color
        public Color getTileDugColor()
        {
            return this.tileDugColor[index];
        }

        public void changeColor()
        {
            //if index exceeds boundary
            index = (index + 1) % this.mineNormalColor.Length;
        }
    }

   
}
