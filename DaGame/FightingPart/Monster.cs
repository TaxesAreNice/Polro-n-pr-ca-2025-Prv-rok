using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class Monster
    {
        private int monsterHP = 100;
        private int monsterDMG = 5;
        private int HP;
        private int DMG;

        public Monster(int HP, int DMG)
        {
            HP = HP;
            DMG = DMG;
        }

        internal void DoDamage(Player player)
        {
            player.TakeDamage(monsterDMG);
        }

        internal void TakeDamage(int DMG)
        {
            monsterHP -= DMG;
        }

        internal bool IsAlive()
        {
            return monsterHP >= 0;
        }
    }
}
