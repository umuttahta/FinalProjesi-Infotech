using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Entity.Abstract;

namespace ChocolateApp.Entity.Concrete
{
    public class Chocolate :  IBaseEntity, ICommonEntity
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string Description { get; set; }
        public double Weight { get; set; }
        public double CocoaPercentage { get; set; }
        public decimal Price { get; set; }
        public  string Brand { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int StockQuantity { get; set; }
        public  string Ingredients { get; set; }
        public  string NutritionalInformation { get; set; }
        public  string ImageUrl { get; set; }
        public  string Category { get; set; }
        public DateTime CreatedDate { get ; set ; } = DateTime.Now;
        public DateTime ModifiedDate { get ; set ; } = DateTime.Now;
        public bool IsActive { get ; set ; }
        public  List<ChocolateCategory> ChocolateCategories {get; set;}
       
    }
}
