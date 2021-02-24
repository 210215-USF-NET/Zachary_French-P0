using Json.NET;
using OSModels;

namespace OSDL
{
    public class LocationFileRepo
    {
        Location l = new Location();
        
        public void AddLocation(Location _loc)
        {
            Location l = new Location();

            l.Name = "New York";
            l.Address = "1 Infinite Loop Cupertino, CA";

            string output = JsonConvert.SerializeObject(l);

            Location deserializedLocation = JsonConvert.DeserializeObject<Location>(output);

        }
        //  private string jsonString;
        // private string filePath = "./ToHDL/HeroFiles.json";
        // public Hero AddHero(Hero newHero)
        // {
        //     List<Hero> herosFromFile = GetHeroes();
        //     herosFromFile.Add(newHero);
        //     jsonString = JsonSerializer.Serialize(herosFromFile);
        //     File.WriteAllText(filePath, jsonString);
        //     return newHero;
        // }

        // public List<Hero> GetHeroes()
        // {
        //     try
        //     {
        //         jsonString = File.ReadAllText(filePath);
        //     }
        //     catch (Exception)
        //     {
        //         return new List<Hero>();
        //     }
        //     return JsonSerializer.Deserialize<List<Hero>>(jsonString);
        // }
    }
}