using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChocolateApp.Shared.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        [JsonIgnore]
        public OrderDto Order { get; set; }
        public int ChocolateId { get; set; }
        [JsonIgnore]
        public ChocolateDto Chocolate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}