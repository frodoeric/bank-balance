using Apollo_Carter.API.BankManager.Application.ViewModels;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Apollo_Carter.API.BankManager.Application.Services
{
    public interface IBalanceCalculatorService
    {
        EndOfDayBalance GetBalanceCalculated(ApolloData apolloData);
    }
}
