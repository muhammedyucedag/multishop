﻿namespace MultiShop.Order.Domain.Entities;

public class OrderDetail
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public int OrderingId { get; set; }
    
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    
    //Relations
    public Ordering Ordering { get; set; }
}