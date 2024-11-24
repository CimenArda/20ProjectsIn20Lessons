using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriggerOrderStockProject.Data;

namespace TriggerOrderStockProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            TriggerOrderStockEntities context = new TriggerOrderStockEntities();

            Console.WriteLine("### Sipariş Stok Sistemi ###");
            Console.WriteLine();
            Console.WriteLine("1-Ürün Listesi");
            Console.WriteLine("2-Sipariş Listesi");
            Console.WriteLine("3-Kasa Durumu");
            Console.WriteLine("4-Yeni Ürün Satışı");
            Console.WriteLine("5-İşlem Sayacı");
            Console.WriteLine("6-Ürün Stok Güncelleme");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine();
            Console.Write("Lütfen Yapmak İstediğiniz İşlemi Seçiniz.");
            Console.WriteLine();

            string number;
            number = Console.ReadLine();

            if (number=="1")
            {
                Console.WriteLine();
                Console.WriteLine("Ürün Listesi");


                var values = context.Products.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine(item.ProductID +" - " + item.ProductName + " - " + item.ProductPrice + " TL - Stok Sayısı: " + item.ProductStock);

                }

            }
            if (number=="2")
            {
                Console.WriteLine();
                Console.WriteLine("Sipariş Listesi");


                var values = context.Orders.ToList();
                foreach (var item in values)
                {
                    Console.WriteLine(item.OrderID + " - " + item.Products.ProductName + " - Birim Fiyat: " + item.UnitPrice + " TL - Adet Sayısı: " + item.Quantity + " - Toplam Fiyat: " + item.TotalPrice +"TL");

                }
            }
            if (number=="3")
            {
                Console.WriteLine();
                Console.WriteLine("Kasa Durumu");
                var values = context.CashRegister.Select(x => x.Balance).FirstOrDefault();
                Console.Write("Kasadaki toplam tutar:" + values + "TL");

            }
            if (number== "4")
            {
                Console.WriteLine();
                Console.WriteLine("Yeni Ürün Satışı");

                Console.Write("Müşteri Adı:");
                string customer = Console.ReadLine();

                Console.Write("Ürün ID:");
                int productID =int.Parse(Console.ReadLine());

                Console.Write("Ürün Adeti:");
                int quantity = int.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("---- Ürün Bilgileri ----");

                var productName = context.Products.Where(x=>x.ProductID == productID).Select(x => x.ProductName).FirstOrDefault();

                Console.WriteLine("Ürün Adı:" + productName);

                var productUnitPrice = context.Products.Where(x=>x.ProductID == productID).Select(X=>X.ProductPrice).FirstOrDefault();  


                Console.WriteLine("Birim Fiyatı:" +productUnitPrice + "TL");

                decimal totalPrice = quantity * decimal.Parse(productUnitPrice.ToString());
                Console.WriteLine("Toplam Fiyat:" + totalPrice + "TL");


                Orders order = new Orders();
                order.UnitPrice = productUnitPrice;
                order.Quantity = quantity;
                order.TotalPrice = totalPrice;
                order.Customer = customer;
                order.ProductID = productID;
                context.Orders.Add(order);
                context.SaveChanges();


            }
            if (number == "5")
            {
                var value = context.Processes.Select(x => x.Process).FirstOrDefault();
                Console.WriteLine("İşlem Sayısı:"+value);


            }


            Console.Read();
        }
    }
}
