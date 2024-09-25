using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Entity.Concrete
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } 
        public required string UserId { get; set; }
        public required List<OrderItem> OrderItems { get; set; }

    }
}
