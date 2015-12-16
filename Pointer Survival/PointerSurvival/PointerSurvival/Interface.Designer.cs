namespace PointerSurvival
{
    partial class Interface
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
            this.startPicture = new System.Windows.Forms.PictureBox();
            this.startBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.startPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startPicture
            // 
            this.startPicture.BackColor = System.Drawing.Color.Transparent;
            this.startPicture.Image = global::PointerSurvival.Properties.Resources.game;
            this.startPicture.Location = new System.Drawing.Point(351, 117);
            this.startPicture.Name = "startPicture";
            this.startPicture.Size = new System.Drawing.Size(531, 320);
            this.startPicture.TabIndex = 0;
            this.startPicture.TabStop = false;
            // 
            // startBox
            // 
            this.startBox.BackColor = System.Drawing.Color.Transparent;
            this.startBox.BackgroundImage = global::PointerSurvival.Properties.Resources.start;
            this.startBox.Image = global::PointerSurvival.Properties.Resources.start;
            this.startBox.Location = new System.Drawing.Point(313, 443);
            this.startBox.Name = "startBox";
            this.startBox.Size = new System.Drawing.Size(569, 118);
            this.startBox.TabIndex = 1;
            this.startBox.TabStop = false;
            this.startBox.Click += new System.EventHandler(this.startBox_Click);
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PointerSurvival.Properties.Resources._1200;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.startBox);
            this.Controls.Add(this.startPicture);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Interface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Interface_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.startPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox startPicture;
        private System.Windows.Forms.PictureBox startBox;
    }
}