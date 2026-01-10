using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Polročná_práca_2025_Prvý_rok.MapPart;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class engine
    {
        public List<string> currentInventory = new List<string>();
        public int expReturner = 0;
        Random random = new Random();

        public int PlayerHp = 100;
        private int PlayerDamege = 10;

        private string daMonster = "";
        public void GettingDaMonster(string currentininyMonstertininy, List<string> playersItems)
        {
            daMonster = currentininyMonstertininy;
            playersItems = playersItems.ToList();
            PlayerHp -= 10;
            currentInventory = playersItems;
            Console.Clear();
            Console.WriteLine(daMonster);
        }
        public void StartFight()
        {
            Console.Clear();
            Console.WriteLine("A wild " + daMonster + " appeared!");
            string? userInput = Console.ReadLine();
            AfterFight();
        }
        private void AfterFight()
        {
            int daNumber = 0;   
            if (daMonster == "Zombie")
            {
                expReturner = 10;
                daNumber = random.Next(0, 4);
            }
            else if (daMonster == "Orc")
            {
                expReturner = 15;
                daNumber = random.Next(3, 6);
            }
            else if (daMonster == "StoneGolem")
            {
                expReturner = 20;
                daNumber = random.Next(3, 6);
            }
            else
            {
                expReturner = 10;
                daNumber = random.Next(0, 6);
            }

            if (currentInventory.Count >= 10)
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
                    if (currentInventory.Contains("leather armor"))
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
            }
        }

        internal void TakeTurns(Player player, Monster monster)
        {
            bool isGoing = true;

            while (isGoing)
            {
                player.DoDamage(monster);
                monster.DoDamage(player);
                
            }
        }
        public void Play(Player player, Monster monster)
        {
            while (player.IsAlive())
            {
                TakeTurns(player, monster);

            }
        }
    }
}
