using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PostgreSqlTodoListProject
{
    public partial class frmTodoListApp : Form
    {
        public frmTodoListApp()
        {
            InitializeComponent();
        }
        string connectionstring = "Server=localhost;port=5432;Database=DbTodoApp;UserId=postgres;Password=112233Arda.08";
        private void frmTodoListApp_Load(object sender, EventArgs e)
        {
          var connection = new NpgsqlConnection(connectionstring);
            connection.Open();
            connection.Close();

        }
    }
}
