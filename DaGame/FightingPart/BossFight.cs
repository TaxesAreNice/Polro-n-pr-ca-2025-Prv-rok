using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaGame.FightingPart;
using Polročná_práca_2025_Prvý_rok.FightingPart;

namespace DaGame.FightingPart
{
    internal class BossFight : Orc
    {


        protected override int damage { get; set; } = 50;
        protected override decimal health { get; set; } = 250;
        public bool RunBossFight()
        {
            Console.SetCursorPosition(0, 25);
            {
                Console.WriteLine("Do want to enter boss fight? (y/n)");
            }

            string? input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.Clear();
                return false;
            }
        }
    }
}