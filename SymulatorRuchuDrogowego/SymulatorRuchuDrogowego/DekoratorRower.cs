using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class DekoratorRower : DekoratorPieszego
    {
        public DekoratorRower (UzytkownikDrogi uzytkownikDrogi) : base (uzytkownikDrogi)
        {
            ;
        }

        public override int Speed()
        {
            return base.Speed() + 1;
        }

        public override string GetName()
        {
            return "Rowerzysta";
        }
    }
}
