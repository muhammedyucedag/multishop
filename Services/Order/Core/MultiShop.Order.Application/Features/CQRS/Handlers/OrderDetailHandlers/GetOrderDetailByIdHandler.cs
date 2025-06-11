using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailByIdHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
    {
        var value = await _repository.GetByIdAsync(query.Id);
        
        return new GetOrderDetailByIdQueryResult
        {
            Id = value.Id,
            ProductAmount = value.ProductAmount,
            ProductName = value.ProductName,
            OrderingId = value.OrderingId,
            ProductPrice = value.ProductPrice,
            ProductId = value.ProductId,
            ProductTotalPrice = value.ProductTotalPrice
        };
    }
}
//todo AutoMapper Yapılabilir