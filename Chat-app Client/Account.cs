using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Chat_app_Client
{
    public class Account
    {
        public const String connectionString = "Server=localhost;Database=proiect;Uid=root;Password=;";
        public static MySqlConnection conn = new MySqlConnection(connectionString);
        public static bool addUser(String username, String password)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("INSERT INTO users (username, password) VALUES (@username, @password)", conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("User not added!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static bool removeUser(String username)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("DELETE FROM Users WHERE userName = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("User not removed!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public static bool checkUser(String username, String password)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT password FROM users WHERE username = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                if ((string)(command.ExecuteScalar()) == password)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Cannot check user password!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static bool searchUser(String username)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT username FROM users WHERE username = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                if ((string)(command.ExecuteScalar()) == username)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                MessageBox.Show("Cannot search user!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static bool updateUserIP(String username, String ipAddress)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("UPDATE users SET ipAddress = @ipAddress WHERE username = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@ipAddress", ipAddress);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("Cannot update IP!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        public static bool updateUserStatus(String username, bool isLogged)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("UPDATE users SET isLogged = @isLogged WHERE username = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@isLogged", isLogged);
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                MessageBox.Show("Cannot update status!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }



        public static Dictionary<String, String> getAllLoggedUsers()
        {
            Dictionary<String, String> loggedUsers = new Dictionary<String, String>();
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT username, ipAddress FROM users WHERE isLogged = true", conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        loggedUsers.Add(reader[0].ToString(), reader[1].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Cannot get logged users!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                return loggedUsers;
            }
            catch
            {
                return null;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static String getUserIPByUsername(String username)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT ipAddress FROM users WHERE username = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                return command.ExecuteScalar().ToString();
            }
            catch
            {
                MessageBox.Show("ERROR!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        public static String getUsernameByIP(String ipAddress)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT username FROM users WHERE ipAddress = @ipAddress", conn);
                command.Parameters.AddWithValue("@ipAddress", ipAddress);
                command.ExecuteNonQuery();
                return command.ExecuteScalar().ToString();
            }
            catch
            {
                MessageBox.Show("ERROR!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return String.Empty;
            }
            finally 
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        public static bool getUserStatus(String username)
        {
            try
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT isLogged FROM Users WHERE username = @username", conn);
                command.Parameters.AddWithValue("@username", username);
                command.ExecuteNonQuery();
                return (bool)(command.ExecuteScalar());
            }
            catch
            {
                MessageBox.Show("Cannot get user status!", "Cannot connect to DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
