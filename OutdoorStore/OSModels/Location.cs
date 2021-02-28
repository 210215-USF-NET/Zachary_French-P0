namespace OSModels
{
    public class Location
    {
        private int id;
        private string name;
        private string address;

        public int ID {
            get{
                return id;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();}
                id = value;
            }
        }
        public string Name {
            get{
                return name;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();}
                name = value;
            }
        }
        public string Address {
            get{
                return address;
            } 
            set {
                if(value.Equals(null))
                    {throw new System.Exception();}
                address = value;
            }
        }

        public override string ToString()
        {
            return $"Location: {name}\n\t ID:{id} - Address: {address}";
        }
    }
}