﻿using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbOrderProjecet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbOrderProjecet.Services
{
    public class OrderOperation
    {
        public void AddOrder(Order order)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollection();

            var document = new BsonDocument
            {
                {"CustomerName",order.CustomerName },
                {"City",order.City},
                {"District",order.District },
                {"TotalPrice",order.TotalPrice }
            };

            orderCollection.InsertOne(document);


        }

        public List<Order> GetAllOrders()
        {
            var connection = new MongoDbConnection();   
            var orderCollection = connection.GetOrdersCollection();

            var orders = orderCollection.Find(new BsonDocument()).ToList();

            List<Order> orderList = new List<Order>();

            foreach (var order in orders)
            {
                orderList.Add(new Order
                {
                    City = order["City"].ToString(),
                    CustomerName = order["CustomerName"].ToString(),
                    District = order["District"].ToString(),
                    OrderID = order["_id"].ToString(),
                    TotalPrice = order["TotalPrice"].AsDecimal
                }) ;
            }
            return orderList;
        }

        public void DeleteOrder(string orderID)
        {
            var connection = new MongoDbConnection();   
            var orderCollection = connection.GetOrdersCollection();

            var filter = Builders<BsonDocument>.Filter.Eq("_id",ObjectId.Parse(orderID));
            orderCollection.DeleteOne(filter);






        }

        public void UpdateOrder(Order order)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollection();

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(order.OrderID));

            var updatedValue = Builders<BsonDocument>.Update
                .Set("CustomerName", order.CustomerName)
                .Set("District", order.District).
                Set("City", order.City).
                Set("TotalPrice", order.TotalPrice);

            orderCollection.UpdateOne(filter, updatedValue);




        }

        public Order GetOrderById(string orderID)
        {
            var connection = new MongoDbConnection();
            var orderCollection = connection.GetOrdersCollection();

            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(orderID));
            var result = orderCollection.Find(filter).FirstOrDefault();

            if (result!=null)
            {
                return new Order
                {
                    City = result["City"].ToString(),
                    CustomerName = result["CustomerName"].ToString(),
                    District = result["District"].ToString(),
                    TotalPrice = result["TotalPrice"].AsDecimal
                };

            }
            else
            {
                return null;
            }
        }


    }
}
