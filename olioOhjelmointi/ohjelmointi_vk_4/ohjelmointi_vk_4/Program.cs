﻿using System;
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
            try
            {
                Valikko();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
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
            Console.WriteLine("eka kt1 5");
            Console.WriteLine("toka kt2 6");
            Console.WriteLine("kolmas kt3 7");
            Console.Title = "VK5";
            Console.WriteLine("kt1 8");
            Console.WriteLine("kt2 9");
            Console.WriteLine("kt3 10");
            Console.WriteLine("kt4 11");
            Console.WriteLine("kt5 12");
            Console.WriteLine("kt6 13");
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
                    case 7:
                        {
                            TestaaKolmas();
                            break;
                        }
                    case 8:
                        {
                            TestaaNeljas();
                            break;
                        }
                    case 9:
                        {
                            TestaaViides();
                            break;
                        }
                    case 10:
                        {
                            TestaaKuudes();
                            break;
                        }
                    case 11:
                        {
                            TestaaSeitsemas();
                            break;
                        }
                    case 12:
                        {
                            TestaaKahdeksas();
                            break;
                        }
                    case 13:
                        {
                            TestaaYhdeksas();
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
            Console.WriteLine("Names in a file program");
            try
            {
                string curFile = @"z:\temp\nimet.txt";
                Console.WriteLine(File.Exists(curFile) ? "Avataan tiedostoa" : "Ei tiedostoa");

                Console.WriteLine();

             string text = System.IO.File.ReadAllText(@"z:\temp\nimet.txt");
                string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                // System.Console.WriteLine("Contents of test.txt:\n" + text);
                Array.Sort(lines);
                System.Console.WriteLine("Taulukon pituus "+lines.Length+" nimea");
                foreach (var l in lines.GroupBy (x=>x))
                {
                   Console.WriteLine("{0}: {1}", l.Key, l.Count());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found (FileNotFoundException)");
            }
            finally
            {
                Console.Read();
            }
        }
        static void TestaaKolmas()
        {
            Console.WriteLine("Anna lukuja");
            System.IO.StreamWriter outputFile = null;
            try
            {              
               // jos se nyt on auki niin ei tarvitse olla.
                if (outputFile != null)
                {
                    outputFile.Close();
                }

                // Console.WriteLine(File.Exists(@"e:\temp\numerot.txt") ? "Avataan tiedostoa" : "Ei tiedostoa");
                // kayttaja syote
                Console.WriteLine("Annan numero (int (1-100 tai double (5,4))");
                string t;
                int num1;
                Double num2;
                int ok=0;


                do
                {
                    t = Console.ReadLine();
                    ok = 0;

              bool result= int.TryParse(t, out num1);
                if (result==true)
                {
                    // tiedoston tarkistaminen
                    if (!(File.Exists(@"z:\temp\numerot.txt")))
                    {
                        FileStream fs = File.Create(@"z:\temp\numerot.txt");
                    }
                        //outputFile = new System.IO.StreamWriter(@"e:\temp\numerot.txt");
                        //outputFile.WriteLine(num1);
                        File.AppendAllText(@"z:\temp\numerot.txt", num1 + Environment.NewLine);
                        // jos se nyt on auki niin ei tarvitse olla.
                        if (outputFile != null)
                        {
                            outputFile.Close();
                        }
                        ok++;
                }

                if (result == false)
                {
                    result = Double.TryParse(t, out num2);
                    if (result == true)
                    {
                        // tiedoston tarkistaminen
                        if (!(File.Exists(@"z:\temp\numerot2.txt")))
                        {
                            FileStream fs = File.Create(@"z:\temp\numerot2.txt");
                            }
                            //outputFile = new System.IO.StreamWriter(@"e:\temp\numerot2.txt");
                            //outputFile.WriteLine(num2);
                            File.AppendAllText(@"z:\temp\numerot2.txt", num2 + Environment.NewLine);
                            ok++;
                        }
                    else
                    {
                        Console.WriteLine("ei pysty");
                            ok--;
                            break;
                        }
                }

                    if (outputFile != null)
                    {
                        outputFile.Close();
                    }
                } while(ok>0);

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found (FileNotFoundException)");
            }
            catch (Exception e)
            {
                //Console.WriteLine("Some exception happened!");
                Console.WriteLine(e.Message); // Access to the path 'c:\test.file' is denied.
            }
            finally
            {
                Console.Read();
                if (outputFile != null)
                {
                    outputFile.Close();
                }
            }
        }
        
        static void TestaaNeljas()
        {
            /*
             * Toteuta Noppa-luokka siten, että noppaa voidaan heittää.
             * Nopan tulee palauttaa satunnainen luku jokaisella heittokerralla.
             * Toteuta pääohjelmassa nopan heittäminen.
             * Kokeile ensin heittää noppaa kerran ja tulosta nopan luku.
             * Toteuta tämän jälkeen ohjelma siten, että kysyt käyttäjältä heittojen määrän.
             * Heitä noppaa ja tulosta heittojen lukujen keskiarvo.
            * Esimerkki:
            *     
How many times you want to throw a dice :  10000

  Dice is now thrown 10000 times
  - average is 3,4853
  - 1 count is 1726
  - 2 count is 1610
  - 3 count is 1705
  - 4 count is 1691
  - 5 count is 1580
  - 6 count is 1688
            */
            try
            {
                int i = 0;
                int t;
                Random rnd = new Random();
                int[] taulu = new int[7];
                int b = 0;
                double keskiArvo;

                //heittojen maara kayttajalta
                Console.WriteLine("Noppa peli\n kuinka monta yritysta)");
                i = Convert.ToInt32(Console.ReadLine());

                //noppa "kone"
                do
                {
                    t = rnd.Next(1, 7);
                    taulu[t]++;
                    ++b;
                    Console.WriteLine(t);
                } while (b < i);

                //tulostukset
                keskiArvo = taulu.Average();
                Console.WriteLine("keskiarvo {0:F4}", keskiArvo);
                Console.WriteLine("tulokset");
                for (int l = 1; l < 7; l++)
                {
                    Console.WriteLine(l+" :"+taulu[l]);
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }

       static void TestaaViides()
        {
            throw new NotImplementedException();
        }
        static void TestaaKuudes()
        {
            throw new NotImplementedException();
        }
        static void TestaaSeitsemas()
        {
            throw new NotImplementedException();
        }
        static void TestaaKahdeksas()
        {
            throw new NotImplementedException();
        }
        static void TestaaYhdeksas()
        {
            throw new NotImplementedException();
        }
    }
}