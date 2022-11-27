namespace CeasarSaveReader.Figures.Model
{
    public class Tourist
    {
        public ushort tourist_money_spent {get; set;}
        public ushort [] ticks_since_last_visited_id {get; set;} = new ushort[12];
        public ushort [] visited_building_type_ids {get; set;} = new ushort[12];
        public byte tourist_rank {get; set;}
    }
}
