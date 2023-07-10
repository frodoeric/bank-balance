using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Commands
{
    public class EndOfDayBalanceType
    {
        public DateTime Day { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
    }
}
