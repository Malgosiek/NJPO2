using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public class InformationsPage : Page
    {
        public InformationsPage()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"informationspage.html", false))
            {
                file.WriteLine(@"<!DOCTYPE html><html><head><meta http-equiv=""content - type"" content=""text/html; charset =UTF-8""><meta charset=""utf-8"" ><title>");
                file.WriteLine(@"Informations page");
                file.WriteLine(@"</title ></head > ");
                file.WriteLine(@"<body>
                <div align=""center"">
                <h1>Alpaka (Vicugna pacos)</hi>
                <h2>południowoamerykański, trawożerny ssak parzystokopytny z rodziny wielbłądowatych.<br>
                Zwierzę udomowione, hodowane dla wełny i mięsa, przypomina nieco lamę, ale jest od niej mniejsza i z budowy ciała bardziej podobna do owcy.<br>
                </h2>
                <h3>Ciało alpaki osiąga 128–151 cm długości, przy wysokości w kłębie 80–100 cm i masie ciała 55–65 kg. <br>
                Ubarwienie różnorodne (26 kolorów), najczęściej czarne lub brązowo-czarne, czasem białe. <br>
                Alpaki są zwierzętami socjalnymi tworzącymi grupy rodzinne złożone z dominującego samca, kilku samic i ich potomstwa. <br>
                Ciąża u alpaki trwa około 335–340 dni, rodzi zazwyczaj jedno małe. Alpaki żyją około 15–25 lat. <br>
                Hodowana w dużych stadach, na mięso i wełnę. Właśnie dla tego surowca przystosowano ją do życia w Europie. Sierść alpaki wyróżnia się jedwabistym połyskiem. <br>
                Występują dwie rasy alpak – suri i huacaya, różnią się okrywą włosową. Włosy suri dorastają do 50 cm długości.<br>
                Z wełny alpaki produkuje się koce, poncza oraz wysokiej klasy odzież. <br>
                Alpaka hodowana jest w Andach na obszarze od południowego Peru, Chile po północną Boliwię.<br>
                </h3>
                </div>
                </body ></html > ");
            }
            System.Diagnostics.Process.Start(@"informationspage.html");
            Thread.Sleep(500);
        }
    }
}
