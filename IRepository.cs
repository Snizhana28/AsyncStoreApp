using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncStoreApp
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> GetAllAsync(CancellationToken token);
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T item);
    }
}
