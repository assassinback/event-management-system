using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace EventManagementSystem
{
    public partial class Welcome : Form
    {
        //sqlConnect x;
        public Welcome()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            //x = new sqlConnect();
            //SqlConnection y=x.con1();
            //y.Open();
            //if(y.State==ConnectionState.Open)
            //{
            //    MessageBox.Show("connected");
            //}
            try
            {
                sqlConnect x = new sqlConnect();
                x.finishBooking();
            }
            catch(System.Exception)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin x = new AdminLogin();
            x.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserLogin x = new UserLogin();
            x.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegisterUser x = new RegisterUser();
            x.Visible = true;
            this.Visible = false;
        }
    }
}
