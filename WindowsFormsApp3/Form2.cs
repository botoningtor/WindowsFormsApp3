using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; // Добавлено для работы с базой данных
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;


namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        private int currentUserId; // Поле для хранения ID текущего пользователя
        // Конструктор формы
        public Form2(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Загружаем данные в таблицу "Items" при загрузке формы
            LoadData();

        }

        // Метод для загрузки данных в DataGridView
        private void LoadData()
        {
            // Получаем строку подключения из файла конфигурации
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Items"; // Запрос для получения всех элементов
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;

                if (dataGridView2.Columns.Contains("ID")) dataGridView2.Columns["ID"].Visible = false;
                if (dataGridView2.Columns.Contains("GUID")) dataGridView2.Columns["GUID"].Visible = false;
                if (dataGridView2.Columns.Contains("UserID")) dataGridView2.Columns["UserID"].Visible = false;
                if (dataGridView2.Columns.Contains("NumberOfBeds")) dataGridView2.Columns["NumberOfBeds"].Visible = false;
                if (dataGridView2.Columns.Contains("NumberOfBedrooms")) dataGridView2.Columns["NumberOfBedrooms"].Visible = false;
                if (dataGridView2.Columns.Contains("NumberOfBathrooms")) dataGridView2.Columns["NumberOfBathrooms"].Visible = false;
                if (dataGridView2.Columns.Contains("ExactAddress")) dataGridView2.Columns["ExactAddress"].Visible = false;
                if (dataGridView2.Columns.Contains("ApproximateAddress")) dataGridView2.Columns["ApproximateAddress"].Visible = false;
                if (dataGridView2.Columns.Contains("Description")) dataGridView2.Columns["Description"].Visible = false;
                if (dataGridView2.Columns.Contains("HostRules")) dataGridView2.Columns["HostRules"].Visible = false;
                if (dataGridView2.Columns.Contains("MinimumNights")) dataGridView2.Columns["MinimumNights"].Visible = false;
                if (dataGridView2.Columns.Contains("MaximumNights")) dataGridView2.Columns["MaximumNights"].Visible = false;

                // Настраиваем порядок отображения столбцов
                if (dataGridView2.Columns.Contains("Title")) dataGridView2.Columns["Title"].DisplayIndex = 0;
                if (dataGridView2.Columns.Contains("Capacity")) dataGridView2.Columns["Capacity"].DisplayIndex = 1;
                if (dataGridView2.Columns.Contains("AreaID")) dataGridView2.Columns["AreaID"].DisplayIndex = 2;
                if (dataGridView2.Columns.Contains("ItemTypeID")) dataGridView2.Columns["ItemTypeID"].DisplayIndex = 3;
                // Продолжайте настройку порядка для других столбцов, если необходимо

                // Обновляем статус с количеством найденных элементов
                UpdateStatus(dataTable.Rows.Count);
            }
        }

        // Метод для поиска элементов по названию или району
        private void SearchItems(string searchText)
        {
            // Получаем строку подключения из файла конфигурации
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Попробуем разобрать введенный текст для поиска по целочисленным полям
                int capacity;
                long areaID;
                long itemTypeID;

                // Создаем параметры для запроса
                string query = @"
            SELECT * 
            FROM Items 
            WHERE Title LIKE @searchText 
               OR Capacity = @capacity 
               OR AreaID = @areaID 
               OR ItemTypeID = @itemTypeID";

                SqlCommand command = new SqlCommand(query, connection);

                // Устанавливаем параметр для поиска по названию
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                // Устанавливаем параметры для целочисленных полей
                command.Parameters.AddWithValue("@capacity", DBNull.Value);
                command.Parameters.AddWithValue("@areaID", DBNull.Value);
                command.Parameters.AddWithValue("@itemTypeID", DBNull.Value);

                // Проверяем, является ли введенный текст целым числом
                if (int.TryParse(searchText, out capacity))
                {
                    command.Parameters["@capacity"].Value = capacity;
                }

                if (long.TryParse(searchText, out areaID))
                {
                    command.Parameters["@areaID"].Value = areaID;
                }

                if (long.TryParse(searchText, out itemTypeID))
                {
                    command.Parameters["@itemTypeID"].Value = itemTypeID;
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;

                // Обновляем статус с количеством найденных элементов
                UpdateStatus(dataTable.Rows.Count);
            }
        }

        // Метод для обновления статуса
        private void UpdateStatus(int count)
        {
            toolStripStatusLabel1.Text = $"Найдено элементов: {count}";
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Проверяем, была ли нажата клавиша Enter
            {
                string searchText = textBoxSearch.Text;
                if (!string.IsNullOrEmpty(searchText))
                {
                    SearchItems(searchText); // Выполняем поиск
                }
                else
                {
                    LoadData(); // Если текст пустой, загружаем все элементы
                }

                e.SuppressKeyPress = true; // Предотвращаем звук "пик" при нажатии Enter
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 formAddListing = new Form4();
            formAddListing.ShowDialog(); // Используйте ShowDialog для модального окна
            LoadOwnerListings(); // Обновляем список объявлений после добавления
        }
        private void LoadOwnerListings()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Title, Capacity, AreaID, ItemTypeID FROM Items WHERE UserID = @UserID"; // Предполагается, что у вас есть UserID текущего клиента
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", currentUserId); // currentUserId - идентификатор текущего пользователя

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;

                // Обновляем статус с количеством найденных элементов
                UpdateStatus(dataTable.Rows.Count);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
