using System;
using System.Collections.Generic;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Commands
{
    public class ApolloCommand
    {
        public Guid Id { get; set; }
        public string ProviderName { get; set; }
        public string CountryCode { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
