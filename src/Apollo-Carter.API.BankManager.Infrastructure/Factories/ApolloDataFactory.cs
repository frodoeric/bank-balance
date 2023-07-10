using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Apollo_Carter.API.BankManager.Domain.ApolloData;

namespace Apollo_Carter.API.BankManager.Infrastructure.Factories
{
    public class ApolloDataFactory : ApolloData
    {
        public ApolloDataFactory(string providerName, string countryCode, IEnumerable<Account> accounts)
        {
            ProviderName = providerName;
            CountryCode = countryCode;
            Accounts = accounts;
        }
    }
}
