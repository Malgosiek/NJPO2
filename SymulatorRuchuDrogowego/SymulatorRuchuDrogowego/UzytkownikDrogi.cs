using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    abstract class UzytkownikDrogi
    {
        public abstract int X
        {
            get; set;
        }
        public abstract int Y
        {
            get; set;
        }

        public abstract int Speed();
        public abstract string GetName();
    }
}
