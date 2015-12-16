using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointerSurvival
{
    public partial class Interface : Form
    {
        public Interface()
        {
            InitializeComponent();
        }

        private void startBox_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form PointerSurvival = new PointerSurvivalView();
            PointerSurvival.Show();
        }

        private void Interface_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Hide();
                Form PointerSurvival = new PointerSurvivalView();
                PointerSurvival.Show();
            }
        }
    }
}
