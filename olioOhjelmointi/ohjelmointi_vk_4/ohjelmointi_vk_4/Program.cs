using System;
using System.Collections.Generic;
using System.IO;
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
            Console.WriteLine("Henkilorekisteri 3");
            Console.WriteLine("CD-levy 4");
            Console.WriteLine("CD-levy 5");
            luku = 0;
            try
            {
                luku = Convert.ToInt32(Console.ReadLine());
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
                    case 3:
                        {
                            TestaaHenkiloRekisteri();
                            break;
                        }
                    case 4:
                        {
                            TestaaLevy();
                            break;
                        }
                    case 5:
                        {
                            TestaaEka();
                            break;
                        }
                    case 6:
                        {
                            TestaaToka();
                            break;
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Syota luku (int)", e);
                //    luku = Convert.ToInt32(Console.ReadLine());
                Valikko();
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
/*
            Kaappi kaappi = new Kaappi();
            kaappi.LisaaTuote();

            Tuote makkara = new Tuote("Makkara",true,3);
            Console.WriteLine(makkara.Nimi+"  " +makkara.OnkoSyotava+"  "+makkara.tuoteMaara);

            Console.WriteLine(kaappi.ToString());*/
        }

     static void TestaaHenkiloRekisteri()
        {
            /// <summary>
            /// This class contains person properties
            /// </summary>
        }
        /* HLO rekisteri
                class HenkiloRekisteri
                {
                    // muutama testi henkilo
                    HenkiloRekisteri poppoo = new HenkiloRekisteri();
                    HenkiloRekisteri hlo = new HenkiloRekisteri { Etunimi = "Jack" }

                foreach (Henkilo h in poppoo.Henkilolista)
            {
                    Console.WriteLine();
                        // todo kysy hetu ja hae henkilö näytölle

                }
                */

        static void TestaaLevy()
        {
            List<CD> levyt = new List<CD>();
            // ois pitany teha biisesita lista niin ei tarvii uudestaan syottaa samaa montaa kertaa
            levyt.Add(new CD { Artisti = "Maija Koo", Nimi = "Tulahdukset", Laulu = "Salamoita", Kesto = 4.4F });
            levyt.Add(new CD { Artisti = "Maija Koo", Nimi = "Tulahdukset",Laulu="Tuuli ulvoo",Kesto=3.43F});

            levyt.Add(new CD { Artisti = "Muumit", Nimi = "Laakson leiri laulut",Laulu="", Kesto = 1.11F });
            levyt.Add(new CD { Artisti = "Muumit", Nimi = "Laakson leiri laulut", Kesto = 2.4F });

            // tulostaa oliot listasta
                levyt.ForEach(item => Console.Write(item + "\n"));

            Console.WriteLine();
        }
        static void TestaaEka()
        {

            //  Tehtävä 1 - Tiedostoon kirjoittaminen ja lukeminen
            System.IO.StreamWriter outputFile = null;
            try
            {
                string syote = null;
                string syote2 = null;
                outputFile = new System.IO.StreamWriter(@"z:\tmp\test.txt");
                Console.WriteLine("Kirjoitas jotain tiedostoon");
                // otetaan syote kayttajalta
                do
                {

                  syote =  Convert.ToString(Console.ReadLine());
                  syote2 += syote+"\n";
 
                }while(!(syote == null || syote == "\n"||syote ==""));
                //kirjotetaan (kirjoittaa paalle, eli ei saasta mita tiedostossa jo on
                if (!(syote2 == null))
                {
                    outputFile.WriteLine("\n" +syote2);
                    outputFile.Close();
                }

                //luetaan
                string text = System.IO.File.ReadAllText(@"z:\tmp\test.txt");
              System.Console.WriteLine("sisalto kohteesta tmp test"+ text);
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Some exception happened!");
                Console.WriteLine(ex.Message); // Access to the path 'c:\test.file' is denied.
            }
            finally
            {
                // check for null because OpenWrite might have failed
                if (outputFile != null)
                {
                    outputFile.Close();
                }
            }
        }
        static void TestaaToka()
        {

        }
        }
}