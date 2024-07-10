using TransportShop.DAL.EF;

DataContext db = new DataContext();
foreach (var p in db.Products)
{
    Console.WriteLine($"Продукт {p.Name} в категории {p.Category.Name}");
}