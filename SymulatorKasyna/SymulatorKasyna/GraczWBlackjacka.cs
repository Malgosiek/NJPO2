using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorKasyna
{
    public class GraczWBlackjacka
    {
        public int Cash { get { return _cash; } set { _cash = value; } }
        private int _cash;

        public static GraczWBlackjacka Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GraczWBlackjacka();
                }

                return _instance;
            }
        }
        private static GraczWBlackjacka _instance;

        private GraczWBlackjacka()
        {
            Cash = 2000;
        }
    }
}
