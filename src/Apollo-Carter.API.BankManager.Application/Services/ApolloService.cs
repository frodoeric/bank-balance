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


namespace Apollo_Carter.API.BankManager.Application.Services
{
    public class ApolloService : IApolloService
    {
        private readonly IApolloDataRepository _taskRepository;
        private readonly IApolloDataFactory _taskFactory;
        private readonly ApolloDataProfile _apolloMapper;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ApolloService(
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
            var apolloViewResult = _mapper.Map<ApolloData, ApolloViewModel>(apolloResult);

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
            var apolloViewResult = _mapper.Map<ApolloData, ApolloViewModel>(apolloData);

            return apolloViewResult;
        }
    }
}
