using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using DaGame.FightingPart;
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
        BossFight bossFight = new BossFight();

        public bool endGame = false;

        private bool playerDead = false;

        public decimal PlayerHp = 100;
        private decimal PlayerArmorProtection = 0;
        private decimal PlayerDamage = 10;

        private decimal MonsterHp = 100;
        private decimal MonseterDamage = 10;

        private bool leaveInventory = false;

        private string Monster = "";
        public void GettingMonster(string currentMonster, List<string> playersItems, int lvl)
        {
            Monster = currentMonster;
            playersItems = playersItems.ToList();

            currentInventory = playersItems;

            if (currentInventory.Contains("Iron sword"))
            {
                PlayerDamage = 25;
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
                PlayerDamage = 15;
            }

            if (Monster == "Zombie")
            {
                zombie.SendingStats(this);
            }
            else if (Monster == "Orc")
            {
                orc.SendingStats(this);
            }
            else if (Monster == "StoneGolem")
            {
                stoneGolem.SendingStats(this);
            }
            else if (Monster == "Boss")
            {
                bossFight.SendingStats(this);
            }

            PlayerHp += lvl * 2;
            if (lvl > 1)
            {
                PlayerDamage = PlayerDamage * (lvl / 2);
            }
        }
        public void StartFight()
        {
            Console.Clear();
            Console.WriteLine("You've started a fight with " + Monster + "\n   Press enter to start the fight");

            string? userInput = Console.ReadLine();

            Fight();

            AfterFight();
        }
        public void CheckingMonsterStats(int damage, decimal hp)
        {
            MonsterHp = hp;
            MonseterDamage = damage;
        }

        private bool fight = true;
        private void Fight()
        {
            while (fight)
            {
                CheckingPlayerOptions();
            }
            fight = true;
        }
        private void RenderingMonster()
        {
            int XX = 42;
            int YY = 15;

            if (Monster == "Zombie")
            {
                RenderingZombie(XX, YY);
            }
            else if (Monster == "Orc")
            {
                RenderingOrc(XX, YY);
            }
            else if (Monster == "StoneGolem")
            {
                RenderingStoneGolem(XX, YY);
            }
            else if (Monster == "Boss")
            {
                RenderingBoss(XX, YY);
            }
        }
        private void RenderingBoss(int XX, int YY)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(XX - 3, YY);
            {
                Console.WriteLine(@"(.\_/.)");
            }
            Console.SetCursorPosition(XX - 2, YY + 1);
            {
                Console.WriteLine(@"/|_|\");
            }
            Console.SetCursorPosition(XX - 2, YY + 2);
            {
                Console.WriteLine(@"/|||\");
            }
            Console.ResetColor();
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
        private void RenderingPlayerOptions()
        {
            int xX = 30;
            int yY = 20;

            RenderingUperAndLowerPartInPlayerChoise(xX, yY);
            yY++;
            RenderingMiddlePartInPlayerChoise(xX, yY);
            yY += 3;
            RenderingUperAndLowerPartInPlayerChoise(xX, yY);
        }


        private void RenderingMiddlePartInPlayerChoise(int xX, int yY)
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
        private void RenderingUperAndLowerPartInPlayerChoise(int xX, int yY)
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
            bool inventoryPickingOption = true;

            Console.Clear();

            RenderingMonster();
            RenderingPlayerOptions();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(36, 22);
            {
                Console.WriteLine("o");
            }
            while (inventoryPickingOption)
            {

                string userInput = Console.ReadKey(true).KeyChar.ToString();
                Console.Clear();

                if (userInput == "d")
                {
                    if (x == 0)
                    {
                        x++;
                        Console.SetCursorPosition(48, 22);
                        {
                            Console.WriteLine("o");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(48, 22);
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
                        Console.SetCursorPosition(36, 22);
                        {
                            Console.WriteLine("o");
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(36, 22);
                        {
                            Console.WriteLine("o");
                        }
                    }
                    Console.ResetColor();
                }
                else
                {
                    inventoryPickingOption = false;
                    Console.ResetColor();
                    Console.Clear();
                    RenderingMonster();

                    if (x == 0)
                    {
                        PlayerAttack();
                    }
                    else if (x == 1)
                    {
                        Console.Clear();
                        Inventory();
                        if (!leaveInventory)
                        {
                            Console.Clear();
                            RenderingMonster();
                            MonsterAttack();
                        }
                        else
                        {
                            leaveInventory = false;
                        }
                    }
                    else
                    {
                        inventoryPickingOption = true;
                    }

                }
                RenderingMonster();
                RenderingPlayerOptions();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Clear();
        }
        private void CreatingInventory()
        {
            int X = 30;
            int Y = 7;

            TheOInventoryPart(X, Y);
            Y += 1;

            for (int i = 0; i < 3; i++)
            {
                TheLineInventoryPart(X, Y);
                Y += 2;
                TheOInventoryPart(X, Y);
                Y += 1;
            }

            TheVPart(X, Y);
            Y++;

            TheUPart(X, Y);

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
                }
            }
            else if (currentInventory[order] == "Spagettie")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("-=-");
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
            else if (currentInventory[order] == "funny tasting candy")
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
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("=▄=");
                }
            }
            else if (currentInventory[order] == "Stone sword")
            {
                Console.SetCursorPosition(daXf - 1, daYf);
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
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

        private void TheVPart(int Xx, int Yy)
        {
            Console.SetCursorPosition(Xx, Yy);
            {
                Console.WriteLine("|");
            }
            Xx += 36;

            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(Xx, Yy);
                {
                    Console.WriteLine("|");
                }
                Xx += 12;
            }
        }
        private void TheUPart(int Xx, int Yy)
        {
            Console.SetCursorPosition(Xx, Yy);
            {
                Console.WriteLine("o------------------------------------------------");
            }
            Xx += 36;


            Console.SetCursorPosition(Xx, Yy);
            {
                Console.WriteLine("o-----------");
            }
            Xx += 12;
            Console.SetCursorPosition(Xx, Yy);
            {
                Console.WriteLine("o");
            }
        }
        private void TheOInventoryPart(int Xx, int Yy)
        {
            int X = Xx;
            int Y = Yy;
            int Exer = 0;
            void TheOPart()
            {
                Console.SetCursorPosition(X + Exer, Y);
                {
                    Console.WriteLine("o");
                }
            }
            void TheLinePart()
            {
                Console.SetCursorPosition(X + Exer, Y);
                {
                    Console.WriteLine("-----------");
                }
            }

            TheOPart();
            X++;
            for (int i = 0; i < 4; i++)
            {
                TheLinePart();
                Exer += 11;
                TheOPart();
                Exer += 1;
            }

        }
        private void TheLineInventoryPart(int Xx, int Yy)
        {
            int X = Xx;
            int Y = Yy;
            int Exer = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.SetCursorPosition(X + Exer, Y);
                    {
                        Console.WriteLine("|");
                    }
                    Exer += 12;
                }
                Y++;
                Exer = 0;
            }
        }
        public void Inventory()
        {
            int XM = 36;
            int YM = 9;

            List<string> unEatableItems = new List<string>() { };

            int o = 0;
            int currentPosition = 0;
            int NumberMinusO = currentPosition = 0;

            bool playingInInventory = true;
            bool usedItem = false;

            string UsedItem = "";

            string currentItemPosition = "";

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

                CurrentPositionConverter2XandYANDCursorPrinter(o, XM, YM, currentPosition);
                Console.WriteLine($"Your Hp is {PlayerHp}");

                if (currentInventory.Count > currentPosition)
                {
                    Console.SetCursorPosition(32, 17);
                    {
                        Console.WriteLine($"That's: {currentItemPosition = currentInventory[currentPosition]}");
                    }
                    Console.SetCursorPosition(67, 17);
                    {
                        if (currentItemPosition == "leather armor" || currentItemPosition == "iron armor" || currentItemPosition == "Iron sword" || currentItemPosition == "Stone sword")
                        {
                            Console.WriteLine("its equeped");
                        }
                        else
                        {
                            Console.WriteLine("'e' to use");
                        }
                    }
                }

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
                    UsedItem = InventoryItemUsager(currentPosition, usedItem);
                    if (!usedItem)
                    {
                        if (UsedItem == "" || UsedItem == "leather armor" || UsedItem == "iron armor" || UsedItem == "Iron sword" || UsedItem == "Stone sword")
                        {
                            usedItem = false;
                        }
                        else
                        {
                            usedItem = true;
                        }
                    }
                }
                else if (userInput == "q")
                {
                    if (!usedItem)
                    {
                        leaveInventory = true;
                    }
                    playingInInventory = false;
                }
                else
                {
                    Console.WriteLine("error");
                }


            }
        }
        private string InventoryItemUsager(int currentPosition, bool usedAnItem)
        {
            if (currentInventory.Count > currentPosition)
            {
                string Item = currentInventory[currentPosition];
                if (Item == "Spagettie")
                {
                    PlayerHp += 20;
                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    currentInventory.Remove("Spagettie");
                }
                else if (Item == "Chicken")
                {
                    PlayerHp += 35;
                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    currentInventory.Remove("Chicken");
                }
                else if (Item == "funny tasting candy")
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
                    currentInventory.Remove("funny tasting candy");
                }
                else if (Item == "Golden chicken")
                {
                    PlayerHp += 50;
                    if (PlayerHp > 100)
                    {
                        PlayerHp = 100;
                    }
                    currentInventory.Remove("Golden chicken");
                }
                return Item;
            }
            return "";
        }
        private void CurrentPositionConverter2XandYANDCursorPrinter(int o, int XM, int YM, int currentPosition)
        {
            int xH = ((currentPosition - o) * 12) + XM;
            int yH = ((o / 4) * 3) + YM;
            Console.SetCursorPosition(xH, yH);
            {
                Console.WriteLine("o");
            }
        }
        private void PlayerAttack()
        {
            bool isBoss = Monster == "Boss";
            MonsterHp -= PlayerDamage;
            if (MonsterHp <= 0)
            {
                if (isBoss)
                {
                    Console.WriteLine("You won!!! Game basically ends:) or press enter to continue");
                }
                else
                {
                    Console.WriteLine("Monster defeated!");
                }
                string? userInput = Console.ReadLine();
                PlayerHp = PlayerHp + 35;
                if (PlayerHp > 100)
                {
                    PlayerHp = 100;
                }
                fight = false;
                return;
            }
            else
            {
                Console.WriteLine("Player hit the monster, MonsterHp: " + MonsterHp + "\nPress enter to continue");
                string? userInput = Console.ReadLine();
                Console.Clear();
                RenderingMonster();
                MonsterAttack();
            }
        }
        private void MonsterAttack()
        {
            bool isBoss = Monster == "Boss";

            if (isBoss)
            {
                int num = random.Next(1, 3);
                if (num != 1)
                {
                    Console.WriteLine("Boss missed the player!\nPress enter to continue");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }

            PlayerHp -= (MonseterDamage * (100 - PlayerArmorProtection)) / 100;

            if (PlayerHp <= 0)
            {
                Console.WriteLine("You have been defeated!");
                fight = false;
                playerDead = false;
                return;
            }

            if (isBoss)
            {
                Console.WriteLine("Boss hit the player, PlayerHp: " + PlayerHp + "\nPress enter to continue");
            }
            else
            {
                Console.WriteLine("Monster hit the player, PlayerHp: " + PlayerHp + "\nPress enter to continue");
            }

            Console.ReadLine();
            Console.Clear();
        }
        private void AfterFight()
        {
            string currentItemGetter = "";
            int Number = 0;

            if (Monster == "Zombie")
            {
                expReturner = 10;
                Number = random.Next(0, 4);
            }
            else if (Monster == "Orc")
            {
                expReturner = 15;
                Number = random.Next(3, 8);
            }
            else if (Monster == "StoneGolem")
            {
                expReturner = 20;
                Number = random.Next(4, 9);
            }
            else if (Monster == "Boss")
            {
                expReturner = 100;
                Number = random.Next(7, 9);
            }
            else
            {
                expReturner = 10;
                Number = random.Next(0, 8);
            }

            if (currentInventory.Count >= 12)
            {
            }
            else
            {
                if (Number == 0)
                {

                }
                else if (Number == 1)
                {
                    currentInventory.Add("Spagettie");
                    currentItemGetter = "Spagettie";
                }
                else if (Number == 2)
                {
                    currentInventory.Add("Chicken");
                    currentItemGetter = "Chicken";
                }
                else if (Number == 3)
                {
                    currentInventory.Add("funny tasting candy");
                    currentItemGetter = "funny tasting candy";
                }
                else if (Number == 4)
                {
                    currentInventory.Add("Golden chicken");
                    currentItemGetter = "Golden chicken";
                }
                else if (Number == 5)
                {
                    if (currentInventory.Contains("leather armor") || currentInventory.Contains("iron armor"))
                    {
                        currentInventory.Add("Chicken");
                        currentItemGetter = "Chicken";
                    }
                    else
                    {
                        currentInventory.Add("leather armor");
                        currentItemGetter = "leather armor";

                    }
                }
                else if (Number == 6)
                {
                    if (currentInventory.Contains("iron armor"))
                    {
                        currentInventory.Add("Golden chicken");
                        currentItemGetter = "Golden chicken";
                    }
                    else
                    {
                        if (currentInventory.Contains("leather armor"))
                        {
                            currentInventory.Remove("leather armor");
                            currentInventory.Add("iron armor");
                            currentItemGetter = "iron armor";
                        }
                        else
                        {
                            currentInventory.Add("iron armor");
                            currentItemGetter = "iron armor";
                        }
                    }
                }
                else if (Number == 7)
                {
                    if (currentInventory.Contains("Stone sword") || currentInventory.Contains("Iron sword"))
                    {
                        currentInventory.Add("funny tasting candy");
                        currentItemGetter = "funny tasting candy";
                    }
                    else
                    {
                        currentInventory.Add("Stone sword");
                        currentItemGetter = "Stone sword";
                    }
                }
                else if (Number == 8)
                {
                    if (currentInventory.Contains("Iron sword"))
                    {
                        currentInventory.Add("Spagettie");
                        currentItemGetter = "Spagettie";
                    }
                    else
                    {
                        if (currentInventory.Contains("Stone sword"))
                        {
                            currentInventory.Remove("Stone sword");
                            currentInventory.Add("Iron sword");
                            currentItemGetter = "Iron sword";
                        }
                        else
                        {
                            currentInventory.Add("Iron sword");
                            currentItemGetter = "Iron sword";
                        }
                    }
                }
            }

            Console.ResetColor();
            if (playerDead!)
            {
                if (currentItemGetter == "")
                {
                    Console.WriteLine("You didn't get any item\n   Press enter to exit");
                }
                else
                {
                    Console.WriteLine($"You got {currentItemGetter}\n   Press enter to exit");
                }
                string? userInput = Console.ReadLine();
            }
        }
    }
}