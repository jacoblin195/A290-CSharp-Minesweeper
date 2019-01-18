namespace Minesweeper
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
            this.button_ChangeTheme = new System.Windows.Forms.Button();
            this.pictureBox_Timer1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Timer2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Timer3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_MineLeft3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_MineLeft2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_MineLeft1 = new System.Windows.Forms.PictureBox();
            this.button_StartOver = new System.Windows.Forms.Button();
            this.comboBox_DifficultySelector = new System.Windows.Forms.ComboBox();
            this.label_Difficulty = new System.Windows.Forms.Label();
            this.button_Quit = new System.Windows.Forms.Button();
            this.label_Timer = new System.Windows.Forms.Label();
            this.label_MinesRemaining = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Timer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Timer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Timer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MineLeft3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MineLeft2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MineLeft1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ChangeTheme
            // 
            this.button_ChangeTheme.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_ChangeTheme.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ChangeTheme.Location = new System.Drawing.Point(122, 361);
            this.button_ChangeTheme.Margin = new System.Windows.Forms.Padding(2);
            this.button_ChangeTheme.Name = "button_ChangeTheme";
            this.button_ChangeTheme.Size = new System.Drawing.Size(192, 32);
            this.button_ChangeTheme.TabIndex = 1;
            this.button_ChangeTheme.Text = "Change Theme";
            this.button_ChangeTheme.UseVisualStyleBackColor = true;
            this.button_ChangeTheme.Click += new System.EventHandler(this.button_changeTheme_Click);
            // 
            // pictureBox_Timer1
            // 
            this.pictureBox_Timer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Timer1.Location = new System.Drawing.Point(22, 24);
            this.pictureBox_Timer1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Timer1.Name = "pictureBox_Timer1";
            this.pictureBox_Timer1.Size = new System.Drawing.Size(34, 57);
            this.pictureBox_Timer1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Timer1.TabIndex = 2;
            this.pictureBox_Timer1.TabStop = false;
            // 
            // pictureBox_Timer2
            // 
            this.pictureBox_Timer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Timer2.Location = new System.Drawing.Point(54, 24);
            this.pictureBox_Timer2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Timer2.Name = "pictureBox_Timer2";
            this.pictureBox_Timer2.Size = new System.Drawing.Size(34, 57);
            this.pictureBox_Timer2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Timer2.TabIndex = 3;
            this.pictureBox_Timer2.TabStop = false;
            // 
            // pictureBox_Timer3
            // 
            this.pictureBox_Timer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Timer3.Location = new System.Drawing.Point(86, 24);
            this.pictureBox_Timer3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_Timer3.Name = "pictureBox_Timer3";
            this.pictureBox_Timer3.Size = new System.Drawing.Size(34, 57);
            this.pictureBox_Timer3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Timer3.TabIndex = 4;
            this.pictureBox_Timer3.TabStop = false;
            // 
            // pictureBox_MineLeft3
            // 
            this.pictureBox_MineLeft3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_MineLeft3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_MineLeft3.Location = new System.Drawing.Point(322, 24);
            this.pictureBox_MineLeft3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_MineLeft3.Name = "pictureBox_MineLeft3";
            this.pictureBox_MineLeft3.Size = new System.Drawing.Size(34, 57);
            this.pictureBox_MineLeft3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_MineLeft3.TabIndex = 7;
            this.pictureBox_MineLeft3.TabStop = false;
            // 
            // pictureBox_MineLeft2
            // 
            this.pictureBox_MineLeft2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_MineLeft2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_MineLeft2.Location = new System.Drawing.Point(290, 24);
            this.pictureBox_MineLeft2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_MineLeft2.Name = "pictureBox_MineLeft2";
            this.pictureBox_MineLeft2.Size = new System.Drawing.Size(34, 57);
            this.pictureBox_MineLeft2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_MineLeft2.TabIndex = 6;
            this.pictureBox_MineLeft2.TabStop = false;
            // 
            // pictureBox_MineLeft1
            // 
            this.pictureBox_MineLeft1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_MineLeft1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_MineLeft1.Location = new System.Drawing.Point(259, 24);
            this.pictureBox_MineLeft1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox_MineLeft1.Name = "pictureBox_MineLeft1";
            this.pictureBox_MineLeft1.Size = new System.Drawing.Size(34, 57);
            this.pictureBox_MineLeft1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_MineLeft1.TabIndex = 5;
            this.pictureBox_MineLeft1.TabStop = false;
            // 
            // button_StartOver
            // 
            this.button_StartOver.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_StartOver.Location = new System.Drawing.Point(167, 37);
            this.button_StartOver.Margin = new System.Windows.Forms.Padding(2);
            this.button_StartOver.Name = "button_StartOver";
            this.button_StartOver.Size = new System.Drawing.Size(44, 45);
            this.button_StartOver.TabIndex = 0;
            this.button_StartOver.Text = "Start Over";
            this.button_StartOver.UseVisualStyleBackColor = true;
            this.button_StartOver.Click += new System.EventHandler(this.button_StartOver_Click);
            // 
            // comboBox_DifficultySelector
            // 
            this.comboBox_DifficultySelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_DifficultySelector.FormattingEnabled = true;
            this.comboBox_DifficultySelector.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.comboBox_DifficultySelector.Location = new System.Drawing.Point(130, 444);
            this.comboBox_DifficultySelector.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_DifficultySelector.Name = "comboBox_DifficultySelector";
            this.comboBox_DifficultySelector.Size = new System.Drawing.Size(92, 25);
            this.comboBox_DifficultySelector.TabIndex = 2;
            this.comboBox_DifficultySelector.Text = "Easy";
            this.comboBox_DifficultySelector.SelectedIndexChanged += new System.EventHandler(this.comboBox_DifficultySelector_SelectedIndexChanged);
            // 
            // label_Difficulty
            // 
            this.label_Difficulty.AutoSize = true;
            this.label_Difficulty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Difficulty.Location = new System.Drawing.Point(149, 417);
            this.label_Difficulty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Difficulty.Name = "label_Difficulty";
            this.label_Difficulty.Size = new System.Drawing.Size(110, 20);
            this.label_Difficulty.TabIndex = 10;
            this.label_Difficulty.Text = "Difficulty Level";
            // 
            // button_Quit
            // 
            this.button_Quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Quit.Location = new System.Drawing.Point(153, 481);
            this.button_Quit.Margin = new System.Windows.Forms.Padding(2);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(84, 39);
            this.button_Quit.TabIndex = 3;
            this.button_Quit.Text = "Quit";
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // label_Timer
            // 
            this.label_Timer.AutoSize = true;
            this.label_Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Timer.Location = new System.Drawing.Point(37, 83);
            this.label_Timer.Name = "label_Timer";
            this.label_Timer.Size = new System.Drawing.Size(48, 20);
            this.label_Timer.TabIndex = 11;
            this.label_Timer.Text = "Timer";
            // 
            // label_MinesRemaining
            // 
            this.label_MinesRemaining.AutoSize = true;
            this.label_MinesRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MinesRemaining.Location = new System.Drawing.Point(286, 83);
            this.label_MinesRemaining.Name = "label_MinesRemaining";
            this.label_MinesRemaining.Size = new System.Drawing.Size(131, 20);
            this.label_MinesRemaining.TabIndex = 12;
            this.label_MinesRemaining.Text = "Mines Remaining";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 717);
            this.Controls.Add(this.label_MinesRemaining);
            this.Controls.Add(this.label_Timer);
            this.Controls.Add(this.button_Quit);
            this.Controls.Add(this.label_Difficulty);
            this.Controls.Add(this.comboBox_DifficultySelector);
            this.Controls.Add(this.button_StartOver);
            this.Controls.Add(this.pictureBox_MineLeft3);
            this.Controls.Add(this.pictureBox_MineLeft2);
            this.Controls.Add(this.pictureBox_MineLeft1);
            this.Controls.Add(this.pictureBox_Timer3);
            this.Controls.Add(this.pictureBox_Timer2);
            this.Controls.Add(this.pictureBox_Timer1);
            this.Controls.Add(this.button_ChangeTheme);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "MineSweeper";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Timer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Timer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Timer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MineLeft3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MineLeft2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MineLeft1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_ChangeTheme;
        private System.Windows.Forms.PictureBox pictureBox_Timer1;
        private System.Windows.Forms.PictureBox pictureBox_Timer2;
        private System.Windows.Forms.PictureBox pictureBox_Timer3;
        private System.Windows.Forms.PictureBox pictureBox_MineLeft3;
        private System.Windows.Forms.PictureBox pictureBox_MineLeft2;
        private System.Windows.Forms.PictureBox pictureBox_MineLeft1;
        private System.Windows.Forms.Button button_StartOver;
        private System.Windows.Forms.ComboBox comboBox_DifficultySelector;
        private System.Windows.Forms.Label label_Difficulty;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Label label_Timer;
        private System.Windows.Forms.Label label_MinesRemaining;
    }
}

