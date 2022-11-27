#define RESOURCE_MAX


using CeasarSaveReader.Emperor;

namespace CeasarSaveReader.City
{
    public class Emperor
    {
        public EmperorGift[] gifts =  new EmperorGift[3]; //3
        public int selected_gift_size;
        public int months_since_gift;
        public int gift_overdose_penalty;

        public int debt_state;
        public int months_in_debt;

        public int player_rank;
        public int salary_rank;
        public int salary_amount;
        public int donate_amount;
        public int personal_savings;

        public EmperorInvasion invasion = new EmperorInvasion();

        public Emperor()
        {
            for (int i = 0; i < 3; i++)
            {
                gifts[i] = new EmperorGift();
            }
        }
    }
}
