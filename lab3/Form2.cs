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
    public partial class Form2 : Form
    {
        Form1 mainform;
        Users users;
        string login;
        public Form2(Form1 mainform, Users users, string login)
        {
            InitializeComponent();
            this.mainform = mainform;
            this.users = users;
            this.login = login;
        }


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainform.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = textBox1.Text;
            PasswordConfirmation pc = new PasswordConfirmation(users, login, newPassword);
            pc.Show();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageUsers mu = new ManageUsers(users);
            mu.Show();
        }
    }
}
