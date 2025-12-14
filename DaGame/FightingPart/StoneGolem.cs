using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polročná_práca_2025_Prvý_rok.FightingPart
{
    internal class StoneGolem : Monster
    {
        public StoneGolem(int _HP, int _DMG) : base(_HP, _DMG)
        {
            _HP = 500;
            _DMG = 1;
        }
    }
}
