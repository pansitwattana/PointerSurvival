using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;


namespace PointerSurvival
{
    public partial class PointerSurvivalView : Form, View
    {
        Model model;
        Controller controller;
        public static PictureBox pointerBox;

        private bool m_right = false;
        private bool m_left = false;


        public PointerSurvivalView()
        {
            InitializeComponent();

            model = new PointerSurvivalModel();
            model.AttachObserver(this);
            controller = new PointerSurvivalController();
            controller.AddModel(model);
            PointerBox.Location = Player.PositionStart;
            //Cursor.Hide();
            pointerBox = PointerBox;

            obstacleTimer.Interval = PointerSurvivalController.TimeToCreateAsteroid * 1000;
            obstacleTimer.Enabled = true;

            timer1.Interval = 10;
            timer1.Enabled= true;
        }

        public void Notify(Model m)
        {
            UpdatePointerX(((PointerSurvivalModel)m).GetDistanceX());
            UpdatePointerY(((PointerSurvivalModel)m).GetDistanceY());
            UpdateAsteroids(((PointerSurvivalModel)m).GetAsteroids());
            UpdateBullets(((PointerSurvivalModel)m).GetBullets(), ((PointerSurvivalModel)m).GetAsteroids(), (PointerSurvivalModel)m);
            //UpdateScore(((PointerSurvivalModel)m).GetScore());
        }

        public void NotifyAsteroid(Model m)
        {
            UpdateNewAsteroid(((PointerSurvivalModel)m).GetLastAsteroids());
        }

        public void NotifyBullet(Model m)
        {
            UpdateBullet(((PointerSurvivalModel)m).GetBullet());
        }

        private void UpdateBullet(Weapon bullet)
        {
            this.Controls.Add(bullet.obj);
        }

        private void UpdateNewAsteroid(Obstacle p)
        {
            this.Controls.Add(p.obj);
        }

        private void UpdateScore(object p)
        {
            throw new NotImplementedException();
        }

        private void UpdatePointerX(int distanceX)
        {
            PointerBox.Left = distanceX;
            //PointerBox.Left += distanceX - PointerBox.Location.X;
        }

        private void UpdatePointerY(int distanceY)
        {
            PointerBox.Top = distanceY;
            //PointerBox.Top += distanceY - PointerBox.Location.Y;
        }

        private void UpdateAsteroids(List<Obstacle> obstacles)
        {
            if (obstacles.Count > 0)
                foreach (Obstacle o in obstacles)
                {
                    if (o.Update())
                    {
                        o.Destroy();
                        this.Controls.Remove(o.obj);
                        PointerBox.Hide();
                        Close();
                    }
                    //if (!this.ClientRectangle.IntersectsWith(o.obj.Bounds))
                    //{
                    //    if ( == -1)
                    //        o.obj.Left = this.ClientRectangle.Width;
                    //    else
                    //        o.obj.Left = -o.obj.Width;
                    //}

                    //foreach (Obstacle o2 in obstacles)
                    //{
                    //    if (o2 != o)
                    //    {
                    //        if (o.isHit(o2))
                    //        {
                    //            o.Bounce(o2);
                    //        }
                    //    }
                    //}
                }
        }
        private void UpdateBullets(List<Weapon> bullets,List<Obstacle> obstacles, PointerSurvivalModel m)
        {
            if (bullets.Count > 0)
            {
                bool isHit = false;
                foreach (Weapon bullet in bullets)
                {
                    bullet.BulletMove();

                    foreach (Obstacle o in obstacles)
                    {
                        if (o.isHit(bullet))
                        {
                            m.cal.storevalue(o.Number);

                            if (m.cal.checkans(int.Parse(answerlbl.Text)))
                            {
                                answerlbl.Text = "" + Obstacle.random.Next(1,20);
                            }

                            num1lbl.Text = "" + m.cal.getNum1;
                            num2lbl.Text = "" + m.cal.getNum2;
                            operationlbl.Text = m.cal.getSymbol;
                            scorelbl.Text = "" + m.cal.getScore;

                            o.obj.Dispose();
                            bullet.obj.Dispose();

                            this.Controls.Remove(o.obj);
                            this.Controls.Remove(bullet.obj);

                            m.Remove(o);
                            m.Remove(bullet);
                            isHit = true;
                            break;
                        }

                    }
                    if(isHit)
                        break;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                controller.ActionPerformed(PointerSurvivalController.Fire);
            }

            if (e.KeyCode == Keys.W && e.Modifiers == Keys.D)
            {
                Console.WriteLine("W D pressed");
                controller.ActionPerformed(PointerSurvivalController.UpRight);
            }
            else if (e.KeyCode == Keys.W && e.Modifiers == Keys.A)
            {
                Console.WriteLine("W A pressed");
                controller.ActionPerformed(PointerSurvivalController.UpLeft);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.D)
            {
                controller.ActionPerformed(PointerSurvivalController.DownRight);
            }
            else if (e.KeyCode == Keys.S && e.Modifiers == Keys.A)
            {
                controller.ActionPerformed(PointerSurvivalController.DownLeft);
            }
            else if (e.KeyCode == Keys.W)
            {
                controller.ActionPerformed(PointerSurvivalController.Up);
            }
            else if (e.KeyCode == Keys.S)
            {
                controller.ActionPerformed(PointerSurvivalController.Down);
            }
            else if (e.KeyCode == Keys.A)
            {
                controller.ActionPerformed(PointerSurvivalController.Left);
            }
            else if (e.KeyCode == Keys.D)
            {
                controller.ActionPerformed(PointerSurvivalController.Right);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            controller.ActionPerformed(PointerSurvivalController.TimeTick);


            //player.Accelerate(MousePosition.X, MousePosition.Y);
            //foreach (Obstacle obstacle in obstacles)
            //{
            //    obstacle.Move();
            //}
            //Bitmap resultPicture = MoveImageByDesiredAngle(playerPicture.Image.Width, playerPicture.Image.Height, 30);
            //playerPicture.Image = resultPicture;
        }

        private void obstacleTimer_Tick(object sender, EventArgs e)
        {
            controller.ActionPerformed(PointerSurvivalController.CreateAsteroid);
            //Obstacle obstacle = new Obstacle();
            //obstacles.Add(obstacle);
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            controller.ActionPerformed(PointerSurvivalController.Fire);
        }

        private void PointerSurvivalView_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBox.Show("Game Over", "You died");
            System.Threading.Thread.Sleep(1000);
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void PointerSurvivalView_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PointerSurvivalView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_left = true;
                Console.WriteLine("Test Mouse Left Clicked");
            }
            if (e.Button == MouseButtons.Right)
            {
                m_right = true;
                Console.WriteLine("Mouse Right Clicked");
            }

            if (m_left == false || m_right == false) return;

           

        }

        private void PointerSurvivalView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                m_left = false;
            if (e.Button == MouseButtons.Right)
                m_right = false;
        }
    }
}
