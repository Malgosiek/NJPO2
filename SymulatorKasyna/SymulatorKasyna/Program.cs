﻿using System;
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
            var casinoCash = Casino.Instance;
            int cash = 2000, tmp;

            while (casinoCash.Cash >0)
            {
                Console.WriteLine("Stan Twojego konta: $" + cash);
                switch (Menu())
                {
                    case 1:
                        tmp = cash;
                        GraczWBlackjacka gb = new GraczWBlackjacka(cash);
                        cash = gb.Play();
                        casinoCash.Cash += tmp - cash;
                        break;
                    case 2:
                        tmp = cash;
                        GraczWJednorekiegoBandyte gj = new GraczWJednorekiegoBandyte(cash);
                        cash = gj.Play();
                        casinoCash.Cash += tmp - cash;
                        break;
                    case 3:
                        return;
                }
                Console.WriteLine("W kasie kasyna: "+casinoCash.Cash);
                
            }
            Console.WriteLine("Brak pieniędzy w kasynie!");
            Console.ReadLine();
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
