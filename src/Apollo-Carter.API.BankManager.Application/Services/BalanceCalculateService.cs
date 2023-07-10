using Apollo_Carter.API.BankManager.Application.Mappers;
using Apollo_Carter.API.BankManager.Application.ViewModels;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using AutoMapper;
using FluentMediator;
using OpenTracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;


namespace Apollo_Carter.API.BankManager.Application.Services
{
    public class BalanceCalculatorService : IBalanceCalculatorService
    {
        private readonly IEndOfDayBalanceFactory _eodBalanceFactory;
        public BalanceCalculatorService(IEndOfDayBalanceFactory balanceFactory)
        {
            _eodBalanceFactory = balanceFactory;
        }
        public EndOfDayBalance GetBalanceCalculated(ApolloData apolloData)
        {

            var eodBalances = new List<EndOfDayBalanceType>();

            var transactionsGroup = apolloData.Accounts.FirstOrDefault()
                ?.Transactions
                .GroupBy(x => Convert.ToDateTime(x.BookingDate.ToShortDateString())).OrderBy(x => x.Key).ToList();

            var account = apolloData.Accounts.FirstOrDefault();

            var amountCredits = 0M;
            var amountDebits = 0M;


            if (account == null) return null;
            {
                var currentBalance = 
                    (decimal)(account.Balances.Current.CreditDebitIndicator == CreditDebitIndicator.Credit ? 
                        account.Balances.Current.Amount : account.Balances.Current.Amount * -1);

                lock (this)
                {
                    if (transactionsGroup != null)
                        foreach (var transactions in transactionsGroup)
                        {
                            var credit = transactions
                                .Where(x => x.CreditDebitIndicator == CreditDebitIndicator.Credit).Sum(x => x.Amount);
                            var debit = transactions
                                .Where(x => x.CreditDebitIndicator == CreditDebitIndicator.Debit).Sum(x => x.Amount);

                            currentBalance += credit - debit;
                            amountCredits += credit;
                            amountDebits += debit;


                            var day = transactions.Key;


                            eodBalances.Add(new EndOfDayBalanceType
                            {
                                Day = day,
                                Type = currentBalance > 0
                                    ? CreditDebitIndicator.Credit
                                    : CreditDebitIndicator.Debit,
                                Balance = Math.Abs(currentBalance)
                            });
                        }
                }

                var eodBalance = _eodBalanceFactory.CreateEndOfDayBalanceInstance(
                    currentBalance, 
                    amountCredits, 
                    amountDebits,
                    eodBalances);

                return eodBalance;
            }

        }
    }

    public static class CreditDebitIndicator
    {
        public const string Credit = "Credit";
        public const string Debit = "Debit";
    }
}
