using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Saman.Test.Backend.Domain.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Saman.Test.Backend.Repository.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly SamanDbContext _dbContext;

        public TransactionBehavior(SamanDbContext dbContext,
            ILogger<TransactionBehavior<TRequest, TResponse>> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(SamanDbContext));
            _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetType();
            var response = default(TResponse);

            if (typeName.BaseType.Name.StartsWith("QueryBase"))
                return await next();

            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    if (_dbContext.HasActiveTransaction)
                    {
                        return await next();
                    }

                    var strategy = _dbContext.Database.CreateExecutionStrategy();

                    await strategy.ExecuteAsync(async () =>
                    {
                        Guid transactionId;

                        using (var transaction = await _dbContext.BeginTransactionAsync())
                        {
                            response = await next();
                            _logger.LogInformation("----- Commit transaction {TransactionId} for {CommandName}", transaction.TransactionId, typeName);

                            await _dbContext.CommitTransactionAsync(transaction);
                            transactionId = transaction.TransactionId;
                        }
                    });

                    return response;
                }
                catch (SamanException ex)
                {
                    _logger.LogError(ex, "ERROR Handling transaction for {CommandName} ({@Command})", typeName, request);

                    if (i >= 3)
                        throw new SamanException(ex.ErrorCode, customMessage: ex.Message);
                }
            }
            return response;

        }
    }
}
