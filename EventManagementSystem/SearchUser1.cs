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
    public partial class SearchUser1 : Form
    {
        string user, pass;
        bool room=false;
        string[] userinfo;
        public SearchUser1()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
        }
        public SearchUser1(string username,string password,DataTable dt)
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            user = username;
            pass = password;
            room = true;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Update";
            btn.UseColumnTextForButtonValue = true;
            btn.Text = "Update";
            dataGridView1.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.Name = "Delete";
            btn.UseColumnTextForButtonValue = true;
            btn.Text = "Delete";
            dataGridView1.Columns.Add(btn);
            dataGridView1.DataSource = dt;
        }
        public SearchUser1(string username, string password,string[] useri)
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            user = username;
            pass = password;
            userinfo = useri;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Update";
            btn.UseColumnTextForButtonValue = true;
            btn.Text = "Update";
            dataGridView1.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.Name = "Delete";
            btn.UseColumnTextForButtonValue = true;
            btn.Text = "Delete";
            dataGridView1.Columns.Add(btn);
            DataGridViewTextBoxColumn text = new DataGridViewTextBoxColumn();
            text.Name = "ID";
            dataGridView1.Columns.Add(text);
            text = new DataGridViewTextBoxColumn();
            text.Name = "username";
            dataGridView1.Columns.Add(text);
            text = new DataGridViewTextBoxColumn();
            text.Name = "password";
            dataGridView1.Columns.Add(text);
            text = new DataGridViewTextBoxColumn();
            text.Name = "email";
            dataGridView1.Columns.Add(text);
            text = new DataGridViewTextBoxColumn();
            text.Name = "phone";
            dataGridView1.Columns.Add(text);
            text = new DataGridViewTextBoxColumn();
            text.Name = "roomsbooked";
            dataGridView1.Columns.Add(text);
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[2].Value = userinfo[0];
            dataGridView1.Rows[0].Cells[3].Value = userinfo[1];
            dataGridView1.Rows[0].Cells[4].Value = userinfo[2];
            dataGridView1.Rows[0].Cells[5].Value = userinfo[3];
            dataGridView1.Rows[0].Cells[6].Value = userinfo[4];
            dataGridView1.Rows[0].Cells[7].Value = userinfo[5];
            dataGridView1.Rows[0].Cells[2].ReadOnly = true;
            dataGridView1.Rows[0].Cells[3].ReadOnly = true;
            dataGridView1.Rows[0].Cells[4].ReadOnly = true;
        }
        private void SearchUser1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!room)
            {
                AdminPanel x = new AdminPanel(user, pass);
                x.Visible = true;
                this.Visible = false;
            }
            else
            {
                ShowRooms x = new ShowRooms(user, pass);
                x.Visible = true;
                this.Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //MessageBox.Show(e.ColumnIndex+"");
            if(e.ColumnIndex==0)
            {
                //update
                int z = e.RowIndex;
                sqlConnect x = new sqlConnect();
                bool t = x.updateUserAdmin(dataGridView1.Rows[z].Cells[2].Value.ToString(), dataGridView1.Rows[z].Cells[3].Value.ToString(), dataGridView1.Rows[z].Cells[4].Value.ToString(), dataGridView1.Rows[z].Cells[5].Value.ToString(), dataGridView1.Rows[z].Cells[6].Value.ToString(), dataGridView1.Rows[z].Cells[7].Value.ToString());
                //if(t)
                //{
                //    sqlConnect p = new sqlConnect();
                //    DataTable dt = p.userinfoSearch(dataGridView1.Rows[z].Cells[2].Value.ToString());
                //    dataGridView1.DataSource = dt;
                //    dataGridView1.Columns[2].ReadOnly = true;
                //    dataGridView1.Columns[3].ReadOnly = true;
                //    dataGridView1.Columns[4].ReadOnly = true;                        
                //}
            }
            if(e.ColumnIndex==1)
            {
                //delete
                int z = e.RowIndex;
                sqlConnect x = new sqlConnect();
                bool t = x.deleteUserAdmin(dataGridView1.Rows[z].Cells[2].Value.ToString());
                if(t)
                {
                    dataGridView1.Rows.RemoveAt(z);
                }
                //if(t)
                //{
                //    sqlConnect p = new sqlConnect();
                //    DataTable dt = p.userinfoSearch();
                //    dataGridView1.DataSource = dt;
                //    dataGridView1.Columns[2].ReadOnly = true;
                //    dataGridView1.Columns[3].ReadOnly = true;
                //    dataGridView1.Columns[4].ReadOnly = true;                        
                //}
            }
        }
    }
}
