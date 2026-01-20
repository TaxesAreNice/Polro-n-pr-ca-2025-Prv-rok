using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaGame.FightingPart;
using DaGame.MapPart;
using Polročná_práca_2025_Prvý_rok.FightingPart;

namespace Polročná_práca_2025_Prvý_rok.MapPart
{
    internal class VisualMap
    {
        BossFight bossFight = new BossFight();

        engine Monsterengine = new engine();

        MapInAMap mapInAMap;
        public VisualMap(MapEngine mapeEngine)
        {
            this.mapInAMap = new MapInAMap(mapeEngine);

        }

        private int currentEXP = 0;

        private int CurrentLevel = 0;
        private int currentLevelbarier = 1;

        public List<string> currentInventory = new List<string>();

        private int xx = 5;
        private int yy = 25;

        private int PlayerMonsterLocation = 4;

        private int hablyICanFly = 0;

        public List<string> daRoom = new List<string>();

        private List<string> currentItems = new List<string>();

        private bool offSet = false;

        private string upperBox = "■-------■";

        private string middleBox = "|";

        private bool moving = true;


        private string movement = "o";

        private int daMapPositionX = 42;
        private int daMapPositionY = 5;

        private int daMapPositionXBackup = 0;
        private int daMapPositionYBackup = 0;

        private bool ignoringTheExes = false;

        private int x = 14;
        private int y = 7;

        internal int tester = 0;

        private bool starterPlayer = true;

        private string userInput = "";

        private decimal PlayerHp = 100;
        private int PlayerDamage = 10;

        public void DaVisualMap()
        {

            CheckingForTheFirstTime();

            settingUpDaPlayer();
            DaMapThing();
        }
        private void CheckingForTheFirstTime()
        {
            mapInAMap.GettingDaUplodedXandY();




            if (starterPlayer)
            {
                mapInAMap.x -= 1;
                PlayerMonsterLocation = mapInAMap.PlayerBoxPosition;
                SettingDaXandYToDaPlayerBoxPosition();

                mapInAMap.SettingDaPlayerHp();
                PlayerHp = mapInAMap.PlayerHp;
                if (PlayerHp <= 0)
                {
                    moving = false;
                    Console.WriteLine("Your dead, GGs");
                    string? lastWords = Console.ReadLine();
                }

                mapInAMap.SettingDaExpAndLevel();
                currentEXP = mapInAMap.PlayerExp;
                CurrentLevel = mapInAMap.PlayerLEVEL;
                currentLevelbarier += CurrentLevel;

                mapInAMap.SettingDaInventory();
                currentInventory = mapInAMap.PlayerInventory;

                mapInAMap.BossReader();
                mapInAMap.BossSpawning(starterPlayer);
                Converting2List("right");
                starterPlayer = false;
            }
            else
            {           
                mapInAMap.BossReader();
                mapInAMap.BossSpawning(starterPlayer);
                starterPlayer = true;
            }
        }

