using System;
using System.Collections.Generic;

namespace ChocolateApp.Shared.Dtos
{
    public class CategoryDto
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
        public string Name { get; set; }
        
        // Description of the category
        public string Description { get; set; }
        }
}
        
        
