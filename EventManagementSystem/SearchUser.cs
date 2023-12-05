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
    public partial class SearchUser : Form
    {
        string user, pass;
        AdminPanel admin;
        public SearchUser()
        {
            InitializeComponent();
        }
        public SearchUser(string username,string password,AdminPanel x)
        {
            InitializeComponent();
            user = username;
            pass = password;
            admin = x;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            sqlConnect y = new sqlConnect();
            //string[] userinfo;
            //bool z;
            var result=y.searchUserAdmin(textBox1.Text);
            if(result.Item1)
            {
                SearchUser1 x = new SearchUser1(user,pass,result.Item2);
                x.Visible = true;
                admin.Visible = false;
                this.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void SearchUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            admin.Enabled = true;
        }
    }
}
