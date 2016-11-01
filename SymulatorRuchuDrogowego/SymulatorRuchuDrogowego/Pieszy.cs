using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class Pieszy : UzytkownikDrogi
    {
        public override int Speed()
        {
            return 1;
        }
        
        public override string GetName()
        {
            return "Pieszy";
        }

        public override void Move()
        {
            ;
        }
    }
}
