using ChocolateAppClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChocolateAppClient.Models
{
    public class ChocolateViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Weight")]
        public double Weight { get; set; }
        [JsonPropertyName("CocoaPercentage")]
        public double CocoaPercentage { get; set; }
        [JsonPropertyName("Price")]
        public decimal Price { get; set; }
        [JsonPropertyName("Brand")]
        public string Brand { get; set; }
        [JsonPropertyName("ExpirationDate")]
        public DateTime ExpirationDate { get; set; }
        [JsonPropertyName("StockQuantity")]
        public int StockQuantity { get; set; }
        [JsonPropertyName("Ingredients")]
        public string Ingredients { get; set; }
        [JsonPropertyName("NutritionalInformation")]
        public string NutritionalInformation { get; set; }
        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }
        [JsonPropertyName("Category")]
        public string Category { get; set; }
        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("Categories")]
        public List<CategoryViewModel> Categories { get;  set; }
    }
}