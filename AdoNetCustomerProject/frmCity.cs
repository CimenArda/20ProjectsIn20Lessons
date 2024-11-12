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

namespace AdoNetCustomerProject
{
    public partial class frmCity : Form
    {
        public frmCity()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=ARDACIMEN\\SQLEXPRESS;initial Catalog=DbCustomer;integrated Security=true;");
        private void btnList_Click(object sender, EventArgs e)
        {
           
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Select * from TblCity",sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Insert into TblCity(CityName,CityCountry) values (@cityName,@cityCountry)",sqlConnection);

            command.Parameters.AddWithValue("@cityName",txtCityName.Text);

            command.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);

            command.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Şehir Başarılı Bir Şekilde Eklendi");



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Delete from TblCity Where CityId=@cityId",sqlConnection);
            command.Parameters.AddWithValue("@cityId", txtCityId.Text);
            command.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Şehir Başarılı Bir Şekilde Silindi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Update TblCity Set CityName=@cityName,CityCountry=@cityCountry where CityId=@cityId", sqlConnection);
            command.Parameters.AddWithValue("@cityName", txtCityName.Text);
            command.Parameters.AddWithValue("@cityCountry", txtCityCountry.Text);
            command.Parameters.AddWithValue("@cityId", txtCityId.Text);
            command.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Şehir Başarılı Bir Şekilde Güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * from TblCity where CityName=@cityName", sqlConnection);
            command.Parameters.AddWithValue("@cityName", txtCityName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }

        private void frmCity_Load(object sender, EventArgs e)
        {

        }
    }
}
