using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Events;
using FluentMediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Apollo_Carter.API.BankManager.Application.Handlers
{
    public class TaskCommandHandler
    {
        private readonly IApolloDataFactory _taskFactory;
        private readonly IAccountRepository _taskRepository;
        private readonly IMediator _mediator;

        public TaskCommandHandler(IAccountRepository taskRepository, IApolloDataFactory taskFactory, IMediator mediator)
        {
            _taskRepository = taskRepository;
            _taskFactory = taskFactory;
            _mediator = mediator;
        }

        public async Task<Domain.ApolloData.ApolloData> HandleNewTask(CreateNewTaskCommand createNewTaskCommand)
        {
            var task = _taskFactory.CreateApolloDataInstance();

            var apolloCreated = await _taskRepository.Add(task);

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new ApolloDataCreatedEvent(apolloCreated));

            return apolloCreated;
        }

        public async Task HandleDeleteTask(DeleteTaskCommand deleteTaskCommand)
        {
            await _taskRepository.Remove(deleteTaskCommand.Id);

            // You may raise an event in case you need to propagate this change to other microservices
            await _mediator.PublishAsync(new TaskDeletedEvent(deleteTaskCommand.Id));
        }
    }
}
