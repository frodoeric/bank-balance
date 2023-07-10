using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Infrastructure.Factories;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace Apollo_Carter.API.BankManager.Infrastructure.Repositories
{

    public class ApolloDataRepository : IApolloDataRepository
    {
        private readonly IApolloDataFactory _accountFactory;

        public ApolloDataRepository(IApolloDataFactory accountFactory)
        {
            _accountFactory = accountFactory;
        }

        public Task<ApolloData> Add(ApolloData entity)
        {
            //todo create a sql or another microservices to add data
            var apolloData =  System.Threading.Tasks.Task.FromResult(
                _accountFactory.CreateApolloDataInstance(entity.ProviderName, entity.CountryCode, entity.Accounts));

            return apolloData;
        }

        public Task<ApolloData> FindAll()
        {
            var entity = ReadApolloDataJsonFile();
            return Task.FromResult(
                _accountFactory.CreateApolloDataInstance(entity.ProviderName, entity.CountryCode, entity.Accounts));
        }

        public Task<ApolloData> FindById(Guid id)
        {
            var entity = ReadApolloDataJsonFile();
            //todo Create Get Count by id
            return Task.FromResult(
                _accountFactory.CreateApolloDataInstance(entity.ProviderName, entity.CountryCode, entity.Accounts));
        }

        public Task Remove(string id)
        {
            //todo create Remove method
            return Task.CompletedTask;
        }

        private static ApolloData ReadApolloDataJsonFile()
        {
            using var r = new StreamReader("../Apollo-Carter.API.BankManager.Infrastructure/Repositories/apollo-carter.json");
            var json = r.ReadToEnd();
            var apolloData = JsonConvert.DeserializeObject<ApolloData>(json);

            return apolloData;
        }

    }
}
