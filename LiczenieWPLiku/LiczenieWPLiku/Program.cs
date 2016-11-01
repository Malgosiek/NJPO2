using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiczenieWPLiku
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===================\nMenu:\n1. Oblicz liczbę wierszy\n2. Oblicz liczbę wyrazów");
                string odp = Console.ReadLine();
                switch (odp)
                {
                    case "1":
                        CountRows();
                        break;
                    case "2":
                        CountWords();
                        break;
                }
            }
        }

        public static void CountRows()
        {
            ;
        }

        public static void CountWords()
        {
            Console.WriteLine("Podaj ścieżkę do pliku lub pozostaw puste (przykładowy plik tekstowy) i wciśnij Enter.");
            string odp = "";
            string text = "";

            odp += Console.ReadLine();
            if (odp.Equals(""))
                text = System.IO.File.ReadAllText(@"piosenka.txt");
            else
            {
                try
                {
                    text = System.IO.File.ReadAllText(odp);
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            string[] words = text.Split(new char [] { '\t', '\n', ' '});
            Console.WriteLine("Słów w tekście jest " +words.Length +".");
        }
    }
}
