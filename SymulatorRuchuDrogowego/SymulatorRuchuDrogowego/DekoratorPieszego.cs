using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class DekoratorPieszego : UzytkownikDrogi
    {

        protected UzytkownikDrogi _uzytkownikdrogi;

        public DekoratorPieszego(UzytkownikDrogi uzytkownikDrogi)
        {
            _uzytkownikdrogi = uzytkownikDrogi;
        }

        public override int Speed()
        {
            return _uzytkownikdrogi.Speed();
        }
        public override string GetName()
        {
            return _uzytkownikdrogi.GetName();
        }
        public override void Move()
        {
            _uzytkownikdrogi.Move();
        }
    }
}
