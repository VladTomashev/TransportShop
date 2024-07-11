using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;
using TransportShop.DAL.Interfaces;

namespace TransportShop.DAL.Repositories
{
    internal class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public async Task<Category?> GetCategoryByNameAsync(string name)
        {
            return await db.Categories.FirstOrDefaultAsync(category => category.Name.Contains(name));
        }
    }
}
