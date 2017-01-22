using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Saadin
    {   private const int minKerros = 1;
        private const int maxKerros = 5;
        private int kerros;
        public bool OnkoPaalla { get {return OnkoPaalla; } set {
                ; }}

        
        public int Kerros
        {
            get {             
                if (kerros >=  minKerros && kerros <= maxKerros)
                {
                    return kerros;
                }
                else
                {
                    return 0; //"Epakelpo arvo";
                }
            }
            set
            {
                kerros = value;

            }
        }
    }
}
