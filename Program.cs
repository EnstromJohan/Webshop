using MongoDB.Driver;
using MongoDB.Bson;
using System.Runtime.InteropServices.ComTypes;

namespace Webshop
{
     class Program
    {
        static void Main(string[] args)
        {
            //MongoClient dbClient = new MongoClient("");

            //var database = dbClient.GetDatabase("Webshop");
            //var collection = database.GetCollection<BsonDocument>("Films");

            IUI io;
            IDAO filmDao;

            io = new UserIO();
            filmDao = new MongoDAO("", "...");
            ProductController productController = new ProductController(io, filmDao);
            productController.Run();



        }
    }
}