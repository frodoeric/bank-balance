using Apollo_Carter.API.BankManager.Application.ViewModels;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace Apollo_Carter.API.BankManager.Application.Mappers
{
    public class ApolloDataProfile : Profile
    {
        public ApolloDataProfile()
        {
            CreateMap<ApolloViewModel, ApolloData>();
        }

        public CreateNewApolloCommand ConvertToNewApolloCommand(ApolloViewModel taskViewModel)
        {
            return new CreateNewApolloCommand(taskViewModel.ProviderName, taskViewModel.CountryCode, taskViewModel.Accounts);
        }

        public DeleteApolloCommand ConvertToDeleteApolloCommand(Guid id)
        {
            return new DeleteApolloCommand(id);
        }
    }
}
