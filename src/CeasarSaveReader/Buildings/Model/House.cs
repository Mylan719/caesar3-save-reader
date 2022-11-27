namespace CeasarSaveReader.Buildings.Model
{
    public class House : BuildingData
    {
        public short[] inventory { get; set; } = new short[8];
        public byte theater { get; set; }
        public byte amphitheater_actor { get; set; }
        public byte amphitheater_gladiator { get; set; }
        public byte colosseum_gladiator { get; set; }
        public byte colosseum_lion { get; set; }
        public byte hippodrome { get; set; }
        public byte school { get; set; }
        public byte library { get; set; }
        public byte academy { get; set; }
        public byte barber { get; set; }
        public byte clinic { get; set; }
        public byte bathhouse { get; set; }
        public byte hospital { get; set; }
        public byte temple_ceres { get; set; }
        public byte temple_neptune { get; set; }
        public byte temple_mercury { get; set; }
        public byte temple_mars { get; set; }
        public byte temple_venus { get; set; }
        public byte no_space_to_expand { get; set; }
        public byte num_foods { get; set; }
        public byte entertainment { get; set; }
        public byte education { get; set; }
        public byte health { get; set; }
        public byte num_gods { get; set; }
        public byte devolve_delay { get; set; }
        public byte evolve_text_id { get; set; }
    }
}
