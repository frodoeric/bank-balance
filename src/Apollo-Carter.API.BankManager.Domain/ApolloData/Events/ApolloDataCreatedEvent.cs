using System;
using System.Linq;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Events
{
    public class ApolloDataCreatedEvent : ApolloDataEvent
    {
        public ApolloDataCreatedEvent(ApolloData apolloData)
        {
            AccountId = apolloData.Accounts.FirstOrDefault()!.AccountId;
        }
    }
}
