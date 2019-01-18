//Final Project
//A290
//Minesweeper
//Author Jacob Lin
//Created on 12/2/2017
//last edit on 12/8/2017
//Highscore Input (Non-blocking

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class HighScoreInput : Form
    {
        //game reference
        Form1 game;
        public HighScoreInput(Form1 game)
        {
            InitializeComponent();

            //message
            String message = "Congratualtion! You beat one of the following High Schores:";

            this.game = game;

            //pop up at the center of the screen
            StartPosition = FormStartPosition.CenterScreen;

            //remove maximize minimize buttons
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            //show high schores
            foreach ((String,int) highscore in game.highscores)
            {
                message += "\n" + highscore.Item1 + "  " + highscore.Item2.ToString();
            }
            message += "\nPleaase put your name here!";
            label_Message.Text = message;

            //freeze game window
            game.Enabled = false;
        }

        private void HighScoreInput_Load(object sender, EventArgs e)
        {

        }
        

        private void label_Message_Click(object sender, EventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            String newname = textBox_Input.Text != "" ? textBox_Input.Text : "Anonymous";
            //game window save new high score
            this.game.saveNewHighScore(newname);
            //unfreeze game window
            this.game.Enabled = true;
            this.Close();
            //ask if a new game is desired
            Continue continueWindow = new Continue(game, true);
            continueWindow.Show();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //unfreeze game window
            this.game.Enabled = true;
            this.Close();
            //ask if continue playing
            Continue continueWindow = new Continue(game, true);
            continueWindow.Show();
        }
    }
}
