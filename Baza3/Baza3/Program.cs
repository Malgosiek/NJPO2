using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza1;
using System.Data.Common;

namespace Baza3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("########## Porównanie sortowania ##########");

            DataBaseConnector connector = DataBaseConnector.Instance;
            string query = "SELECT * FROM Data";

            DbDataReader reader = connector.Query(query);

            if (!reader.HasRows)
            {
                Console.WriteLine("Trwa wypełnianie bazy danych...");

                Random rand = new Random();

                for (long i = 1; i < long.MaxValue; i++)
                {
                    connector.NonQuery($"INSERT INTO Data VALUES ({i}, {rand.Next()})");
                }
            }

            reader.Close();

            reader = connector.Query(query);

            List<Data> data = new List<Data>();

            while (reader.Read())
            {
                Data d = new Data
                {
                    Id = long.Parse(reader["Id"].ToString()),
                    Value = long.Parse(reader["Data"].ToString())
                };

                data.Add(d);
            }

            Console.WriteLine("Trwa sortowanie...");
            // Sortowanie w C#

            DateTime start = DateTime.Now;

            data.OrderBy(x => x.Value);

            DateTime end = DateTime.Now;
            TimeSpan difference = end.Subtract(start);


            Console.WriteLine($"Czas sortowania w pamięci: {difference.Hours}:{difference.Minutes}:{difference.Seconds}.{difference.Milliseconds}");

            start = DateTime.Now;

            reader = connector.Query("SELECT * FROM Data ORDER BY Data");

            end = DateTime.Now;
            difference = end.Subtract(start);

            reader.Close();

            Console.WriteLine($"Czas sortowania w bazie danych: {difference.Hours}:{difference.Minutes}:{difference.Seconds}.{difference.Milliseconds}");
            Console.WriteLine("Naciśnij enter aby kontynuować...");
            Console.ReadLine();
        }
    }
}
