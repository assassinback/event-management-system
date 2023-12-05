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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome x = new Welcome();
            x.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnect x = new sqlConnect();
            var res = x.userlogin(textBox1.Text, textBox2.Text);
            if(res.Item1)
            {
                MessageBox.Show("Logged in");
                UserPanel pan = new UserPanel(res.Item2,textBox1.Text,textBox2.Text);
                pan.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
        }
    }
}
