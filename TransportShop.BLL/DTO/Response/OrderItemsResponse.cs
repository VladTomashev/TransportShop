﻿using TransportShop.DAL.Entities;

namespace TransportShop.BLL.DTO.Response
{
    internal class OrderItemsResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<OrderItem>? Items { get; set; }
    }
}
