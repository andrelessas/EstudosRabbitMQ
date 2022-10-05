using System.Collections.Generic;
using System.Threading.Tasks;
using Publish.Core.Entities;

namespace Publish.Core.Interfaces
{
    public interface IProductRepository
    {
        Task InsertAsync(Product product);
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> GetByIdAsync(int id);
    }
}