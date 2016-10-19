using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorKasyna
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        BlackJack bj = new BlackJack();
                        bj.Play(GraczWBlackjacka.Instance);
                        break;
                    case 2:
                        JednorekiBandyta jb = new JednorekiBandyta();
                        jb.Play(GraczWJednorekiegoBandyte.Instance);
                        break;
                    case 3:
                        return;
                }
                Console.ReadLine();
                
            }
        }

        static int Menu()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("Wybierz gre: "
                + "\n1. Black Jack\n2. Jednoręki bandyta\n3. Wyjście");
            Console.WriteLine("---------------------------");
            return int.Parse(Console.ReadLine());
        }
    }
}
