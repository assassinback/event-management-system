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
    public partial class RegisterUser : Form
    {
        public RegisterUser()
        {
            InitializeComponent();
            textBox2.PasswordChar='*';
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnect x = new sqlConnect();
            bool result = x.userRegister(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if(result)
            {
                MessageBox.Show("Registered");
                Welcome wel = new Welcome();
                wel.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Username Already Exists");
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
