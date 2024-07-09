using TransportShopAPI.Classes;

DataContext db = new DataContext();
foreach (var p in db.Products)
{
    Console.WriteLine(p.name);
}