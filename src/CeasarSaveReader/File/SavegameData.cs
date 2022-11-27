namespace CeasarSaveReader.File
{
    public class SavegameData
    {
        public int num_pieces { get; set; }
        public List<FilePiece> pieces { get; set; } = new List<FilePiece>();
        public SavegameState state { get; set; } = new SavegameState();
    }
}
