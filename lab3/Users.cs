using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lab3
{
    public class Users
    {
        List<User> users;
        public List<User> GetUsers { get { return users; } }
        public Users()
        {
            users = new List<User>();

            FileInfo fileInfo = new FileInfo("data.json");

            if (fileInfo.Exists)
            {
                using (StreamReader sr = new StreamReader("data.json"))
                {
                    string json = sr.ReadToEnd();
                    users = JsonSerializer.Deserialize<List<User>>(json);
                }
            }
            else
            {
                User newUser = new User();
                newUser.login = "ADMIN";
                users.Add(newUser);
            }
        }

        public int LogIn(string login, string pass)
        {
            //Codes:
            //0 - Неверный пароль 
            //1 - Пользователя не существует 
            //2 - Админитратор
            //3 - Пользователь 
            //31 - Пользователь новый 
            //32 - Пользователь доступ запрещен 

            User CurrentUser = null;

            foreach (User user in users)
            {
                if (user.login == login)
                {
                    CurrentUser = user;
                    break;
                }
            }

            if (CurrentUser != null)
            {
                if (CurrentUser.password == null)
                    return 31;
                if (CurrentUser.password == pass)
                {
                    if (CurrentUser.access == true)
                    {
                        if (CurrentUser.login == "ADMIN")
                            return 2;
                        else
                            return 3;
                    }
                    else
                        return 32;
                }
                else
                    return 0;
            }
            else
                return 1;
        }

        public bool ChangePassword(string login, string password)
        {
            User user = FindUserByLogin(login);

            if (user != null)
            {
                if (CheckPassword(user, password))
                {
                    user.password = password;
                    return true;
                }
                return false;
            }
            throw new Exception();
        }

        bool CheckPassword(User user, string pass)
        {
            if (pass.Length < user.passMinLength)
                    return false;
            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] < 33 && pass[i] > 127)
                    return false;
            }
            if (user.passNum == true)
            {
                bool fits = false;
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 48 && pass[i] <= 57)
                    {
                        fits = true;
                        break;
                    }
                }
                if (fits == false)
                    return false;
            }
            if (user.passUpper == true)
            {
                bool fits = false;
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 65 && pass[i] <= 90)
                    {
                        fits = true;
                        break;
                    }
                }
                if (fits == false)
                    return false;
            }
            if (user.passLower == true)
            {
                bool fits = false;
                for (int i = 0; i < pass.Length; i++)
                {
                    if (pass[i] >= 97 && pass[i] <= 122)
                    {
                        fits = true;
                        break;
                    }
                }
                if (fits == false)
                    return false;
            }
            if (user.passSymb == true)
            {
                bool fits = false;
                for (int i = 0; i < pass.Length; i++)
                {
                    if ((pass[i] >= 33 && pass[i] <= 47) ||
                        (pass[i] >= 58 && pass[i] <= 64) ||
                        (pass[i] >= 91 && pass[i] <= 96) ||
                        (pass[i] >= 123 && pass[i] <= 127))
                    {
                        fits = true;
                        break;
                    }
                }
                if (fits == false)
                    return false;
            }
            return true;
        }

        public void AddUser(string login)
        {
            if (FindUserByLogin(login) == null)
            {
                User newUser = new User();
                newUser.login = login;
                users.Add(newUser);
            }
        }

        public void Save()
        {
            string s = JsonSerializer.Serialize(users);

            using (StreamWriter sw = new StreamWriter("data.json", false))
            {
                sw.Write(s);
            }
        }

        User FindUserByLogin(string login)
        {
            foreach(User user in users)
            {
                if (user.login == login)
                    return user;
            }
            return null;
        }
    }
}
