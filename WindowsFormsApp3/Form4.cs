using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form4 : Form
    {
        private long itemId;

        public Form4()
        {
            InitializeComponent();
            LoadAmenities();
            LoadAttractionsAndAreas();
            LoadItemTypes();
            SaveDataToDatabase(); // Сохраняем данные в БД при инициализации (если это необходимо)
        }

        // Загрузка доступных удобств (Amenities)
        private void LoadAmenities()
        {
            string query = @"
                SELECT a.ID, a.Name 
                FROM Amenities a
                LEFT JOIN ItemAmenities ia ON a.ID = ia.AmenityID AND ia.ItemID = @ItemID";

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ItemID", itemId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            // Заполнение CheckedListBox данными
                            AmenitiesCheckedListBox.DataSource = dataTable;
                            AmenitiesCheckedListBox.DisplayMember = "Name";
                            AmenitiesCheckedListBox.ValueMember = "ID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке удобств: " + ex.Message);
            }
        }

        // Сохранение данных в таблицы Items, ItemAmenities и ItemAttractions
        private void SaveDataToDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Вставка данных в таблицу Items и получение сгенерированного ItemID
                string insertItemQuery = @"
                    INSERT INTO Items (GUID, UserID, ItemTypeID, AreaID, Title, Capacity, NumberOfBeds, NumberOfBedrooms, NumberOfBathrooms, ExactAddress, ApproximateAddress, Description, HostRules, MinimumNights, MaximumNights) 
                    VALUES (@GUID, @UserID, @ItemTypeID, @AreaID, @Title, @Capacity, @NumberOfBeds, @NumberOfBedrooms, @NumberOfBathrooms, @ExactAddress, @ApproximateAddress, @Description, @HostRules, @MinimumNights, @MaximumNights);
                    SELECT SCOPE_IDENTITY();";

                using (SqlCommand insertCommand = new SqlCommand(insertItemQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@GUID", Guid.NewGuid());
                    insertCommand.Parameters.AddWithValue("@UserID", 2); // Здесь укажите текущий ID пользователя
                    insertCommand.Parameters.AddWithValue("@ItemTypeID", Convert.ToInt64(Type.SelectedValue));
                    insertCommand.Parameters.AddWithValue("@AreaID", 2); // Замените на соответствующий ID области
                    insertCommand.Parameters.AddWithValue("@Title", Title.Text);
                    insertCommand.Parameters.AddWithValue("@Capacity", (int)Capacity.Value);
                    insertCommand.Parameters.AddWithValue("@NumberOfBeds", (int)NumberOfBeds.Value);
                    insertCommand.Parameters.AddWithValue("@NumberOfBedrooms", (int)NumberOfBedrooms.Value);
                    insertCommand.Parameters.AddWithValue("@NumberOfBathrooms", (int)NumberOfBethrooms.Value);
                    insertCommand.Parameters.AddWithValue("@ExactAddress", ExtraAddress.Text);
                    insertCommand.Parameters.AddWithValue("@ApproximateAddress", ApproximateAddress.Text);
                    insertCommand.Parameters.AddWithValue("@Description", Description.Text);
                    insertCommand.Parameters.AddWithValue("@HostRules", HostRules.Text);
                    insertCommand.Parameters.AddWithValue("@MinimumNights", (int)Minimum.Value);
                    insertCommand.Parameters.AddWithValue("@MaximumNights", (int)Maximum.Value);

                    try
                    {
                        itemId = Convert.ToInt64(insertCommand.ExecuteScalar());
                        MessageBox.Show("Данные элемента успешно сохранены. ItemID: " + itemId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при вставке данных элемента: " + ex.Message);
                        return;
                    }
                }

                // Вставка выбранных удобств (Amenities)
                SaveAmenities(connection);

                // Вставка аттракционов и расстояний
                SaveAttractions(connection);
            }
        }

        // Вставка выбранных удобств (Amenities) для текущего элемента (Item)
        private void SaveAmenities(SqlConnection connection)
        {
            string insertAmenitiesQuery = "INSERT INTO ItemAmenities (GUID, ItemID, AmenityID) VALUES (@GUID, @ItemID, @AmenityID)";
            foreach (var amenity in AmenitiesCheckedListBox.CheckedItems)
            {
                using (SqlCommand amenityCommand = new SqlCommand(insertAmenitiesQuery, connection))
                {
                    amenityCommand.Parameters.AddWithValue("@GUID", Guid.NewGuid());
                    amenityCommand.Parameters.AddWithValue("@ItemID", itemId);
                    int amenityId = Convert.ToInt32(((DataRowView)amenity)["ID"]);
                    amenityCommand.Parameters.AddWithValue("@AmenityID", amenityId);

                    try
                    {
                        amenityCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при вставке данных удобства: " + ex.Message);
                    }
                }
            }
        }

        // Вставка аттракционов (Attractions) и расстояний до них
        private void SaveAttractions(SqlConnection connection)
        {
            string insertAttractionQuery = @"
                INSERT INTO ItemAttractions (GUID, ItemID, AttractionID, Distance, DurationOnFoot, DurationByCar) 
                VALUES (@GUID, @ItemID, @AttractionID, @Distance, @DurationOnFoot, @DurationByCar)";

            foreach (DataGridViewRow row in LandmarksDataGridView.Rows)
            {
                if (row.Cells["Attraction"].Value != null && row.Cells["Distance"].Value != null)
                {
                    using (SqlCommand attractionCommand = new SqlCommand(insertAttractionQuery, connection))
                    {
                        attractionCommand.Parameters.AddWithValue("@GUID", Guid.NewGuid());
                        attractionCommand.Parameters.AddWithValue("@ItemID", itemId);
                        attractionCommand.Parameters.AddWithValue("@AttractionID", GetAttractionIDByName(row.Cells["Attraction"].Value.ToString(), connection));
                        attractionCommand.Parameters.AddWithValue("@Distance", Convert.ToDecimal(row.Cells["Distance"].Value));
                        attractionCommand.Parameters.AddWithValue("@DurationOnFoot", row.Cells["DurationOnFoot"].Value ?? DBNull.Value);
                        attractionCommand.Parameters.AddWithValue("@DurationByCar", row.Cells["DurationByCar"].Value ?? DBNull.Value);

                        try
                        {
                            attractionCommand.ExecuteNonQuery();
                            MessageBox.Show("Аттракцион успешно добавлен: " + row.Cells["Attraction"].Value.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка при вставке аттракциона: " + ex.Message);
                        }
                    }
                }
            }
        }

        // Загрузка доступных типов объектов (ItemTypes)
        private void LoadItemTypes()
        {
            string query = "SELECT ID, Name FROM ItemTypes";
            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            Type.DataSource = dataTable;
                            Type.DisplayMember = "Name";
                            Type.ValueMember = "ID";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов объектов: " + ex.Message);
            }
        }

        // Получение ID аттракциона по его названию
        private int GetAttractionIDByName(string attractionName, SqlConnection connection)
        {
            string query = "SELECT ID FROM Attractions WHERE Name = @Name";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", attractionName);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

        // Загрузка аттракционов и областей в DataGridView
        private void LoadAttractionsAndAreas()
        {
            LandmarksDataGridView.Columns.Clear();
            LandmarksDataGridView.Columns.Add("Attraction", "Аттракцион");
            LandmarksDataGridView.Columns.Add("Area", "Область");
            LandmarksDataGridView.Columns.Add("Distance", "Расстояние");
            LandmarksDataGridView.Columns.Add("DurationOnFoot", "Время пешком");
            LandmarksDataGridView.Columns.Add("DurationByCar", "Время на машине");

            string query = @"
                SELECT a.Name AS AttractionName, ar.Name AS AreaName
                FROM Attractions a
                INNER JOIN Areas ar ON a.AreaID = ar.ID";

            string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string attractionName = reader["AttractionName"].ToString();
                                string areaName = reader["AreaName"].ToString();
                                LandmarksDataGridView.Rows.Add(attractionName, areaName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке аттракционов и областей: " + ex.Message);
            }
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex < tabControl1.TabCount - 1)
            {
                tabControl1.SelectedIndex++;
            }
        }
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Done_Click(object sender, EventArgs e)
        {
            SaveDataToDatabase();
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void ApproximateAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
