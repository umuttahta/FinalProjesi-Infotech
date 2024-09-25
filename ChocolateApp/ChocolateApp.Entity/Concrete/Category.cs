using System;
using System.Collections.Generic;
using ChocolateApp.Entity.Abstract;

namespace ChocolateApp.Entity.Concrete
{
    public class Category : IBaseEntity, ICommonEntity
    {
        // Unique identifier for the category
        public int Id { get; set; }
        
        // Date when the category was created
        public DateTime CreatedDate { get; set; }
        
        // Date when the category was last modified
        public DateTime ModifiedDate { get; set; }
        
        // Indicates if the category is active or not
        public bool IsActive { get; set; }
        
        // Name of the category
        public required string Name { get; set; }
        
        // Description of the category
        public required string Description { get; set; }
        
        // List of chocolates that belong to this category
       
    }
}
