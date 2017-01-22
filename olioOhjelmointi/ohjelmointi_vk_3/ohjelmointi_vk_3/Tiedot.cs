using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Tiedot
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public int Salary { get; set; }

        public Tiedot(string nimi, string nimike, int palkka)
        {
            Name = nimi;
            Profession = nimike;
            Salary = palkka;
        }
    }
 

    class PomonTiedot : Tiedot
    {
        public string Car { get; set; }
        public int  Bonus { get; set; }
        public PomonTiedot(string nimi, string nimike, int palkka,string auto, int bonus)
        :base(nimi, nimike, palkka)
        {
            Car = auto;
            Bonus = bonus;
        }
    }

}
