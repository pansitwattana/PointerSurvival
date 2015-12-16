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

            LevelTxt.Text = "1";
            asteroidSpawnTimeTxt.Text = "" + PointerSurvivalController.TimeToCreateAsteroid/1000;
            speedTxt.Text = "" + PointerSurvivalController.Speed;

            obstacleTimer.Interval = PointerSurvivalController.TimeToCreateAsteroid;
            obstacleTimer.Enabled = true;

            timer1.Interval = 30;
            timer1.Enabled = true;

            itemTimer.Interval = 10000;
            itemTimer.Enabled = true;

        }

        public void Notify(Model m)
        {
            UpdatePointerX(((PointerSurvivalModel)m).GetDistanceX());
            UpdatePointerY(((PointerSurvivalModel)m).GetDistanceY());
            UpdateAsteroids(((PointerSurvivalModel)m).GetAsteroids());
            UpdateBullets(((PointerSurvivalModel)m).GetBullets(), ((PointerSurvivalModel)m).GetAsteroids(), (PointerSurvivalModel)m);
            UpdateItems(((PointerSurvivalModel)m).GetItems(), ((PointerSurvivalModel)m).GetAsteroids());

        }

        

        public void NotifyAsteroid(Model m)
        {
            UpdateNewAsteroid(((PointerSurvivalModel)m).GetLastAsteroids());
        }

        public void NotifyBullet(Model m)
        {
            UpdateBullet(((PointerSurvivalModel)m).GetBullet());
        }

        public void NotifyItem(Model m)
        {
            UpdateItem(((PointerSurvivalModel)m).GetItem());
        }

        private void UpdateItem(Item item)
        {
            this.Controls.Add(item.obj);
        }

        private void UpdateBullet(Weapon bullet)
        {
            this.Controls.Add(bullet.obj);
        }

        private void UpdateNewAsteroid(Obstacle p)
        {
            this.Controls.Add(p.obj);
        }

        private void UpdatePointerX(int distanceX)
        {

            PointerBox.Left = distanceX;
        }

        private void UpdatePointerY(int distanceY)
        {
            PointerBox.Top = distanceY;
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
                    if (o.isOutOfBoundary())
                    {
                        o.Destroy();
                        this.Controls.Remove(o.obj);
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

        private void UpdateItems(List<Item> items, List<Obstacle> obstacles)
        {
            if (items.Count > 0)
                foreach (Item item in items)
                {
                    if (item.Update(pointerBox))
                    {   
                        item.RunAbility(obstacles);
                        speedTxt.Text = "" + PointerSurvivalController.Speed;
                        ToastShow(item.Text);
                        item.obj.Dispose();
                        this.Controls.Remove(item.obj);
                        items.Remove(item);
                        break;
                    }
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

                    if (bullet.isOutOfBoundary())
                    {
                        bullet.obj.Dispose();
                        m.Remove(bullet);
                        this.Controls.Remove(bullet.obj);
                        isHit = true;
                        break;
                    }

                    foreach (Obstacle o in obstacles)
                    {
                        if (o.isHit(bullet))
                        {
                            m.cal.storevalue(o.Number,bullet.isRight);

                            if (m.cal.checkans(int.Parse(answerlbl.Text)))
                            {
                                answerlbl.Text = "" + Calculation.random.Next(1,20);
                                if (m.cal.isBossClear)
                                {
                                    ToastShow("Boss Level " + m.cal.Level + " Clear !");
                                    if(obstacleTimer.Interval > 100)
                                    {
                                        obstacleTimer.Interval -= 100;
                                        PointerSurvivalController.TimeToCreateAsteroid = obstacleTimer.Interval;
                                        LevelTxt.Text = "" + (m.cal.Level + 1);
                                        asteroidSpawnTimeTxt.Text = "" + (PointerSurvivalController.TimeToCreateAsteroid/1000.00);
                                    }
                                        
                                }
                                if (m.cal.isBoss)
                                {
                                    ToastShow("Boss Stage " + m.cal.Level + " !");
                                    m.cal.isBoss = true; 
                                }
                            }

                            num1lbl.Text = "" + m.cal.getNum1;
                            num2lbl.Text = "" + m.cal.getNum2;
                            operationlbl.Text = m.cal.getSymbol;
                            scorelbl.Text = "" + m.cal.getScore;

                            o.Destroy();
                            bullet.obj.Dispose();

                            if (!o.isActive)
                            {
                                this.Controls.Remove(o.obj);
                                m.Remove(o);
                            }
                                
                            this.Controls.Remove(bullet.obj);

                            
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
                controller.ActionPerformed(PointerSurvivalController.Fire1);
            }

          
            if (e.KeyCode == Keys.W)
            {
                pointerBox.Image = PointerSurvival.Properties.Resources.pointer;
                controller.ActionPerformed(PointerSurvivalController.Up);
            }
            else if (e.KeyCode == Keys.S)
            {
                pointerBox.Image = PointerSurvival.Properties.Resources.pointerD;
                controller.ActionPerformed(PointerSurvivalController.Down);
            }
            else if (e.KeyCode == Keys.A)
            {
                pointerBox.Image = PointerSurvival.Properties.Resources.pointerL;
                controller.ActionPerformed(PointerSurvivalController.Left);
            }
            else if (e.KeyCode == Keys.D)
            {
                pointerBox.Image = PointerSurvival.Properties.Resources.pointerR;
                controller.ActionPerformed(PointerSurvivalController.Right);
            }

            if (e.KeyCode == Keys.Left)
            {
                m_left = true;
                controller.ActionPerformed(PointerSurvivalController.Fire1);
            }
            if (e.KeyCode == Keys.Right)
            {
                m_right = true;
                controller.ActionPerformed(PointerSurvivalController.Fire2);
            }

            if (m_left == false || m_right == false) return;
        }


        private void PointerSurvivalView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                m_left = false;
            if (e.KeyCode == Keys.Right)
                m_right = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            controller.ActionPerformed(PointerSurvivalController.TimeTick);
        }

        private void obstacleTimer_Tick(object sender, EventArgs e)
        {
            controller.ActionPerformed(PointerSurvivalController.CreateAsteroid);
        }

        

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

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
                controller.ActionPerformed(PointerSurvivalController.Fire1);
                Console.WriteLine("Left Clicked");
            }
            if (e.Button == MouseButtons.Right)
            {
                m_right = true;
                controller.ActionPerformed(PointerSurvivalController.Fire2);
                Console.WriteLine("Right Clicked");
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

        private void itemTimer_Tick(object sender, EventArgs e)
        {
            controller.ActionPerformed(PointerSurvivalController.ItemSpawn);
        }

        private void timer_toast_Tick(object sender, EventArgs e)
        {
            int fadingSpeed = 5;
            if(toastLabel.ForeColor.R < 251)
                toastLabel.ForeColor = Color.FromArgb(toastLabel.ForeColor.R + fadingSpeed, toastLabel.ForeColor.G + fadingSpeed, toastLabel.ForeColor.B + fadingSpeed);

            if (toastLabel.ForeColor.R >= 250)
            {
                timer_toast.Stop();
                toastLabel.ForeColor = Color.FromArgb(0,0,0);
                toastLabel.Hide();
                toastLabel.ForeColor = this.BackColor;
            }

        }

        private void threesecondTimer_Tick(object sender, EventArgs e)
        {
            timer_toast.Start();
            threesecondTimer.Stop();
        }

        private void ToastShow(string Text)
        {
            toastLabel.ForeColor = Color.FromArgb(0, 0, 0);
            toastLabel.Show();
            toastLabel.Text = Text;
            threesecondTimer.Start();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
