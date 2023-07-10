using System.Collections.Generic;
using System.Linq;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Commands
{
    public class CreateNewApolloCommand : ApolloCommand
    {
        public CreateNewApolloCommand(string providerName, string countryCode, IEnumerable<Account> accounts)
        {
            ProviderName = providerName;
            CountryCode = countryCode;
            Accounts = accounts;
        }
    }
}
