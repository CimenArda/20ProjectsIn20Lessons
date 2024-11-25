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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        SqlConnection sqlConnection = new SqlConnection("Server=ARDACIMEN\\SQLEXPRESS;initial Catalog=JWTTokenProject;integrated Security=true;");

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TokenGenerator tokenGenerator = new TokenGenerator();

            sqlConnection.Open();
            SqlCommand command = new SqlCommand("Select * from Users Where UserName =@username and Password=@password",sqlConnection);
            command.Parameters.AddWithValue("@username",txtUserName.Text);
            command.Parameters.AddWithValue("@password", txtPassword.Text);

            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                string token = tokenGenerator.GenerateJwtToken2(txtUserName.Text);
                
                FrmEmployee frm = new FrmEmployee();
                frm.tokenget = token;
                frm.Show();

            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!");
                txtPassword.Clear();
                txtUserName.Clear();
                txtUserName.Focus();
            }
            sqlConnection.Close();
        }
    }
}
