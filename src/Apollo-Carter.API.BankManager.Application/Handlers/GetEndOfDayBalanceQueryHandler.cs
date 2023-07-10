using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apollo_Carter.API.BankManager.Domain.ApolloData;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Commands;
using Apollo_Carter.API.BankManager.Domain.ApolloData.Query;
using MediatR;
using IMediator = FluentMediator.IMediator;

namespace Apollo_Carter.API.BankManager.Application.Handlers
{
    public class GetEndOfDayBalanceQueryHandler : IRequestHandler<GetEndOfDayBalanceQuery, EndOfDayBalance>
    {
        //private readonly IApolloDataRepository _dataRepository;
        //private readonly IMediator _mediator;

        //public GetEndOfDayBalanceQueryHandler(
        //    IApolloDataRepository dataRepository,
        //    IMediator mediator
        //    )
        //{
        //    dataRepository = _dataRepository;
        //    _mediator = mediator;
        //}

        public Task<EndOfDayBalance> Handle(GetEndOfDayBalanceQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
