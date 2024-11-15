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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        MovieContext db = new MovieContext();

        private void Form2_Load(object sender, EventArgs e)
        {
            var values = db.Categories.ToList();
            cmbcategory.DisplayMember = "Name";
            cmbcategory.ValueMember = "CategoryId";
            cmbcategory.DataSource = values;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Movies.ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            movie.Title = txtMovieName.Text;
            movie.Duration = Convert.ToInt32(txtMovieDuration.Text);
            movie.Description = txtMovieDescription.Text;
            movie.CategoryId =Convert.ToInt32(cmbcategory.SelectedValue);
            movie.CreatedDate =Convert.ToDateTime(mskdate.Text);
            db.Movies.Add(movie);
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtMovieId.Text);
            var value = db.Movies.Find(id);

            db.Movies.Remove(value);
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Movie movie = new Movie();
            int id = Convert.ToInt32(txtMovieId.Text);
            var value = db.Movies.Find(id);
            value.Title = txtMovieName.Text;
            value.Duration = Convert.ToInt32(txtMovieDuration.Text);
            value.Description = txtMovieDescription.Text;
            value.CategoryId = Convert.ToInt32(cmbcategory.SelectedValue);
            value.CreatedDate = Convert.ToDateTime(mskdate.Text);
            db.SaveChanges();
            MessageBox.Show("İşlem Başarılı");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var values = db.Movies.Where(x => x.Title == txtMovieName.Text).ToList();
            dataGridView1.DataSource = values;
        }

        private void btnlist2_Click(object sender, EventArgs e)
        {
            var values = db.Movies.Join(db.Categories,
                                       movie => movie.CategoryId,
                                       category => category.CategoryId,
                                       (movie, category) => new
                                       {
                                           MovieId = movie.MovieId,
                                           Title = movie.Title,
                                           Description = movie.Description,
                                           Duration = movie.Duration,
                                           Name = category.Name
                                       }).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
