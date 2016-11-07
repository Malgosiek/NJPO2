using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLGenerator
{
    public class SimpleFactory
    {
        public Page CreatePage(PageType type)
        {
            switch (type)
            {
                case PageType.Gallery:
                    return new GalleryPage();
                case PageType.Informations:
                    return new InformationsPage();
                case PageType.Contact:
                    return new ContactPage();
                case PageType.News:
                    return new NewsPage();
                default:
                    throw new Exception();
            }
        }
    }
}
