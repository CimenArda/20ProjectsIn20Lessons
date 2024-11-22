using MongoDbOrderProjecet.Entities;
using MongoDbOrderProjecet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MongoDbOrderProjecet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        OrderOperation orderOperation = new OrderOperation();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var order = new Order
            {
                City = txtCity.Text,
                CustomerName = txtCustomerName.Text,
                District = txtdistrict.Text,
                TotalPrice = decimal.Parse(txtTotalPrice.Text),
            };

            orderOperation.AddOrder(order);
            MessageBox.Show("Ekleme İşlemi Yapıldı");

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            List<Order> orders =orderOperation.GetAllOrders();
            dataGridView1.DataSource = orders;

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string orderID = txtOrderID.Text;
            orderOperation.DeleteOrder(orderID);
            MessageBox.Show("Silme İşlemi Tamamlandı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = txtOrderID.Text;
            var updateOrder = new Order
            {
                City = txtCity.Text,
                CustomerName = txtCustomerName.Text,
                District = txtdistrict.Text,
                OrderID = id,
                TotalPrice = decimal.Parse(txtTotalPrice.Text)
            };
            orderOperation.UpdateOrder(updateOrder);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            string id = txtOrderID.Text;
            Order orders = orderOperation.GetOrderById(id);
            dataGridView1.DataSource=new List<Order> { orders};
        }
    }
}
