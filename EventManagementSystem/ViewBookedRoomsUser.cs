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
    public partial class ViewBookedRoomsUser : Form
    {
        public ViewBookedRoomsUser()
        {
            InitializeComponent();
        }
        int id;
        string user, pass;
        public ViewBookedRoomsUser(int ids,string username,string password)
        {
            InitializeComponent();
            id = ids;
            user = username;
            pass = password;
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "Update";
            btn.Text = "Update";
            dataGridView1.Columns.Add(btn);
            btn = new DataGridViewButtonColumn();
            btn.UseColumnTextForButtonValue = true;
            btn.Name = "Delete";
            btn.Text = "Delete";
            dataGridView1.Columns.Add(btn);
            sqlConnect x = new sqlConnect();
            DataTable dt = x.ViewBookedRoomsUser(id);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
        }
        private void ViewBookedRoomsUser_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserPanel x = new UserPanel(id, user, pass);
            x.Visible = true;
            this.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("here" + e.ColumnIndex);
            if(e.ColumnIndex==0)
            {
                //update
                sqlConnect x = new sqlConnect();
                int z = e.RowIndex;
                bool t = x.updateBookedRoomUser(dataGridView1.Rows[z].Cells[3].Value.ToString(), dataGridView1.Rows[z].Cells[4].Value.ToString(), dataGridView1.Rows[z].Cells[5].Value.ToString(), dataGridView1.Rows[z].Cells[6].Value.ToString(), dataGridView1.Rows[z].Cells[7].Value.ToString(), dataGridView1.Rows[z].Cells[8].Value.ToString(), dataGridView1.Rows[z].Cells[9].Value.ToString(), dataGridView1.Rows[z].Cells[10].Value.ToString());
                if (t)
                {
                    MessageBox.Show("Updated");
                }
            }
            if(e.ColumnIndex==1)
            {
                
                //delete
                sqlConnect x = new sqlConnect();
                bool t = x.deleteBookedRoomUser(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                if(t)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
