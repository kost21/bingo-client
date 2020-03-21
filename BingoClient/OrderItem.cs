using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BingoClient
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public string Id { get; set; } = string.Empty;

        public string DateTime { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string OrderName { get; set; } = string.Empty;

        public string OrderPrice { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Manager { get; set; } = string.Empty;

        public string ClientName { get; set; } = string.Empty;

        public string ClientPhone { get; set; } = string.Empty;

        public string ClientEmail { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;
    }
}
