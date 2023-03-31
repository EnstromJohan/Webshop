
using MongoDB.Bson;

namespace Webshop
{
    internal interface IDAO
    {
        void Create(Film film);
        List<Film> ReadAll();
        Film ReadOne(ObjectId id);
        void Update(ObjectId id, Film film);
        void Delete(ObjectId id);
    }
}
