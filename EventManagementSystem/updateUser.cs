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
    public partial class updateUser : Form
    {
        public updateUser()
        {
            InitializeComponent();
        }
        UserPanel y;
        public updateUser(int id,UserPanel z)
        {
            InitializeComponent();
            y = z;
            label2.Text = id + "";
            textBox2.UseSystemPasswordChar = true;
            sqlConnect x = new sqlConnect();
            var t=x.updateUseruser(id);
            textBox1.Text = t.Item1;
            textBox2.Text = t.Item2;
            textBox3.Text = t.Item3;
            textBox4.Text = t.Item4;
        }
        private void updateUser_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            //textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = false;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void updateUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            y.Enabled = true;
        }
    }
}
