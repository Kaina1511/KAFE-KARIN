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
    public partial class mark : Form
    {
        public mark()
        {
            InitializeComponent();
            ShowMark();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            marketolog mark = new marketolog();
            mark.Rek = textBox1.Text;
            mark.Kol = Convert.ToInt32(textBox2.Text);
            mark.Price = Convert.ToInt32(textBox3.Text);
            Program.kafe.marketolog.Add(mark);
            Program.kafe.SaveChanges();
            ShowMark();
        }
        void ShowMark()
        {
            listView1.Items.Clear();
            foreach (marketolog mark in Program.kafe.marketolog)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    mark.Rek, mark.Kol.ToString(), mark.Price.ToString()
                });
                item.Tag = mark;
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
                    marketolog mark = listView1.SelectedItems[0].Tag as marketolog;
                    Program.kafe.marketolog.Remove(mark);
                    Program.kafe.SaveChanges();
                    ShowMark();
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
