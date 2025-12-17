using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class engine
    {
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
