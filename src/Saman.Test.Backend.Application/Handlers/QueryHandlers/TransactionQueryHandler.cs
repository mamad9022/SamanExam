using AutoMapper;
using MediatR;
using Saman.Test.Backend.Application.Query;
using Saman.Test.Backend.Application.Responses;
using Saman.Test.Backend.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Application.Handlers.QueryHandlers
{
    public class TransactionQueryHandler : IRequestHandler<TransactionQuery, List<TransactionResponse>>
    {
        private readonly ITranscationRepository _transcationRepository;
        private readonly IMapper _mapper;

        public TransactionQueryHandler(ITranscationRepository transcationRepository, IMapper mapper)
        {
            _transcationRepository = transcationRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionResponse>> Handle(TransactionQuery request, CancellationToken cancellationToken)
        {
            var resultQueryable = _transcationRepository.Where();

            return _mapper.Map<List<TransactionResponse>>(resultQueryable.ToList());
        }
    }
}
