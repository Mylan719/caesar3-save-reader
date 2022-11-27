namespace CeasarSaveReader.Figures.Paths
{
    public class FigurePathData
    {
        public int id { get; set; }
        public int figure_id { get; set; }
        public DirectionType[] directions { get; set; } = new DirectionType[Constants.MAX_PATH_LENGTH];
    }
}
