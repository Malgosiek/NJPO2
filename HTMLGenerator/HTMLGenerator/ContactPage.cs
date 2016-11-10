using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public enum Names
    {
        Ania,
        Kasia,
        Tomek,
        Kuba
    }
    public enum LastNames
    {
        Zwierz,
        Kot,
        Lis,
        Lama
    }

    public class ContactPage : Page
    {
        public ContactPage()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"contactpage.html", false))
            {
                Random r = new Random();

                file.WriteLine(@"<!DOCTYPE html><html><head><meta http-equiv=""content - type"" content=""text/html; charset =UTF-8""><meta charset=""utf-8"" ><title>");
                file.WriteLine(@"Contact page");
                file.WriteLine(@"</title ></head > ");
                file.WriteLine(@"<body>
                <div align=""center"">
                <h1>Kontakt</h1>");
                file.WriteLine("<h2>"+ ((Names)r.Next(3)).ToString() +" " +((LastNames)r.Next(3)).ToString());
                file.WriteLine(@"<br>Telefon: ");
                for (int i = 0; i < 10; i++)
                {
                    int x = r.Next(10);
                    if (i == 0 && x == 0)
                        i++;
                    else
                        file.Write("" + x);
                }
                file.WriteLine(@"<br></h2>
                </div>
                </body ></html > ");
                Console.ReadLine();
            }
        }
    }
}
