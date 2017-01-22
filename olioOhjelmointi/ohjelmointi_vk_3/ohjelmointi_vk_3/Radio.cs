using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Radio
    {
        public bool paalla;
        int aani;
        float taajuus;
        // onko radio paalla
        public bool Paalla { get { return paalla; }
        set { paalla = value;  if (paalla == true){ paalla = true;}else{paalla = false;};}}

        //mika on aanen taajuus
        public int Aani { get { return aani; } set {
                aani = value;
                if (aani < 0)
                {
                    aani = 0;
                }else if (aani > 10) {
                    aani = 10;
                }else
                {
                    aani = Aani;
                } 
                ;}}
        //mika on taajuus
        public float Taajuus { get {return taajuus; } set {
                taajuus = value;
                if (taajuus < 2000)
                {
                    taajuus = 2000;
                }else if (taajuus > 26000)
                {
                    taajuus = 26000;
                }else
                {
                    taajuus = Taajuus;
                }
                ;}}


    }
}
