using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop
{
    internal class Film
    {
        public Film(string title, string director, string genre, decimal price )
        {
            Id = new ObjectId();
            _title = title;
            _director = director;
            _genre = genre;
            _price = price;
        }

        [BsonId]
        public ObjectId Id { get; set; }


        [BsonElement]
        public string _title { get; set; }

        [BsonElement]
        public string _director { get; set; }

        [BsonElement]
        public string _genre { get; set; }
        [BsonElement]
        public decimal _price { get; set; }
    }
}
