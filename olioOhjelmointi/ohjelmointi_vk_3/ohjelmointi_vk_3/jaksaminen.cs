using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Jaksaminen
    {
        int pinna;
        int vasymys;

        public int Pinna { get {return pinna;} set { pinna = value;}}
        public int Vasymys { get { return vasymys; } set { vasymys = value ;}}

        public Jaksaminen(int pinna, int vasymys)
        {
            Pinna = pinna;
            Vasymys = vasymys;
        }

    }
   class Opiskelija : Jaksaminen
    {
        bool onkoTerve;
        public bool OnkoTerve{get{ return onkoTerve; }set{onkoTerve = value;}}

        public Opiskelija(int pinna, int vasymys, bool onkoTerve)
        :base(pinna,vasymys)
        {
            OnkoTerve = onkoTerve;
        }
    }
}
