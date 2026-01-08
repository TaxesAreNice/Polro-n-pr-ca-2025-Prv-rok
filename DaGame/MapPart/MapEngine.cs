using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using static System.Net.Mime.MediaTypeNames;

namespace DaGame.MapPart
{
    
    internal class MapEngine
    {
        private const int V = 12;
        Random random = new Random();

        public List<List<List<string>>> DaMap = new List<List<List<string>>>();

        private List<string> daBackUpMap = new List<string>();
        private List<string> daBackUpSettings = new List<string>();

        private bool itsThere = false;

        private int bosininy = 10;

        private string daGameSettings = "";

        private int neun = 9;

        public bool firstlyRuniny = true;

        string daFileSettingsPath = @"";

        private string daFilePath = @"";
        
        private string dafileMapPath = @"";

        public int daBossY = 0;
        public int daBossX = 0;

        private int bosinichancinyY = 0;
        private int bosinichancinyX = 0;

        private List<string> Stuff = new List<string>() { "Item", "x", "Zombie", "Orc", "StoneGolem" };

        public int PlayerBoxPosition = 4;

        public int daMapSizeX = 0;
        public int daMapSizeY = 0;

        private string daCurrentMonster = "";

        public void SettingThePlayerBoxLocation()
        {

        }
        public void Run()
        {
            bool FirstRun = true;

            DaPathChoser();
            FirstRun = DaFileChecker(FirstRun);

            if (FirstRun)
            {
                GrabDificulty();

            }
            else
            {
                GettingDaMapBack();
            }
        }
        private bool DaFileChecker(bool FirstRun)
        {
            try
            {
                File.ReadAllText(dafileMapPath);
                FirstRun = false;
                firstlyRuniny = false;
                Console.WriteLine("ah shit, here we go again");
            }
            catch (Exception)
            {
                FirstRun = true;
                Console.WriteLine("first time");
                string? u = Console.ReadLine();
            }
            return FirstRun;
        }
        
