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

        public void Delete(ObjectId id)
        {
            var filter = Builders<Film>.Filter.Eq("_id",id);
            _collection.DeleteOne(filter);
        }

        public List<Film> ReadAll()
        {
            return _collection.Find(new BsonDocument()).ToList();
            //var result = _collection.Find(new BsonDocument()).ToList();
            //return new List<Film>(result.ToList());

        }


        public Film ReadOne(string title)
        {
            var filter = Builders<Film>.Filter.Eq("title", title);
            return _collection.Find(filter).FirstOrDefault();
        }



        public void Update(ObjectId id, Film film)
        {
            var filter = Builders<Film>.Filter.Eq("id", film.Id);
            var update = Builders<Film>.Update
                .Set(f => f.Title, film.Title)
                .Set(f => f.Director, film.Director)
                .Set(f => f.Genre, film.Genre)
                .Set(f => f.Price, film.Price);

            var result = _collection.UpdateOne(filter, update);
        }
    }
}