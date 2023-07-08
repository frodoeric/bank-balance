using System.Collections.Generic;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class Current
    {
        public double Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public List<object> CreditLines { get; set; }
    }
}