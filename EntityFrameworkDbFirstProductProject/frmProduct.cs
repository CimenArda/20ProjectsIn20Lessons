using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDbFirstProductProject
{
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        Db2Project20Entities db =new Db2Project20Entities();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        void ProductList()
        {
            dataGridView1.DataSource=db.TblProduct.ToList();
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ProductList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblProduct tblProduct = new TblProduct();
            tblProduct.ProductName = txtProductName.Text;
            tblProduct.ProductPrice =decimal.Parse(txtProductPrice.Text);
            tblProduct.ProductStock =int.Parse(txtProductStock.Text);
            tblProduct.CategoryId =int.Parse(cmbProductCategory.SelectedValue.ToString());
            db.TblProduct.Add(tblProduct);
            db.SaveChanges();
            ProductList();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));
            db.TblProduct.Remove(value);
            db.SaveChanges();
            ProductList();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var value = db.TblProduct.Find(int.Parse(txtProductId.Text));
            value.ProductName = txtProductName.Text;
            value.ProductPrice = decimal.Parse(txtProductPrice.Text);
            value.ProductStock = int.Parse(txtProductStock.Text);
            value.CategoryId = int.Parse(cmbProductCategory.SelectedValue.ToString());
            db.SaveChanges();
            ProductList();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            var values = db.TblCategory.ToList();
            cmbProductCategory.DisplayMember = "CategoryName";
            cmbProductCategory.ValueMember = "CategoryId";
            cmbProductCategory.DataSource= values;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values =db.TblProduct.Where(x=>x.ProductName==txtProductName.Text).ToList();
            dataGridView1.DataSource= values;
        }

        private void btnWithCategoryList_Click(object sender, EventArgs e)
        {
            var values = db.TblProduct.Join(db.TblCategory,
                                            product=>product.CategoryId,
                                            category=>category.CategoryId,
                                            (product,category)=>new
                                            {
                                                ProductId = product.ProductId,
                                                ProductName =product.ProductName,
                                                ProductPrice = product.ProductPrice,
                                                ProductStock = product.ProductStock,
                                                CategoryId = category.CategoryId,
                                                CategoryName = category.CategoryName
                                            }).ToList();
            dataGridView1.DataSource= values;

        }






    }
}
