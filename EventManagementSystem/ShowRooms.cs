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
    public partial class ShowRooms : Form
    {
        string user, pass;
        public ShowRooms()
        {
            InitializeComponent();
        }
        public ShowRooms(string username,string password)
        {
            InitializeComponent();
            user = username;
            pass = password;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "Delete";
            btn.Text = "Delete";
            dataGridView1.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "Update";
            btn.Text = "Update";
            dataGridView1.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "Show User";
            btn.Text = "Show User";
            dataGridView1.Columns.Add(btn);
            sqlConnect x = new sqlConnect();
            dataGridView1.DataSource = x.bookedroomsInfo();
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            
        }
        private void ShowRooms_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel x = new AdminPanel(user,pass);
            x.Visible = true;
            this.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==0)
            {
                //delete
                sqlConnect x = new sqlConnect();
                int z = e.RowIndex;
                bool t=x.deleteBookedRoom(dataGridView1.Rows[z].Cells[4].Value.ToString());
                if(t)
                {
                    dataGridView1.Rows.RemoveAt(z);
                }
            }
            if(e.ColumnIndex==1)
            {
                //update
                sqlConnect x = new sqlConnect();
                int z = e.RowIndex;
                bool t = x.updateBookedRoom(dataGridView1.Rows[z].Cells[4].Value.ToString(), dataGridView1.Rows[z].Cells[5].Value.ToString(), dataGridView1.Rows[z].Cells[6].Value.ToString(), dataGridView1.Rows[z].Cells[7].Value.ToString(), dataGridView1.Rows[z].Cells[8].Value.ToString(), dataGridView1.Rows[z].Cells[9].Value.ToString());
                if(t)
                {
                    MessageBox.Show("Updated");
                }
                else
                {

                }
            }
            if(e.ColumnIndex==2)
            {
                int z = e.RowIndex;
                sqlConnect x = new sqlConnect();
                var user1 = x.searchUser(dataGridView1.Rows[z].Cells[3].Value.ToString());
                if (user1.Item1)
                {
                    
                    SearchUser1 y = new SearchUser1(user, pass, user1.Item2);
                    y.Visible = true;
                    this.Visible = false;
                }
            }
        }
    }
}
