using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.Tasks.Events
{
    public class TaskEvent
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Summary { get; set; }
    }
}
