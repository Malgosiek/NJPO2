using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class DekoratorPieszego : UzytkownikDrogi
    {

        public override int X
        {
            get; set;
        }
        public override int Y
        {
            get; set;
        }

        protected UzytkownikDrogi _uzytkownikdrogi;

        public DekoratorPieszego(UzytkownikDrogi uzytkownikDrogi)
        {
            _uzytkownikdrogi = uzytkownikDrogi;
            X = uzytkownikDrogi.X;
            Y = uzytkownikDrogi.Y;
        }

        public override int Speed()
        {
            return _uzytkownikdrogi.Speed();
        }
        public override string GetName()
        {
            return _uzytkownikdrogi.GetName();
        }
    }
}
