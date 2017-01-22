using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Ajoneuvo
    {
        public string Nimi { get; set; }
        public string Malli { get; set; }
        public int Vuosimalli { get; set; }
        public string Vari { get; set; }

        public Ajoneuvo(string nimi, string malli, int vuosimalli, string vari)
        {
           Nimi = nimi;
           Malli = malli;
           Vuosimalli = vuosimalli;
            Vari = vari;
        }
    }


    class Vene : Ajoneuvo
    {

        public int Paikkoja { get; set; }
        public string Tyyppi { get; set; }
        public Vene(string nimi, string malli, int vuosimalli, string vari,int paikkoja, string tyyppi )
        :base(nimi,malli, vuosimalli,vari)
        {
           Paikkoja = paikkoja;
           Tyyppi= tyyppi;
        }
    }
    class Pyora : Ajoneuvo
    {
        public bool Vaihteet { get; set; }
        public string VaihteetNimi { get; set; }
        public Pyora(string nimi, string malli, int vuosimalli, string vari, bool vaihteet,string vaihteetNimi )
        : base(nimi, malli, vuosimalli, vari)
        {
            Vaihteet = vaihteet;
            VaihteetNimi = vaihteetNimi;
        }
    }

}
