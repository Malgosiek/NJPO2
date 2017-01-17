using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testy2
{
    public class Sortowanie
    {
        private List<int> _lista;

        public List<int> Numbers
        {
            get { return _lista; }
        }

        public Sortowanie()
        {
            _lista = new List<int>();

            Random r = new Random();

            for (int i = 0; i < 10000000; i++)
            {
                _lista.Add(r.Next());
            }
        }

        public List<int> Sortuj()
        {
            return _lista.OrderBy(x => x).ToList();
        }
    }
}
