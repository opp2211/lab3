using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class ManageUsers : Form
    {
        Users users;
        List<User> uss;
        public ManageUsers(Users users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            FillUsers();
        }

        void FillUsers()
        {
            dataGridView1.Rows.Clear();

            uss = users.GetUsers;
            for (int i = 1; i < uss.Count; i++)
            {
                dataGridView1.Rows.Add(uss[i].login, uss[i].access, uss[i].passNum, uss[i].passUpper, uss[i].passLower, uss[i].passSymb);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                users.AddUser(textBox1.Text);

            FillUsers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                uss[i + 1].access = (bool)dataGridView1.Rows[i].Cells[1].Value;
                uss[i + 1].passNum = (bool)dataGridView1.Rows[i].Cells[2].Value;
                uss[i + 1].passUpper = (bool)dataGridView1.Rows[i].Cells[3].Value;
                uss[i + 1].passLower= (bool)dataGridView1.Rows[i].Cells[4].Value;
                uss[i + 1].passSymb = (bool)dataGridView1.Rows[i].Cells[5].Value;
            }

            FillUsers();
        }
    }
}
