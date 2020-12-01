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
    public partial class tov : Form
    {
        public tov()
        {
            InitializeComponent();
            ShowTov();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tovaroved tov = new tovaroved();
            tov.zak = textBox1.Text;
            tov.ost = textBox2.Text;
            tov.otst = textBox3.Text;
            Program.kafe.tovaroved.Add(tov);
            Program.kafe.SaveChanges();
            ShowTov();
        }
        void ShowTov()
        {
            listView1.Items.Clear();
            foreach (tovaroved tov in Program.kafe.tovaroved)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    tov.zak, tov.ost.ToString(), tov.otst
                });
                item.Tag = tov;
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.SelectedItems.Count == 1)
                {
                    tovaroved tov = listView1.SelectedItems[0].Tag as tovaroved;
                    Program.kafe.tovaroved.Remove(tov);
                    Program.kafe.SaveChanges();
                    ShowTov();
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
            catch
            {
                MessageBox.Show("Невозможно удалить эту запись!", "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

