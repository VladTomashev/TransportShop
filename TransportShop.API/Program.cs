using TransportShop.DAL.EF;

DataContext db = new DataContext();
foreach (var p in db.Products)
{
    Console.WriteLine($"Продукт {p.name} в категории {p.category.name}");
}