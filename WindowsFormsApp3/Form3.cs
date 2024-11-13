using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WindowsFormsApp3;

namespace WindowsFormsApp3
{
    public partial class Form3 : Form
    {
        private bool hasViewedTerms = false; // Флаг для отслеживания, просмотрел ли пользователь условия

        public Form3()
        {
            InitializeComponent();
            checkBox1.Enabled = false; // Изначально блокируем CheckBox для принятия условий
            button1.Enabled = false;  // Изначально блокируем кнопку регистрации
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Путь к файлу с условиями
            string filePath = Path.Combine(Application.StartupPath, @"..\..\Terms.txt");

            // Проверяем наличие файла
            if (File.Exists(filePath))
            {
                Process.Start("notepad.exe", filePath); // Открываем файл с условиями
                hasViewedTerms = true; // Отмечаем, что пользователь просмотрел условия
                checkBox1.Enabled = true; // Разблокируем CheckBox
            }
            else
            {
                MessageBox.Show("Файл с условиями использования (Terms.txt) не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Разблокируем кнопку регистрации, если пользователь принял условия и все поля заполнены
            button1.Enabled = hasViewedTerms && checkBox1.Checked && AreFieldsFilled();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, совпадают ли пароли
            if (Password.Text != RetypePassword.Text)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }

            // Собираем данные для регистрации
            string username = Username.Text;
            string fullname = FullName.Text;
            DateTime birthday = dateTimePicker1.Value;
            string password = Password.Text;
            int familyCount = int.Parse(Family.Text);
            int gender = radioFemale.Checked ? 1 : 0; // 1 = Female, 0 = Male
            Guid guid = Guid.NewGuid();
            int userTypeID = 2; // 2 = Пользователь

            // Подключаемся к базе данных и добавляем пользователя
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString))
            {
                string query = "INSERT INTO Users (GUID, Username, FullName, BirthDate, Password, Gender, FamilyCount, UserTypeID) " +
                               "VALUES (@GUID, @Username, @FullName, @BirthDate, @Password, @Gender, @FamilyCount, @UserTypeID)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GUID", guid);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@FullName", fullname);
                command.Parameters.AddWithValue("@BirthDate", birthday);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@FamilyCount", familyCount);
                command.Parameters.AddWithValue("@UserTypeID", userTypeID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Регистрация прошла успешно!");
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка при регистрации: {ex.Message}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Возвращение к форме входа
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private bool AreFieldsFilled()
        {
            // Проверка, что все поля заполнены
            return !string.IsNullOrEmpty(Username.Text) &&
                   !string.IsNullOrEmpty(FullName.Text) &&
                   !string.IsNullOrEmpty(Password.Text) &&
                   !string.IsNullOrEmpty(RetypePassword.Text) &&
                   !string.IsNullOrEmpty(Family.Text);
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // Проверка на заполнение всех полей и активацию CheckBox
            button1.Enabled = hasViewedTerms && checkBox1.Checked && AreFieldsFilled();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Username_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}