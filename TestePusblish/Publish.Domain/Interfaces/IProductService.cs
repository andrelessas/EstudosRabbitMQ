using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Publish.Core.DTOs;
using Publish.Core.Entities;

namespace Publish.Domain.Interfaces
{
    public interface IProductService
    {
        Task Insert(ProductDTO productDTO);
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task SendProduct(string queue);
        Task SendProduct(string queue, int id);
    }
}