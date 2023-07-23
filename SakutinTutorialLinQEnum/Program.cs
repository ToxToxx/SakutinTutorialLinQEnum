using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //LinQ
        }
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
}
