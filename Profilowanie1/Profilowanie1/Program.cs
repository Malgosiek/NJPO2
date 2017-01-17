using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza1;

namespace Profilowanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Przykład wycieku pamięci w C#");

            DataBaseConnector connector = DataBaseConnector.Instance;

            // Brak zamykania zasobów powoduje wyciek pamięci

            while (true)
            {
                connector.Query("SELECT * FROM Contacts");
            }

            Console.WriteLine($"Ilość zajętej pamięci: {GC.GetTotalMemory(true)}");
            Console.WriteLine("Naciśnij enter aby kontynuować...");
            Console.ReadLine();
        }
    }
}
