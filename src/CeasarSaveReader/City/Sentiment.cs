#define RESOURCE_MAX


namespace CeasarSaveReader.City
{
    public class Sentiment
    {
        public int value;
        public int previous_value;
        public int message_delay;

        public sbyte include_tents;
        public int unemployment;
        public int wages;
        public int low_mood_cause;
        public short blessing_festival_boost;

        public int protesters;
        public int criminals; // muggers+rioters
        public sbyte crime_cooldown;
    }
}
