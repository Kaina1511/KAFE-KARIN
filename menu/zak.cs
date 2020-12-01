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
    public partial class zak : Form
    {
        public zak()
        {
            InitializeComponent();
            ShowZak();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           zakupchik zak = new zakupchik();
            zak.pok = textBox1.Text;
            zak.kol = Convert.ToInt32(textBox2.Text);
            zak.price = Convert.ToInt32(textBox3.Text);
            Program.kafe.zakupchik.Add(zak);
            Program.kafe.SaveChanges();
            ShowZak();
        }
        void ShowZak()
        {
            listView1.Items.Clear();
            foreach (zakupchik zak in Program.kafe.zakupchik)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    zak.pok, zak.kol.ToString(), zak.price.ToString()
                });
                item.Tag = zak;
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
                    zakupchik zak = listView1.SelectedItems[0].Tag as zakupchik;
                    Program.kafe.zakupchik.Remove(zak);
                    Program.kafe.SaveChanges();
                    ShowZak();
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

