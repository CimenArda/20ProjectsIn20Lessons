using EntityFrameworkCodeFirstMovieProject.DAL.Context;
using EntityFrameworkCodeFirstMovieProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkCodeFirstMovieProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MovieContext db = new MovieContext();
        private void btnList_Click(object sender, EventArgs e)
        {
                   dataGridView1.DataSource= db.Categories.ToList();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name =txtCategoryName.Text;
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            int id = Convert.ToInt32(txtCategoryId.Text);
            var value = db.Categories.Find(id);
            value.Name = txtCategoryName.Text;
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            var value = db.Categories.Find(id);

            db.Categories.Remove(value);
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values =db.Categories.Where(x=>x.Name==txtCategoryName.Text).ToList();
            dataGridView1.DataSource= values;
        }
    }
}
