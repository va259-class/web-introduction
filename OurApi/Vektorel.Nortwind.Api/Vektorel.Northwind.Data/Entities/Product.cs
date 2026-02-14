using System.ComponentModel.DataAnnotations.Schema;

namespace Vektorel.Northwind.Data.Entities;

[Table("Products")]
public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public int CategoryID { get; set; }
    public int SupplierID { get; set; }
}