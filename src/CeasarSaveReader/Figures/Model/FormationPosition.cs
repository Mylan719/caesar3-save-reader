namespace CeasarSaveReader.Figures.Model
{
    public class FormationPosition
    {
        private byte union;
     
        public byte soldier { get => union; set => union = value; }
        public sbyte enemy { get => (sbyte)union; set => union = (byte)value; }
    }
}
