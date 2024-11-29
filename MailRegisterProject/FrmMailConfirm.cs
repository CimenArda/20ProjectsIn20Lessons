using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailRegisterProject
{
    public partial class FrmMailConfirm : Form
    {
        public FrmMailConfirm()
        {
            InitializeComponent();
        }
        DbMailRegisterEntities context = new DbMailRegisterEntities();

        public string email;
        private void btnCompleted_Click(object sender, EventArgs e)
        {
            var value = context.Users.Where(x => x.Email == txtmail.Text).Select(y => y.ConfirmCode).FirstOrDefault();
            if (txtcode.Text == value.ToString())
            {
                MessageBox.Show("Hesabınız Aktif Edildi");
                var value2 = context.Users.Where(x => x.Email == txtmail.Text).FirstOrDefault();
                value2.IsConfirm = true;
                context.SaveChanges();
            }
            else
            {
                MessageBox.Show("HATALI KOD!!");

            }
        }

        private void FrmMailConfirm_Load(object sender, EventArgs e)
        {
            txtmail.Text = email;

        }
    }
}
