using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Polročná_práca_2025_Prvý_rok.FightingPart;
using static System.Net.Mime.MediaTypeNames;

namespace DaGame.MapPart
{

    internal class MapEngine
    {
        public decimal PlayerHP = 100;
        public int PlayerDamage = 10;

        private const int V = 12;
        Random random = new Random();

        public List<List<List<string>>> DaMap = new List<List<List<string>>>();

        private List<string> daBackUpMap = new List<string>();
        private List<string> daBackUpSettings = new List<string>();

        private bool itsThere = false;

        private int bosininy = 10;

        private string daGameSettings = "";

        public List<string> PlayerPlayerInventory = new List<string>();

        private int neun = 9;

        public bool firstlyRuniny = true;

        string daFileSettingsPath = @"";

        private string daFilePath = @"";

        private string dafileMapPath = @"";

        private string daFileInventoryPath = @"";

        private string daFileEXPPath = @"";

        private string daFilePlayerStatsPath = @"";

        public int daBossY = 0;
        public int daBossX = 0;

        private int bosinichancinyY = 0;
        private int bosinichancinyX = 0;

        public int PlayerExp = 0;
        public int PlayerLEVEL = 0;

        private List<string> Stuff = new List<string>() { "Item", "x", "Zombie", "Orc", "StoneGolem" };

        private List<string> PlayerInventory = new List<string>();

        public int PlayerBoxPosition = 4;

        public int PlayerEXP = 0;
        public int PlayerLevel = 0;
        private List<string> InventoryBaby = new List<string>();

        public int daMapSizeX = 0;
        public int daMapSizeY = 0;

        private string daCurrentMonster = "";

        public void SettingThePlayerBoxLocation()
        {

        }
        public bool Run()
        {
            bool FirstRun = true;
            bool endingGame = false;

            DaPathChoser();
            FirstRun = DaFileChecker(FirstRun);

            if (FirstRun)
            {
                endingGame = GrabDificulty();
                return endingGame;
            }
            else
            {
                GettingDaMapBack();
                return endingGame;
            }
        }
        private bool DaFileChecker(bool FirstRun)
        {
            try
            {
                File.ReadAllText(dafileMapPath);
                FirstRun = false;
                firstlyRuniny = false;
            }
            catch (Exception)
            {
                FirstRun = true;
            }
            return FirstRun;
        }

        private void DaPathChoser()
        {
            Console.WriteLine("Chose a file path(even if you alredy did this)\n   Just create a folder somewhere and grab the path from there");
            daFilePath = Console.ReadLine();
            dafileMapPath = daFilePath + "/DaMap.txt";
            daFileSettingsPath = daFilePath + "/DaGameSettings.txt";
            daFileInventoryPath = daFilePath + "/DaInventory.txt";
            daFileEXPPath = daFilePath + "/DaExp.txt";
            daFilePlayerStatsPath = daFilePath + "/DaPlayerStats.txt";

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
            foreach (string item in File.ReadAllLines(daFileInventoryPath))
            {
                PlayerInventory.Add(item);
            }
            foreach (string item in File.ReadAllLines(daFileEXPPath))
            {
                InventoryBaby.Add(item);
            }
            InventoryBaby[0] = PlayerEXP.ToString();
            InventoryBaby[1] = PlayerLevel.ToString();

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
        private bool GrabDificulty()
        {
            bool dificultyChosing = true;
            bool endingGame = false;
            while (dificultyChosing)
            {
                Console.WriteLine("What size are ya chosing?\n\n" +
                "   15x15(1)\n" +
                "   10x10(2)\n" +
                "   5x5(3)\n" +
                "   Custom (custom)\n" +
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
                    case "custom":
                        RandomDificulty();
                        dificultyChosing = false;
                        break;
                    case "?":
                        Console.WriteLine("\n" +
                            "1 - 15x15 (225 rooms)\n" +
                            "2 - 10x10 (100 rooms)\n" +
                            "3 - 5x5 (25 rooms)\n" +
                            "Custom  - You chose da rooms. Max = 50x50, more rooms may lag this program btw, not sure tho...\n" +
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
                        return true;

                    }
                }
            }
            return false;
        }
        public void SettingDaPlayerBoxPosition()
        {
            //List<string> ov = new List<string>();

            File.AppendAllText(daFileSettingsPath, "4\n");
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

            daGameSettings += 0.ToString() + "\n" + 0.ToString() + "\n\n"; // position of player in map

            daGameSettings += 4.ToString() + "\n\n"; // position of player in box, thats in middle btw

            File.WriteAllText(dafileMapPath, daMapText);
            File.WriteAllText(daFileSettingsPath, daGameSettings);
            File.WriteAllText(daFileInventoryPath, "");
            File.WriteAllText(daFileEXPPath, "0\n0");
            File.WriteAllText(daFilePlayerStatsPath, "100\n");


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
            int daEndPosition = 11;

            foreach (string item in File.ReadAllLines(daFileSettingsPath))
            {
                if (currentPosition >= daStarterPosition && currentPosition <= daEndPosition)
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
            if (daMapSizeY != 0)
            {
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
            DaMapBoxUpdater(PML);
            DaMapUpdater();
        }
        public void gettingdaBoxPlayerPosition(int PlayerMonsterLocation)
        {
            DaMapBoxUpdater(PlayerMonsterLocation);
        }
        private void DaMapBoxUpdater(int PML)
        {
            List<string> f = new List<string>();
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
        public void DaExpAndLevelSaver(int exp, int level)
        {
            List<string> f = new List<string>();
            f.Add(exp.ToString());
            f.Add(level.ToString());
            File.WriteAllText(daFileEXPPath, "");
            foreach (string item in f)
            {
                File.AppendAllText(daFileEXPPath, item + "\n");
            }
        }
        public void DaInventorySaver(List<string> inventory)
        {
            File.WriteAllText(daFileInventoryPath, "");
            foreach (string item in inventory)
            {
                File.AppendAllText(daFileInventoryPath, item + "\n");
            }
        }
        public void GettingDaExpAndLevel()
        {

            List<string> f = new List<string>();
            foreach (string item in File.ReadAllLines(daFileEXPPath))
            {
                f.Add(item);
            }
            PlayerExp = int.Parse(f[0]);
            PlayerLEVEL = int.Parse(f[1]);

        }
        public void GettingDaInventory()
        {

            List<string> f = new List<string>();
            foreach (string item in File.ReadAllLines(daFileInventoryPath))
            {
                f.Add(item);
            }
            PlayerPlayerInventory = f.ToList();


        }
        public void SettingDaPlayerStats(decimal playerHp)
        {
            File.WriteAllText(daFilePlayerStatsPath, playerHp.ToString());
        }
        public void GettingDaPlayerStats()
        {


            string f = File.ReadAllText(daFilePlayerStatsPath);
            PlayerHP = decimal.Parse(f);


        }
    }
}