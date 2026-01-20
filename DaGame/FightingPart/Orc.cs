using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class Orc
    {
        protected virtual int damage { get; set; } = 12;
        protected virtual decimal health { get; set; } = 80;

        public void SendingStats(engine fightEngine)
        {
            fightEngine.CheckingMonsterStats(damage, health);
        }
    }
}
