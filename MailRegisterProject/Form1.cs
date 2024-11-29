using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Windows.Forms;

namespace MailRegisterProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbMailRegisterEntities context = new DbMailRegisterEntities();  
        private void btnregister_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int confirmCode = rnd.Next(100000, 1000000);


            Users users = new Users();
            users.Email = txtemail.Text;
            users.Name = txtName.Text;
            users.Surname = txtSurname.Text;
            users.Password = txtpassword.Text;
            users.IsConfirm = false;

            users.ConfirmCode = confirmCode.ToString();

            context.Users.Add(users);
            context.SaveChanges();

            #region MailKodları
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress from = new MailboxAddress("Admin", "arda.1235850@gmail.com");
            mimeMessage.From.Add(from);

            MailboxAddress to = new MailboxAddress("User",txtemail.Text);
            mimeMessage.To.Add(to);

            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = "Email Adresinizin Onay Kodu:"  +confirmCode;
            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = "Email Onay Kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("arda.1235850@gmail.com", "zlclyruvexnryddi");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            MessageBox.Show("Mail Adresinize Doğrulama Kodu Gönderilmiştir");

            FrmMailConfirm frmMailConfirm = new FrmMailConfirm();
            frmMailConfirm.email = txtemail.Text;
            frmMailConfirm.Show();

            #endregion

        }
    }
}
