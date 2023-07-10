using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using MediatR;

namespace Apollo_Carter.API.BankManager.Domain.ApolloData.Query
{
    public class CalculateBalanceSummaryQuery : IRequest<EndOfDayBalance>
    {
        public CalculateBalanceSummaryQuery() { }
    }
}
