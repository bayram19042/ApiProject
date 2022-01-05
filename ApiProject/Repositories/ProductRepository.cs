using ApiProject.Contexts;
using ApiProject.Data;
using ApiProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProject.Repositories
{
  
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext _context;
        public ProductRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Create(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var removedData = await _context.Products.FindAsync(id);
             _context.Products.Remove(removedData);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var updateVeri = await _context.Products.FindAsync(product.Id);
            _context.Entry(updateVeri).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }
    }
}