        private void SettingDaXandYToDaPlayerBoxPosition()
        {
            int o = 0;
            int Lx = 0;

            if (PlayerMonsterLocation >= 3 && PlayerMonsterLocation <= 5) // this checks if y's in the middle layer
            {
                y = 7;
                o = 3;
            }
            else if (PlayerMonsterLocation >= 6 && PlayerMonsterLocation <= 8) // here in the 3th one
            {
                y = 12;
                o = 6;
            }
        else // and here if it's in the first one
            {
                y = 2;
                o = 0;
            }

            Lx = PlayerMonsterLocation - o; // this gets the x position

            if (Lx == 0)
            {
                x = 4;
            }
            else if (Lx == 1)
            {
                x = 14;
            }
            else if (Lx == 2)
            {
                x = 24;
            }

        }
        private void settingUpDaPlayer()
        {
            x += daMapPositionX;
            y += daMapPositionY;
        }
        private void DaMapThing()
        {
            Console.SetCursorPosition(xx, yy);
            {
                Console.WriteLine("? = settings, e = inventory");
            }

            while (moving)
            {

                MapLoader();
                SpawningDaPlayer();
                Console.SetCursorPosition(xx, yy + 1);
                {
                    Console.WriteLine($"Level: {CurrentLevel}");

                }
                Console.SetCursorPosition(xx, yy + 2);
                {
                    Console.WriteLine($"Exp: {currentEXP}");

                }
                userInput = Console.ReadKey(true).KeyChar.ToString();
                Console.Clear();
                MapLoader();

                if (userInput == "w")
                {
                    CheckingBeforeCheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        y -= 5;
                        PlayerMonsterLocation -= 3;
                        CheckingDaMovment(PlayerMonsterLocation);
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "s")
                {
                    CheckingBeforeCheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        y += 5;
                        PlayerMonsterLocation += 3;
                        CheckingDaMovment(PlayerMonsterLocation);
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "a")
                {
                    CheckingBeforeCheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        x -= 10;
                        PlayerMonsterLocation -= 1;
                        CheckingDaMovment(PlayerMonsterLocation);
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "d")
                {
                    CheckingBeforeCheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        x += 10;
                        PlayerMonsterLocation += 1;
                        CheckingDaMovment(PlayerMonsterLocation);
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "?")
                {
                    Settings();
                }
                else if (userInput == "e")
                {
                    Monsterengine.currentInventory = currentInventory;
                    Monsterengine.PlayerHp = PlayerHp;

                    Monsterengine.Inventory();
                    Console.Clear();

                    PlayerHp = Monsterengine.PlayerHp;
                    currentInventory = Monsterengine.currentInventory;

                    mapInAMap.UpdatingDaInventory(currentInventory);
                    mapInAMap.SettingDaCurentPlayerStatus(PlayerHp);
                }
                else
                {
                    SpawningDaPlayer();
                }

                UpdatingDaPlayerBoxLocation(PlayerMonsterLocation);

                Console.SetCursorPosition(xx, yy);
                {
                    Console.WriteLine("? = settings, e = inventory");
                }
                foreach (var item in daRoom)
                { Console.WriteLine(item); }
            }
            Console.Clear();
        }
        private void UpdatingDaPlayerBoxLocation(int PlayerMonsterLocation)
        {
            mapInAMap.GettingDaPlayerBoxPossition(PlayerMonsterLocation);
        }
        private void MapLoader()
        {


            for (int jj = 0; jj < 3; jj++)
            {
                int yY = 5 * jj; // IF yY = 0 = first row, if yY = 5 = second row, if yY = 10 = third row ... jj * 3
                int j = 0;
                for (j = 0; j < 3; j++)
                {
                    int xX = 10 * j; // now xX = 0 = first column, IF xX = 10 = second column, if xX = 20 = third column ... just use j here

                    int xU = daMapPositionX + xX;
                    int yU = daMapPositionY + yY;
                    int i = 1;

                    Console.SetCursorPosition(xU, yU);
                    {
                        Console.WriteLine(upperBox);
                    }

                    while (i < 3 + 1)
                    {
                        Console.SetCursorPosition(xU, yU + i);
                        {
                            Console.WriteLine(middleBox);
                        }
                        if (i == 2 && starterPlayer == false)
                        {
                            SpawningDaMonster(xU, yU, i, xX, yY, j, jj);

                        }

                        Console.SetCursorPosition(xU + 8, yU + i);
                        {
                            Console.WriteLine(middleBox);
                        }
                        i++;
                    }

                    Console.SetCursorPosition(xU, yU + i);
                    {
                        Console.WriteLine(upperBox);
                    }
                }
            }
            hablyICanFly = 0;
        }
        private void CheckingEadges()
        {
            if (userInput == "a" && x - daMapPositionX == 4)
            {
                x = 4 + daMapPositionX;
                offSet = true;
            }
            else if (userInput == "d" && x - daMapPositionX == 24)
            {
                x = 24 + daMapPositionX;
                offSet = true;
            }

            if (userInput == "w" && y - daMapPositionY == 2)
            {
                y = 2 + daMapPositionY;
                offSet = true;
            }
            else if (userInput == "s" && y - daMapPositionY == 12)
            {
                y = 12 + daMapPositionY;
                offSet = true;
            }

        }
        private void Bossinifafiny()
        {
            currentItems.Clear();
            for (int i = 0; i < 9; i++)
            {
                currentItems.Add("x");
            }
            UpdatingDaXandYOfDaRoom();
        }
        private void CheckingBeforeCheckingEadges()
        {
            string direction = "";
            bool bossHere = false;

            if (currentItems.Contains("Boss"))
            {
                bossHere = true;

            }

            if (userInput == "a" && x - daMapPositionX == 4 && y - daMapPositionY == 7)
            {
                if (bossHere && currentItems.Contains("right"))
                {
                    GoingToTheBossRoom();
                }
                else
                {
                    SettingThePlayerRoomValue();
                    direction = "left";
                    UpdatingDaXandYOfDaRoom();
                    Converting2List(direction);
                }
            }
            else if (userInput == "d" && x - daMapPositionX == 24 && y - daMapPositionY == 7)
            {
                if (bossHere && currentItems.Contains("left"))
                {
                    GoingToTheBossRoom();;
                }
                else
                {

                    SettingThePlayerRoomValue();
                    direction = "right";
                    Converting2List(direction);
                    UpdatingDaXandYOfDaRoom();
                }
            }
            else if (userInput == "w" && y - daMapPositionY == 2 && x - daMapPositionX == 14)
            {
                if (bossHere && currentItems.Contains("down"))
                {
                    GoingToTheBossRoom();
                }
                else
                {
                    SettingThePlayerRoomValue();
                    direction = "up";
                    Converting2List(direction);
                    UpdatingDaXandYOfDaRoom();
                }
            }
            else if (userInput == "s" && y - daMapPositionY == 12 && x - daMapPositionX == 14)
            {
                if (bossHere && currentItems.Contains("up"))
                {
                    GoingToTheBossRoom();
                }
                else
                {
                    SettingThePlayerRoomValue();
                    direction = "down";
                    Converting2List(direction);
                    UpdatingDaXandYOfDaRoom();
                }
            }
            else
            {
                CheckingEadges();
            }
        }
        private void GoingToTheBossRoom()
        {
            int endCaser = 0;
            offSet = true;
            starterPlayer = false;

            if (PlayerMonsterLocation == 1)
            {
                endCaser = 1;
            }
            else if (PlayerMonsterLocation == 3)
            {
                endCaser = 2;
            }
            else if (PlayerMonsterLocation == 5)
            {
                endCaser = 3;
            }
            else if (PlayerMonsterLocation == 7)
            {
                endCaser = 4;
            }


            SpawningDaPlayer();
            bool theBossFightHasStarted = bossFight.RunBossFight();
            if (theBossFightHasStarted)
            {
                mapInAMap.x -= 1;
                Converting2List("right");

                currentItems.Clear();
                currentItems.Add("Boss");
                PlayerMonsterLocation = 0;
                ignoringTheExes = true;

                CheckingDaMovment(PlayerMonsterLocation);
                if (endCaser == 1)
                {
                    PlayerMonsterLocation = 1;
                    x = 14 + daMapPositionX;
                    y = 2 + daMapPositionY;
                }
                else if (endCaser == 2)
                {
                    PlayerMonsterLocation = 3;
                    x = 4 + daMapPositionX;
                    y = 7 + daMapPositionY;
                }
                else if (endCaser == 3)
                {
                    PlayerMonsterLocation = 5;
                    x = 24 + daMapPositionX;
                    y = 7 + daMapPositionY;
                }
                else if (endCaser == 4)
                {
                    PlayerMonsterLocation = 7;
                    x = 14 + daMapPositionX;
                    y = 12 + daMapPositionY;
                }

                ignoringTheExes = false;
                mapInAMap.x -= 1;

                Converting2List("right");
                UpdatingDaXandYOfDaRoom();
            }
        }
        private void UpdatingDaXandYOfDaRoom()
        {
            mapInAMap.imLosingIt();
        }

