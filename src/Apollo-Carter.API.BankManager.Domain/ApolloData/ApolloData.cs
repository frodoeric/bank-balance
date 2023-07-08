using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;
using ApolloData.ValueObjects;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class ApolloData : IAggregateRoot
    {
        public ProviderName ProviderName { get; set; }
        public CountryCode CountryCode { get; set; }
        public AccountList Accounts { get; set; }
    }
}
