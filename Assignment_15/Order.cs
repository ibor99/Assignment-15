using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    public class Order
    {
        public Order(string orderName, OrderStatus status)
        {
            Name = orderName;
            Status = status;
        }

        public string Name { get; set; }
        public OrderStatus Status { get; set; }
        public enum OrderStatus
        {
            New,
            Processing,
            Shipped,
            Delivered
        }
    }
}
