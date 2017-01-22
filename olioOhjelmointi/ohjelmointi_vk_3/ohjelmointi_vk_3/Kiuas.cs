using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{


    public class Kiuas
    { 
        // properties // ominaisuudet
        public bool OnkoPaalla { get; set; } // prop <sarkain><sarkain>... 
        public float Lampotila { get; set; }
        float kosteus;
        public float Kosteus
        {
            get{ return kosteus;}

            set {kosteus =value;
            if (kosteus >0 || kosteus > 100)
                {
                    kosteus = 0;
                }
            }
        }


    }
    }
