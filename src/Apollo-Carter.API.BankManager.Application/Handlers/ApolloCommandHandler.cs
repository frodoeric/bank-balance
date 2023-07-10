using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Events;
using FluentMediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo_Carter.API.BankManager.Application.Handlers
{
    public class ApolloCommandHandler
    {
        private readonly IApolloDataFactory _taskFactory;
        private readonly IApolloDataRepository _taskRepository;
        private readonly IMediator _mediator;

        public ApolloCommandHandler(IApolloDataRepository taskRepository, IApolloDataFactory taskFactory, IMediator mediator)
        {
            _taskRepository = taskRepository;
            _taskFactory = taskFactory;
            _mediator = mediator;
        }

        public async Task<ApolloData> HandleNewTask(CreateNewApolloCommand createNewApolloCommand)
        {
            var task = _taskFactory.CreateApolloDataInstance(
                createNewApolloCommand.ProviderName,
                createNewApolloCommand.CountryCode,
                createNewApolloCommand.Accounts);

            var apolloCreated = await _taskRepository.Add(task);

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new ApolloDataCreatedEvent(apolloCreated));

            return apolloCreated;
        }

        public async Task HandleDeleteTask(DeleteApolloCommand deleteTaskCommand)
        {
            var id = deleteTaskCommand.Accounts.FirstOrDefault()!.AccountId;
            await _taskRepository.Remove(id);

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new TaskDeletedEvent(id));
        }
    }
}
