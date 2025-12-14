using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class Boss : Monster
    {
        public Boss(int _HP, int _DMG) : base(_HP, _DMG)
        {
            _HP = 200;
            _DMG = 25;
        }
    }
}
