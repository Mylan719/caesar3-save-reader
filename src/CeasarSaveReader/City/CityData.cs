using CeasarSaveReader.City.Houses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.City
{
    public class CityData
    {
        public Building building = new Building();
        public Figure figure = new Figure();
        public HouseDemands houses = new HouseDemands();
        public Emperor emperor = new Emperor();
        public Military military = new Military();
        public DistantBattle distant_battle = new DistantBattle();
        public Finance finance = new Finance();
        public Taxes taxes = new Taxes();
        public Population population = new Population();
        public Labor labor = new Labor();
        public Migration migration = new Migration();
        public Sentiment sentiment = new();
        public Health health = new();
        public Ratings ratings = new();
        public Culture culture = new();
        public Religion religion = new();
        public Entertainment entertainment = new();
        public Festival festival = new();
        public Games games = new();
        public Resource resource = new();
        public Sound sound = new();
        public Trade trade = new();
        public Map? Map { get; set; }
        public Mission mission = new();
        public MessHall mess_hall = new();
        public Caravanserai caravanserai = new();
        public Unused unused = new();
    }
}
