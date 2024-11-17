using Dapper;
using DapperNorthwind.Dtos.CategoryDtos;
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

namespace DapperNorthwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Server=ARDACIMEN\\SQLEXPRESS;initial Catalog=DbDapperNorthwind;integrated Security=true;");

        private async void btnCategoryList_Click(object sender, EventArgs e)
        {
            string query = "Select * from Categories";

            var values =await connection.QueryAsync<ResultCategoryDtos>(query);
            dataGridView1.DataSource = values;
        }

        private async void btnEkle_Click(object sender, EventArgs e)
        {
            string sql = "Insert into Categories (CategoryName,Description) values (@p1,@p2)";
            var parametres = new DynamicParameters();
            parametres.Add("@p1",txtCategoryName.Text);
            parametres.Add("@p2",txtCategoryDescription.Text);

            await connection.ExecuteAsync(sql,parametres);

        }

        private async void btnSil_Click(object sender, EventArgs e)
        {
            string query = "Delete from Categories Where CategoryId=@categoryId";
            var parametres = new DynamicParameters();

            parametres.Add("@categoryId",txtCategoryId.Text);
            await connection.ExecuteAsync(query,parametres);

        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            string query = "Update Categories set CategoryName =@categoryName,Description=@description Where CategoryID=@categoryId";
            var parametres = new DynamicParameters();
            parametres.Add("@categoryName", txtCategoryName.Text);
            parametres.Add("@description", txtCategoryDescription.Text);
            parametres.Add("@categoryId", txtCategoryId.Text);
            await connection.ExecuteAsync(query, parametres);


        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //Kategori Sayısı
            string query = "Select Count(*) from Categories";
            var count = await connection.ExecuteScalarAsync<int>(query);
            lblCategoryCount.Text = count.ToString();

            //Ürün Sayısı
            string query2 = "Select Count(*) from Products";
            var count2 = await connection.ExecuteScalarAsync<int>(query2);
            lblProductCount.Text = count2.ToString();

            // Ortalama Ürün Stok Sayısı
            string query3 = "Select Avg(UnitsInStock) from Products";
            var avgProductStock = await connection.ExecuteScalarAsync<int>(query3);
            lblAvgProductStock.Text = avgProductStock.ToString();

            //Kategorisi Deniz Ürünü Olan Ürünlerin Toplam Fiyatı
            string query4 = "Select Sum(UnitPrice) from Products where CategoryId =(Select CategoryId from Categories where CategoryName = 'SeaFood')";

            var totalseaFoodPrice = await connection.ExecuteScalarAsync<decimal>(query4);
            lblseafood.Text = totalseaFoodPrice.ToString();



        }
    }
}
