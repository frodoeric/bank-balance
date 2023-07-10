using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Apollo_Carter.API.BankManager.Domain.ApolloData;

namespace Apollo_Carter.API.BankManager.Application.ViewModels
{
    public class ApolloViewModel
    {
        public string ProviderName { get; set; }
        public string CountryCode { get; set; } = string.Empty;
        public IEnumerable<Account> Accounts { get; set; }
    }
}
