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
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=ARDACIMEN\\SQLEXPRESS;initial Catalog=DbCustomer;integrated Security=true;");

        private void txtCityCountry_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Select CustomerId,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus,CityName from TblCustomer Inner Join TblCity on TblCity.CityId=TblCustomer.CustomerCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();

        }

        private void btnProcedure_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Execute CustomerListWithCity", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Select * from TblCity ", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable) ;
            cmbCity.ValueMember= "CityId";
            cmbCity.DisplayMember = "CityName";
            cmbCity.DataSource = dataTable;

            sqlConnection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Insert into TblCustomer (CustomerName,CustomerSurname,CustomerCity,CustomerBalance,CustomerStatus) values (@customerName,@customerSurname,@customerCity,@customerBalance,@customerStatus)", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            sqlCommand.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            sqlCommand.Parameters.AddWithValue("@customerCity", cmbCity.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@customerBalance", txtBalance.Text);

            if (rdrActive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", true);

            }
            if (rdrPassive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", false);
            }
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Müşteri Başarılı Bir Şekilde Eklendi");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Delete from TblCustomer Where CustomerId=@customerId", sqlConnection);
            command.Parameters.AddWithValue("@customerId", txtcustomerId.Text);
            command.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Müşteri Başarılı Bir Şekilde Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Update TblCustomer set CustomerName=@customerName,CustomerSurname=@customerSurname,CustomerCity=@customerCity,CustomerBalance=@customerBalance,CustomerStatus=@customerStatus where CustomerId=@customerId", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);
            sqlCommand.Parameters.AddWithValue("@customerSurname", txtCustomerSurname.Text);
            sqlCommand.Parameters.AddWithValue("@customerCity", cmbCity.SelectedValue);
            sqlCommand.Parameters.AddWithValue("@customerBalance", txtBalance.Text);
            sqlCommand.Parameters.AddWithValue("@customerId", txtcustomerId.Text);

            if (rdrActive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", true);

            }
            if (rdrPassive.Checked)
            {
                sqlCommand.Parameters.AddWithValue("@customerStatus", false);
            }
            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            MessageBox.Show("Müşteri Başarılı Bir Şekilde Eklendi");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();


            SqlCommand sqlCommand = new SqlCommand("Select CustomerId,CustomerName,CustomerSurname,CustomerBalance,CustomerStatus,CityName from TblCustomer Inner Join TblCity on TblCity.CityId=TblCustomer.CustomerCity Where CustomerName=@customerName", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@customerName", txtCustomerName.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            sqlConnection.Close();
        }
    }
}
