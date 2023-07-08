using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apollo_Carter.API.BankManager.Domain.ApolloData;


/*
 * Encapsulate the tiny domain business rules. Structures that are unique 
 * by their properties and the whole object is immutable, once it is created
 * its state can not change.
 * https://martinfowler.com/bliki/ValueObject.html
 */

namespace ApolloData.ValueObjects
{
    public readonly struct AccountList : IEnumerable<Account>
    {
        private readonly List<Account> _accounts;

        public AccountList(IEnumerable<Account> accounts)
        {
            var enumerable = accounts.ToList();
            if (accounts == null || !enumerable.Any())
            {
                //todo create custom exception
                throw new ArgumentNullException($"AccountList value is required");
            }

            _accounts = enumerable.ToList();
        }

        public IEnumerator<Account> GetEnumerator()
        {
            return _accounts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
