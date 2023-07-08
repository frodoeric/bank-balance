using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Tests.UnitTests.Helpers
{
    public static class TaskHelper
    {
        public static Account GetTask()
        {
            return new Account()
            {
                TaskId = new AccountId(Guid.NewGuid()),
                Summary = new Summary("Summary"),
                Description = new AccountHolderNames("Description")
            };
        }

        public static IEnumerable<Account> GetTasks()
        {
            return new List<Account>()
            {
                GetTask()
            };
        }

    }
}
