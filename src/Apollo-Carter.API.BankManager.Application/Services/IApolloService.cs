using Apollo_Carter.API.BankManager.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo_Carter.API.BankManager.Application.Services
{
    public interface IApolloService
    {
        Task<ApolloViewModel> GetAll();
        Task<ApolloViewModel> GetById(Guid id);
        Task<ApolloViewModel> Create(ApolloViewModel apolloVewModel);
        Task Delete(Guid id);
    }
}
