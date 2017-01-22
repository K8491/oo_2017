using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Vahvistin
    {
        const int minAani=0;
        const int maxAani=100;
        int aani;
        public int Aani
        {
            get { return aani; }
            set { aani = value;
                if (aani < minAani)
                {
                    aani = 0;
                }else if (aani > maxAani)
                {
                    aani = 100;
                }
                else
                {
                  aani = Aani;
                }
            }
        }



    }
}
