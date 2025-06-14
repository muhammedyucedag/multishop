﻿using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var values = await _repository.GetByIdAsync(command.Id);
        
        values.OrderingId = command.OrderingId;
        values.ProductId = command.ProductId;
        values.ProductAmount = command.ProductAmount;
        values.ProductName = command.ProductName;
        values.ProductPrice = command.ProductPrice;
        values.ProductTotalPrice = command.ProductTotalPrice;
        
        await _repository.UpdateAsync(values);
    }
}
//todo AutoMapper Yapılabilir