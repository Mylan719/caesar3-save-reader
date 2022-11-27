namespace CeasarSaveReader.Buildings.Model
{
    public class Sentiment
    {
        private sbyte unionField;
        public sbyte house_happiness { get => unionField; set => unionField = value; }
        public sbyte native_anger { get => unionField; set => unionField = value; }
    }
}
