using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Webshop
{
    internal class Film
    {
        public Film(string title, string director, string genre, decimal price )
        {
            Id = new ObjectId();
            this.Title = title;
            this.Director = director;
            this.Genre = genre;
            this.Price = price;
        }

        [BsonId]
        public ObjectId Id { get; set; }


        [BsonElement]
        public string Title { get; set; }

        [BsonElement]
        public string Director { get; set; }

        [BsonElement]
        public string Genre { get; set; }
        [BsonElement]
        public decimal Price { get; set; }
    }
}
