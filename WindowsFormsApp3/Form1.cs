using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using WindowsFormsApp3;
using WindowsFormsApp3.Properties;
    
namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Password.UseSystemPasswordChar = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeID = Employee.Text;
            string username = Username.Text;
            string password = Password.Text;

            if (!string.IsNullOrEmpty(username))
            {
                AuthenticateByUsername(username, password);
            }
            else if (!string.IsNullOrEmpty(employeeID))
            {
                AuthenticateByEmployeeID(employeeID, password);
            }
            else
            {
                MessageBox.Show("Введите либо имя пользователя, либо ID сотрудника.");
            }
        }

        private int GetUserIdAfterLogin(string usernameOrFullName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            int userId = -1;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserTypeID FROM Users WHERE Username=@UsernameOrFullName OR FullName=@UsernameOrFullName";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsernameOrFullName", usernameOrFullName);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }

            return userId;
        }

        private void AuthenticateByUsername(string username, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM Users WHERE Username=@Username AND Password=@Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        int userId = GetUserIdAfterLogin(username);
                        if (userId != -1)
                        {
                            
                            Properties.Settings.Default.UserID = userId;
                            Properties.Settings.Default.Save();

                            MessageBox.Show("Вход выполнен успешно!");
                            Form2 form2 = new Form2(userId);
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось получить ID пользователя.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильное имя пользователя или пароль.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void AuthenticateByEmployeeID(string employeeID, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(1) FROM Users WHERE FullName=@FullName AND Password=@Password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FullName", employeeID);
                    command.Parameters.AddWithValue("@Password", password);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 1)
                    {
                        int userId = GetUserIdAfterLogin(employeeID);
                        if (userId != -1)
                        {
                            Properties.Settings.Default.UserID = userId;
                            Properties.Settings.Default.Save();

                            MessageBox.Show("Вход выполнен успешно!");
                            Form2 form2 = new Form2(userId);
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось получить ID пользователя.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный ID сотрудника или пароль.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = !ShowPassword.Checked;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Employee_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
