using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ohjelmointi.VK3; // helpottaa (tai JAMK.IT niin kuin opella)
namespace ohjelmointi.VK3
{
    class Program
    {
        static void Main(string[] args)
        {
            Valikko();
        }

        static void Valikko()
        {
            int luku = 0;
            Console.Title = "WHHHAAAAT??!!";
            Console.WriteLine("Viikko 3 tehtavat");
            Console.WriteLine("Valitse tehtava");
            Console.WriteLine("Kiuas tehtava (nro 1)");
            Console.WriteLine("Pesukone tehtava (nro 2)");
            Console.WriteLine("Televisio tehtava (nro 3)");
            Console.WriteLine("Hissi tehtava (nro 8)");
            Console.WriteLine("vahvistin tehtava (nro 9)");
            Console.WriteLine("Tietojen käsittely tehtava (nro 10)");
            Console.WriteLine("Ajoneuvojen käsittely tehtava (nro 11)");
       
            luku = Convert.ToInt32(Console.ReadLine());
            switch (luku)
            {
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("Tai paina CTRL + C (lopettaa ohjelman)");
                        Valikko();
                        break;
                    }
                case 1:
                    {
                        Console.Title = "Tehtava 1";
                        TestaaKiuas();
                        break;
                    }
                case 2:
                    {
                        Console.Title = "Tehtava 2";
                        TestaaPesukone();
                        break;
                    }
                case 3:
                    {
                        Console.Title = "Tehtava 3";
                        TestaaTelevisio();
                        break;
                    }

                case 8:
                    {
                        Console.Title = "Tehtava 8";
                        TestaaSaadin();
                        break;
                    }
                case 9:
                    {
                        Console.Title = "Tehtava 9";
                        TestaaVahvistin();
                        break;
                    }
                case 10:
                    {
                        Console.Title = "Tehtava 10";
                        TestaaTietojenKasittely();
                        break;
                    }
                case 11:
                    {
                        Console.Title = "Tehtava 11";
                        TestaaRadio();
                        break;
                    }
                case 12:
                    {
                        Console.Title = "Tehtava 12";
                        TestaaHylly();
                        break;
                    }
                case 13:
                    {
                        Console.Title = "Tehtava 13";
                        //TestaaOhjelmoijanPinnaa();
                        break;
                    }

            }
        }

        // teht 1 Kiuas luokan testaus
        static void TestaaKiuas()
        {
            //luodaan kiuas olio
            Kiuas kiuas = new Kiuas();
            //pistetaan kiuas lampenemaan ja asetetaan kosteus
            kiuas.OnkoPaalla = true;
            kiuas.Lampotila = 90;
            kiuas.Kosteus = 50;
            //näytetään konsolilla
            Console.WriteLine("Kiuas on paalla {0}", kiuas.OnkoPaalla);
            Console.WriteLine("Kiukaan lampotila on {0}", kiuas.Lampotila);
        }
        // teht2 pesukone
        static void TestaaPesukone()
        {
            //luodaan kiuas olio
            Pesukone pesukone = new Pesukone();
            //pesukoneen kaaoottiset tulostukset
            pesukone.OnkoPaalla = true;
            pesukone.VedenLampo = 40; //C
            pesukone.Vesi = 10.3F; // L
            //näytetään konsolilla
            Console.WriteLine("Pesukone on paalla {0}", pesukone.OnkoPaalla);
            Console.WriteLine("Pesukonessa  on vetta {0:F2} L", pesukone.Vesi);
            Console.WriteLine("Pesukoneen vedet ovat {0} C", pesukone.VedenLampo);

            // muutetaan tietoja
            Console.WriteLine("Pesukone syottaa vetta 4 L");
            pesukone.Vesi = pesukone.Vesi + 4;
            Console.WriteLine("Pesukoneessa on nyt {0} L", pesukone.Vesi);

            // lampo muuttuu
            pesukone.VedenLampo = 44;
            Console.WriteLine("Kuumaa vetta {0} C", pesukone.VedenLampo);

        }
        // teht 3 Televio luokan testaus
        static void TestaaTelevisio()
        {
            // televiso
            Televisio televiso = new Televisio();

            televiso.OnkoPaalla = true;
            televiso.kanava = 2;
            televiso.Aani = 30;

            Console.WriteLine("Televisio on paalla ja kanava {0} nakyy ", televiso.kanava);
            Console.WriteLine("Televisiossa on aanet ja ne kuuluvat {0} lujaa", televiso.Aani);

        }

        static void TestaaSaadin()
        {
            //tehtävä 1
            {
                /*
                 * https://msdn.microsoft.com/en-us/library/ms229059(v=vs.110).aspx
                      *    Tehtävän anti    *

                           Tehtävänäsi on ohjelmoida Dynamon hissin
                           kerroksen ohjaukseen liittyvä säädin.

                           Toteutetun ohjelman tulee pystyä kysymään 
                           käyttäjältä haluttu kerros ja siirtämään hissi
                           haluttuun kerrokseen (tässä tapauksessa ohjelma
                           kertoo käyttäjälle missä kerroksessa hissi on).

                           Muista, että Dynamon hissi voi olla vain kerroksissa
                           1-5. Käytä Hissi-luokassa get- ja set-aksessoreita 
                           suojamaan olion tila.


                    ESIMERKKI         *             ESIMERKKI
                    Elevator is now in floor : 1
                    Give a new floor number (1-5) > 2
                    ESIMERKKI         *             ESIMERKKI
                */
                Saadin saadin = new Saadin();
                saadin.OnkoPaalla = true;
                saadin.Kerros = 0;
                int number = 0;
                string line;

                Console.Write("Hissi Ohjelma\n x/X lopettaa ohjelman\n (ctrl + c panikoiville)\n");
                do
                {
                  
                    // ask number from the user (read one line)
                 Console.Write("Hissi on kerroksessa {0} > ", saadin.Kerros);
                   line = Console.ReadLine();
                    bool result = int.TryParse(line, out number);
                    Console.Clear();
                    // number (integer) was given correctly, use it..
                    if (result)
                    {
                        Console.WriteLine("Number was " + number);
                        if(!(number<0 || number >5))
                        saadin.Kerros = number;
                        else
                        {
                            Console.WriteLine("Rakennukseesa on vain kerrokset 1-5, kokeile uudestaan");
                        }

                        Console.WriteLine("floor:  " + saadin.Kerros);
                        if (!(saadin.Kerros == number))
                        {

                            Console.WriteLine("Annoitko kelvollisen numeron?? ");
                            Console.WriteLine("Liikumme kerrokseen "+saadin.Kerros);
                            Console.WriteLine("Kokeile hetken kuluttua uudelleen ");
                        }
                    }
                } while (!(line == "x" || line == "X"));
                
                }
        }
        static void TestaaVahvistin()
        {
            // tehtävä 2

        }
        static void TestaaTietojenKasittely()
        {
            // tehtävä 3

        }
        static void TestaaAjoneuvojenKasittely()
        {
            // tehtävä 4

        }
        static void TestaaHylly()
        {
            // tehtävä 6

        }
        static void TestaaRadio()
        {
            // tehtävä 5

        }
        //muista tehdä 7

    }
}
