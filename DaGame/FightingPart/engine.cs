using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Polročná_práca_2025_Prvý_rok.MapPart;
using static System.Formats.Asn1.AsnWriter;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class engine
    {
        public List<string> currentInventory = new List<string>();
        public int expReturner = 0;
        Random random = new Random();

        Zombie zombie = new Zombie();
        Orc orc = new Orc();
        StoneGolem stoneGolem = new StoneGolem();

        public bool endGame = false;

        public int PlayerHp = 100;
        private int PlayerArmorProtection = 0;
        private int PlayerDamage = 10;

        private int MonsterHp = 100;
        private int MonseterDamage = 10;

        private bool quitedDaInventory = false;

        private string daMonster = "";
        public void GettingDaMonster(string currentininyMonstertininy, List<string> playersItems, int lvl)
        {
            daMonster = currentininyMonstertininy;
            playersItems = playersItems.ToList();

            currentInventory = playersItems;

            if (currentInventory.Contains("Iron sword"))
            {
                PlayerDamage = 50;
            }
            else if (currentInventory.Contains("leather armor"))
            {
                PlayerArmorProtection = 15;
            }
            else if (currentInventory.Contains("iron armor"))
            {
                PlayerArmorProtection = 25;
            }
            else if (currentInventory.Contains("Stone sword"))
            {
                PlayerDamage = 25;
            }

            if (daMonster == "Zombie")
            {
                zombie.SendingStats(this);
            }
            else if (daMonster == "Orc")
            {
                orc.SendingStats(this);
            }
            else if (daMonster == "StoneGolem")
            {
                stoneGolem.SendingStats(this);
            }
            PlayerHp += lvl;
            if (lvl! > 1)
            {
                PlayerDamage = PlayerDamage * (lvl / 2);
            }
        }
        public void StartFight()
        {
            Console.Clear();
            Console.WriteLine("You've started a fight with" + daMonster + "\n   Press enter to start the fight");

            string? userInput = Console.ReadLine();

            TheFight();

            AfterFight();
        }
        public void CheckingDaMonsterStats(int damage, int hp)
        {
            MonsterHp = hp;
            MonseterDamage = damage;
        }

        private void TheFight()
        {
            CheckingPlayerOptions();
        }
        private void RenderingTheMonster()
        {
            int XX = 42;
            int YY = 15;

            if (daMonster == "Zombie")
            {
                RenderingZombie(XX, YY);
            }
            else if (daMonster == "Orc")
            {
                RenderingOrc(XX, YY);
            }
            else if (daMonster == "StoneGolem")
            {
                RenderingStoneGolem(XX, YY);
            }
        }
        private void RenderingZombie(int XX, int YY)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(XX, YY);
            {
                Console.WriteLine("O");
            }
            Console.SetCursorPosition(XX - 1, YY + 1);
            {
                Console.WriteLine(@"/|\");
            }
            Console.SetCursorPosition(XX - 1, YY + 2);
            {
                Console.WriteLine(@"/ \");
            }
            Console.ResetColor();
        }
        private void RenderingOrc(int XX, int YY)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(XX - 1, YY);
            {
                Console.WriteLine("^=^");
            }
            Console.SetCursorPosition(XX - 1, YY + 1);
            {
                Console.WriteLine(@"/|\");
            }
            Console.SetCursorPosition(XX - 1, YY + 2);
            {
                Console.WriteLine(@"/ \");
            }
            Console.ResetColor();
        }
        private void RenderingStoneGolem(int XX, int YY)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(XX - 1, YY);
            {
                Console.WriteLine("###");
            }
            Console.SetCursorPosition(XX - 1, YY + 1);
            {
                Console.WriteLine(@"/|\");
            }
            Console.SetCursorPosition(XX - 1, YY + 2);
            {
                Console.WriteLine(@"/ \");
            }
            Console.ResetColor();
        }
        private void RenderingThePlayerOptions()
        {
            int xX = 30;
            int yY = 20;

            RenderingTheUperAndLowerPartInPlayerChoise(xX, yY);
            yY++;
            RenderingTheMiddlePartInPlayerChoise(xX, yY);
            yY += 3;
            RenderingTheUperAndLowerPartInPlayerChoise(xX, yY);
        }


        private void RenderingTheMiddlePartInPlayerChoise(int xX, int yY)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(xX, yY + i);
                {
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(xX + 12, yY + i);
                {
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(xX + 24, yY + i);
                {
                    Console.WriteLine("|");
                }
            }

        }
        private void RenderingTheUperAndLowerPartInPlayerChoise(int xX, int yY)
        {
            Console.SetCursorPosition(xX, yY);
            {
                Console.WriteLine("o");
            }

            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(xX + 1 + i, yY);
                {
                    Console.WriteLine("-");
                }
            }
            Console.SetCursorPosition(xX + 12, yY);
            {
                Console.WriteLine("o");
            }

            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(xX + 13 + i, yY);
                {
                    Console.WriteLine("-");
                }
            }
            Console.SetCursorPosition(xX + 24, yY);
            {
                Console.WriteLine("o");
            }
        }

        private void CheckingPlayerOptions()
        {
            int x = 0;
            bool playingPickingOption = true;

            Console.Clear();

            RenderingTheMonster();
            RenderingThePlayerOptions();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(36, 22); // Change the position here
            {
                Console.WriteLine("o");
            }
            while (playingPickingOption)
            {

                string userInput = Console.ReadKey(true).KeyChar.ToString();
                Console.Clear();

                if (userInput == "d")
                {
                    if (x == 0)
                    {
                        x++;
                        Console.SetCursorPosition(48, 22); // Change the position here
                        {
                            Console.WriteLine("o");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 22); // Change the position here
                        {
                            Console.WriteLine("o");
                        }
                    }
                    Console.ResetColor();
                }
                else if (userInput == "a")
                {
                    if (x == 1)
                    {
                        x--;
                        Console.SetCursorPosition(36, 22); // And here too
                        {
                            Console.WriteLine("o");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(36, 22); // And here too
                        {
                            Console.WriteLine("o");
                        }
                    }
                    Console.ResetColor();
                }
                else
                {
                    playingPickingOption = false;
                    Console.ResetColor();
                    Console.Clear();
                    RenderingTheMonster();

                    if (x == 0)
                    {
                        PlayerAttack();
                    }
                    else if (x == 1)
                    {
                        Console.Clear();
                        Inventory();
                        if (!quitedDaInventory)
                        {
                            Console.Clear();
                            RenderingTheMonster();
                            MonsterAttack();
                            // Inventory
                        }
                        else
                        {
                            quitedDaInventory = false;
                            TheFight();
                        }
                    }
                    else
                    {
                        playingPickingOption = true;
                    }

                }
                RenderingTheMonster();
                RenderingThePlayerOptions();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Clear();
        }
        private void CreatingInventory()
        {
            int daX = 30;
            int daY = 7;

            TheOInventoryPart(daX, daY);
            daY += 1;

            for (int i = 0; i < 3; i++)
            {
                TheLineInventoryPart(daX, daY);
                daY += 2;
                TheOInventoryPart(daX, daY);
                daY += 1;
            }

            daVPart(daX, daY);
            daY++;

            daVUPart(daX, daY);

            spawingDaInventoryItems();
        }
        private void spawingDaInventoryItems()
        {
            int daXM = 36;
            int daYM = 8;

            int k = 0;

            for (int i = 0; i < 3; i++) // for y
            {
                for (int j = 0; j < 4; j++) // for x
                {
                    if (k! < currentInventory.Count)
                    {
                        CheckingDaInventoryItems(daXM, daYM, k);
                        //Console.WriteLine(currentInventory[k]);
                        k++;
                        daXM += 12;
                    }
                }
                daXM = 36;
                daYM += 3;
            }
        }
        private void CheckingDaInventoryItems(int daXf, int daYf, int order)
        {

            if (currentInventory[order] == "leather armor")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("=▄=");
                    Console.WriteLine("o");
                }
            }
            else if (currentInventory[order] == "Spagettie")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("=");
                }
            }
            else if (currentInventory[order] == "Chicken")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("O-c");
                }
            }
            else if (currentInventory[order] == "funny tasing candy")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("oOo");
                }
            }
            else if (currentInventory[order] == "Golden chicken")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("O-c");
                }
            }
            else if (currentInventory[order] == "iron armor")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("=▄=");
                }
            }
            else if (currentInventory[order] == "Stone sword")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("+--");
                }
            }
            else if (currentInventory[order] == "Iron sword")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("+--");
                }
            }
            else
            {
                Console.WriteLine("Something was missing from the Item side of the inventory");
            }
            Console.ResetColor();
        }

        private void daVPart(int daXx, int daYy)
        {
            Console.SetCursorPosition(daXx, daYy);
            {
                Console.WriteLine("|");
            }
            daXx += 36;

            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(daXx, daYy);
                {
                    Console.WriteLine("|");
                }
                daXx += 12;
            }
        }
        private void daVUPart(int daXx, int daYy)
        {
            Console.SetCursorPosition(daXx, daYy);
            {
                Console.WriteLine("o------------------------------------------------");
            }
            daXx += 36;


            Console.SetCursorPosition(daXx, daYy);
            {
                Console.WriteLine("o-----------");
            }
            daXx += 12;
            Console.SetCursorPosition(daXx, daYy);
            {
                Console.WriteLine("o");
            }
        }
        private void TheOInventoryPart(int daXx, int daYy)
        {
            int daX = daXx;
            int daY = daYy;
            int daExer = 0;
            void TheOPart()
            {
                Console.SetCursorPosition(daX + daExer, daY);
                {
                    Console.WriteLine("o");
                }
            }
            void TheLinePart()
            {
                Console.SetCursorPosition(daX + daExer, daY);
                {
                    Console.WriteLine("-----------"); // 11 dashes
                }
            }

            TheOPart();
            daX++;
            for (int i = 0; i < 4; i++)
            {
                TheLinePart();
                daExer += 11;
                TheOPart();
                daExer += 1;
            }

        }
        private void TheLineInventoryPart(int daXx, int daYy)
        {
            int daX = daXx;
            int daY = daYy;
            int daExer = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(daX + daExer, daY);
                    {
                        Console.WriteLine("|");
                    }
                    daExer += 12;
                }
                daY++;
                daExer = 0;
            }
        }
        public void Inventory()
        {
            int daXM = 36;
            int daYM = 9;

            int o = 0;
            int currentPosition = 0;
            int NumberMinusO = currentPosition = 0;

            bool playingInInventory = true;
            bool usededAnItem = false;

            string UsededItem = "";

            while (playingInInventory)
            {
                Console.Clear();
                CreatingInventory();

                if (currentPosition < 4)
                {
                    o = 0;
                }
                else if (currentPosition < 8)
                {
                    o = 4;
                }
                else if (currentPosition < 12)
                {
                    o = 8;
                }
                else
                {
                    o = 12;
                }
                NumberMinusO = currentPosition - o;

                CurrentPositionConverter2XandYANDCursorPrinter(o, daXM, daYM, currentPosition);
                Console.WriteLine($"Your Hp is {PlayerHp}");

                string userInput = Console.ReadKey(true).KeyChar.ToString();

                if (userInput == "a" && NumberMinusO != 0)
                {
                    currentPosition -= 1;
                }
                else if (userInput == "d" && NumberMinusO != 3)
                {
                    currentPosition += 1;
                }
                else if (userInput == "w" && o != 0)
                {
                    currentPosition -= 4;
                }
                else if (userInput == "s" && o != 8)
                {
                    currentPosition += 4;
                }
                else if (userInput == "e")
                {
                    UsededItem = InventoryItemUsager(currentPosition, usededAnItem);
                    if (!usededAnItem)
                    {
                        if (UsededItem == "" || UsededItem == "leather armor" || UsededItem == "iron armor" || UsededItem == "Iron sword" || UsededItem == "Stone sword")
                        {
                            usededAnItem = false;
                        }
                        else
                        {
                            usededAnItem = true;
                        }
                    }
                }
                else if (userInput == "q")
                {
                    if (!usededAnItem)
                    {
                        quitedDaInventory = true;
                    }
                    playingInInventory = false;
                }
                else
                {
                    Console.WriteLine("fafafela");
                }
            }
        }
        private string InventoryItemUsager(int currentPosition, bool usededAnItem)
        {
            if (currentInventory.Count > currentPosition)
            {
                string daItem = currentInventory[currentPosition];
                if (daItem == "Spagettie")
                {
                    PlayerHp += 20;
                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    currentInventory.Remove("Spagettie");
                }
                else if (daItem == "Chicken")
                {
                    PlayerHp += 35;
                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    currentInventory.Remove("Chicken");
                }
                else if (daItem == "funny tasing candy")
                {
                    Random random = new Random();
                    int daRandomNumber = random.Next(-25, 50);
                    PlayerHp += daRandomNumber;

                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    else if (PlayerHp < 0)
                    {
                        PlayerHp = 1;
                    }
                    currentInventory.Remove("funny tasing candy");
                }
                else if (daItem == "Golden chicken")
                {
                    PlayerHp += 50;
                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    currentInventory.Remove("Golden chicken");
                }
                return daItem;
            }
            return "";
        }
        private void CurrentPositionConverter2XandYANDCursorPrinter(int o, int daXM, int daYM, int currentPosition)
        {
            int xH = ((currentPosition - o) * 12) + daXM;
            int yH = ((o / 4) * 3) + daYM;
            Console.SetCursorPosition(xH, yH);
            {
                Console.WriteLine("o");
            }
        }
        private void PlayerAttack()
        {
            MonsterHp -= PlayerDamage;
            if (MonsterHp <= 0)
            {
                Console.WriteLine("Monster defeated!");
                string? userInput = Console.ReadLine();
                PlayerHp = PlayerHp + 50;
                if (PlayerHp > 100)
                {
                    PlayerHp = 100;
                }
                return;
            }
            else
            {
                Console.WriteLine("Player hit the monster, MonsterHp: " + MonsterHp + "\nPress enter to continue");
                string? userInput = Console.ReadLine();
                Console.Clear();
                RenderingTheMonster();
                MonsterAttack();
            }
        }
        private void MonsterAttack()
        {
            PlayerHp = PlayerHp - (MonseterDamage * ((100 - PlayerArmorProtection)) / 100);
            if (PlayerHp <= 0)
            {
                Console.WriteLine("You have been defeated!");
                return;
                // make sure to end the game as well
            }
            else
            {
                Console.WriteLine("Monster hit the player, PlayerHp: " + PlayerHp + "\nPress enter to continue");
                string? userInput = Console.ReadLine();
                Console.Clear();
                TheFight();
            }
        }
        private void AfterFight()
        {
            int daNumber = 0;
            if (daMonster == "Zombie")
            {
                expReturner = 10;
                daNumber = random.Next(0, 3);
            }
            else if (daMonster == "Orc")
            {
                expReturner = 15;
                daNumber = random.Next(3, 7);
            }
            else if (daMonster == "StoneGolem")
            {
                expReturner = 20;
                daNumber = random.Next(3, 8);
            }
            else
            {
                expReturner = 10;
                daNumber = random.Next(0, 8);
            }

            if (currentInventory.Count >= 12)
            {
            }
            else
            {
                if (daNumber == 0)
                {

                }
                else if (daNumber == 1)
                {
                    currentInventory.Add("Spagettie");
                }
                else if (daNumber == 2)
                {
                    currentInventory.Add("Chicken");
                }
                else if (daNumber == 3)
                {
                    currentInventory.Add("funny tasing candy");
                }
                else if (daNumber == 4)
                {
                    currentInventory.Add("Golden chicken");
                }
                else if (daNumber == 5)
                {
                    if (currentInventory.Contains("leather armor") && currentInventory.Count != 12)
                    {
                        currentInventory.Add("Chicken");
                    }
                    else
                    {
                        currentInventory.Add("leather armor");
                    }
                }
                else if (daNumber == 6)
                {
                    if (currentInventory.Contains("iron armor"))
                    {
                        currentInventory.Add("Golden chicken");
                    }
                    else
                    {
                        if (currentInventory.Contains("leather armor"))
                        {
                            currentInventory.Remove("leather armor");
                            currentInventory.Add("iron armor");
                        }
                    }
                }
                else if (daNumber == 7)
                {
                    if (currentInventory.Contains("Stone sword"))
                    {
                        currentInventory.Add("funny tasing candy");
                    }
                    else
                    {
                        currentInventory.Add("Stone sword");
                    }
                }
                else if (daNumber == 8)
                {
                    if (currentInventory.Contains("Iron sword"))
                    {
                        currentInventory.Add("Spagettie");
                    }
                    else
                    {
                        if (currentInventory.Contains("Stone sword"))
                        {
                            currentInventory.Remove("Stone sword");
                            currentInventory.Add("Iron sword");
                        }
                    }
                }
            }
        }



    }
}