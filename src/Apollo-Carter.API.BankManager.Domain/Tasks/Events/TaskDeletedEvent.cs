using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.Tasks.Events
{
    public class TaskDeletedEvent : TaskEvent
    {
        public TaskDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
