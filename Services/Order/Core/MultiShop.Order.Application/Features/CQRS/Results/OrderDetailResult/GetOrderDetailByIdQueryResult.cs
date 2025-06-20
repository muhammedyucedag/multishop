﻿namespace MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResult;

public class GetOrderDetailByIdQueryResult
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int OrderingId { get; set; }
    
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
}