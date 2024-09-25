using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateApp.Entity.Concrete
{
    public class ChocolateCategory
    {
        public int ChocolateId { get; set; }
        public  Chocolate Chocolate { get; set; }
        public int CategoryId { get; set; }
        public  Category Category { get; set; }
    }
}
