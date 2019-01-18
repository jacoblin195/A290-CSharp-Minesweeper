//Final Project
//A290
//Minesweeper
//Author Jacob Lin
//Created on 12/2/2017
//last edit on 12/8/2017
//Continue popup
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
    public partial class Continue : Form
    {
        Form1 game;
        public Continue(Form1 game,bool wingame)
        {
            InitializeComponent();
            //Start position
            StartPosition = FormStartPosition.CenterScreen;

            //remove maximize minimize boxes
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.game = game;

            //check if game is lost or won
            game.Enabled = false;
            if (!wingame)
            {
                label_Message.Text = "You Lost!\n" + label_Message.Text;
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Close();
            //unfreeze game window and restart
            game.Enabled = true;
            game.setup();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            //unfreeze the game window
            game.Enabled = true;
            Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            //unfreeze the game window
            base.OnClosed(e);
            game.Enabled = true;
        }
    }
}
