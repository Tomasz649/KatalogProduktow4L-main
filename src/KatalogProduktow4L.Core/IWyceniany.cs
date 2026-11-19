using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public interface IWyceniany
    {
        string Nazwa { get; set; }
        double Cena { get; set; }
    }
}
