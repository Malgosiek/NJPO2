using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class Pieszy : UzytkownikDrogi
    {
        private int _X;
        public override int X
        {
            get { return _X; }
            set { _X = value; }
        }

        private int _y;
        public override int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Pieszy() { }

        public Pieszy(UzytkownikDrogi user)
        {
            X = user.X;
            Y = user.Y;
        }
        
        public override int Speed()
        {
            return 1;
        }
        
        public override string GetName()
        {
            return "P";
        }
    }
}
