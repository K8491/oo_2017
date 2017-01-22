using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{


    public class Televisio
    {
        // properties // ominaisuudet
        public bool OnkoPaalla { get; set; } // prop <sarkain><sarkain>... 
        int kanava;
        float aani;
        public float Aani
        {
            get { return aani; }
            set
            {
                if (aani>100 || aani < 0)
                {
                    aani = 0;
                }
                ;
            }
        }

        public int Kanava {
            get { return kanava; }
            set {
                kanava = value;
         if (kanava > 100 || kanava < 0)
                {
                    kanava = 1;
                }
             ;}
        }
        
    }
}
