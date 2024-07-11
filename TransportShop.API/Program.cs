using TransportShop.DAL.Entities;
using TransportShop.DAL.Repositories;

class Program
{
    static async Task Main(string[] args)
    {
        await TestRepositoryAsync();
    }

    public static async Task TestRepositoryAsync()
    {
        Repository<Product> prodRep = new Repository<Product>();

        IEnumerable<Product> products = await prodRep.GetAllAsync();

        List<Product> productList = products.ToList();

        foreach (var product in productList)
        {
            Console.WriteLine($"Product ID: {product.Id}, Product Name: {product.Name}, Product Category: {product.Category.Name}");
        }
    }
}