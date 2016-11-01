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
            bool correct = false;
            char [] text = {' '};

            do
            {
                Console.WriteLine("Podaj ścieżkę do pliku lub pozostaw puste (przykładowy plik tekstowy) i wciśnij Enter.");
                string odp = "";

                odp += Console.ReadLine();

                if (odp.Equals(""))
                {
                    text = System.IO.File.ReadAllText(@"piosenka.txt").ToCharArray();
                    correct = true;
                }
                else
                {
                    try
                    {
                        text = System.IO.File.ReadAllText(odp).ToCharArray();
                        correct = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Błąd! Sprawdź poprawnosć wpisywanych danych i spróbuj ponownie!");
                    }
                }
            } while (correct == false);

            int answer = text.Where(x => x == '\n').Count() +1;

            Console.WriteLine("Liczba Wierszy w tekście to " + answer + ".");
        }

        public static void CountWords()
        {
            bool correct = false;
            string text = "";
            do
            {
                Console.WriteLine("Podaj ścieżkę do pliku lub pozostaw puste (przykładowy plik tekstowy) i wciśnij Enter.");
                string odp = "";

                odp += Console.ReadLine();

                if (odp.Equals(""))
                {
                    text = System.IO.File.ReadAllText(@"piosenka.txt");
                    correct = true;
                }
                else
                {
                    try
                    {
                        text = System.IO.File.ReadAllText(odp);
                        correct = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Błąd! Sprawdź poprawnosć wpisywanych danych i spróbuj ponownie!");
                    }
                }
            } while (correct == false);

            string[] words = text.Split(new char [] { '\t', '\n', ' '});
            Console.WriteLine("Liczba Słów w tekście to " + words.Where(x => x!="\r").Count() +".");
        }
    }
}
