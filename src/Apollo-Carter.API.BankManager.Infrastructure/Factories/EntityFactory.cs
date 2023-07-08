using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo_Carter.API.BankManager.Infrastructure.Factories
{
    public class EntityFactory : IApolloDataFactory
    {
        public Domain.ApolloData.ApolloData CreateApolloDataInstance()
        {
            return new ApolloDataFactory();
        }

        public Domain.ApolloData.ApolloData GetAllApolloDataInstance()
        {
            return new ApolloDataFactory();
        }
    }
}