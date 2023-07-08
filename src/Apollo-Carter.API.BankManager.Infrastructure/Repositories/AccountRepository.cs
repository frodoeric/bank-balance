using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloData.ValueObjects.AccountValueObjects;

namespace Apollo_Carter.API.BankManager.Infrastructure.Repositories
{

    public class ApolloDataRepository : IAccountRepository
    {
        private readonly IApolloDataFactory _accountFactory;

        public ApolloDataRepository(IApolloDataFactory accountFactory)
        {
            _accountFactory = accountFactory;
        }

        public Task<Domain.ApolloData.ApolloData> Add(string providerName, string countryCode, ApolloDataloEntity  )
        {
            return Task.FromResult(apolloDataloEntity);
        }

        public Task<List<Domain.ApolloData.ApolloData>> FindAll()
        {
            var accounts = Task.FromResult(new List<Domain.ApolloData.ApolloData> {
                _accountFactory.CreateApolloDataInstance()
            });

            return accounts;
        }

        public Task<Domain.ApolloData.ApolloData> FindById(Guid id)
        {
            return Task.FromResult(
                _accountFactory.CreateApolloDataInstance());
        }

        public Task Remove(Guid id)
        {
            return Task.CompletedTask;
        }
        

    }
}
