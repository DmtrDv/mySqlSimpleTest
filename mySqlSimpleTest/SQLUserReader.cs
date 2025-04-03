using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mySqlSimpleTest
{
    public class SQLUserReader
    {
        string myConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo;database=myvknetwork;"; /// строка соединения с БД
        public BindingList<User> ReadUsers()
        {
            BindingList<User> result = new BindingList<User>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    const string query = "SELECT Login, Name, Surname, Email, Password, Birthday FROM users;";
                    MySqlCommand command = new MySqlCommand(query, conn); /// объект команды
                    using (MySqlDataReader reader = command.ExecuteReader()) /// запуск исполнения команды на сервере
                    {
                        while (reader.Read()) /// пока  есть данные в результате
                        {
                            string login = reader.GetString("Login");

                            User us = new User(login);
                            us.Name = reader.GetString("name");
                            us.Surname = reader.GetString("surname");
                            us.Email = reader.GetString("email");
                            us.Password = reader.GetString("password");
                            us.Birthday = reader.GetDateTime("birthday");
                            result.Add(us);
                        }
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }

            return result;
        }

        public void DeleteUser(string login)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM users WHERE login = @login;";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@login", login);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
