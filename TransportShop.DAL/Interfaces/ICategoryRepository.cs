using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.DAL.Interfaces
{
    internal interface ICategoryRepository : IRepository<Category>
    {
        public Task<Category?> GetCategoryByNameAsync(string name);
    }
}
