using System;
using System.Collections.Generic;
using System.Linq;


namespace SakutinTutorialLinQEnum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Enum
            List<Game> games = new List<Game>
            {
                new Game("Black & White", Genre.Strategy),
                new Game("The Witcher 3", Genre.RPG),
                new Game("Civilization 5", Genre.Strategy),
                new Game("Obscure", Genre.Horror)
            };

            foreach (Game game in games)
            {
                game.ShowInfo();
            }

            Console.WriteLine((Genre)3);
            Console.WriteLine(new string('-', 25));

            //LinQ введение
            //Язык запросов к источникам данных
            //intellisense - подсказки, автозаполнения (как пример)
            List<Player> players = new List<Player>
            {
                new Player("Jim", 100),
                new Player("Jack", 100),
                new Player("Abraham", 220),
                new Player("Sarah", 212),
                new Player("Zeke", 58),
                new Player("Solomon", 678)
            };
            List<Player> players2 = new List<Player>
            {
                new Player("Sergei", 566),
                new Player("Boris", 756),
            };

            //как раньше бы делали
            List<Player> filteredPlayers = new List<Player>();

            foreach (var player in players)
            {
                if (player.Level > 99)
                    filteredPlayers.Add(player);
            }

            foreach (var player in filteredPlayers)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine("-----------With LinQ---------");

            //как делается с linq
            var filteredPlayersLinq = from Player player in players where player.Level > 99 select player; //можно обратиться и к player.Level и player.Login
            foreach (var player in filteredPlayersLinq)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine(new string('-', 25));

            //Методы расширения LinQ
            var filteredPlayersLinq2 = players.Where(player => player.Level > 200).Select(player => player.Level);
            foreach (var player in filteredPlayersLinq2)
            {
                Console.WriteLine(player);
            }

            Console.WriteLine(new string('-', 25));

            var filteredPlayersLinq3 = players.Where(player => player.Login.ToUpper().StartsWith("S"));
            foreach (var player in filteredPlayersLinq3)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine(new string('-', 25));
            var orderedPlayersByLevel = players.OrderBy(player => player.Level);
            foreach (var player in orderedPlayersByLevel)
            {
                Console.WriteLine(player.Level);
            }

            Console.ReadKey();
            Console.Clear();

            //Нахождение Максимума и минимума
            var maxLevelPlayer = players.Max(player => player.Level);
            Console.WriteLine(maxLevelPlayer);

            Console.WriteLine(new string('-', 25));

            //создание объекта анонимного типа
            var newPlayers = from Player player in players select new { Login = player.Login, dateOfBirth = DateTime.Now };
            foreach (var player in newPlayers)
            {
                Console.WriteLine(player.Login + " " + player.dateOfBirth);
            }

            Console.WriteLine(new string('-', 25));

            var newPlayers2 = players.Select(player => new { Login = player.Login, dateOfBirth = "пятница" });
            foreach (var player in newPlayers2)
            {
                Console.WriteLine(player.Login + " " + player.dateOfBirth);
            }

            Console.WriteLine(new string('-', 25));

            //Соединение коллекций
            var unitedTeam = players2.Union(players);

            foreach (var player in unitedTeam)
            {
                Console.WriteLine(player.Login);
            }

            Console.ReadKey();
            Console.Clear();

            //Take и Skip
            var filteredPlayersSkip = players.Skip(1);
            foreach (var player in filteredPlayersSkip)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine(new string('-', 25));

            var filteredPlayersTake = players.Take(1);
            foreach (var player in filteredPlayersTake)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine(new string('-', 25));

            //TakeWhile и SkipWhile

            var filteredPlayersSkipWhile = players.SkipWhile(player => player.Login.ToUpper().StartsWith("J"));
            foreach (var player in filteredPlayersSkipWhile)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine(new string('-', 25));

            var filteredPlayersTakeWhile = players.TakeWhile(player => player.Login.ToUpper().StartsWith("J")).ToList(); 
            foreach (var player in filteredPlayersTakeWhile)
            {
                Console.WriteLine(player.Login);
            }

            Console.WriteLine(new string('-', 25));

            //Тип
            //преобразование последовательности
            Console.WriteLine(filteredPlayersTakeWhile.GetType());
            Console.WriteLine(filteredPlayersSkipWhile.GetType());
            Console.WriteLine(filteredPlayersSkipWhile.ToString().GetType());
        }

        enum Genre//Тип значение определенный набором именованных констант
        {
            Strategy = 1,
            RPG,
            Horror
        }

        class Game
        {
            private string _title;
            private Genre _genre;

            public Game(string title, Genre genre)
            {
                _title = title;
                _genre = genre;
            }

            public void ShowInfo()
            {
                Console.WriteLine($"Это игра: {_title}, её жанр {_genre}");
            }
        }

        class Player
        {
            public string Login { get; private set; }
            public int Level { get; private set; }

            public Player(string login, int level)
            {
                Login = login;
                Level = level;
            }
        }
    }
}
