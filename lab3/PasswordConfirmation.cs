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
    public partial class PasswordConfirmation : Form
    {
        Users users;
        string login;
        string password;
        public PasswordConfirmation(Users users, string login, string password)
        {
            InitializeComponent();
            this.users = users;
            this.login = login;
            this.password = password;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == password)
            {
                if(users.ChangePassword(login, password))
                    MessageBox.Show("Пароль успешно изменен!");
                else
                    MessageBox.Show("Пароль не подходит, возможно стоит ограничение, либо проверьте раскладку!");
                Close();
            }
            else
            {
                MessageBox.Show("Подтверждение введено неверно!");
                Close();
            }
        }
    }
}
