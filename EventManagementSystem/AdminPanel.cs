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
    public partial class AdminPanel : Form
    {
        string user, pass;
        public AdminPanel()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            
        }
        public AdminPanel(string username,string password)
        {
            InitializeComponent();
            user = username;
            pass = password;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            sqlConnect x = new sqlConnect();
            var data = x.getNbRoomsLeft();
            label1.Text = data.Item1;
            label2.Text = data.Item2;
            label3.Text = data.Item3;
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
        //public Tuple<int,string> doit()
        //{
        //    return Tuple.Create(1,"");
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            AdminLogin x = new AdminLogin();
            x.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowUsers x = new ShowUsers(user,pass);
            x.Visible = true;
            this.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            SearchUser x = new SearchUser(user,pass,this);
            x.Visible = true;
            this.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ShowRooms x = new ShowRooms(user,pass);
            x.Visible = true;
            this.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditRoomsLeft x = new EditRoomsLeft(this);
            x.Visible = true;
            this.Enabled = false;
        }

        private void button6_EnabledChanged(object sender, EventArgs e)
        {
            sqlConnect x = new sqlConnect();
            var data = x.getNbRoomsLeft();
            label1.Text = data.Item1;
            label2.Text = data.Item2;
            label3.Text = data.Item3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SetPrices x = new SetPrices(this);
            x.Visible = true;
            this.Enabled = false;
        }
    }
}
