using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Commands
{
    public class DeleteApolloCommand : ApolloCommand
    {
        public DeleteApolloCommand(Guid id)
        {
            Id = id;
        }
    }
}
