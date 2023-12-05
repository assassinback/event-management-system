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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnect x = new sqlConnect();
            bool res=x.adminLogin(textBox1.Text,textBox2.Text);
            if(res)
            {
                MessageBox.Show("Logged in");
                AdminPanel z = new AdminPanel(textBox1.Text,textBox2.Text);
                z.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome x = new Welcome();
            x.Visible = true;
            this.Visible = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
