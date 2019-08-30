using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace eGP.Abstraction.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly DbContext _dbContext;
      //  private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;

        //public TransactionBehavior(DbContext dbContext,
        //    IOrderingIntegrationEventService orderingIntegrationEventService,
        //    ILogger<TransactionBehaviour<TRequest, TResponse>> logger)
        //{
        //    _dbContext = dbContext ?? throw new ArgumentException(nameof(OrderingContext));
        //    _orderingIntegrationEventService = orderingIntegrationEventService ?? throw new ArgumentException(nameof(orderingIntegrationEventService));
        //    _logger = logger ?? throw new ArgumentException(nameof(ILogger));
        //}

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default(TResponse);
            return response;
            //try
            //{
            //    var strategy = _dbContext.Database.CreateExecutionStrategy();
            //    await strategy.ExecuteAsync(async () =>
            //    {
            //        _logger.LogInformation($"Begin transaction {typeof(TRequest).Name}");

            //        await _dbContext.BeginTransactionAsync();

            //        response = await next();

            //        await _dbContext.CommitTransactionAsync();

            //        _logger.LogInformation($"Committed transaction {typeof(TRequest).Name}");

            //        await _orderingIntegrationEventService.PublishEventsThroughEventBusAsync();
            //    });

            //    return response;
            //}
            //catch (Exception)
            //{
            //    _logger.LogInformation($"Rollback transaction executed {typeof(TRequest).Name}");

            //    _dbContext.RollbackTransaction();
            //    throw;
            //}
        }
    }
}
