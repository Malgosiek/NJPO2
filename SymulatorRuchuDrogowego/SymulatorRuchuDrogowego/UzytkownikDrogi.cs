using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    abstract class UzytkownikDrogi
    {
        public abstract int Speed();
        public abstract string GetName();
        public abstract void Move();
    }
}
