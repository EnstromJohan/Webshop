using MongoDB.Bson;
using MongoDB.Driver;


namespace Webshop
{
    internal class MongoDAO : IDAO
    {
        private IMongoCollection<Film> _collection;

        public MongoDAO(string db, string MongoURI)
        {
            var client = new MongoClient(MongoURI);
            var database = client.GetDatabase("Webshop");
            _collection = database.GetCollection<Film>("Films");
        }

        public void Create(Film film)
        {
            _collection.InsertOne(film);
        }

        public void Delete(string title)
        {
            var filter = Builders<Film>.Filter.Eq("title", title);
            _collection.DeleteOne(filter);
        }

        public List<Film> GetAll()
        {
            var result = _collection.Find(new BsonDocument()).ToList();
            return new List<Film>(result.ToList());

        }


        public Film GetOne(string title)
        {
            var filter = Builders<Film>.Filter.Eq("title", title);
            return _collection.Find(filter).FirstOrDefault();
        }



        public void Update(string id, Film film)
        {
            var filter = Builders<Film>.Filter.Eq("id", film.Id);
            var update = Builders<Film>.Update
                .Set(f => f._title, film._title)
                .Set(f => f._director, film._director)
                .Set(f => f._genre, film._genre)
                .Set(f => f._price, film._price);

            var result = _collection.UpdateOne(filter, update);
        }
    }
}