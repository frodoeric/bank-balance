using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public interface IApolloDataFactory
    {
        ApolloData CreateApolloDataInstance(string providerName, string countryCode, IEnumerable<Account> accounts);
    }
}
