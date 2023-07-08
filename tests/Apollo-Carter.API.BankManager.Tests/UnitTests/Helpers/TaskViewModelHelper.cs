using Apollo_Carter.API.BankManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Tests.UnitTests.Helpers
{
    public static class TaskViewModelHelper
    {
        public static TaskViewModel GetTaskViewModel()
        {
            return new TaskViewModel
            {
                Id = Guid.NewGuid().ToString(),
                Summary = "Summary",
                Description = "Description"
            };
        }
    }
}
