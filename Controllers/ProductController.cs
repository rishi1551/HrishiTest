using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesAutomationAPI.Data;
using SalesAutomationAPI.Models;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly SalesContext _context;

    public ProductController(SalesContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _context.Products.ToList();
        return Ok(products);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateProduct([FromBody] Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }
}
