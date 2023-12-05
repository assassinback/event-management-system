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
    public partial class EditRoomsLeft : Form
    {
        public EditRoomsLeft()
        {
            InitializeComponent();
        }
        AdminPanel y;
        public EditRoomsLeft(AdminPanel x)
        {
            InitializeComponent();
            y = x;
            sqlConnect z = new sqlConnect();
            var t=z.getEditNbRoomsLeft();
            textBox1.Text = t.Item1;
            textBox2.Text = t.Item2;
            textBox3.Text = t.Item3;

        }
        private void EditRoomsLeft_FormClosing(object sender, FormClosingEventArgs e)
        {
            y.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnect x = new sqlConnect();
            bool t = x.updatenbroomsleft(textBox1.Text,textBox2.Text,textBox3.Text);
            if(t)
            {
                MessageBox.Show("Updated");
            }
            else
            {

            }
        }
    }
}
