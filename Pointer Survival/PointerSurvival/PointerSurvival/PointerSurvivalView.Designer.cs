namespace PointerSurvival
{
    partial class PointerSurvivalView
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
            this.PointerBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.obstacleTimer = new System.Windows.Forms.Timer(this.components);
            this.num1lbl = new System.Windows.Forms.Label();
            this.operationlbl = new System.Windows.Forms.Label();
            this.num2lbl = new System.Windows.Forms.Label();
            this.answerlbl = new System.Windows.Forms.Label();
            this.scorelbl = new System.Windows.Forms.Label();
            this.itemTimer = new System.Windows.Forms.Timer(this.components);
            this.timer_toast = new System.Windows.Forms.Timer(this.components);
            this.toastLabel = new System.Windows.Forms.Label();
            this.threesecondTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LevelTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fireTimer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.clearItemTimer = new System.Windows.Forms.Timer(this.components);
            this.lifePicture1 = new System.Windows.Forms.PictureBox();
            this.lifePicture2 = new System.Windows.Forms.PictureBox();
            this.lifePicture3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PointerBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePicture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePicture3)).BeginInit();
            this.SuspendLayout();
            // 
            // PointerBox
            // 
            this.PointerBox.BackColor = System.Drawing.Color.Transparent;
            this.PointerBox.Image = global::PointerSurvival.Properties.Resources.spaceup;
            this.PointerBox.Location = new System.Drawing.Point(600, 350);
            this.PointerBox.Name = "PointerBox";
            this.PointerBox.Size = new System.Drawing.Size(34, 36);
            this.PointerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PointerBox.TabIndex = 0;
            this.PointerBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // obstacleTimer
            // 
            this.obstacleTimer.Enabled = true;
            this.obstacleTimer.Interval = 1000;
            this.obstacleTimer.Tick += new System.EventHandler(this.obstacleTimer_Tick);
            // 
            // num1lbl
            // 
            this.num1lbl.AutoSize = true;
            this.num1lbl.BackColor = System.Drawing.Color.Transparent;
            this.num1lbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 40F);
            this.num1lbl.ForeColor = System.Drawing.Color.White;
            this.num1lbl.Location = new System.Drawing.Point(496, 580);
            this.num1lbl.Name = "num1lbl";
            this.num1lbl.Size = new System.Drawing.Size(59, 62);
            this.num1lbl.TabIndex = 1;
            this.num1lbl.Text = "0";
            // 
            // operationlbl
            // 
            this.operationlbl.AutoSize = true;
            this.operationlbl.BackColor = System.Drawing.Color.Transparent;
            this.operationlbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationlbl.ForeColor = System.Drawing.Color.White;
            this.operationlbl.Location = new System.Drawing.Point(589, 581);
            this.operationlbl.Name = "operationlbl";
            this.operationlbl.Size = new System.Drawing.Size(57, 61);
            this.operationlbl.TabIndex = 2;
            this.operationlbl.Text = "?";
            // 
            // num2lbl
            // 
            this.num2lbl.AutoSize = true;
            this.num2lbl.BackColor = System.Drawing.Color.Transparent;
            this.num2lbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num2lbl.ForeColor = System.Drawing.Color.White;
            this.num2lbl.Location = new System.Drawing.Point(679, 580);
            this.num2lbl.Name = "num2lbl";
            this.num2lbl.Size = new System.Drawing.Size(59, 62);
            this.num2lbl.TabIndex = 3;
            this.num2lbl.Text = "0";
            this.num2lbl.Click += new System.EventHandler(this.num2lbl_Click);
            // 
            // answerlbl
            // 
            this.answerlbl.AllowDrop = true;
            this.answerlbl.AutoSize = true;
            this.answerlbl.BackColor = System.Drawing.Color.Transparent;
            this.answerlbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerlbl.ForeColor = System.Drawing.Color.White;
            this.answerlbl.Location = new System.Drawing.Point(564, 9);
            this.answerlbl.Name = "answerlbl";
            this.answerlbl.Size = new System.Drawing.Size(89, 61);
            this.answerlbl.TabIndex = 6;
            this.answerlbl.Text = "10";
            this.answerlbl.Click += new System.EventHandler(this.label5_Click);
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.BackColor = System.Drawing.Color.Transparent;
            this.scorelbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelbl.ForeColor = System.Drawing.Color.White;
            this.scorelbl.Location = new System.Drawing.Point(1128, 9);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(44, 46);
            this.scorelbl.TabIndex = 7;
            this.scorelbl.Text = "0";
            // 
            // itemTimer
            // 
            this.itemTimer.Enabled = true;
            this.itemTimer.Interval = 10000;
            this.itemTimer.Tick += new System.EventHandler(this.itemTimer_Tick);
            // 
            // timer_toast
            // 
            this.timer_toast.Interval = 1;
            this.timer_toast.Tick += new System.EventHandler(this.timer_toast_Tick);
            // 
            // toastLabel
            // 
            this.toastLabel.AutoSize = true;
            this.toastLabel.BackColor = System.Drawing.Color.Transparent;
            this.toastLabel.Font = new System.Drawing.Font("Monotype Corsiva", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toastLabel.ForeColor = System.Drawing.Color.White;
            this.toastLabel.Location = new System.Drawing.Point(509, 123);
            this.toastLabel.Name = "toastLabel";
            this.toastLabel.Size = new System.Drawing.Size(144, 24);
            this.toastLabel.TabIndex = 8;
            this.toastLabel.Text = "I\'m fading out now";
            this.toastLabel.Visible = false;
            // 
            // threesecondTimer
            // 
            this.threesecondTimer.Interval = 3000;
            this.threesecondTimer.Tick += new System.EventHandler(this.threesecondTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1079, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Score : ";
            // 
            // LevelTxt
            // 
            this.LevelTxt.AutoSize = true;
            this.LevelTxt.BackColor = System.Drawing.Color.Transparent;
            this.LevelTxt.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelTxt.ForeColor = System.Drawing.Color.White;
            this.LevelTxt.Location = new System.Drawing.Point(53, 3);
            this.LevelTxt.Name = "LevelTxt";
            this.LevelTxt.Size = new System.Drawing.Size(20, 24);
            this.LevelTxt.TabIndex = 14;
            this.LevelTxt.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Level";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // fireTimer
            // 
            this.fireTimer.Enabled = true;
            this.fireTimer.Interval = 10;
            this.fireTimer.Tick += new System.EventHandler(this.fireTimer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(499, 638);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 16;
            this.label4.Text = "Left Arrow";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(674, 638);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "Right Arrow";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Modern No. 20", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Location = new System.Drawing.Point(587, 638);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 18;
            this.label7.Text = "Left / Right";
            // 
            // clearItemTimer
            // 
            this.clearItemTimer.Interval = 60000;
            this.clearItemTimer.Tick += new System.EventHandler(this.clearItemTimer_Tick);
            // 
            // lifePicture1
            // 
            this.lifePicture1.Image = global::PointerSurvival.Properties.Resources.spaceup;
            this.lifePicture1.Location = new System.Drawing.Point(95, 9);
            this.lifePicture1.Name = "lifePicture1";
            this.lifePicture1.Size = new System.Drawing.Size(30, 31);
            this.lifePicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lifePicture1.TabIndex = 19;
            this.lifePicture1.TabStop = false;
            // 
            // lifePicture2
            // 
            this.lifePicture2.Image = global::PointerSurvival.Properties.Resources.spaceup;
            this.lifePicture2.Location = new System.Drawing.Point(130, 9);
            this.lifePicture2.Name = "lifePicture2";
            this.lifePicture2.Size = new System.Drawing.Size(30, 31);
            this.lifePicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lifePicture2.TabIndex = 20;
            this.lifePicture2.TabStop = false;
            // 
            // lifePicture3
            // 
            this.lifePicture3.Image = global::PointerSurvival.Properties.Resources.spaceup;
            this.lifePicture3.Location = new System.Drawing.Point(166, 9);
            this.lifePicture3.Name = "lifePicture3";
            this.lifePicture3.Size = new System.Drawing.Size(30, 31);
            this.lifePicture3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lifePicture3.TabIndex = 21;
            this.lifePicture3.TabStop = false;
            this.lifePicture3.Visible = false;
            // 
            // PointerSurvivalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuText;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.lifePicture3);
            this.Controls.Add(this.lifePicture2);
            this.Controls.Add(this.lifePicture1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LevelTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toastLabel);
            this.Controls.Add(this.scorelbl);
            this.Controls.Add(this.answerlbl);
            this.Controls.Add(this.num2lbl);
            this.Controls.Add(this.operationlbl);
            this.Controls.Add(this.num1lbl);
            this.Controls.Add(this.PointerBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointerSurvivalView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PointerSurvival";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PointerSurvivalView_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PointerSurvivalView_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PointerSurvivalView_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PointerSurvivalView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PointerSurvivalView_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.PointerBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePicture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifePicture3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PointerBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer obstacleTimer;
        private System.Windows.Forms.Label num1lbl;
        private System.Windows.Forms.Label operationlbl;
        private System.Windows.Forms.Label num2lbl;
        private System.Windows.Forms.Label answerlbl;
        private System.Windows.Forms.Label scorelbl;
        private System.Windows.Forms.Timer itemTimer;
        private System.Windows.Forms.Timer timer_toast;
        private System.Windows.Forms.Label toastLabel;
        private System.Windows.Forms.Timer threesecondTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LevelTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer fireTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer clearItemTimer;
        private System.Windows.Forms.PictureBox lifePicture1;
        private System.Windows.Forms.PictureBox lifePicture2;
        private System.Windows.Forms.PictureBox lifePicture3;
    }
}

