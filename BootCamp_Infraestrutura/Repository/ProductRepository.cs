using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BootCamp_Domain.Interfaces;
using BootCamp_Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace BootCamp_Infraestrutura.Repository
{
    public class ProductRepository : IProductRepository

    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> Add(Product productItem)
        {
            _context.Products.Add(productItem);
            await _context.SaveChangesAsync();

            return productItem;
        }

        public async Task<bool> Delete(Guid id)
        {
            var productItem = await _context.Products.FindAsync(id);
            if (productItem == null)
            {
                return false;
            }

            _context.Products.Remove(productItem);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            var productItem = await _context.Products.FindAsync(id);

            return productItem;
        }

        public async Task<Product> Update(Guid id, Product productItem)
        {
            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            existingProduct.Name = productItem.Name;
            existingProduct.Price = productItem.Price;
            existingProduct.Description = productItem.Description;

            _context.Products.Update(existingProduct);
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}
