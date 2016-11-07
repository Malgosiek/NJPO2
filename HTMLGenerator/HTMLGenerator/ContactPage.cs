using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public class ContactPage : Page
    {
        public ContactPage()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"contactpage.html", false))
            {
                file.WriteLine(@"<!DOCTYPE html><html><head><meta http-equiv=""content - type"" content=""text/html; charset =UTF-8""><meta charset=""utf-8"" ><title>");
                file.WriteLine(@"Contact page");
                file.WriteLine(@"</title ></head > ");
                file.WriteLine(@"<body>
                <div>
                </div>
                </body ></html > ");
                Console.ReadLine();
            }
        }
    }
}
