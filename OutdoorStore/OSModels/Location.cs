namespace OSModels
{
    public class Location
    {
        private string name;
        private string address;

        public string Name {
            get{
                return name;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                name = value;
            }
        }
        public string Address {
            get{
                return address;
            } 
            set {
                if(value.Equals(null)) {} //TODO: throw exception
                address = value;
            }
        }

        public override string ToString()
        {
            return $"Location: {name} address: {address}";
        }
    }
}