using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaGame.MapPart
{
    internal class MapEngine
    {
        Random random = new Random();

        public List<List<List<string>>> DaMap = new List<List<List<string>>>();
 
        private bool itsThere = false;

        private int bosininy = 10;

        private int neun = 9;

        public int daBossY = 0;
        public int daBossX = 0;

        private int bosinichancinyY = 0;
        private int bosinichancinyX = 0;

        private List<string> Stuff = new List<string>() { "Item", "x", "Zombie", "Orc", "StoneGolem"};

        public int daMapSizeX = 0;
        public int daMapSizeY = 0;

        private string daCurrentMonster = "";
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
                string? userInput = Console.ReadLine();
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

                if (!endingGame)
                {
                    if (!dificultyChosing)
                    {
                        Console.Clear();
                        DaBossPlacer();
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
            bool containsHim = false;
            bool notDoneYet = true;
            int i = 0;
            

            while (i < daMapSizeY)
            {
                DaMap.Add(new List<List<string>>());

                
                for (int j = 0; j < daMapSizeX; j++)
                {
                    DaMap[i].Add(new List<string>());
                    
 
                        for (int k = 0; k < neun; k++)
                        {

                            RandomItemGenerator(containsHim);
                            DaMap[i][j].Add(daCurrentMonster);
                        }
                    }
                    
                

                i++;
               
                
            }

            // i = the y's
            // j = the x's
            // k = the items
            
            /*
                        i = 0;
                        int h = 0; //h = j, btw
                        while (i < daMapSizeY)
                        {
                            if (h == 15)
                            {
                                h = 14;
                            }
                            Console.WriteLine(i + "Y");
                            foreach (var item in DaMap[i][h])
                            {
                                if (item == "Boss")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"x:{h + 1}");
                                    Console.WriteLine(item);
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.WriteLine(h + 1);
                                    Console.WriteLine(item);
                                }
                                h++;

                            }
                            h = 0; i++;

                        }
            */
            
        }

        public void RandomItemGenerator(bool containsHim)
        {
                daCurrentMonster = Stuff[random.Next(0, Stuff.Count)].ToString();
        }
        public void SendingTheBossPosition(int y, int x)
        {
            Console.WriteLine($"Boss at: y:{y},x:{x}");
        }
        

        public List<string> DaBossPlacer()
        {
        List<string> fan = new List<string>();

            daBossY = random.Next(0, daMapSizeY - 1);

            if (daBossY == daMapSizeY - 1)
            {
                daBossX = random.Next(0, daMapSizeX - 1);
            }
            else if (daBossY == 0)
            {
                daBossX = random.Next(0, daMapSizeX - 1);
            }
            else
            {
                daBossX = random.Next(0, 1);

                if (daBossX == 1)
                {
                    daBossX = daMapSizeX - 1;
                }
            }

            fan.Add(daBossY.ToString());
            fan.Add(daBossX.ToString());

            if (daBossY == 0)
            {
                fan.Add("down");
            }
            else if (daBossY == daMapSizeX - 1)
            {
                fan.Add("up");
            }

            if (daBossX == 0)
            {
                fan.Add("right");
            }
            else if (daBossX == daMapSizeY - 1)
            {
                fan.Add("left");
            }


            return fan;
        }
        
    }
}