using JWTProject.JWT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JWTProject
{
    public partial class FrmTokenGenerator : Form
    {
        public FrmTokenGenerator()
        {
            InitializeComponent();
        }

        private void btnTokenGenerator_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string email = txtMail.Text;
            string name = txtName.Text;
            string surname = txtSurname.Text;
            TokenGenerator tokenGenerator = new TokenGenerator();
            string token = tokenGenerator.GenerateJwtToken(userName,email,name,surname);
            richTextBox1.Text = token;
        }
    }
}
