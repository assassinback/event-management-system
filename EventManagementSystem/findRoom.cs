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
    public partial class findRoom : Form
    {
        public findRoom()
        {
            InitializeComponent();
        }
        string user, pass;
        public findRoom(string username,string password,DataTable dt)
        {
            InitializeComponent();
            user = username;
            pass=password;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;
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
            dataGridView1.DataSource = dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ShowUsers x = new ShowUsers(user, pass);
            x.Visible = true;
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //delete
                sqlConnect x = new sqlConnect();
                int z = e.RowIndex;
                bool t = x.deleteBookedRoom(dataGridView1.Rows[z].Cells[3].Value.ToString());
                if (t)
                {
                    dataGridView1.Rows.RemoveAt(z);
                }
            }
            if (e.ColumnIndex == 1)
            {
                //update
                sqlConnect x = new sqlConnect();
                int z = e.RowIndex;
                bool t = x.updateBookedRoom(dataGridView1.Rows[z].Cells[3].Value.ToString(), dataGridView1.Rows[z].Cells[4].Value.ToString(), dataGridView1.Rows[z].Cells[5].Value.ToString(), dataGridView1.Rows[z].Cells[6].Value.ToString(), dataGridView1.Rows[z].Cells[7].Value.ToString(), dataGridView1.Rows[z].Cells[8].Value.ToString());
                if (t)
                {
                    MessageBox.Show("Updated");
                }
                else
                {

                }
            }
        }
    }
}
