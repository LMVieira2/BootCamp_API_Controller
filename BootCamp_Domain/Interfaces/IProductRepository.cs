using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Models;

namespace BootCamp_Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> Add(Product entity);
        Task<Product> Update(Guid id, Product entity);
        Task<bool> Delete(Guid id);

    }
}