        private void DaPathChoser()
        {
            Console.WriteLine("Chose a file path(even if you alredy did this)\n   Just create a folder somewhere and grab the path from there");
            daFilePath = Console.ReadLine();
            dafileMapPath = daFilePath + "/DaMap.txt";
            daFileSettingsPath = daFilePath + "/DaGameSettings.txt";

            Console.Clear();

        }
        private void GettingDaMapBack()
        {
            foreach (string item in File.ReadAllLines(dafileMapPath))
            {
                daBackUpMap.Add(item);
            }
            foreach (string item in File.ReadAllLines(daFileSettingsPath))
            {
                daBackUpSettings.Add(item);
            }
            daMapSizeX = int.Parse(daBackUpSettings[0]);
            daMapSizeY = int.Parse(daBackUpSettings[1]);
            PlayerBoxPosition = int.Parse(daBackUpSettings[12]);

            int i = 0;
            int kk = 0;

            while (i < daMapSizeY)
            {
                DaMap.Add(new List<List<string>>());

                for (int j = 0; j < daMapSizeX; j++)
                {
                    DaMap[i].Add(new List<string>());

                    for (int k = 0; k < neun; k++)
                    {
                        daCurrentMonster = daBackUpMap[kk];
                        DaMap[i][j].Add(daCurrentMonster);
                        daCurrentMonster = "";
                        kk++;
                    }
                }
                i++;
            }
            
        }
        public void UpdatingDaXandYForDaRooms(int xF, int yF)
        {
            List<string> allDaSettingsItems = new List<string>();
            string daWholeSettingsText = "";

            // make sure it reads every line and then it puts it into a list and then puts the first 3 lines back and then swaps the 4th and 5th one and then keeps the same 6th one to the 9th one, cause 7 and 8 are the player position in da box
            foreach (string item in File.ReadAllLines(daFileSettingsPath))
            {
                allDaSettingsItems.Add(item);
            }
            allDaSettingsItems[3] = xF.ToString();
            allDaSettingsItems[4] = yF.ToString();

            foreach (string item in allDaSettingsItems)
            {
                daWholeSettingsText += item + "\n";
            }

            File.WriteAllText(daFileSettingsPath, daWholeSettingsText);
        }
        public List<int> GettingDaXandYForDaRooms()
        {
            List<string> allDaSettingsItems = new List<string>();
            List<int> daWholeSettingsText = new List<int>();

            // make sure it reads every line and then it puts it into a list and then puts the first 3 lines back and then swaps the 4th and 5th one and then keeps the same 6th one to the 9th one, cause 7 and 8 are the player position in da box
            foreach (string item in File.ReadAllLines(daFileSettingsPath))
            {
                allDaSettingsItems.Add(item);
            }

            daWholeSettingsText.Add(Convert.ToInt32(allDaSettingsItems[3]));
            daWholeSettingsText.Add(Convert.ToInt32(allDaSettingsItems[4]));
            daWholeSettingsText.Add(PlayerBoxPosition);

            return daWholeSettingsText;
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
                        daMapSizeX = 15 ;
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
        public void SettingDaPlayerBoxPosition()
        {
            //List<string> ov = new List<string>();

            File.AppendAllText(daFileSettingsPath, "4\n");
            /*
foreach (var item in File.ReadAllLines(daFileSettingsPath))
{
    ov.Add(item);
}
Console.WriteLine(ov[0]);
*/
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
            string daMapText = "";
            daGameSettings += daMapSizeX.ToString() + "\n" + daMapSizeY.ToString() + "\n\n";

            daGameSettings += 0.ToString() + "\n" + 0.ToString() + "\n\n"; // da position of da player in da Map

            daGameSettings += 4.ToString() + "\n\n"; // da position of da player in da box, thats da middle btw

            File.WriteAllText(dafileMapPath, daMapText);
            File.WriteAllText(daFileSettingsPath, daGameSettings);

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
                        RandomItemGenerator();
                        daMapText = daCurrentMonster;
                        DaMap[i][j].Add(daCurrentMonster);
                        File.AppendAllText(dafileMapPath, daMapText + "\n");
                        daMapText = "";
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


        public void RandomItemGenerator()
        {
            daCurrentMonster = Stuff[random.Next(0, Stuff.Count)].ToString();
        }
        public void SendingTheBossPosition(int y, int x)
        {
            Console.WriteLine($"Boss at: y:{y},x:{x}");
        }
        private int ff = 0;
        private List<string> DaBossSaver = new List<string>();
        public void SavingDaBossLocation(string item, int number)
        {
            ff += number;
            if (ff == 3)
            {
                DaBossSaver.Add(item);
                SavingDaBoss();
            }
            else
            {
                DaBossSaver.Add(item);
            }
        }
        private void SavingDaBoss()
        {
            string text = "";

            foreach (string item in DaBossSaver)
            {
                text += item + "\n";
            }
            text += "\n";
            File.AppendAllText(daFileSettingsPath, text);
        }
        public List<string> BossReader()
        {
            List<string> fan = new List<string>();
            int daStarterPosition = 8;
            int currentPosition = 0;
            int daEndPosition = 10;

            foreach (string item in File.ReadAllLines(daFileSettingsPath))
            {
                if (currentPosition >= daStarterPosition || currentPosition != daEndPosition)
                {
                    fan.Add(item.ToString());
                    currentPosition++;
                }
                else
                {
                    currentPosition++;
                }
            }
            return fan;
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
            /*
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
            */
            if (daBossY == daMapSizeY - 1 && daBossX == daMapSizeX - 1)
            {
                fan.Add("up");
                fan.Add("left");
            }
            else if (daBossY == 0 && daBossX == 0)
            {
                fan.Add("down");
                fan.Add("right");
            }
            else if (daBossY == daMapSizeY - 1 && daBossX == 0)
            {
                fan.Add("up");
                fan.Add("right");
            }
            else if (daBossY == 0 && daBossX == daMapSizeX - 1)
            {
                fan.Add("down");
                fan.Add("up");
            }
            else
            {
                if (daBossX == 0)
                {
                    fan.Add("right");
                }
                else if (daBossX == daMapSizeX - 1)
                {
                    fan.Add("left");
                }
                else if (daBossY == 0)
                {
                    fan.Add("down");
                }
                else if (daBossY == daMapSizeY - 1)
                {
                    fan.Add("up");
                }
                else
                {
                    Console.WriteLine("Cant get da direcion");
                }
            }
        // the: up, down, left and right things are inverted... so yeah, just saying

            return fan;
        }
        public void DaMapSaver(int xX, int yY, int PML)
        {
            int x = xX;
            int y = yY;

            DaMap[y][x][PML] = "x";
            DaMapFileSaver(PML);

        }
        private void DaMapFileSaver(int PML)
        {
            //1. done
            //2. done
            //3. done

            // dafileMapPath
            // daMapSizeX
            DaMapBoxUpdater(PML);
            DaMapUpdater();

        }
        public  void gettingdaBoxPlayerPosition(int PlayerMonsterLocation)
        {
            DaMapBoxUpdater(PlayerMonsterLocation);
        }
        private void DaMapBoxUpdater(int PML)
        {
            List<string> f  = new List<string>();
            List<string> newf = new List<string>();

            int i = 0;

            foreach (string list in File.ReadAllLines(daFileSettingsPath))
            {
                f.Add(list);
            }

            f[12] = PML.ToString();

            if (f.Count > 14)
            {
                while (i < 13)
                {
                    newf.Add(f[i] + "\n");
                    i++;
                }
            }
            else
           {
                foreach (string list in f)
                {
                    newf.Add(list + "\n");
                }
            }
            i = 0;
                File.WriteAllText(daFileSettingsPath, string.Empty);
            foreach (string list in newf)
            {
                File.AppendAllText(daFileSettingsPath, newf[i]);
                i++;
            }
        }
        private void DaMapUpdater()
        {
            string daMapText = "";
            File.WriteAllText(dafileMapPath, "");

            for (int yY = 0; yY < daMapSizeY; yY++)
            {
                for (int xX = 0; xX < daMapSizeX; xX++)
                {
                    foreach (string item in DaMap[yY][xX])
                    {
                        daMapText = item;
                        File.AppendAllText(dafileMapPath, daMapText + "\n");
                        daMapText = "";
                    }
                }
            }
        }
    }
}