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
            ((System.ComponentModel.ISupportInitialize)(this.PointerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PointerBox
            // 
            this.PointerBox.BackColor = System.Drawing.Color.Transparent;
            this.PointerBox.BackgroundImage = global::PointerSurvival.Properties.Resources.pointer;
            this.PointerBox.Image = global::PointerSurvival.Properties.Resources.pointer;
            this.PointerBox.Location = new System.Drawing.Point(575, 350);
            this.PointerBox.Name = "PointerBox";
            this.PointerBox.Size = new System.Drawing.Size(38, 46);
            this.PointerBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
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
            this.num1lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.num1lbl.Location = new System.Drawing.Point(524, 597);
            this.num1lbl.Name = "num1lbl";
            this.num1lbl.Size = new System.Drawing.Size(43, 46);
            this.num1lbl.TabIndex = 1;
            this.num1lbl.Text = "0";
            // 
            // operationlbl
            // 
            this.operationlbl.AutoSize = true;
            this.operationlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.operationlbl.Location = new System.Drawing.Point(573, 597);
            this.operationlbl.Name = "operationlbl";
            this.operationlbl.Size = new System.Drawing.Size(43, 46);
            this.operationlbl.TabIndex = 2;
            this.operationlbl.Text = "?";
            // 
            // num2lbl
            // 
            this.num2lbl.AutoSize = true;
            this.num2lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.num2lbl.Location = new System.Drawing.Point(622, 597);
            this.num2lbl.Name = "num2lbl";
            this.num2lbl.Size = new System.Drawing.Size(43, 46);
            this.num2lbl.TabIndex = 3;
            this.num2lbl.Text = "0";
            // 
            // answerlbl
            // 
            this.answerlbl.AllowDrop = true;
            this.answerlbl.AutoSize = true;
            this.answerlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.answerlbl.Location = new System.Drawing.Point(564, 9);
            this.answerlbl.Name = "answerlbl";
            this.answerlbl.Size = new System.Drawing.Size(89, 63);
            this.answerlbl.TabIndex = 6;
            this.answerlbl.Text = "10";
            this.answerlbl.Click += new System.EventHandler(this.label5_Click);
            // 
            // scorelbl
            // 
            this.scorelbl.AutoSize = true;
            this.scorelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.scorelbl.Location = new System.Drawing.Point(1129, 9);
            this.scorelbl.Name = "scorelbl";
            this.scorelbl.Size = new System.Drawing.Size(43, 46);
            this.scorelbl.TabIndex = 7;
            this.scorelbl.Text = "0";
            // 
            // itemTimer
            // 
            this.itemTimer.Enabled = true;
            this.itemTimer.Interval = 10000;
            this.itemTimer.Tick += new System.EventHandler(this.itemTimer_Tick);
            // 
            // PointerSurvivalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1184, 661);
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
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PointerSurvivalView_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PointerSurvivalView_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.PointerBox)).EndInit();
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
    }
}

