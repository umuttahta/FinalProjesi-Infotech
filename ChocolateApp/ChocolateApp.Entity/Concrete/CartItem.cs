namespace ChocolateApp.Entity.Concrete
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int ChocolateId { get; set; } 
        public int Quantity { get; set; } 
        public decimal Price { get; set; } 
        public decimal TotalPrice => Quantity * Price; 
        public  Chocolate Chocolate { get; set; }
        public int ProductId {  get; set; }
        public int CartId { get; set; }
    }
}
