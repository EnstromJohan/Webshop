using MongoDB.Bson;
using System.Diagnostics;

namespace Webshop
{
    internal class ProductController
    {
        private IUI io;
        private IDAO filmDao;

        public ProductController(IUI io, IDAO filmDao)
        {
            this.io = io;
            this.filmDao = filmDao;

        }

        public void Run()
        {
            bool isOn = true;

            while (isOn)
            {
                io.Output("1. Lägg till  film");
                io.Output("2. Hämta filmer");
                io.Output("3. Hämta film efter titel");
                io.Output("4. Uppdatera film");
                io.Output("5. Ta bort film");
                io.Output("6. Stäng applikationen");
                io.Output("Vad vill du göra?");
                int input = int.Parse(io.Input());
                switch (input)
                {
                    case 1:
                        AddFilm();
                        break;
                    case 2:
                        GetFilms();
                        break;
                    case 3:
                        GetFilm();
                        break;
                    case 4:
                        UpdateFilm();
                        break;
                    case 5:
                        DeleteFilm();
                        break;
                    case 6:
                        io.Exit();
                        break;
                    default:
                        io.Output("Inmatning fel");
                        break;

                }
            }
        }

        private void AddFilm()
        {
            string title;
            string director;
            string genre;
            decimal price;

            io.Output("Ange titel: ");
            title = io.Input();
            io.Output("Ange regissörens namn: ");
            director = io.Input();
            io.Output("Ange genre: ");
            genre = io.Input();
            io.Output("Ange pris: ");
            price = Convert.ToDecimal(io.Input());

            Film film = new Film(title, director, genre, price);
            filmDao.Create(film);

            io.Output("Film lades till");
        }

        private void GetFilms()
        {
            var films = filmDao.ReadAll();
            filmDao.ReadAll()
                .ForEach(films => { 
                io.Output(films.Title); 
                io.Output(films.Director); 
                io.Output(films.Genre); 
                io.Output(films.Price.ToString()); });

        }

        private void GetFilm()
        {
            io.Output("Vilken film vill du hämta?");
            string title = io.Input();
            var result = filmDao.ReadOne(title);

            if (result == null)
            {
                io.Output("Ingen film hittades");
            }
            else
            {
                io.Output(result.Title); io.Output(result.Director); io.Output(result.Genre); io.Output(result.Price.ToString()) ;
            }

        }

        private void UpdateFilm()
        {
            var films = filmDao.ReadAll();
            filmDao.ReadAll()
                .ForEach(films =>
                {
                    io.Output(films.Title);
                    io.Output(films.Id.ToString());
                });

                io.Output("Skriv in id för filmen du vill uppdatera");
            string id = io.Input();

            var objectId = ObjectId.Parse(id);

           

            if (id == null)
            {
                io.Output("Filmen hittades inte");
            }
            else
            {
                io.Output("Skriv in info om filmen");

                io.Output("Titel: ");
                string title = io.Input();

                io.Output("Regissör: ");
                string director = io.Input();

                io.Output("Genre: ");
                string genre = io.Input();

                io.Output("Pris: ");
                decimal price = decimal.Parse(io.Input());

                Film film = new Film(title, director, genre, price);
                filmDao.Update(objectId, film);

                io.Output("Film uppdaterad");
            }
        }

        private void DeleteFilm()
        {
            var films = filmDao.ReadAll();
            filmDao.ReadAll()
                .ForEach(films =>
                {
                    io.Output(films.Title);
                    io.Output(films.Id.ToString());
                });
                
            io.Output("Skriv in id på filmen du vill ta bort");
            string id = io.Input();
            var objectId = ObjectId.Parse(id);
            filmDao.Delete(objectId);

            io.Output("Filmen togs bort");

        }


    }


}
