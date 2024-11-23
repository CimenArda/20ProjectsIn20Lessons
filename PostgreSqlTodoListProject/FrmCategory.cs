using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlTodoListProject
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        string connectionstring = "Server=localhost;port=5432;Database=DbTodoApp;UserId=postgres;Password=112233Arda.08";

        void CategoryList()
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select * from Categories";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }
        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Insert into categories (CategoryName) values (@categoryName)";
            using(var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryName",txtCategoryName.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Eklendi");
                CategoryList();

            }
            connection.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txtcategoryID.Text);

            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Delete from categories where CategoryID =@categoryID";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryID", id);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Silindi");
                CategoryList();

            }
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtcategoryID.Text);

            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Update categories set CategoryName =@categoryName where CategoryID =@categoryID";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryID", id);
                command.Parameters.AddWithValue("@categoryName", txtCategoryName.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Kategori Güncellendi");
                CategoryList();

            }
            connection.Close();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtcategoryID.Text);

            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select * from categories where CategoryID=@categoryID";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@categoryID", id);

                using(var adapter = new NpgsqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }

            }
            connection.Close();
        }
    }
}
