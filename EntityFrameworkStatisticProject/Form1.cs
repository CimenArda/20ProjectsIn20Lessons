using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkStatisticProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DbStatisticProjectEntities db = new DbStatisticProjectEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı
            int CategoryCount = db.TblCategory.Count();
            lblCategoryCount.Text = CategoryCount.ToString();

            //Toplam Ürün Sayısı
            int ProductCount = db.TblProduct.Count();
            lblProductCount.Text = ProductCount.ToString();

            //Toplam Müşteri Sayısı
            int CustomerCount = db.TblCustomer.Count();
            lblCustomerCount.Text = CustomerCount.ToString();

            //Toplam Sipariş  Sayısı
            int OrderCount = db.TblOrder.Count();
            lblOrderCount.Text = OrderCount.ToString();

            //toplam stok sayısı
            var totalproductstockcount = db.TblProduct.Sum(x=>x.ProductStock);
            lblproducttotalstock.Text = totalproductstockcount.ToString();

            //Ortalama Ürün Fiyatı
            var avgProductPrice =db.TblProduct.Average(x=>x.ProductPrice);
            lblproductavgprice.Text =avgProductPrice.ToString() + "TL";

            // Toplam Meyve Stoğu Sayısı
            var totalProductCountByFruit = db.TblProduct.Where(x => x.CategoryId == 1).Sum(y=>y.ProductStock);
            lblProductCountByCategoryIsFruit.Text =totalProductCountByFruit.ToString();

            //Tablet İsimli Ürünün Toplam İşlem Hacmi
            var getStock = db.TblProduct.Where(x => x.ProductName == "Tablet").Select(y => y.ProductStock).FirstOrDefault();
            var unitPrice = db.TblProduct.Where(x => x.ProductName == "Tablet").Select(y => y.ProductPrice).FirstOrDefault();
            var TotalPriceByProductNameTablet = getStock * unitPrice;
            lblTotalPriceByProductNameTablet.Text = TotalPriceByProductNameTablet.ToString() + "TL";


            //Stok Sayısı 50'den Küçük Olan Ürün Sayısı
            var ProductStockIsSmaller50 = db.TblProduct.Where(x => x.ProductStock < 50).Count();
            lblProductStockIsSmaller50.Text = ProductStockIsSmaller50.ToString();

            // Kategorisi Sebze Ve Durumu Aktif Olan Ürün Stok Sayısı **
            //subquery =>categoryId değeri 
            var ProductCountByCategorySebzeAndStatusActive =db.TblProduct.Where(x=>x.CategoryId==(db.TblCategory.Where(z=>z.CategoryName=="Sebze").Select(w=>w.CategoryId).FirstOrDefault()) && x.ProductStatus==true).Sum(q=>q.ProductStock);
            lblProductCountByCategorySebzeAndStatusActive.Text =ProductCountByCategorySebzeAndStatusActive.ToString();

            // Türkiyeden Yapılmış Siparişler SQL QUERY **         
            var x2 = db.Database.SqlQuery<int>("Select Count(*) from TblOrder where CustomerId  In (Select CustomerId from TblCustomer where CustomerCountry='Türkiye')").FirstOrDefault();
            lblOrderCountFromTurkiyeSQL.Text = x2.ToString();

            // Türkiyeden Yapılmış Siparişler EF **         
            var turkishCustomerIds = db.TblCustomer.Where(x => x.CustomerCountry == "Türkiye").Select(y => y.CustomerId).ToList();
            var orderCountFromTurkiyeWithEF = db.TblOrder.Count(z => turkishCustomerIds.Contains(z.CustomerId.Value));
            lblOrderCountFromTurkiyeEF.Text = orderCountFromTurkiyeWithEF.ToString();

            //Siparişler içinde kategorisi meyve olan ürünlerin toplam satış fiyatı SQL QUERY **
            var OrderTotalPriceByCategoryIsMeyve = db.Database.SqlQuery<decimal>("Select Sum(o.TotalPrice) as ToplamSatisFiyati from TblOrder o Join TblProduct p on o.ProductId=p.ProductId join TblCategory c on p.CategoryId =c.CategoryId where c.CategoryName='Meyve'").FirstOrDefault();
            lblOrderTotalPriceByCategoryIsMeyve.Text = OrderTotalPriceByCategoryIsMeyve.ToString() + "TL";


            //Siparişler içinde kategorisi meyve olan ürünlerin toplam satış fiyatı EF **
            var OrderTotalPriceByCategoryIsMeyveEF =(from o in db.TblOrder
                                                        join p in db.TblProduct on o.ProductId equals p.ProductId
                                                        join c in db.TblCategory on p.CategoryId equals c.CategoryId
                                                        where c.CategoryName == "Meyve"
                                                        select o.TotalPrice).Sum();
            lblOrderTotalPriceByCategoryIsMeyveEF.Text = OrderTotalPriceByCategoryIsMeyveEF.ToString() + "TL";


            //Son Eklenen Ürün Adı
            var lastProductName =db.TblProduct.OrderByDescending(x=>x.ProductId).Select(y=>y.ProductName).FirstOrDefault();
                lblLastaddedProductName.Text = lastProductName.ToString();

            //Son EKlenen Ürünün Kategorisi
            var LastAddedProductCategoryId = db.TblProduct.OrderByDescending(x => x.ProductId).Select(y => y.CategoryId).FirstOrDefault();
            var lastProductCategoryName =db.TblCategory.Where(x=>x.CategoryId==LastAddedProductCategoryId).Select(y=>y.CategoryName).FirstOrDefault();
            lblLastAddedProductCategoryName.Text = lastProductCategoryName.ToString();


            //Aktif Ürün Sayısı
            var activeProductCount = db.TblProduct.Where(x => x.ProductStatus == true).Count();
            lblActiveProductCount.Text= activeProductCount.ToString();



            //Çamaşır Makinesi Ürününe Ait Toplam Kazanç Beklentisi
            var machinestock = db.TblProduct.Where(x => x.ProductName == "Çamaşır Makinesi").Select(y=>y.ProductStock).FirstOrDefault();
            var machinePrice =db.TblProduct.Where(x=>x.ProductName=="Çamaşır Makinesi").Select(y=>y.ProductPrice).FirstOrDefault();

            var totalMachineStockPrice = machinestock * machinePrice;

            lblTotalPriceNameIsCamasirMakine.Text = totalMachineStockPrice.ToString() + "TL";



            //Sistemde Son Sipariş Veren Müşterinin Adı

            var LastAddedCustomerId = db.TblOrder.OrderByDescending(x => x.OrderId).Select(y => y.CustomerId).FirstOrDefault();
            var LastAddedCustomerName =db.TblCustomer.Where(x=>x.CustomerId==LastAddedCustomerId).Select(y=>y.CustomerName).FirstOrDefault();
            lblLastAddedCustomerName.Text = LastAddedCustomerName.ToString();


            //Kaç Farklı Ülkeden Müşterimiz Var ?

            var differentCountry = db.TblCustomer.Select(x=>x.CustomerCountry).Distinct().Count();

                lbldifferentCountry.Text= differentCountry.ToString();

        }

        private void label10_Click(object sender, EventArgs e)
        {
            //SqlQuery,LINQ,OrderByDesc,Distinct
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }
    }
}
