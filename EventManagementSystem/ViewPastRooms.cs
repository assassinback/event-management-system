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
    public partial class ViewPastRooms : Form
    {
        public ViewPastRooms()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
        }
        int id;
        string user, pass;
        public ViewPastRooms(int ids,string username,string password)
        {
            InitializeComponent();
            id = ids;
            user = username;
            pass = password;
            sqlConnect x = new sqlConnect();
            DataTable dt=x.viewpastrooms(id);
            dataGridView1.DataSource = dt;

        }
        private void ViewPastRooms_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserPanel x = new UserPanel(id,user,pass);
            x.Visible = true;
            this.Visible = false;
        }
    }
}
