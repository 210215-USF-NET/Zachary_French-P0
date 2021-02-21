namespace OSModels
{
    public class Location
    {
        private string name;
        private string location;
        public string Name {
            get{
                return name;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                name = value;
            }
        }
        public string StoreLocation {
            get{
                return location;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                location = value;
            }
        }

        //TODO: Inventory
    }
}