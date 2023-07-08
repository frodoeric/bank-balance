using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;
using ApolloData.ValueObjects;
using ApolloData.ValueObjects.AccountValueObjects;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class Account : IAggregateRoot
    {
        public AccountId AccountId { get; set; }
        public CurrencyCode CurrencyCode { get; set; }
        public DisplayName DisplayName { get; set; }
        public AccountHolderNames AccountHolderNames { get; set; }
        public AccountType AccountType { get; set; }
        public AccountSubType AccountSubType { get; set; }
        public Identifiers Identifiers { get; set; }
        public List<Party> Parties { get; set; }
        public Balances Balances { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
