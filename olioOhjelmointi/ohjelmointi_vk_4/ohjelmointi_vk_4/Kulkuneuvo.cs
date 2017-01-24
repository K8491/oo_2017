using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK4
{
    class Kulkuneuvo
    {
    }
    class Rengas
    {
        public string Valmistaja { get; set; }
        public string Malli { get; set; }
        public string RengasKoko { get; set; }
        
        public override string ToString()
        {
            return "Renkaiden " + Malli +" Valmistaja " + Valmistaja+ " Rengaskoko " + RengasKoko;
        }
    }
    class Auto
    {
        public string Nimi { get; set; }
        public string Malli { get; set; }
        const int MaxRenkaat = 4;
        private int lkmRenkaat = 0;
        public List<Rengas> Renkaat { get; }

        public Auto(string nimi, string malli, int renkaaat, int maxRenkaat)
        {
            Renkaat = new List<Rengas>();
        }

        public void LisaaRengas(Rengas rengas)
        {
            if (lkmRenkaat < MaxRenkaat)
            {
                Renkaat.Add(rengas);
                lkmRenkaat++;
                Console.WriteLine("rengas lisatty");
            }
            else
            {
                Console.WriteLine("Ei renkaita saatavilla");
            }
        }

        public override string ToString()
        {
            // ei tulosta auton nimeä tai mallia onnistuneesti
            string s = " autossa " + Nimi + " Malli " + Malli + "\nrenkaat:";
            foreach (Rengas r in Renkaat)
            {
                if (r != null) s += "\n-" + r.ToString();
            }
            return s;
        }

    }
}