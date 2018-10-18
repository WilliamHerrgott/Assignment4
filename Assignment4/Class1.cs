using System;
using System.Collections.Generic;
using System.Linq.M;


namespace Assignment4
{
    [Table(Name = "Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public double QuantityPerUnit { get; set; }
        public double UnitsInStock { get; set; }
        public Category Category { get; set; }
    }

    public class OrderDetails
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public double UnitPrice { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
    }
    
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
    }
    
    public class DataService
    {
        public List<Category> GetCategories()
        {
            return null;
        }
        
        public Category GetCategory(int id)
        {
            return null;
        }

        public Category CreateCategory(string name, string description)
        {
            return null;
        }

        public bool DeleteCategory(int id)
        {
            return false;
        }
        
        public bool UpdateCategory(int id, string newName, string newDescription)
        {
            return false;
        }

        public Product GetProduct(int id)
        {
            return null;
        }
        
        public List<Product> GetProductByName(string name)
        {
            return null;
        }
        
        public List<Product> GetProductByCategory(int categoryId)
        {
            return null;
        }

        public Order GetOrder(int id)
        {
            return null;
        }
        
        public List<Order> GetOrders()
        {
            return null;
        }

        public List<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            return null;
        }
        
        public List<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            return null;
        }
    }
}