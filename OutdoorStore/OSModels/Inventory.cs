namespace OSModels
{
    public class Inventory
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int LocationID { get; set; }
        public int ProductID { get; set; }

        // public override string ToString()
        // {
        //     return $"{Quantity} {Product.Name} in stock at {Location.Name}";
        //     //return $"Inv Report for: {Location.Name}\nProduct: {Product.Name} - {Quantity} in stock";
        // }
    }
}