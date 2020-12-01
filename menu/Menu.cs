using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menu
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mark = new mark();
            mark.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form tov = new tov();
            tov.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form zak = new zak();
            zak.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}
