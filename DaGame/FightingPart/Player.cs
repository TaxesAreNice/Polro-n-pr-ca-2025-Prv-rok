using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class Player
    {
        private int maxHP = 100;
        private int DMG = 15;

        internal void DoDamage(Monster monster)
        {
            monster.TakeDamage(DMG);
        }

        internal void TakeDamage(int monsterDMG)
        {
            maxHP -= monsterDMG;
        }

        internal bool IsAlive()
        {
            return maxHP >= 0;
        }
    }
}



