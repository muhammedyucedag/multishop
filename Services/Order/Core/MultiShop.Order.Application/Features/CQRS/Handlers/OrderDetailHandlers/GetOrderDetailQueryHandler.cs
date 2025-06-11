using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();
        
        return values.Select(x => new GetOrderDetailQueryResult
        {
            Id = x.Id,
            ProductAmount = x.ProductAmount,
            ProductName = x.ProductName,
            ProductId = x.ProductId,
            OrderingId = x.OrderingId,
            ProductPrice = x.ProductPrice,
            ProductTotalPrice = x.ProductTotalPrice
            
        }).ToList();
    }
}
//todo AutoMapper Yapılabilir.