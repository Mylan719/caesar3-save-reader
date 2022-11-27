namespace CeasarSaveReader.Figures.Paths
{
    public class FigurePathLoader
    {
        public List<FigurePathData> Load(Stream routeFigureStream, Stream pathStream)
        {
            var paths = new List<FigurePathData>();
            var routeFigureReader = new BinaryReader(routeFigureStream);
            var pathReader = new BinaryReader(pathStream);

            for (int i = 0; i < pathStream.Length/Constants.MAX_PATH_LENGTH; i++)
            {
                var path = new FigurePathData();
                path.id = i;
                path.figure_id = routeFigureReader.ReadInt16();
                path.directions = pathReader.ReadBytes(Constants.MAX_PATH_LENGTH).Select(b=> (DirectionType)b).ToArray();
                paths.Add(path);
            }

            var lastUsedIndex = paths.FindLastIndex(p => p.figure_id != 0);
            return paths.GetRange(0, lastUsedIndex + 1);
        }
    }
}
