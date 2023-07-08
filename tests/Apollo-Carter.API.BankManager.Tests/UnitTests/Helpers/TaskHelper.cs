using Apollo_Carter.API.BankManager.Domain.Tasks;
using Apollo_Carter.API.BankManager.Domain.Tasks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Tests.UnitTests.Helpers
{
    public static class TaskHelper
    {
        public static Task GetTask()
        {
            return new Task()
            {
                TaskId = new TaskId(Guid.NewGuid()),
                Summary = new Summary("Summary"),
                Description = new Description("Description")
            };
        }

        public static IEnumerable<Task> GetTasks()
        {
            return new List<Task>()
            {
                GetTask()
            };
        }

    }
}
