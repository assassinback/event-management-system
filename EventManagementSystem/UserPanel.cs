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
    public partial class UserPanel : Form
    {
        public UserPanel()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            //3,4,5,6,1,2
            button3.TabIndex = 0;
            button4.TabIndex = 1;
            button5.TabIndex = 2;
            button6.TabIndex = 3;
            button1.TabIndex = 4;
            button2.TabIndex = 5;
        }
        int id;
        
        string user, pass;
        public UserPanel(int ids,string username,string password)
        {
            InitializeComponent();
            button3.TabIndex = 0;
            button4.TabIndex = 1;
            button5.TabIndex = 2;
            button6.TabIndex = 3;
            button2.TabIndex = 4;
            button1.TabIndex = 5;
            id = ids;
            user = username;
            pass = password;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            sqlConnect x = new sqlConnect();
            var data = x.setPricesinfo();
            label2.Text = "";
            for(int i=0;i<data.Item1.Length;i++)
            {
                label2.Text += data.Item1[i].Eventtype + "   ";
            }
            label2.Text += "\r\n";
            for (int i = 0; i < data.Item1.Length; i++)
            {
                label2.Text += data.Item1[i].Price+ "   ";
            }
            label3.Text = "";
            for (int i = 0; i < data.Item2.Length; i++)
            {
                label3.Text += data.Item2[i].Rooms+ "   ";
            }
            label3.Text += "\r\n";
            for (int i = 0; i < data.Item2.Length; i++)
            {
                label3.Text += data.Item2[i].Price + "   ";
            }
            label4.Text = "";
            for (int i = 0; i < data.Item3.Length; i++)
            {
                label4.Text += data.Item3[i].Size+ "   ";
            }
            label4.Text += "\r\n";
            for (int i = 0; i < data.Item3.Length; i++)
            {
                label4.Text += data.Item3[i].Price + "   ";
            }
            label5.Text = "";
            for (int i = 0; i < data.Item4.Length; i++)
            {
                label5.Text += data.Item4[i].Roomtype + "   ";
            }
            label5.Text += "\r\n";
            for (int i = 0; i < data.Item4.Length; i++)
            {
                label5.Text += data.Item4[i].Price + "   ";
            }
        }
        private void UserPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin x = new UserLogin();
            x.Visible = true;
            this.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateUser x = new updateUser(id,this);
            x.Visible = true;
            this.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewPastRooms x = new ViewPastRooms(id,user,pass);
            x.Visible = true;
            this.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewBookedRoomsUser x = new ViewBookedRoomsUser(id, user, pass);
            x.Visible = true;
            this.Visible = false;
        }

    }
}
