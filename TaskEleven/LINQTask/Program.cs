using LINQTask.Data;
using LINQTask.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LINQTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            #region 01 - List all customers' first and last names along with their email addresses.
            //var customers = _context.Customers.AsQueryable();

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine($"First Name: {customer.FirstName}, Last Name: {customer.LastName}, Email: {customer.Email}");
            //} 
            #endregion

            #region 02 - Retrieve all orders processed by a specific staff member(e.g., staff_id = 3).
            //var orders = _context.Orders.AsQueryable();
            //orders = orders.Where(o => o.StaffId == 3);

            //foreach (var order in orders)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, Customer ID: {order.CustomerId}, Order Date: {order.OrderDate}, Staff ID: {order.StaffId}");
            //} 
            #endregion

            #region 03 - Get all products that belong to a category named "Mountain Bikes".
            //var productsWithCategory = _context.Products
            //    .Where(p => p.Category.CategoryName == "Mountain Bikes")
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,
            //        p.Category.CategoryName
            //    });

            //foreach (var item in productsWithCategory)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductId}, Name: {item.ProductName}, Category Name: {item.CategoryName}");
            //}
            #endregion

            #region 04 - Count the total number of orders per store.
            //var orderPerStore = _context.Orders
            //    .GroupBy(o => o.Store.StoreName)
            //    .Select(g => new
            //    {
            //        StoreName = g.Key,
            //        OrderCount = g.Count()
            //    });

            //foreach (var item in orderPerStore)
            //{
            //    Console.WriteLine($"Store Name: {item.StoreName}, Order Count: {item.OrderCount}");
            //}
            #endregion

            #region 05 - List all orders that have not been shipped yet(shipped_date is null).
            //var ordersNotShipped =_context.Orders
            //    .Where(o => o.ShippedDate == null);

            //foreach (var order in ordersNotShipped)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}");
            //}
            #endregion

            #region 06 - Display each customer’s full name and the number of orders they have placed.
            //var customerOrdersCount = _context.Customers
            //        .Select(c => new
            //        {
            //            FullName = $"{c.FirstName} {c.LastName}",
            //            OrderCount = c.Orders.Count()
            //        });

            //foreach (var item in customerOrdersCount)
            //{
            //    Console.WriteLine($"Customer: {item.FullName}, Order Count: {item.OrderCount}");
            //}
            #endregion

            #region 07 - List all products that have never been ordered(not found in order_items).
            //var productsNeverOrdered = _context.Products
            //    .Where(p => !_context.OrderItems.Select(o => o.ProductId).Contains(p.ProductId));

            //foreach (var product in productsNeverOrdered)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}");
            //}
            #endregion

            #region 08 - Display products that have a quantity of less than 5 in any store stock.
            //var productsLessFive = _context.Stocks
            //    .Where(s => s.Quantity < 5)
            //    .Select(s => new
            //    {
            //        s.ProductId,
            //        s.Product.ProductName,
            //        s.Quantity
            //    })
            //    .OrderBy(s => s.Quantity);

            //foreach (var product in productsLessFive)
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Product Name: {product.ProductName}, Quantity: {product.Quantity}");
            //}
            #endregion

            #region 09 - Retrieve the first product from the products table.
            //var firstProduct = _context.Products.FirstOrDefault();

            //if (firstProduct != null)
            //{
            //    Console.WriteLine($"First Product ID: {firstProduct.ProductId}, Name: {firstProduct.ProductName}");
            //}
            //else
            //{
            //    Console.WriteLine("No products found.");
            //}
            #endregion

            #region 10 - Retrieve all products from the products table with a certain model year.
            //var modelYearProducts = _context.Products
            //    .Where(p => p.ModelYear == 2018);

            //foreach (var product in modelYearProducts) 
            //{
            //    Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.ProductName}, Model Year: {product.ModelYear}");
            //}
            #endregion

            #region 11 - Display each product with the number of times it was ordered.
            //var productOrderCount = _context.Products
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,
            //        OrderCount = p.OrderItems.Count()
            //    });

            //foreach (var item in productOrderCount)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductId}, Name: {item.ProductName}, Order Count: {item.OrderCount}");
            //}
            #endregion

            #region 12 - Count the number of products in a specific category.
            //var categoryProductCount = _context.Products
            //    .Where(p => p.Category.CategoryName == "Road Bikes")
            //    .Count();

            //Console.WriteLine($"Number of products in 'Road Bikes' category: {categoryProductCount}");
            #endregion

            #region 13 - Calculate the average list price of products.
            //var averageListPrice = _context.Products
            //    .Average(p => p.ListPrice);

            //Console.WriteLine(averageListPrice);
            #endregion

            #region 14 - Retrieve a specific product from the products table by ID.
            //var productById = _context.Products
            //    .FirstOrDefault(p => p.ProductId == 10);

            //if (productById != null)
            //{
            //    Console.WriteLine($"Product ID: {productById.ProductId}, Name: {productById.ProductName}");
            //}
            //else
            //{
            //    Console.WriteLine("Product not found.");
            //}
            #endregion

            #region 15 - List all products that were ordered with a quantity greater than 3 in any order.
            //var productsOrderedGreaterThanThree = _context.OrderItems
            //    .Where(o => o.Quantity > 3)
            //    .Select(o => new
            //    {
            //        o.ProductId,
            //        o.Product.ProductName,
            //        o.Quantity
            //    });

            //foreach (var item in productsOrderedGreaterThanThree)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductId}, Name: {item.ProductName}, Quantity: {item.Quantity}");
            //}
            #endregion

            #region 16 - Display each staff member’s name and how many orders they processed.
            //var staffOrderCount = _context.Staffs
            //    .Select(s => new
            //    {
            //        s.FirstName,
            //        s.LastName,
            //        OrderCount = s.Orders.Count()
            //    });

            //foreach (var item in staffOrderCount)
            //{
            //    Console.WriteLine($"Staff Name: {item.FirstName} {item.LastName}, Order Count: {item.OrderCount}");
            //}
            #endregion

            #region 17 - List active staff members only(active = true) along with their phone numbers.
            //var activeStaff = _context.Staffs
            //    .Where(s => s.Active == 1)
            //    .Select(s => new
            //    {
            //        s.FirstName,
            //        s.LastName,
            //        s.Phone,
            //        s.Active
            //    });

            //foreach (var staff in activeStaff) 
            //{
            //    Console.WriteLine($"Staff Name: {staff.FirstName} {staff.LastName}, Phone: {staff.Phone}");
            //}
            #endregion

            #region 18 - List all products with their brand name and category name.
            //var productsWithBrandAndCategory = _context.Products
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,
            //        p.Brand.BrandName,
            //        p.Category.CategoryName
            //    });

            //foreach (var item in productsWithBrandAndCategory)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductId}, Name: {item.ProductName}, Brand: {item.BrandName}, Category: {item.CategoryName}");
            //}
            #endregion

            #region 19 - Retrieve orders that are completed.
            //var completedOrders = _context.Orders
            //    .Where(o => o.ShippedDate != null);
            
            //foreach (var order in completedOrders)
            //{
            //    Console.WriteLine($"Order ID: {order.OrderId}, Shipped Date: {order.ShippedDate}");
            //}
            #endregion

            #region 20 - List each product with the total quantity sold(sum of quantity from order_items).
            //var productTotalQuantitySold = _context.Products
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,
            //        TotalQuantitySold = p.OrderItems.Sum(o => o.Quantity)
            //    });

            //foreach (var item in productTotalQuantitySold)
            //{
            //    Console.WriteLine($"Product ID: {item.ProductId}, Name: {item.ProductName}, Total Quantity Sold: {item.TotalQuantitySold}");
            //}
            #endregion

        }
    }
}
