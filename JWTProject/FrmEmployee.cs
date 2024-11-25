using JWTProject.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JWTProject
{
    public partial class FrmEmployee : Form
    {
        public FrmEmployee()
        {
            InitializeComponent();
        }
         public  string tokenget;

        SqlConnection sqlConnection = new SqlConnection("Server=ARDACIMEN\\SQLEXPRESS;initial Catalog=JWTTokenProject;integrated Security=true;");
        private void FrmEmployee_Load(object sender, EventArgs e)
        {
               


            richTextBox1.Text = tokenget;

        


            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Select * From Employees", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }
    }
}
