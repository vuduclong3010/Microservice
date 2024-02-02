using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using ProjectServiceB.Entity;
using ProjectServiceB.Models;
using System;
using System.Text.Json;

namespace ProjectServiceB.Service
{
    public class HandleDatabaseService : IHandleDatabaseService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public HandleDatabaseService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> HandleDatabaseTable(string url)
        {
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri(url);

            try
            {
                // Thực hiện Get
                var response = await httpClient.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var obj = JObject.Parse(responseContent);

                foreach (var item in obj)
                {
                    var type = item.Key;
                    var value = JArray.Parse(item.Value.ToString());
                    await HandleDataTable(value, type);
                }

            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing exception
                Console.WriteLine($"JSON Parsing Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }

            return true;
        }

        public async Task HandleDataTable(JArray data, string type)
        {
            switch (type)
            {
                case "Product":
                    await HandleProduct(data);
                    break;
                case "Order":
                    await HandleOrder(data);
                    break;
                case "Customer":
                    await HandleCustomer(data);
                    break;
                case "OrderDetail":
                    await HandleOrderDetails(data);
                    break;
                default:
                    break;
            }
        }

        public async Task HandleProduct(JArray request)
        {
            foreach (JObject item in request)
            {
                var productOld = await _context.Products.FirstOrDefaultAsync(x => x.Id == item.GetValue("id").ToString());
                if (productOld == null)
                {
                    var newProduct = _mapper.Map<JObject, Product>(item);
                    _context.Products.Add(newProduct);
                }
                else
                {
                    productOld.Id = item.GetValue("id").ToString();
                    productOld.Name = item.GetValue("name").ToString();
                    productOld.Description = item.GetValue("description").ToString();
                    productOld.IsDelete = ((bool)item.GetValue("isDelete"));
                    productOld.Node = item.GetValue("node").ToString();
                    productOld.Qty = (int)item.GetValue("qty");
                    productOld.Price = (decimal)item.GetValue("price");
                    _context.Products.Update(productOld);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task HandleOrder(JArray request)
        {
            foreach (JObject item in request)
            {
                var orderOld = await _context.Orders.FirstOrDefaultAsync(x => x.Id == item.GetValue("id").ToString());
                if (orderOld == null)
                {
                    var newOrder = _mapper.Map<JObject, Order>(item);
                    _context.Orders.Add(newOrder);
                }
                else
                {
                    orderOld.Id = item.GetValue("id").ToString();
                    orderOld.OrderDate = ((DateTime)item.GetValue("orderDate"));
                    orderOld.TotalMoney = ((decimal)item.GetValue("totalMoney"));
                    orderOld.Node = item.GetValue("node").ToString();
                    orderOld.NameReciver = item.GetValue("nameReciver").ToString();
                    orderOld.Address = item.GetValue("address").ToString();
                    orderOld.Email = item.GetValue("email").ToString();
                    orderOld.Phone = item.GetValue("phone").ToString();
                    orderOld.IsDelete = ((bool)item.GetValue("isDelete"));
                    orderOld.IsActive = item.GetValue("isActive").ToString();
                    orderOld.CustomerId = item.GetValue("customerId").ToString();
                    _context.Orders.Update(orderOld);
                }
                await _context.SaveChangesAsync();
            }

        }

        public async Task HandleCustomer(JArray request)
        {
            foreach (JObject item in request)
            {
                var customerOld = await _context.Customers.FirstOrDefaultAsync(x => x.Id == item.GetValue("id").ToString());
                if (customerOld == null)
                {
                    var newCustomer = _mapper.Map<JObject, Customer>(item);
                    _context.Customers.Add(newCustomer);
                }
                else
                {
                    customerOld.Id = item.GetValue("id").ToString();
                    customerOld.Name = item.GetValue("name").ToString();
                    customerOld.Address = item.GetValue("address").ToString();
                    customerOld.Email = item.GetValue("email").ToString();
                    customerOld.PhoneNumber = item.GetValue("phoneNumber").ToString();
                    customerOld.Avatar = item.GetValue("avatar").ToString();
                    customerOld.IsDeleted = ((bool)item.GetValue("isDeleted"));
                    _context.Customers.Update(customerOld);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task HandleOrderDetails (JArray request)
        {
            foreach (JObject item in request)
            {
                var orderDeatilOld = await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == item.GetValue("id").ToString());
                if (orderDeatilOld == null)
                {
                    var newOrderDetail = new OrderDetail
                    {
                        Id = item.GetValue("id").ToString(),
                        Total = ((decimal)item.GetValue("total")),
                        ReturnQty = ((int)item.GetValue("total")),
                        Qty = ((int)item.GetValue("total")),
                        IdProduct = item.GetValue("idProduct").ToString(),
                        OrderId = item.GetValue("orderId").ToString(),
                        Price = ((decimal)item.GetValue("price")),
                    };
                    _context.OrderDetails.Add(newOrderDetail);
                }
                else
                {
                    orderDeatilOld.Id = item.GetValue("id").ToString();
                    orderDeatilOld.Price = ((decimal)item.GetValue("price"));
                    orderDeatilOld.Qty = ((int)item.GetValue("total"));
                    orderDeatilOld.Total = ((decimal)item.GetValue("total"));
                    orderDeatilOld.ReturnQty = ((int)item.GetValue("total"));
                    orderDeatilOld.IdProduct = item.GetValue("idProduct").ToString();
                    orderDeatilOld.OrderId = item.GetValue("orderId").ToString();
                    _context.OrderDetails.Update(orderDeatilOld);
                }
                await _context.SaveChangesAsync();
            }
        }
    }
}
