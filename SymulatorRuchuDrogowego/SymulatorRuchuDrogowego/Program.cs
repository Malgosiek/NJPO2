using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Podaj rozmiar planszy (sugerowane 5): ");
                try
                {
                    int length = Convert.ToInt32(Console.ReadLine());
                    Symulator sym = new Symulator(length);
                    sym.Play();
                }
                catch(Exception)
                {
                    Console.WriteLine("Nieprawidłowa wartość.");
                }
            }
        }
    }
}
