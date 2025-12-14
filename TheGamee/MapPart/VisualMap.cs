using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.MapPart
{
    internal class VisualMap
    {
        private int xx = 5;
        private int yy = 25;

        private bool offSet = false;

        private string upperBox = "■-------■"; // 1 + 7 + 1, 4 = center

        private string middleBox = "|"; // meowino fofinino fiaovino... don't ask, bro

        private bool moving = true;


        private string movement = "o";

        private int daMapPositionX = 42;
        private int daMapPositionY = 5;

        private int daMapPositionXBackup = 0;
        private int daMapPositionYBackup = 0;


        private int x = 14;
        private int y = 7;


        private string userInput = "";

        //x{xU + 4 - daMapPositionX},y{yU + i - daMapPositionY}" just in case, yk?

        
        public void DaVisualMap()
        {
            settingUpDaPlayer();
            DaMapThing();
        }

        private void settingUpDaPlayer()
        {
            x += daMapPositionX;
            y += daMapPositionY;
        }
        private void DaMapThing()
        {
            MapLoader();
            SpawningDaPlayer();

            while (moving)
            {
                userInput = Console.ReadLine();
                Console.Clear();
                MapLoader();

                if (userInput == "w")
                {
                    CheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        y -= 5;
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "s")
                {
                    CheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        y += 5;
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "a")
                {
                    CheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        x -= 10;
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "d")
                {
                    CheckingEadges();
                    if (offSet)
                    {
                        offSet = false;
                        SpawningDaPlayer();
                    }
                    else
                    {
                        x += 10;
                        SpawningDaPlayer();
                    }
                }
                else if (userInput == "?")
                {
                    Settings();
                }
                else
                {
                    SpawningDaPlayer();
                }

                Console.SetCursorPosition(xx, yy);
                {
                    Console.WriteLine($"x{x},y{y}, ? = settings");
                }
            }
            Console.Clear();
        }
        private void MapLoader()
        {
            for (int jj = 0; jj < 3; jj++)
            {
                int yY = 5 * jj;
                int j = 0;
                for (j = 0; j < 3; j++)
                {
                    int xX = 10 * j;

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
                        if (i == 2)
                        {
                            Console.SetCursorPosition(xU + 4, yU + i);
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("x");
                                Console.ResetColor();
                            }
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
        private void CheckingBeforeMoving()
        {
            CheckingEadges();
        }
        private void SpawningDaPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(x - 1, y);
            {
                Console.WriteLine("|");
            }

            Console.SetCursorPosition(x, y);
            {

                Console.WriteLine(movement);
            }
            Console.SetCursorPosition(x + 1, y);
            {
                Console.WriteLine("|");
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
            if (daMapPositionX < 90)
            {
                daMapPositionX = 90;
            }
            Console.SetCursorPosition(20, 5);
            {
                Console.WriteLine("da Map Position? Y");
            }
            daMapPositionYBackup = daMapPositionY;
            daMapPositionY = int.Parse(Console.ReadLine()); //14 - max
            if (daMapPositionY < 14)
            {
                daMapPositionX = 14;
            }
            int bbX = daMapPositionXBackup - daMapPositionX;
            int bbY = daMapPositionYBackup - daMapPositionY;

            x -= bbX;
            y -= bbY;

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
                else
                {
                    Console.SetCursorPosition(20, 6);
                    {
                        Console.WriteLine("What?");
                    }
                }
                Console.Clear();
                MapLoader();
                SpawningDaPlayer();
            }
        }
    }
}
