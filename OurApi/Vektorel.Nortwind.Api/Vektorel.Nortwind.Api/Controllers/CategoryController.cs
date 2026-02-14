using Microsoft.AspNetCore.Mvc;
using Vektorel.Northwind.Data.Context;
using Vektorel.Nortwind.Api.Models;

namespace Vektorel.Nortwind.Api.Controllers;

[ApiController]
[Route("categories")]
public class CategoryController : ControllerBase
{
    private readonly NorthwindContext context;

    public CategoryController(NorthwindContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        var categories = context.Categories.Select(c => new CategoryListDto
                                            {
                                                Id = c.CategoryID,
                                                Name = c.CategoryName
                                            })
                                           .ToList();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetDetails(int id)
    {
        var category = context.Categories.Where(c => c.CategoryID == id)
                                         .Select(c => new CategoryDetailDto
                                         {
                                             Id = c.CategoryID,
                                             Name = c.CategoryName,
                                             Description = c.Description
                                         })
                                         .FirstOrDefault();

        if (category is null)
        {
            return BadRequest("undefined category");
        }

        return Ok(category);
    }

    [HttpGet("{id}/photo")]
    public IActionResult GetPhoto(int id, [FromQuery] bool download = false)
    {
        var photo = context.Categories.Where(f => f.CategoryID == id)
                                      .Select(c => c.Picture)
                                      .FirstOrDefault();
        
        //Northwind fotoğrafları özel formatta olduğu için eklemek zorunda kaldık
        var imageBytes = photo.Skip(78).ToArray();

        if (!download)
        {
            Response.Headers.Append("Content-Disposition", "inline");
            return File(imageBytes, "image/png");
        }

        return File(imageBytes, "image/png", $"{id}.png");
    }
}