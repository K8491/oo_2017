using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK4
{
    class Program
    {
            static void Main(string[] args){
                Valikko();
            }
            static void Valikko()
        {
                Console.Clear();
                int luku = 0;
                Console.Title = "VK4";
                Console.WriteLine("Viikko 4 tehtavat");
            Console.WriteLine("Rengas tehtava 1");
            Console.WriteLine("Rengas tehtava 2");
            switch (luku)
            {
                case 0:
                    {
                        Console.WriteLine("Viikko 4 tehtavat");
                        break;
                    }
                case 1:
                    {
                        RengasTehtava();
                        break;
                    }
                case 2:
                    {
                        JaakaappiTehtava();
                        break;
                    }
                   
            }
            Console.Read();
            Console.Clear();
            Valikko();
        }

    static void RengasTehtava()
        {
            Auto auto = new Auto();
            auto.Malli = "Porche model 911";
            
      Rengas tyre1 = new Rengas { Valmistaja = "Nokia", Malli = "Hakkapeliitta", Rengaskoko = "205R16" };
             
     // create a car
        Auto kaara = new Auto { Nimi = "Porsche", Malli = "911" };
        Console.WriteLine("Luotu uusi pirssi {0} {1}", kaara.Nimi, kaara.Malli);
      
            // nelja kpl
           kaara.LisääRengas(tyre1);
            // tuloste
            Console.WriteLine(kaara.ToString());
            }
        static void JaakaappiTehtava()
        {

        }
    }
}
