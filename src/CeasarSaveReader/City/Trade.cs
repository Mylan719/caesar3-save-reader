#define RESOURCE_MAX


namespace CeasarSaveReader.City
{
    public class Trade
    {
        public short num_land_routes;
        public short num_sea_routes;
        public short land_trade_problem_duration;
        public short sea_trade_problem_duration;
        public ushort months_since_last_land_trade_problem;
        public ushort months_since_last_sea_trade_problem;
        public int caravan_import_resource;
        public int caravan_backup_import_resource;
        public int docker_import_resource;
        public int docker_export_resource;
        public byte land_policy;
        public byte sea_policy;
    }
}
