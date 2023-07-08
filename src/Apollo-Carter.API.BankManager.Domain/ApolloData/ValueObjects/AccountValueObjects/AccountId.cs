using System;
using System.Collections.Generic;
using System.Text;

namespace ApolloData.ValueObjects.AccountValueObjects
{
    public struct AccountId
    {
        private readonly Guid _accountId;

        public AccountId(Guid accountId)
        {
            if (accountId.Equals(Guid.Empty))
                throw new ArgumentNullException($"Task Id does not have any value");

            _accountId = accountId;
        }

        public Guid ToGuid()
        {
            return _accountId;
        }
    }
}
