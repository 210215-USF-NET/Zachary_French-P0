namespace OSModels
{
    /// <summary>
    /// This class contains necessary properties and fields for customer info. 
    /// </summary>
    public class Customer
    {
        private string name;
        public string Name {
            get{
                return name;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                name = value;
            }
        }
    }
}