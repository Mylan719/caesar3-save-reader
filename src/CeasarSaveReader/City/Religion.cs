#define RESOURCE_MAX


using CeasarSaveReader.Game;

namespace CeasarSaveReader.City
{
    public class Religion
    {
        public GodStatus[] gods = new GodStatus[Config.MAX_GODS]; //5
        public int least_happy_god;
        public int angry_message_delay;
        public int venus_curse_active;
        public int venus_blessing_months_left;
        public int neptune_double_trade_active;
        public int neptune_sank_ships;
        public int mars_spirit_power;

        public Religion()
        {
            for (int i = 0; i < Config.MAX_GODS; i++)
            {
                gods[i] = new GodStatus();
            }
        }
    }
}
