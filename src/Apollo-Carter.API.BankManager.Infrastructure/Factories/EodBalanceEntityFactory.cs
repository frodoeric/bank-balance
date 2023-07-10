using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Text;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;

namespace Apollo_Carter.API.BankManager.Infrastructure.Factories
{
    public class EodBalanceEntityFactory : IEndOfDayBalanceFactory
    {
        public EndOfDayBalance CreateEndOfDayBalanceInstance(decimal endBalance,
            decimal amountCredits,
            decimal amountDebits,
            IEnumerable<EndOfDayBalanceType> balanceTypes)
        {
            return new EndOfDayBalanceFactory(endBalance, amountCredits, amountDebits, balanceTypes);
        }
    }
}