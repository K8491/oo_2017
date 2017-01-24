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
                Console.WriteLine("Jaakaappi 2");
            luku = 0;
            try
            {
                luku = Convert.ToInt32(Console.ReadLine());
            }

            catch (Exception e)
            {
                Console.WriteLine("Syota luku (int)", e);
                luku = 0;
                luku = Convert.ToInt32(Console.ReadLine());
            }
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
            Auto auto = new Auto("Porche","911",0,4);
            Rengas tyre1 = new Rengas { Valmistaja = "Nokia", Malli = "Hakkapeliitta", RengasKoko = "205R16" };
             
     // create a car
        Console.WriteLine("Luotu uusi pirssi {0} {1}", auto.Nimi, auto.Malli);

            // viisi kpl, koska rajat on maaritelty 4
            auto.LisaaRengas(tyre1);//1
            auto.LisaaRengas(tyre1);//2
            auto.LisaaRengas(tyre1);//3
            auto.LisaaRengas(tyre1);//4
            auto.LisaaRengas(tyre1);//5
            // tuloste
            Console.WriteLine(auto.ToString());

            Auto auto2 = new Auto("Ducanti", "diavel", 0, 2);
            Rengas tyre2 = new Rengas { Valmistaja = "MIC", Malli = "Pilot", RengasKoko = "160R17" };
            Rengas tyre3 = new Rengas { Valmistaja = "MIC", Malli = "Pilot", RengasKoko = "140R16" };

            Console.WriteLine("Luotu uusi pirssi {0} {1}", auto2.Nimi, auto2.Malli);
            auto2.LisaaRengas(tyre2);//1
            auto2.LisaaRengas(tyre3);//2
            Console.WriteLine(auto2.ToString());
        }
        static void JaakaappiTehtava()
        {

            Kaappi kaappi = new Kaappi(makkara);
            kaappi.LisaaTuote(makkara);

            Tuote makkara = new Tuote("Makkara",true,3);
            Console.WriteLine(makkara.Nimi+"  " +makkara.OnkoSyotava+"  "+makkara.tuoteMaara);

            Console.WriteLine(kaappi.ToString());
        }
    }
}
