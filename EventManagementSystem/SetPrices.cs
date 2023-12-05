using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventManagementSystem
{
    public partial class SetPrices : Form
    {
        public SetPrices()
        {
            InitializeComponent();
            sqlConnect x = new sqlConnect();
        }
        AdminPanel admin;
        public SetPrices(AdminPanel t)
        {
            InitializeComponent();
            sqlConnect x = new sqlConnect();
            var data=x.setPricesinfo();
            comboBox1.DisplayMember = "Eventtype";
            comboBox2.DisplayMember = "Rooms";
            comboBox3.DisplayMember = "Size";
            comboBox4.DisplayMember = "Roomtype";
            for(int i=0;i<data.Item1.Length;i++)
            {
                //MessageBox.Show(i + "");
                comboBox1.Items.Add(data.Item1[i]);
            }
            for (int i = 0; i < data.Item2.Length; i++)
            {
                //MessageBox.Show(i + "");
                comboBox2.Items.Add(data.Item2[i]);
            }
            for (int i = 0; i < data.Item3.Length; i++)
            {
                //MessageBox.Show(i + "");
                comboBox3.Items.Add(data.Item3[i]);
            }
            for (int i = 0; i < data.Item4.Length; i++)
            {
                //MessageBox.Show(i + "");
                comboBox4.Items.Add(data.Item4[i]);
            }
            admin = t;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }
        private void SetPrices_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = ((Classes.eventtype)comboBox1.SelectedItem).Price + "";
        }

        private void SetPrices_FormClosed(object sender, FormClosedEventArgs e)
        {
            admin.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnect x = new sqlConnect();
            bool t = x.updatePrices(comboBox1.Text, int.Parse(textBox1.Text), comboBox2.Text, int.Parse(textBox2.Text), comboBox3.Text, int.Parse(textBox3.Text), comboBox4.Text, int.Parse(textBox4.Text));
            if (t)
            {
                MessageBox.Show("Updated");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Text = ((Classes.nbroomsinfo)comboBox2.SelectedItem).Price+ "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = ((Classes.roomsize)comboBox3.SelectedItem).Price + "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = ((Classes.roomtype)comboBox4.SelectedItem).Price+ "";
        }
    }
}
