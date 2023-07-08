using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Commands
{
    public class DeleteTaskCommand : TaskCommand
    {
        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
