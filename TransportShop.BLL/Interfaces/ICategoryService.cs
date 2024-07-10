using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.Interfaces
{
    internal interface ICategoryService : IService<Category>
    {
        public List<Product> GetProductsByCategory(int categoryId);
    }
}
