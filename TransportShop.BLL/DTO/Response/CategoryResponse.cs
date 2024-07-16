using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO
{
    internal class CategoryResponse
    {
        public List<Product> ProductsInCategory { get; set; }
    }
}
