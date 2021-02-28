namespace OSModels
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public Location Location { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"{Quantity} {Product.Name} in stock at {Location.Name}";
            //return $"Inv Report for: {Location.Name}\nProduct: {Product.Name} - {Quantity} in stock";
        }
    }
}