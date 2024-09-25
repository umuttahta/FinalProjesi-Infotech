using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChocolateApp.Shared.Dtos
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public int ChocolateId { get; set; }
        public ChocolateDto Chocolate { get; set; }
        public int CartId { get; set; }
        [JsonIgnore]
        public CartDto Cart { get; set; }
        public int Quantity { get; set; }
        
    }
}