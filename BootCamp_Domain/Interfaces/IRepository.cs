using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp_Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);
    }
}
