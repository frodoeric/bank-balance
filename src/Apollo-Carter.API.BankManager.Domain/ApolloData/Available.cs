using System.Collections.Generic;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class Available
    {
        public double amount { get; set; }
        public string creditDebitIndicator { get; set; }
        public List<object> creditLines { get; set; }
    }
}