using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface IProductService : IService<Product>
    {
        public Task <List<Product>> GetProductsByCategoryAsync(int categoryId);
        public Task <List<Product>> GetProductsByName(string name);

    }
}
