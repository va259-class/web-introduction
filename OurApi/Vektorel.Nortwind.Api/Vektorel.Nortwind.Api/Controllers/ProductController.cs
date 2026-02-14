using Microsoft.AspNetCore.Mvc;
using Vektorel.Northwind.Data.Context;

namespace Vektorel.Nortwind.Api.Controllers;

[ApiController]
[Route("products")]
public class ProductController : ControllerBase
{
    private readonly NorthwindContext context;
    public ProductController(NorthwindContext context)
    {
        this.context = context;
    }
    [HttpGet]
    public IActionResult Products([FromQuery] int page = 1)
    {
        var products = context.Products.Skip((page - 1) * 10)
                                       .Take(10)
                                       .ToList();
        if (products.Count == 0)
        {
            return BadRequest("out of range");
        }
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = context.Products.Where(f => f.ProductID == id)
                                      .FirstOrDefault();
        if (product is null)
        {
            return BadRequest("product is not known");
        }
        return Ok(product);
    }
}