        private List<string> Converting2List(string direction)
        {

            var a = mapInAMap.CheckingTheRoomMovment(direction);
            foreach (var item in a)
            {
                currentItems.Add(item);
            }
            if (currentItems.Contains("Boss"))
            {
                string f = "";
                if (currentItems.Contains("up"))
                {
                    f = "up";
                }
                else if (currentItems.Contains("down"))
                {
                    f = "down";
                }
                else if (currentItems.Contains("left"))
                {
                    f = "left";
                }
                else if (currentItems.Contains("right"))
                {
                    f = "right";
                }
                Bossinifafiny();
                currentItems.Add("Boss");
                currentItems.Add(f);
            }
            return currentItems;
        }

        private void SettingThePlayerRoomValue()
        {
            x = 14 + daMapPositionX;
            y = 7 + daMapPositionY;
            offSet = true;
            starterPlayer = false;
            PlayerMonsterLocation = 4;
            currentItems.Clear();
        }

        private void SpawningDaPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x - 1, y - 1);
            {
                Console.WriteLine("   ");
            }

            Console.SetCursorPosition(x - 1, y);
            {

                Console.WriteLine($"|{movement}|");
            }
            Console.SetCursorPosition(x - 1, y + 1);
            {
                Console.WriteLine("   ");
            }
            Console.ResetColor();
        }
        private void SettingUpTheMapPlacement()
        {
            Console.SetCursorPosition(20, 5);
            {
                Console.WriteLine("da Map Position? X");
            }
            daMapPositionXBackup = daMapPositionX;
            daMapPositionX = int.Parse(Console.ReadLine()); // 90 - max
            if (daMapPositionX > 90)
            {
                daMapPositionX = 90;
            }
            Console.SetCursorPosition(20, 5);
            {
                Console.WriteLine("da Map Position? Y");
            }
            daMapPositionYBackup = daMapPositionY;
            daMapPositionY = int.Parse(Console.ReadLine()); //14 - max
            if (daMapPositionY > 14)
            {
                daMapPositionY = 14;
            }
            int bbX = 0;
            int bbY = 0;
            if (daMapPositionXBackup > daMapPositionX)
            {
                bbX = daMapPositionXBackup - daMapPositionX;
                x -= bbX;
            }
            else
            {
                bbX = daMapPositionX - daMapPositionXBackup;
                x += bbX;
            }
            if (daMapPositionYBackup > daMapPositionY)
            {
                bbX = daMapPositionYBackup - daMapPositionY;
                y -= bbY;
            }
            else
            {
                bbX = daMapPositionY - daMapPositionYBackup;
                y += bbY;
            }




            Console.Clear();
        }
        private void Settings()
        {
            bool settingLoop = true;
            while (settingLoop)
            {
                Console.Clear();
                Console.SetCursorPosition(20, 5);
                {
                    Console.WriteLine("Change the Map location on the screen(change)");
                }
                Console.SetCursorPosition(20, 6);
                {
                    Console.WriteLine("End the game(end)");
                }
                Console.SetCursorPosition(20, 7);
                {
                    Console.WriteLine("Admin settings(admin)");
                }
                Console.SetCursorPosition(20, 9);
                {
                    Console.WriteLine("Back to the game(anything else)");
                }

                string? userSettingsInput = Console.ReadLine();
                Console.Clear();

                if (userSettingsInput == "change")
                {
                    SettingUpTheMapPlacement();
                    settingLoop = false;

                }
                else if (userSettingsInput == "end")
                {
                    moving = false;
                    settingLoop = false;
                }
                else if (userSettingsInput == "admin")
                {
                    mapInAMap.BossChecking();
                    settingLoop = false;
                    string? adminInput = Console.ReadLine();
                }
                else
                {
                    settingLoop = false;
                }
                Console.Clear();
                MapLoader();
                SpawningDaPlayer();
            }
        }
        private void SpawningDaMonster(int xU, int yU, int i, int xX, int yY, int j, int jj)
        {

            if (yY == 5 && xX == 10)
            {
            }
            else
            {
                if (currentItems[j + jj * 3] == "Item")
                {
                    UpAndDownKiller(xU, yU, i);
                    Console.SetCursorPosition(xU + 3, yU + i);
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(@"-o-");
                        Console.ResetColor();
                    }
                }
                else if (currentItems[j + jj * 3] == "Zombie")
                {
                    Console.SetCursorPosition(xU + 3, yU + i - 1);
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(@" o ");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i);
                    {
                        Console.WriteLine(@"/X\");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i + 1);
                    {
                        Console.WriteLine(@"/ \");
                        Console.ResetColor();
                    }
                }
                else if (currentItems[j + jj * 3] == "Boss")
                {
                    Console.SetCursorPosition(xU + 3, yU + i - 1);
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(@" O ");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i);
                    {
                        Console.WriteLine(@"/X\");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i + 1);
                    {
                        Console.WriteLine(@"/ \");
                        Console.ResetColor();
                    }
                }
                else if (currentItems[j + jj * 3] == "Orc")
                {
                    Console.SetCursorPosition(xU + 3, yU + i - 1);
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(@"^=^");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i);
                    {
                        Console.WriteLine(@"/-\");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i + 1);
                    {
                        Console.WriteLine(@"/ \");
                        Console.ResetColor();
                    }
                }
                else if (currentItems[j + jj * 3] == "StoneGolem")
                {
                    Console.SetCursorPosition(xU + 3, yU + i - 1);
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(@" _ ");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i);
                    {
                        Console.WriteLine(@"/O\");
                    }
                    Console.SetCursorPosition(xU + 3, yU + i + 1);
                    {
                        Console.WriteLine(@"/ \");
                        Console.ResetColor();
                    }
                }
                else
                {
                    UpAndDownKiller(xU, yU, i);
                    Console.SetCursorPosition(xU + 3, yU + i);
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" x ");
                        Console.ResetColor();
                    }

                }
            }
        }
        private void UpAndDownKiller(int xU, int yU, int i)
        {
            Console.SetCursorPosition(xU + 3, yU + i - 1);
            {
                Console.WriteLine(@"   ");
            }
            Console.SetCursorPosition(xU + 3, yU + i + 1);
            {
                Console.WriteLine(@"   ");
            }
        }
        private void CheckingDaMovment(int PML)
        {
            if (currentItems.Count == 0)
            {
            }
            else if (currentItems[PML] == "x" && !ignoringTheExes)
            {
            }
            else if (currentItems[PML] == "Item")
            {
                if (currentInventory.Count <= 12)
                {
                    Random rand = new Random();
                    int itemPicer = rand.Next(0, 4);
                    if (itemPicer == 0)
                    {
                        currentInventory.Add("Spagettie");
                        Console.WriteLine("You found some Spagettie!");
                    }
                    else if (itemPicer == 1)
                    {
                        currentInventory.Add("Golden chicken");
                        Console.WriteLine("You found a Golden chicken!");
                    }
                    else if (itemPicer == 2)
                    {
                        currentInventory.Add("Chicken");
                        Console.WriteLine("You found a Chicken");
                    }
                    else if (itemPicer == 3)
                    {
                        currentInventory.Add("funny tasting candy");
                        Console.WriteLine("You found some funny tasting candy");
                    }
                    else
                    {
                        Console.WriteLine("You found nothin'");
                    }

                    currentItems[PML] = "x";
                    mapInAMap.DaMapSaver(PML);
                    mapInAMap.UpdatingDaInventory(currentInventory);
                }
                else
                {
                    Console.WriteLine("Yo inventory's full");
                }

            }
            else
            {
                string daMonster = currentItems[PML];

                Monsterengine.PlayerHp = PlayerHp;

                Monsterengine.GettingMonster(daMonster, currentInventory, CurrentLevel);
                Monsterengine.StartFight();

                currentInventory = Monsterengine.currentInventory;
                if (currentLevelbarier! <= 5)
                {
                    currentEXP += Monsterengine.expReturner;
                }
                PlayerHp = Monsterengine.PlayerHp;

                if (PlayerHp <= 0)
                {
                    moving = false;
                    Console.WriteLine("Your dead, GGs");
                    string? lastWords = Console.ReadLine();
                }

                SettingDaPlayerLevel();
                mapInAMap.UpdatingDaLevelAndExp(CurrentLevel, currentEXP);
                mapInAMap.UpdatingDaInventory(currentInventory);
                mapInAMap.SettingDaCurentPlayerStatus(PlayerHp);

                currentItems[PML] = "x";
                mapInAMap.DaMapSaver(PML);

            }
        }
        private void SettingDaPlayerLevel()
        {
            int leftOverExp = 0;

            if (currentEXP >= 10 * currentLevelbarier)
            {
                CurrentLevel += 1;
                if (currentEXP > 10 * currentLevelbarier)
                {
                    leftOverExp = currentEXP - 10 * currentLevelbarier;
                    currentEXP = leftOverExp;
                    currentLevelbarier += 1;
                    SettingDaPlayerLevel(); // just in case if you level up again, so it can check again
                }
                else
                {
                    currentEXP = 0;
                    currentLevelbarier += 1;
                }
            }
            else
            {

            }
        }
    }
}