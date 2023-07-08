using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApolloData.ValueObjects.AccountValueObjects;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Events
{
    public class TaskDeletedEvent : ApolloDataEvent
    {
        public TaskDeletedEvent(Guid id)
        {
            AccountId = new AccountId(id);
        }
    }
}
