using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Commands
{
    public class EndOfDayBalance
    {
        public decimal EndBalance { get; set; }
        public decimal AmountCredits { get; set; }
        public decimal AmountDebits { get; set; }
        public IEnumerable<EndOfDayBalanceType> EodBalanceTypes { get; set; }
    }
}
