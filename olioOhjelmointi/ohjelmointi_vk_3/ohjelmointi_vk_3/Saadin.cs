using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Saadin
    {
        bool OnkoKerrosValidi;
        private const int minKerros = 1;
        private const int maxKerros = 5;
        private int kerros;
        public bool OnkoPaalla { get {return OnkoPaalla; } set {
                ; }}

        /*
         * näkyvyys(valuminen), return.
         * mainb ohjelmassa ei saa olla tietoja, eikä käsitellä
         * pyritään vain tulostamaan mainistä
         * 
                     if (kerros > maxKerros || kerros < minKerros)
                     {
                         OnkoKerrosValidi = false;                
                     }
                     else
                     {
                         OnkoKerrosValidi = true;
                     }
                     return ???
         * 
         * 
         * 
         * */
        public int Kerros
        {
            get {
                if (kerros < minKerros)
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
