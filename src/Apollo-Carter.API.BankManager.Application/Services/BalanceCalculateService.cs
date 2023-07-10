using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var amountCredits = 0M;
            var amountDebits = 0M;

            var transactionsGroup = apolloData.Accounts.FirstOrDefault()
                ?.Transactions
                .GroupBy(x => Convert.ToDateTime(x.BookingDate.ToShortDateString())).OrderBy(x => x.Key).ToList();

            var account = apolloData.Accounts.FirstOrDefault();

            if (account == null) return null;
            {
                var currentBalance =
                    (decimal)(account.Balances.Current.CreditDebitIndicator == CreditDebitIndicator.Credit ?
                        account.Balances.Current.Amount : account.Balances.Current.Amount * -1);

                if (transactionsGroup != null)
                    foreach (var transactions in transactionsGroup)
                    {
                        var credit = transactions
                            .Where(x => x.CreditDebitIndicator == CreditDebitIndicator.Credit).Sum(x => x.Amount);
                        var debit = transactions
                            .Where(x => x.CreditDebitIndicator == CreditDebitIndicator.Debit).Sum(x => x.Amount);

                        amountCredits += credit;
                        amountDebits += debit;
                        currentBalance += credit - debit;

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
