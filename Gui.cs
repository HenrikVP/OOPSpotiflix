namespace OOPSpotiflix
{
    internal class Gui
    {
        private List<Movie> movieList = new();
        public Gui()
        {
            while (true)
            {
                Menu();
            }

        }

        private void Menu()
        {
            Console.WriteLine("\nMENU\n1 for movies\n2 for series\n3 for music\n4 for save\n5 for load");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    MovieMenu();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    break;
                case ConsoleKey.NumPad4:
                case ConsoleKey.D4:
                    SaveData();
                    break;
                case ConsoleKey.NumPad5:
                case ConsoleKey.D5:
                    break;
                default:
                    break;
            }
        }
        private void SaveData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = System.Text.Json.JsonSerializer.Serialize(movieList);
            File.WriteAllText(path + "/movielist.json", json);
        }

        private void MovieMenu()
        {
            Console.WriteLine("\nMOVIE MENU\n1 for list of movies\n2 for search movies\n3 for add new movie");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    ShowMovieList();
                    break;
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    SearchMovie();
                    break;
                case ConsoleKey.NumPad3:
                case ConsoleKey.D3:
                    AddMovie();
                    break;

                default:
                    break;
            }
        }

        private void AddMovie()
        {
            Movie movie = new Movie();
            movie.Title = GetString("Title: ");
            movie.Length = GetLength();
            movie.Genre = GetString("Genre: ");
            movie.ReleaseDate = GetReleaseDate();
            movie.WWW = GetString("WWW: ");

            ShowMovie(movie);
            Console.WriteLine("Confirm adding to list (Y/N)");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Y:
                    movieList.Add(movie);
                    break;
                default:
                    break;
            }
        }

        private void SearchMovie()
        {
            Console.Write("Search: ");
            string? search = Console.ReadLine();
            foreach (Movie movie in movieList)
            {
                if (search != null)
                {
                    if (movie.Title.Contains(search) || movie.Genre.Contains(search))
                        ShowMovie(movie);
                }
            }
        }

        private TimeOnly GetLength()
        {
            TimeOnly to;
            do
            {
                Console.Write("Length (hh:mm:ss): ");
            }
            while (!TimeOnly.TryParse(Console.ReadLine(), out to));
            return to;
        }
        private DateOnly GetReleaseDate()
        {
            DateOnly dateOnly;
            do
            {
                Console.Write("Release Date (dd/mm/yyyy): ");
            }
            while (!DateOnly.TryParse(Console.ReadLine(), out dateOnly));
            return dateOnly;
        }
        private string GetString(string type)
        {
            string? input;
            do
            {
                Console.Write(type);
                input = Console.ReadLine();
            }
            while (input == null || input == "");
            return input;
        }
        private void ShowMovie(Movie m)
        {
            Console.WriteLine($"{m.Title} {m.Length} {m.Genre} {m.ReleaseDate} {m.WWW}");
        }

        private void ShowMovieList()
        {
            foreach (Movie m in movieList)
            {
                ShowMovie(m);
            }
        }
    }
}
