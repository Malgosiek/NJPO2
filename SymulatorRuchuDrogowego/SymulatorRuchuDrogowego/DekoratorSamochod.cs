using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class DekoratorSamochod : DekoratorPieszego
    {
        public DekoratorSamochod(UzytkownikDrogi uzytkownikDrogi) : base(uzytkownikDrogi)
        {
            ;
        }

        public override int Speed()
        {
            return 4;
        }

        public override string GetName()
        {
            return "K";
        }
    }
}
