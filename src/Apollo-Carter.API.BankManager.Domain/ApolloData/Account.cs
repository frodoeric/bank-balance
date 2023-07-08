using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string CurrencyCode { get; set; }
        public string DisplayName { get; set; }
        public string AccountHolderNames { get; set; }
        public string AccountType { get; set; }
        public string AccountSubType { get; set; }
        public string Identifiers { get; set; }
        public List<Party> Parties { get; set; }
        public List<Balance> Balances { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
