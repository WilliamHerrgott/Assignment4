using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Assignment4
{
    public class DataService
    {
        public List<Category> GetCategories()
        {
            using (var context = new Context())
            {
                var cats = context.Categories.ToList();
                return cats;
            }
        }

        public Category GetCategory(int id)
        {
            using (var context = new Context())
            {
                var cat = context.Categories
                    .FirstOrDefault(b => b.Id == id);
                return cat;
            }
        }

        public Category CreateCategory(string name, string description)
        {
            using (var context = new Context())
            {
                var cat = context.Categories.Add(new Category
                {
                    Id = context.Categories.Max(x => x.Id) + 1,
                    Name = name,
                    Description = description
                });

                context.SaveChanges();
                return cat.Entity;
            }
        }

        public bool DeleteCategory(int id)
        {
            using (var context = new Context())
            {
                var cat = context.Categories
                    .FirstOrDefault(x => x.Id == id);
                if (cat == null)
                    return false;
                context.Categories.Remove(cat);
                context.SaveChanges();
                return true;
            }
        }

        public bool UpdateCategory(int id, string newName, string newDescription)
        {
            var cat = GetCategory(id);
            if (cat == null)
                return false;
            using (var context = new Context())
            {
                cat.Name = newName;
                cat.Description = newDescription;
                context.Categories.Update(cat);
                context.SaveChanges();
                return true;
            }
        }

        public Product GetProduct(int id)
        {
            using (var context = new Context())
            {
                var prod = context.Products
                    .Include(x => x.Category)
                    .FirstOrDefault(b => b.Id == id);
                return prod;
            }
        }

        public ICollection<Product> GetProductByName(string name)
        {
            using (var context = new Context())
            {
                var prods = context.Products
                    .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                    .ToList();
                return prods.Count == 0 ? null : prods;
            }
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            using (var context = new Context())
            {
                var prods = context.Products
                    .Where(p => p.CategoryId == categoryId)
                    .Include(p => p.Category)
                    .ToList();
                return prods.Count == 0 ? null : prods;
            }
        }

        public Order GetOrder(int id)
        {
            using (var context = new Context())
            {
                var ord = context.Orders
                    .Include(x => x.OrderDetails)
                        .ThenInclude(c => c.Product)
                            .ThenInclude(i => i.Category)
                    .FirstOrDefault(b => b.Id == id);
                return ord;
            }
        }

        public ICollection<Order> GetOrders()
        {
            using (var context = new Context())
            {
                var orders = context.Orders
                    .ToList();
                return orders.Count == 0 ? null : orders;
            }
        }

        public ICollection<OrderDetails> GetOrderDetailsByOrderId(int id)
        {
            using (var context = new Context())
            {
                var orders = context.OrderDetails
                    .Where(o => o.OrderId == id)
                    .Include(o => o.Product)
                    .ToList();
                return orders.Count == 0 ? null : orders;
            }
        }

        public ICollection<OrderDetails> GetOrderDetailsByProductId(int id)
        {
            using (var context = new Context())
            {
                var orders = context.OrderDetails
                    .Where(o => o.ProductId == id)
                    .Include(o => o.Order)
                    .OrderBy(p => p.Order.Date)
                    .ToList();
                return orders.Count == 0 ? null : orders;
            }
        }
    }
}
