using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public class NewsPage : Page
    {
        public NewsPage()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"newspage.html", false))
            {
                file.WriteLine(@"<!DOCTYPE html><html><head><meta http-equiv=""content - type"" content=""text/html; charset =UTF-8""><meta charset=""utf-8"" ><title>");
                file.WriteLine(@"News page");
                file.WriteLine(@"</title ></head > ");
                file.WriteLine(@"<body>
                <div align=""center"">
                <h1>Aktualności</h1>
                <h2>Alpaca Day 2016</h2>
                <h3>Alpaca Day 2016 - to dwudniowa WYSTAWA dla hodowców i miłośników alpak.<br><br>

                ALPACA DAY 2016 odbędzie się 12-13 listopada 2016 w Gajewnikach k. Zduńskiej Woli w znanej z imprez jeździeckich Stajni Gajewniki.<br><br>

                W programie:<br>
                -> Wystawa zwierząt- alpaki<br>
                -> Konferencja naukowa<br>
                ->Wybór czempiona imprezy<br>
                -> Warsztaty rzeźby w drewnie, filcowania i przędzenia włókna,<br>
                -> Występ zespołu peruwiańskiego,<br>
                -> Pokaz mody wyrobów odzieżowych z włókna alpaki,<br>
                -> Konkursy i zabawy dla dzieci i wiele wiele innych...<br><br>

                Serdecznie zapraszamy do udziału. <br>
                <a href=""https://www.facebook.com/events/109849429421478/"">Link do wydarzenia</a>
                </h3>
                <h2>Fanpage na Facebook</h2>
                <h3>Zapraszamy do polajkowania naszego fanpage <br>
                <a href=""https://www.facebook.com/alpacaday/"">Link do fanpage </a>
                </h3>
                </div>
                </body ></html > ");
                Console.ReadLine();
            }
        }
    }
}
