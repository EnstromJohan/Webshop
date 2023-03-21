
namespace Webshop
{
    internal interface IDAO
    {
        void Create(Film film);
        List<Film> GetAll();
        Film GetOne(string title);
        void Update(string id, Film film);
        void Delete(string title);
    }
}
