using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Pesukone
    {

        // properties // ominaisuudet
        public bool OnkoPaalla { get; set; } // prop <sarkain><sarkain>... 
        public float Vesi { get;
            set;
        }
        float vedenLampo;
        public float VedenLampo
        {
            get { return vedenLampo; }

            set { vedenLampo = value; 
                if (vedenLampo < 0 || vedenLampo > 100)
                {
                    vedenLampo = 0; // ei anneta veden lammon nosuta tai laskea halutulta alueelta
                }

            }
        }
    }
}