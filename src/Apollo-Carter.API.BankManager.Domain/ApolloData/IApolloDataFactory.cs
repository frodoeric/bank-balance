using System;
using System.Collections.Generic;
using System.Text;
using ApolloData.ValueObjects.AccountValueObjects;

/*
 * Factories are concerned with creating new entities and value objects. 
 * They also validate the invariants for the newly created objects.
 * 
 * This is the interface definition to create Tasks (to be implemented in
 * Infrastructure layer)
 */

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public interface IApolloDataFactory
    {
        ApolloData CreateApolloDataInstance();
    }
}
