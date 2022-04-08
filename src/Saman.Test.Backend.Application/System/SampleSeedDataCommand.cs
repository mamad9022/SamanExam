using MediatR;
using Saman.Test.Backend.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Application.System
{
    public class SampleSeedDataCommand : IRequest
    {
    }

    public class SampleSeedDataCommandHandler : IRequestHandler<SampleSeedDataCommand>
    {
        private readonly IBankRepository _bankRepository;

        public SampleSeedDataCommandHandler(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
        public async Task<Unit> Handle(SampleSeedDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SeedData(_bankRepository);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
