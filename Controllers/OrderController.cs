using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesAutomationAPI.Data;
using SalesAutomationAPI.Models;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly SalesContext _context;

    public OrderController(SalesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _context.Orders.ToList();
        return Ok(orders);
    }

    [HttpPost]
    public IActionResult CreateOrder([FromBody] Order order)
    {
        var product = _context.Products.SingleOrDefault(p => p.Id == order.ProductId);
        if (product == null)
            return BadRequest("Product not found.");

        if (product.Stock < order.Quantity)
            return BadRequest("Insufficient stock.");

        order.TotalPrice = order.Quantity * product.Price;
        product.Stock -= order.Quantity;

        _context.Orders.Add(order);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);
    }
}
