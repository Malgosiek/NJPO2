using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public enum PageType
    {
        Gallery,
        Informations,
        Contact,
        News
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleFactory factory = new SimpleFactory();
            Random random = new Random();

            Page page = factory.CreatePage(PageType.Contact);
            Console.WriteLine(page.GetType());
            page = factory.CreatePage((PageType)random.Next(4));
            Console.WriteLine(page.GetType());
            page = factory.CreatePage((PageType)random.Next(4));
            Console.WriteLine(page.GetType());
            page = factory.CreatePage((PageType)random.Next(4));
            Console.WriteLine(page.GetType());
            Console.ReadLine();
        }
    }
}
