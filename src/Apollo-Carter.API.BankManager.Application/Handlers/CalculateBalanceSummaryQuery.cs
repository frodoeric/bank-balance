using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Application.Services;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using MediatR;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Query
{
    public class CalculateBalanceSummaryQuery : IRequest<EndOfDayBalance>
    {
    }

    public class CalculateBalanceSummaryQueryHandler : IRequestHandler<CalculateBalanceSummaryQuery, EndOfDayBalance>
    {
        private readonly IApolloDataRepository _dataRepository;
        private readonly IBalanceCalculatorService _balanceCalculatorService;

        public CalculateBalanceSummaryQueryHandler(
            IApolloDataRepository dataRepository, 
            IBalanceCalculatorService balanceCalculatorService)
        {
            _dataRepository = dataRepository;
            _balanceCalculatorService = balanceCalculatorService;
        }

        public async Task<EndOfDayBalance> Handle(CalculateBalanceSummaryQuery request, CancellationToken cancellationToken)
        {
            var apolloData = await _dataRepository.FindAll();
            var eodBalance = _balanceCalculatorService.GetBalanceCalculated(apolloData);

            return eodBalance;
        }
    }
}
