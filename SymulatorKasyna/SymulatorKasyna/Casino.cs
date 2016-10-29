using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorKasyna
{
    public class Casino
    {
        public int Cash { get { return _cash; } set { _cash = value; } }
        private int _cash;

        public static Casino Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Casino();
                }

                return _instance;
            }
        }
        private static Casino _instance;

        private Casino()
        {
            Cash = 10000;
        }
    }
}
