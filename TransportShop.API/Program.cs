using TransportShop.DAL.EF;

DataContext db = new DataContext();
foreach (var p in db.Products)
{
    Console.WriteLine($"������� {p.name} � ��������� {p.category.name}");
}