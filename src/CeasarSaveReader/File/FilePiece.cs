namespace CeasarSaveReader.File
{
    public class FilePiece
    {
        public int Size { get; set; }
        public bool compressed { get; set; }
        public bool dynamic { get; set; }
        public byte [] Data { get; set; }
    }
}
