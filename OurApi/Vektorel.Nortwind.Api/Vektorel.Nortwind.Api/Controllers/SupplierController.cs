using Microsoft.AspNetCore.Mvc;
using Vektorel.Northwind.Data.Context;
using Vektorel.Northwind.Data.Entities;
using Vektorel.Nortwind.Api.Models;

namespace Vektorel.Nortwind.Api.Controllers;

[ApiController]
[Route("suppliers")]
public class SupplierController : ControllerBase
{
    private readonly NorthwindContext context;

    public SupplierController(NorthwindContext context)
    {
        this.context = context;
    }

    [HttpGet("{page?}")]
    public IActionResult GetSuppliers(int page = 1)
    {
        var suppliers = context.Suppliers.Select(s => new SupplierListDto
                                         {
                                             Id = s.SupplierID,
                                             Name = s.CompanyName,
                                             Country = s.Country,
                                         })
                                         .OrderBy(o => o.Name)
                                         .Skip((page - 1) * 10)
                                         .Take(10)
                                         .ToList();

        return Ok(suppliers);
    }

    [HttpPost]
    public IActionResult CreateSupplier([FromBody] NewSupplierDto payload)
    {
        var entity = new Supplier
        {
            CompanyName = payload.Name,
            ContactName = payload.Manager,
            Country = payload.Country,
            City = payload.City,
            Phone = payload.Phone
        };

        context.Suppliers.Add(entity);
        context.SaveChanges();
        return Ok();
    }
}