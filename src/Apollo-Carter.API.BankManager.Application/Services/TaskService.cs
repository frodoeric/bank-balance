using Apollo_Carter.API.BankManager.Application.Mappers;
using Apollo_Carter.API.BankManager.Application.ViewModels;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using AutoMapper;
using FluentMediator;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;

/*
 * Application service is that layer which initializes and oversees interaction 
 * between the domain objects and services. The flow is generally like this: 
 * get domain object (or objects) from repository, execute an action and put it 
 * (them) back there (or not). It can do more - for instance it can check whether 
 * a domain object exists or not and throw exceptions accordingly. So it lets the 
 * user interact with the application (and this is probably where its name originates 
 * from) - by manipulating domain objects and services. Application services should 
 * generally represent all possible use cases.
 */

namespace Apollo_Carter.API.BankManager.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly IApolloDataRepository _taskRepository;
        private readonly IApolloDataFactory _taskFactory;
        private readonly ApolloDataProfile _apolloMapper;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TaskService(
            IApolloDataRepository taskRepository, 
            ApolloDataProfile apolloMapper,
            IApolloDataFactory taskFactory, 
            IMediator mediator,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _apolloMapper = apolloMapper;
            _taskFactory = taskFactory;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<ApolloViewModel> Create(ApolloViewModel apolloViewModel)
        {
            var newApolloCommand = _apolloMapper.ConvertToNewApolloCommand(apolloViewModel);
            var apolloResult = await _mediator.SendAsync<ApolloData>(newApolloCommand);
            var apolloViewResult = _mapper.Map<ApolloViewModel>(apolloResult);

            return apolloViewResult;
        }

        public async System.Threading.Tasks.Task Delete(Guid id)
        {
            var deleteTaskCommand = _apolloMapper.ConvertToDeleteApolloCommand(id);
            await _mediator.PublishAsync(deleteTaskCommand);
        }

        public async Task<ApolloViewModel> GetAll()
        {
            var apolloData = await _taskRepository.FindAll();
            var apolloViewResult = _mapper.Map<ApolloData, ApolloViewModel>(apolloData);

            return apolloViewResult;
        }

        public async Task<ApolloViewModel> GetById(Guid id)
        {
            var apolloData = await _taskRepository.FindById(id);
            var apolloViewResult = _mapper.Map<ApolloViewModel>(apolloData);

            return apolloViewResult;
        }
    }
}
