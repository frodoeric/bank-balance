using ApolloData.ValueObjects;
using ApolloData.ValueObjects.AccountValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Events
{
    public class ApolloDataEvent
    {
        public AccountId AccountId { get; set; }
    }
}
