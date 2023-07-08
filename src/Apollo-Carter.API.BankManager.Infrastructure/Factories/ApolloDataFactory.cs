using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using ApolloData.ValueObjects.AccountValueObjects;

namespace Apollo_Carter.API.BankManager.Infrastructure.Factories
{
    public class ApolloDataFactory : Domain.ApolloData.ApolloData
    {
        public ApolloDataFactory()
        {
            var apolloData = ReadApolloDataJsonFile();
            Accounts = apolloData.Accounts;
            CountryCode = apolloData.CountryCode;
            ProviderName = apolloData.ProviderName;
        }

        private static Domain.ApolloData.ApolloData ReadApolloDataJsonFile()
        {
            using var r = new StreamReader("apollo-carter.json");
            var json = r.ReadToEnd();
            var apolloData = JsonSerializer.Deserialize<Domain.ApolloData.ApolloData>(json);

            return apolloData;
        }
    }
}
