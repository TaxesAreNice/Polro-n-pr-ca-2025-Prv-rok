using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DaGame.MapPart
{
    internal class MapEngine
    {

        public List<List<string>> DaWholeMap = new List<List<string>>();

        private int daMapSizeX = 0;
        private int daMapSizeY = 0;
        public void Run()
        {
            GrabDificulty();
        }

        private void GrabDificulty()
        {
            bool dificultyChosing = true;
            bool endingGame = false;
            while (dificultyChosing)
            {
                Console.WriteLine("What dificulty are ya chosing?\n\n" +
                "   Easy(1)\n" +
                "   Medium(2)\n" +
                "   Hard(3)\n" +
                "   Random(random)\n" +
                "   Explain(?)\n" +
                "   End(end)"
                );
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                          daMapSizeX = 15;
                          daMapSizeY = 15;
                          dificultyChosing = false;
                        break;
                    case "2":
                        daMapSizeX = 10;
                        daMapSizeY = 10;
                        dificultyChosing = false;
                        break;
                    case "3":
                        daMapSizeX = 5;
                        daMapSizeY = 5;
                        dificultyChosing = false;
                        break;
                    case "random":
                        RandomDificulty();
                        dificultyChosing = false;
                        break;
                    case "?":
                        Console.WriteLine("\nBasicly, harder dificulty = more harder enemies, less loot and smaller map" +
                            "Easy - 15x15 (225 rooms)\n" +
                            "Medium - 10x10 (100 rooms)\n" +
                            "Hard - 5x5 (25 rooms)\n" +
                            "Random - You chose da rooms. Max = 50x50, more rooms may lag this program btw\n" +
                            "\nPress enter to continue");
                        string? skip = Console.ReadLine();
                        break;
                    case "end":
                        Console.WriteLine("Exiting the game. Bye-Bye!");
                        endingGame = true;
                        dificultyChosing = false;
                        break;
                    default:
                        Console.WriteLine("C'mon bro, you got this!\n\nPress enter to continue");
                        skip = Console.ReadLine();
                        break;
                }

                if (endingGame = false)
                {
                    if (dificultyChosing = false)
                    {
                        Console.Clear();
                        LoadingDaMaps();
                    }
                }
            }
        }
        private void RandomDificulty()
        {
            Console.WriteLine("da Lenght? (x)");
            int userInputX = int.Parse(Console.ReadLine());
            if (userInputX > 50)
            {
                Console.WriteLine("Bro, chill. Max size is 50. Setting to max size.\n\nPress enter to continue");
                daMapSizeX = 50;
                string? skip = Console.ReadLine();
            }
            else
            {
                daMapSizeX = userInputX;
            }    
            Console.WriteLine("da Hight? (y)");
            int userInputY = int.Parse(Console.ReadLine());

            if (userInputY > 50)
            {
                Console.WriteLine("Bro, chill. Max size is 50. Setting to max size.\n\nPress enter to continue");
                daMapSizeY = 50;
                string? skip = Console.ReadLine();
            }
            else
            {
                daMapSizeY = userInputY;
            }
        }

        private void LoadingDaMaps()
        {
            


        }
    }
}
