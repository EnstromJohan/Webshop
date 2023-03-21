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
                int input = int.Parse(Console.ReadLine());
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
            price = Convert.ToInt32(io.Input());

            Film film = new Film(title, director, genre, price);
            filmDao.Create(film);

            io.Output("Film lades till");
        }

        private void GetFilms()
        {
            var films = filmDao.GetAll();

            foreach (var film in films)
            {
                io.Output(film.ToString());
            }
        }

        private void GetFilm()
        {
            io.Output("Vilken film vill du hämta?");
            string title = io.Input();
            var result = filmDao.GetOne(title);

            if (result == null)
                io.Output("Ingen film hittades");
            else
                io.Output(result.ToString());
            Console.Read();

        }

        private void UpdateFilm()
        {
            var films = filmDao.GetAll();

            foreach (var movie in films)
            {
                io.Output(movie.ToString());
            }

            io.Output("Skriv in id för filmen du vill uppdatera");
            string id = Console.ReadLine();

            var film = filmDao.GetOne(id);

            if (film == null)
            {
                io.Output("Filmen hittades inte");
            }
            else
            {
                io.Output("Skriv in info om filmen");

                io.Output("Titel: ");
                string title = Console.ReadLine();

                io.Output("Regissör: ");
                string director = Console.ReadLine();

                io.Output("Genre: ");
                string genre = Console.ReadLine();

                io.Output("Pris: ");
                decimal price = decimal.Parse(Console.ReadLine());

                film._title = title;
                film._director = director;
                film._genre = genre;
                film._price = price;

                filmDao.Update(id, film);

                io.Output("Film uppdaterad");
            }
        }

        private void DeleteFilm()
        {
            var films = filmDao.GetAll();

            foreach (var film in films)
            {
                io.Output(film.ToString());
            }

            io.Output("Skriv in titeln du vill ta bort");
            string title = Console.ReadLine();

            filmDao.Delete(title);
        }


    }


}
