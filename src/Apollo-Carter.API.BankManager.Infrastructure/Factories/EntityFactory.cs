using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Infrastructure.Factories
{
    public class EntityFactory : IApolloDataFactory
    {
        public ApolloData CreateApolloDataInstance(string providerName, string countryCode, IEnumerable<Account> accounts)
        {
            return new ApolloDataFactory(providerName, countryCode, accounts);
        }
    }
}