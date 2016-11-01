using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymulatorRuchuDrogowego
{
    class Program
    {
        static void Main(string[] args)
        {
            //pieszy
            UzytkownikDrogi user1 = new Pieszy();
            Console.WriteLine("Szybkosc pieszego: " + user1.Speed());
            //rowerzysta
            UzytkownikDrogi user2 = new Pieszy();
            user2 = new DekoratorRower(user2);
            Console.WriteLine("Szybkosc rowerzysty: "+user2.Speed());
            //kierowca
            UzytkownikDrogi user3 = new Pieszy();
            user3 = new DekoratorSamochod(user3);
            Console.WriteLine("Szybkosc kierowcy: " + user3.Speed());

            Console.ReadLine();
        }
    }
}
