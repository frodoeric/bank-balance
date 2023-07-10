using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;
using Newtonsoft.Json;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public class ApolloData
    {
        public string ProviderName { get; set; }
        public string CountryCode { get; set; }
        public IEnumerable<Account> Accounts { get; set; }
    }
}
