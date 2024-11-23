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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionstring = "Server=localhost;port=5432;Database=DbTodoApp;UserId=postgres;Password=112233Arda.08";

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            FrmCategory category = new FrmCategory();
            category.Show();
        }
        void todoList()
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select * from ToDo";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
        void categoryList()
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select * from Categories";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            cmbcategory.DisplayMember = "CategoryName";
            cmbcategory.ValueMember = "CategoryID";
            cmbcategory.DataSource = dataTable;
            connection.Close();
        }
        private void btnlist_Click(object sender, EventArgs e)
        {
            todoList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            categoryList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            int categoryID = int.Parse(cmbcategory.SelectedValue.ToString());
            string title = txttitle.Text;
            string priority = txtpriority.Text;
            string description = txtDescription.Text;
            //bool status =false;
            //if (rdbCompleted.Checked)
            //{
            //    status = true;

            //}
            //if (rdbContinue.Checked)
            //{

            //    status = false;
            //}

            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "insert into ToDoLists (title,description,status,priority,categoryid) values (@title,@description,B'1',@priority,@categoryid)";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                // command.Parameters.AddWithValue("@status", "B'1'");
                command.Parameters.AddWithValue("@priority", priority);
                command.Parameters.AddWithValue("@categoryid", categoryID);
                command.ExecuteNonQuery();
                MessageBox.Show("Yapılacak İşlem Eklendi");
                todoList();
            }
            connection.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtprocessID.Text);

            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Delete From todo Where todoid=@todoid";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@todoid", id);
                command.ExecuteNonQuery();
                MessageBox.Show("Veri başarıyla silindi");
                categoryList();
            }
            connection.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtprocessID.Text);
            int categoryId = int.Parse(cmbcategory.SelectedValue.ToString());
            string title = txttitle.Text;
            string priority = txtpriority.Text;
            string description = txtDescription.Text;

            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Update todo Set Title=@title,Description=@description,priority=@priority,categoryid=@categoryid where todoid=@todoid";
            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@todoid", id);
                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@description", description);
                command.Parameters.AddWithValue("@priority", priority);
                command.Parameters.AddWithValue("@categoryid", categoryId);
                command.ExecuteNonQuery();
                MessageBox.Show("İşlem başarıyla güncellendi");
                categoryList();
            }
            connection.Close();
        }

        private void btncompleted_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select * From todo Where Status='1'";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnContinued_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select * From todo Where Status='0'";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void btnAllList_Click(object sender, EventArgs e)
        {
            var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            string query = "Select todoid,title,description,status,priority,categoryname from todo inner join categories on todo.categoryid=categories.categoryid";
            var command = new NpgsqlCommand(query, connection);
            var adapter = new NpgsqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }
    }
}
