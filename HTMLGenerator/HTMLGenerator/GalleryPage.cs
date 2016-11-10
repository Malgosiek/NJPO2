using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public class GalleryPage : Page
    {
        public GalleryPage()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"gallerypage.html", false))
            {
                file.WriteLine(@"<!DOCTYPE html><html><head><meta http-equiv=""content - type"" content=""text/html; charset =UTF-8""><meta charset=""utf-8"" ><title>");
                file.WriteLine(@"Gallery page");
                file.WriteLine(@"</title ></head > ");
                file.WriteLine(@"<body>
                <div align=""center"" width=""1200"" >
                <img src=""Images/alpaka0.jpg"" width=""400""/>
                <img src=""Images/alpaka1.jpg"" width=""400""/>
                <img src=""Images/alpaka2.jpg"" width=""400""/>
                </div>
                </body ></html > ");
                Console.ReadLine();
            }
        }
    }
}
