namespace Vektorel.Northwind.Data.Entities;

public class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }
    public int CategoryID { get; set; }
    public int SupplierID { get; set; }
}
