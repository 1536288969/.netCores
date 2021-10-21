using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
   public class WebMenu
    {
        public int ID { get; set; }
        public string Cn { get; set; }

        public virtual List<Information> Informations { get; set; }
    }
}
