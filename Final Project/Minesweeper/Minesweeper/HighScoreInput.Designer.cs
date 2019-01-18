namespace Minesweeper
{
    partial class HighScoreInput
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
            this.label_Message = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Message.Location = new System.Drawing.Point(43, 28);
            this.label_Message.MaximumSize = new System.Drawing.Size(480, 0);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(64, 25);
            this.label_Message.TabIndex = 0;
            this.label_Message.Text = "label1";
            this.label_Message.Click += new System.EventHandler(this.label_Message_Click);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(106, 294);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(93, 37);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(298, 294);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(93, 37);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // textBox_Input
            // 
            this.textBox_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Input.Location = new System.Drawing.Point(48, 250);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(408, 30);
            this.textBox_Input.TabIndex = 3;
            // 
            // HighScoreInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 361);
            this.Controls.Add(this.textBox_Input);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.label_Message);
            this.Name = "HighScoreInput";
            this.Text = "HighScoreInput";
            this.Load += new System.EventHandler(this.HighScoreInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Message;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_Input;
    }
}