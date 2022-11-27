using CeasarSaveReader.Buildings;
using CeasarSaveReader.Buildings.Bridge;
using CeasarSaveReader.Buildings.Model;
using CeasarSaveReader.City;
using CeasarSaveReader.Figures.Paths;
using CeasarSaveReader.Map;
using CeasarSaveReader.Scenario.Model;
using CeasarSaveReader.Terrain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.File
{
    public class GameSave
    {
        public Grid<TerrainType> Terrain { get; set; }
        public Grid<int> Elevation { get; set; }
        public Grid<int> BuildingGrid { get; set; }
        public Grid<int> FigureGrid { get; set; }
        public Grid<int> BuildingsDamage { get; set; }
        public Grid<PropertyType> EdgeGrid { get; set; }
        public Grid<int> BitField { get; set; }
        public CityData City { get; set; }
        public List<Buildings.Model.Building> Buildings { get; set; }
        public List<Figures.Model.Figure> Figures { get; set; }
        public List<FigurePathData> Paths { get; set; }
        public ScenarioData Scenario { get; set; }
        public Grid<int> Sprite { get; set; }
        public List<BridgeTile> Bridges { get; set; }
    }
}
