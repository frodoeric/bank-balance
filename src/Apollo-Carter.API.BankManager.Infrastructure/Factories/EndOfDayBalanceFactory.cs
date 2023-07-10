using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;

namespace Apollo_Carter.API.BankManager.Infrastructure.Factories
{
    public class EndOfDayBalanceFactory : EndOfDayBalance
    {
        public EndOfDayBalanceFactory(
            decimal endBalance, 
            decimal amountCredits, 
            decimal amountDebits, 
            IEnumerable<EndOfDayBalanceType> balanceTypes)
        {
            AmountCredits = amountCredits;
            AmountDebits = amountDebits;
            EndBalance = endBalance;
            EodBalanceTypes = balanceTypes;
        }
    }
}
