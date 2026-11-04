using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    class Accessory
    {
        public string color { get; set; }

        public override string Description()
        {
            return $"Color: {color},Product: {Product},Cost: {Cost}, Category: {Category}, Quantity: {Quantity}";
        }
    }
}
