using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarSaveReader.City.Finances
{
    public class FinanceOverview
    {
        public Income income = new();
        public Expenses expenses = new();       
        public int net_in_out;
        public int balance;
    };
}
