using Apollo_Carter.API.BankManager.Application.ViewModels;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * A view model represents the data that you want to display on 
 * your view/page, whether it be used for static text or for input
 * values (like textboxes and dropdown lists). It is something 
 * different than your domain model. So we need to convert the 
 * domain model to a view model to send it to the client (API response)
 * 
 * This is an example of the mapping, you can use whatever you want in
 * your code, Automapper or any similar library to do this conversion.
 */

namespace Apollo_Carter.API.BankManager.Application.Mappers
{
    public class ApolloDataViewModelMapper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public ApolloDataViewModelMapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<ApolloViewModel> ConstructFromListOfEntities(IEnumerable<Domain.ApolloData.ApolloData> apolloData)
        {
            var tasksViewModel = apolloData.Select(i => new ApolloViewModel
            {
                Id = i.Accounts.FirstOrDefault().AccountId.ToGuid().ToString(),
            }
            );

            return tasksViewModel;
        }

        public ApolloViewModel ConstructFromEntity(string providerName, string countryCode, IEnumerable<Account> accountList)
        {
            return new ApolloViewModel
            {
                Id = apolloData.TaskId.ToGuid().ToString(),
                Description = apolloData.Description.ToString(),
                Summary = apolloData.Summary.ToString(),
            };
        }

        public CreateNewTaskCommand ConvertToNewTaskCommand(ApolloViewModel taskViewModel)
        {
            return new CreateNewTaskCommand(taskViewModel.Summary, taskViewModel.Description);
        }

        public DeleteTaskCommand ConvertToDeleteTaskCommand(Guid id)
        {
            return new DeleteTaskCommand(id);
        }
    }
}
