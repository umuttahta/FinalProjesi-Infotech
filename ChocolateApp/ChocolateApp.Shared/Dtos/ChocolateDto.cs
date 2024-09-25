using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChocolateApp.Shared.Dtos
{
    public class ChocolateDto 
    {
        // Unique identifier for the chocolate item
        public int Id { get; set; }
        
        // Name of the chocolate product
        public string Name { get; set; }
        
        // Description of the chocolate product
        public string Description { get; set; }
        
        // Weight of the chocolate (e.g., in grams)
        public double Weight { get; set; }
        
        // Percentage of cocoa in the chocolate
        public double CocoaPercentage { get; set; }
        
        // Price of the chocolate product
        public decimal Price { get; set; }
        
        // Brand or manufacturer of the chocolate
        public string Brand { get; set; }
        
        // Expiration date of the chocolate
        public DateTime ExpirationDate { get; set; }
        
        // Stock quantity available
        public int StockQuantity { get; set; }
        
        // List of ingredients used in the chocolate
        public string Ingredients { get; set; }
        
        // Nutritional information (e.g., calories, fat, sugar)
        public string NutritionalInformation { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get ; set ; }
        public DateTime ModifiedDate { get ; set ; }
        public bool IsActive { get ; set ; }
        public  string ImageUrl { get; set; }

        public List<CategoryDto> Categories { get; set; }
    }
}
