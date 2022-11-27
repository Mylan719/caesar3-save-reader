using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.City.Houses
{
    public class HouseDemands
    {
        public Missing missing = new Missing();
        public Requiring requiring = new Requiring();
        public int health;
        public int religion;
        public int education;
        public int entertainment;
    };
}
