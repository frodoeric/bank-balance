using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Query;
using MediatR;

namespace Apollo_Carter.API.BankManager.Application.Handlers
{
    public class CalculateBalanceSumaryQueryHandler : IRequestHandler<CalculateBalanceSummaryQuery, EndOfDayBalance>
    {
        public CalculateBalanceSumaryQueryHandler()
        {
                
        }
        public Task<EndOfDayBalance> Handle(CalculateBalanceSummaryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
