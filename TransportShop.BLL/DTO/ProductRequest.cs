using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportShop.BLL.DTO
{
    internal class ProductRequest
    {
        public int? CategoryId { get; set; }
        public string ProductName { get; set; }

    }
}
