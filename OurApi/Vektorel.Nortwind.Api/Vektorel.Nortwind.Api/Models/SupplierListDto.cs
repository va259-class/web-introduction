using System.ComponentModel.DataAnnotations;

namespace Vektorel.Nortwind.Api.Models;

public class SupplierListDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
}


public class NewSupplierDto
{
    [Required]
    [MaxLength(32)]
    [MinLength(5)]
    public string Name { get; set; }
    [Required]
    public string Manager { get; set; }
    [MaxLength(16)]
    public string Country { get; set; }
    [MaxLength(16)]
    public string City { get; set; }
    [Required]
    public string Phone { get; set; }
}