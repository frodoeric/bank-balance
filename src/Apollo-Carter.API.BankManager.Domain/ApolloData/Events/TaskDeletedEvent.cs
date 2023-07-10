using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Events
{
    public class TaskDeletedEvent : ApolloDataEvent
    {
        public TaskDeletedEvent(string id)
        {
            AccountId = id;
        }
    }
}
