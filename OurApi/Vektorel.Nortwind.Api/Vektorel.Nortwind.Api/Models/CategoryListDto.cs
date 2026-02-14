namespace Vektorel.Nortwind.Api.Models;

public class CategoryListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class CategoryDetailDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
