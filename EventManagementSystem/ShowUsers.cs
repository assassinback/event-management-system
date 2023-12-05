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
    public partial class ShowUsers : Form
    {
        public ShowUsers()
        {
            InitializeComponent();
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            
            //DataGridViewButtonCell b = new DataGridViewButtonCell();
            ////b.UseColumnTextForButtonValue = true;
            //int rowIndex = dataGridView1.Rows.Add(b);
            //dataGridView1.Rows[rowIndex].Cells[1].Value = "Update";
        }
        string user, pass;
        
        public ShowUsers(string username,string password)
        {
            InitializeComponent();
            user = username;
            pass = password;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
            sqlConnect x = new sqlConnect();
            DataTable dt=x.userinfo();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            DataGridViewButtonColumn update = new DataGridViewButtonColumn();
            update.Name = "Update";
            update.UseColumnTextForButtonValue = true;
            update.Text = "Update";
            dataGridView1.Columns.Add(update);
            update = new DataGridViewButtonColumn();
            update.Name = "Delete";
            update.UseColumnTextForButtonValue = true;
            update.Text = "Delete";
            dataGridView1.Columns.Add(update);
            update = new DataGridViewButtonColumn();
            update.Name = "Show Booked Rooms";
            update.UseColumnTextForButtonValue = true;
            update.Text = "Show Booked Rooms";
            update.Width = 200;
            dataGridView1.Columns.Add(update);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminPanel x = new AdminPanel(user,pass);
            x.Visible = true;
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex+"");
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("here");
                int x = e.RowIndex;
                sqlConnect y = new sqlConnect();
                bool t=y.updateUserAdmin(dataGridView1.Rows[x].Cells[3].Value.ToString(), dataGridView1.Rows[x].Cells[4].Value.ToString(), dataGridView1.Rows[x].Cells[5].Value.ToString(), dataGridView1.Rows[x].Cells[6].Value.ToString(), dataGridView1.Rows[x].Cells[7].Value.ToString(), dataGridView1.Rows[x].Cells[8].Value.ToString());
                if(t)
                {
                    sqlConnect p = new sqlConnect();
                    DataTable dt = p.userinfo();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                }
            }
            if(e.ColumnIndex==1)
            {
                int x = e.RowIndex;
                sqlConnect y = new sqlConnect();
                bool t=y.deleteUserAdmin(dataGridView1.Rows[x].Cells[3].Value.ToString());
                if(t)
                {
                    sqlConnect p = new sqlConnect();
                    DataTable dt = p.userinfo();
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].ReadOnly = true;
                    dataGridView1.Columns[1].ReadOnly = true;
                    dataGridView1.Columns[2].ReadOnly = true;
                }
            }
            if(e.ColumnIndex==2)
            {
                int x = e.RowIndex;
                sqlConnect y = new sqlConnect();
                var t=y.findRoom(dataGridView1.Rows[x].Cells[3].Value.ToString());
                if(t.Item1)
                {
                    findRoom p = new findRoom(user,pass,t.Item2);
                    p.Visible = true;
                    this.Visible = false;
                }
            }
            // 1
        }

        private void dataGridView1_CellContenClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
