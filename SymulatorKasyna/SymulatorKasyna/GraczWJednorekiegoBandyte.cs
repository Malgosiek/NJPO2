using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorKasyna
{
    public class GraczWJednorekiegoBandyte
    {
        public int Cash { get { return _cash; } set { _cash = value; } }
        private int _cash;

        public static GraczWJednorekiegoBandyte Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GraczWJednorekiegoBandyte();
                }

                return _instance;
            }
        }
        private static GraczWJednorekiegoBandyte _instance;

        private GraczWJednorekiegoBandyte()
        {
            Cash = 2000;
        }
    }
}
