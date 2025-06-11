using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderDetailController : ControllerBase
{
    private readonly GetOrderDetailByIdHandler _getOrderDetailByIdHandler;
    private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
    private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;

    public OrderDetailController(
        GetOrderDetailByIdHandler getOrderDetailByIdHandler, 
        GetOrderDetailQueryHandler getOrderDetailQueryHandler, 
        CreateOrderDetailCommandHandler createOrderDetailCommandHandler, 
        RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler, 
        UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
    {
        _getOrderDetailByIdHandler = getOrderDetailByIdHandler;
        _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
        _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
    }

    [HttpGet]
    public async Task<IActionResult> OrderDetailList()
    {
        var values = await _getOrderDetailQueryHandler.Handle();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetailById(int id)
    {
        var values = await _getOrderDetailByIdHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
    {
        await _createOrderDetailCommandHandler.Handle(command);
        return Ok("Sipariş detayı başarıyla oluşturuldu.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
        return Ok("Sipariş detayı başarıyla silindi.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
    {
        await _updateOrderDetailCommandHandler.Handle(command);
        return Ok("Sipariş detayı başarıyla güncellendi.");
    }
}