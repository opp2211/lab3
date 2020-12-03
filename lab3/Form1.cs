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
    public partial class Form1 : Form
    {
        Users users;
        int wpCount = 2;
        public Form1()
        {
            InitializeComponent();
            users = new Users();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int code = users.LogIn(textBox1.Text, textBox2.Text);
            //Codes:
            //0 - Неверный пароль 
            //1 - Пользователя не существует 
            //2 - Админитратор
            //3 - Пользователь 
            //31 - Пользователь новый 
            //32 - Пользователь доступ запрещен 
            switch (code)
            {
                case 0:
                    if (wpCount == 0)
                    {
                        Close();
                    }
                    else
                    {
                        MessageBox.Show($"Неверный пароль! Осталось попыток: {wpCount--}");
                        textBox2.Clear();
                    }
                    break;
                case 1:
                    MessageBox.Show("Пользователя не существует");
                    break;
                case 2:
                    ShowAdminForm();
                    break;
                case 3:
                    ShowUserForm();
                    break;
                case 31:
                    ShowPasswordConfForm(textBox1.Text, textBox2.Text);
                    textBox2.Clear();
                    break;
                case 32:
                    MessageBox.Show("Доступ заблокирован администратором");
                    break;
                default:
                    MessageBox.Show("Что-то пошло не так!");
                    break;
            }
        }

        void ShowAdminForm()
        {
            Form2 form2 = new Form2(this, users, textBox1.Text);
            form2.Show();
            Visible = false;
        }

        void ShowUserForm()
        {
            Form3 form3 = new Form3(this, users, textBox1.Text);
            form3.Show();
            Visible = false;
        }

        void ShowPasswordConfForm(string login, string password)
        {
            PasswordConfirmation pc = new PasswordConfirmation(users, login, password);
            pc.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            users.Save();
        }
    }
}
