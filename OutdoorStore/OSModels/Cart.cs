namespace OSModels
{
    public class Cart
    {
        public int ID {get; set;}
        public int CustID {get; set;}
        public int LocID {get; set;}
        public int ProductID {get; set;}
        public int Quantity {get; set;}

        public override string ToString()
        {
            return "lol";
        }
    }
}