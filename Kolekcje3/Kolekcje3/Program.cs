using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolekcje3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startAL, endAL, startLL, endLL;
            List<int> list = new List<int>();
            LinkedList<int> llist = new LinkedList<int>();

            Console.WriteLine("Porównywanie ArrayLista i LinkedList.");
            Console.WriteLine("Czekaj: tworzenie list");

            startAL = DateTime.Now;
            for (int i = 0; i < 10000000; i++)
                    list.Add(100);
            endAL = DateTime.Now;

            startLL = DateTime.Now;
            for (int i = 0; i < 10000000; i++)
                llist.AddLast(100);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));

            Console.WriteLine("Wstawianie elementu na początek");
            startAL = DateTime.Now;
            for (int i = 0; i < 1000; i++)
                list.Insert(0, 5);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 1000; i++)
                llist.AddFirst(5);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" +endAL.Subtract(startAL) +"\nLinkedList: \t"+endLL.Subtract(startLL));

            Console.WriteLine("Wstawianie elementu do środka");
            startAL = DateTime.Now;
            for (int i = 0; i < 100; i++)
                list.Insert(list.Count / 2, 5);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 100; i++)
                llist.AddAfter(llist.Find(llist.ElementAt(llist.Count / 2)), 5);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));

            Console.WriteLine("Wstawianie elementu na koniec");
            startAL = DateTime.Now;
            for(int i=0; i<200000; i++)
                list.Add(5);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 200000; i++)
                llist.AddLast(5);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));

            Console.WriteLine("Usunięcie z początku"); startAL = DateTime.Now;
            for (int i = 0; i < 100; i++)
                list.Remove(0);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 100; i++)
                llist.Remove(0);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));

            Console.WriteLine("Usunięcie ze środka");
            for (int i = 0; i < 100; i++)
                list.Remove(list.Count/2);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 100; i++)
                llist.Remove(llist.Count/2);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));
            
            Console.WriteLine("Usunięcie z końca");
            startAL = DateTime.Now;
            for (int i = 0; i < 200000; i++)
                list.RemoveAt(list.Count -1);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 200000; i++)
                llist.RemoveLast();
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));


            int tmp;
            Console.WriteLine("Zwrócenie wartości pierwszego elementu");
            startAL = DateTime.Now;
            for (int i = 0; i < 50000; i++)
                tmp = list.ElementAt(0);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 50000; i++)
                tmp = llist.ElementAt(0);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));

            Console.WriteLine("Zwrócenie wartości środkowego elementu");
            startAL = DateTime.Now;
            for (int i = 0; i < 500; i++)
                tmp = list.ElementAt(list.Count / 2);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 500; i++)
                tmp = llist.ElementAt(llist.Count / 2);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));

            Console.WriteLine("Zwrócenie wartości ostatniego elementu");
            startAL = DateTime.Now;
            for (int i = 0; i < 500; i++)
                tmp = list.ElementAt(list.Count-1);
            endAL = DateTime.Now;
            startLL = DateTime.Now;
            for (int i = 0; i < 500; i++)
                tmp = llist.ElementAt(llist.Count -1);
            endLL = DateTime.Now;
            Console.WriteLine("List: \t\t" + endAL.Subtract(startAL) + "\nLinkedList: \t" + endLL.Subtract(startLL));
            Console.WriteLine("Koniec testów. Kliknij enter aby zakończyć.");
            Console.ReadLine();
        }
    }
}
