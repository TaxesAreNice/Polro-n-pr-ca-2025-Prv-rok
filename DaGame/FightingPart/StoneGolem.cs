using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class StoneGolem : Orc
    {
        protected override int damage { get; set; } = 8;
        protected override decimal health { get; set; } = 125;
    }
}
