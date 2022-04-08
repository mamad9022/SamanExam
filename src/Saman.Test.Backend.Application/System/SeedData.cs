using Saman.Test.Backend.Domain.Models;
using Saman.Test.Backend.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Application.System
{
    public class SeedData
    {
        private readonly IBankRepository _bankRepository;

        public SeedData(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public async Task SeedAllAsync(CancellationToken cancellationToken)
        {

            List<Bank> banks = null;
            
            if (!_bankRepository.Any())
            {
                banks = new List<Bank>
                {
                new Bank("Melat",Domain.Enums.BankType.Melat,610433),
                new Bank("Saman",Domain.Enums.BankType.Saman,621986),
                new Bank("Ayndeh",Domain.Enums.BankType.Ayandeh,636214)
                };

                await _bankRepository.CreateRangeAsync(banks);
            }

        }
    }
}
