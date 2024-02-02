using Microsoft.EntityFrameworkCore;
using ProjectServiceA.Dto;
using ProjectServiceA.Entity;
using ProjectServiceA.Models;
using System.Linq;

namespace ProjectServiceA.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly DatabaseContext _context;

        public CustomerService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, object>> GetDatabase()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add("Order", await GetOrdes());
            dictionary.Add("Customer", await GetCustomers());
            dictionary.Add("Product", await GetProducts());
            dictionary.Add("OrderDetail", await GetOrderDetails());
            return dictionary;
        }

        public async Task<List<OrderDto>> GetOrdes()
        {
            var orders = await _context.Orders.Select(x => new OrderDto
            {
                Id = x.Id,
                Email = x.Email,
                IsActive = x.IsActive,
                Address = x.Address,
                IsDelete = x.IsDelete,
                NameReciver = x.NameReciver,
                Node = x.Node,
                OrderDate = x.OrderDate,
                Phone = x.Phone,
                TotalMoney = x.TotalMoney
            }).ToListAsync();

            return orders;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<List<OrderDetail>> GetOrderDetails()
        {
            var orderDetails = await _context.OrderDetails.ToListAsync();
            return orderDetails;
        }
    }
}
