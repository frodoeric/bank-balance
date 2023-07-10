using System;
using System.Collections.Generic;
using System.Text;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData
{
    public interface IEndOfDayBalanceFactory
    {
        EndOfDayBalance CreateEndOfDayBalanceInstance(
            decimal endBalance,
            decimal amountCredits,
            decimal amountDebits,
            IEnumerable<EndOfDayBalanceType> balanceTypes);
    }
}
