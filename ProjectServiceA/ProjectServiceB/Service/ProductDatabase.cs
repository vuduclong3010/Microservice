
using Microsoft.EntityFrameworkCore;
using ProjectServiceB.Entity;
using ProjectServiceB.Models;

namespace ProjectServiceB.Service
{
    public class ProductDatabase : IHandleData
    {
        private readonly DatabaseContext _dbContext;

        public ProductDatabase(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> HandleDatabaseTable(List<Product> request)
        {
            if (request.Count == 0)
            {
                return true;
            }

            foreach (var item in request)
            {
                var product = await _dbContext.Products.Where(x => x.Id.Equals(item)).FirstOrDefaultAsync();
                if (product == null)
                {
                    var newProduct = new Product
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Description = item.Description,
                        IsDelete = item.IsDelete,
                        Node = item.Node,
                        Price = item.Price,
                        Qty = item.Qty
                    };
                    
                    await _dbContext.AddAsync(newProduct);
                }

                product.Price = item.Price;
                

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
