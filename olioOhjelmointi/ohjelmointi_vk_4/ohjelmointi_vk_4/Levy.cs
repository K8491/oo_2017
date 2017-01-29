using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK4
{
    class CD
    { 
        public string Nimi { get; set; }
        public string Artisti { get; set; }

        public string Laulu { get; set; }
        public float Kesto { get; set; }

        public override string ToString()
        {
            return Nimi + " " + Artisti+" "+Laulu + " "+Kesto;
        }
    }
    class Levyt
    {
        private int biisi = 0;
        private List<CD> levyt;
        public List<CD> LevytL
        {
            get { return levyt; }
        }
        public void LisaaLevy(CD levy)
        {
            levyt.Add(levy);
            biisi++;
        }
        public CD HaeLevy(int index)
        {
            if (index < levyt.Count)
            {
                return levyt.ElementAt(index);
            }
            else
            {
                return null;
            }
        }
    }
}
