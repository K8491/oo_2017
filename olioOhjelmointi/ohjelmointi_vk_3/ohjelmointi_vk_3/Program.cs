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
            Console.Clear();
            int luku = 0;
            Console.Title = "WHHHAAAAT??!!";
            Console.WriteLine("Viikko 3 tehtavat");
            Console.WriteLine("Valitse tehtava");
            Console.WriteLine("Kiuas tehtava (nro 1)");
            Console.WriteLine("Pesukone tehtava (nro 2)");
            Console.WriteLine("Televisio tehtava (nro 3)");
            Console.WriteLine("TT1 Hissi tehtava (nro 8)");
            Console.WriteLine("TT2 vahvistin tehtava (nro 9)");
            Console.WriteLine("TT3 Tietojen käsittely tehtava (nro 10)");
            Console.WriteLine("TT4 Ajoneuvojen käsittely tehtava (nro 11)");
            Console.WriteLine("KT5 Radio tehtava (nro 12)");
            Console.WriteLine("KT6 Hylly tehtava (nro 13)");
            Console.WriteLine("KT7 (nro 14)");
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
                        TestaaAjoneuvojenKasittely();
                        break;
                    }
                case 12:
                    {
                        Console.Title = "Tehtava 12";
                        TestaaRadio();
                        break;
                    }
                case 13:
                    {
                        Console.Title = "Tehtava 13";

                       TestaaHylly();
                        break;
                    }
                case 14:
                    {
                        Console.Title = "Tehtava 14";

                        TestaaPinnaa();
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
            televiso.Kanava = 2;
            televiso.Aani = 30;

            Console.WriteLine("Televisio on paalla ja kanava {0} nakyy ", televiso.Kanava);
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
            /*
             * Tehtävänäsi on ohjelmoida yksinkertaisen 
             * vahvistimen toiminta, jolla voidaan kontrolloida
             *  äänenvoimakkuutta välillä 0-100.
             *  Toteuta Vahvistin-luokka ja tee pääohjelma,
             *  jolla luot olion Vahvistin-luokasta.
             *  Säädä ja kokeile vahvistinta eri äänenvoimakkuuksilla.
             *  Käytä Vahvistin-luokassa get- ja set-aksessoreita.
             *  get-aksessori palauttaa äänenvoimakkuuden ja
             *  set-aksessori rajaa äänenvoimakkuuden arvoa.
             * */
             // Vahvistin luokka, olio vahvistin
            Vahvistin vahvistin = new Vahvistin();
            vahvistin.Aani = 10;
            int ui = 1;
            Console.WriteLine("Vahvistin on palla jos syottaa yli -100");
            do
            {
                Console.Clear();
                if (ui < 0)
                {
                    Console.WriteLine("Liian alhainen aani\n ei alta 0");
                }
                else if (ui > 100)
                {
                    Console.WriteLine("Liian korkea aani ei yli 100");
                }
                else
                {

                    if (vahvistin.Aani <= 10)
                    {
                        Console.WriteLine("Ei kuulu mitaan");
                    }
                    else if (vahvistin.Aani <= 30)
                    {
                        Console.WriteLine("Kuuluu huonosti");
                    }
                    else if (vahvistin.Aani <= 60)
                    {
                        Console.WriteLine("Kuuluu hyvin");
                    }
                    else if (vahvistin.Aani <= 100)
                    {
                        Console.WriteLine("Kuuluu Lujaa");
                    }
                }
                Console.Write("Saada aanta {0} >",vahvistin.Aani);
                ui =  Int32.Parse((Console.ReadLine()));
                vahvistin.Aani = ui;
               
            } while (ui>-100);
            Console.WriteLine("Vahvistin on pois paalta");
            Valikko();

        }
        static void TestaaTietojenKasittely()
        {
            // tehtävä 3

            Tiedot tiedot = new Tiedot("Kirsi Kernel","Teacher",1200);
            PomonTiedot pomonTiedot = new PomonTiedot("Jussi Jurkka","Head of Institute", 9000,"Audi",5000);
            Console.WriteLine("{0} {1} {2}",tiedot.Name , tiedot.Profession , tiedot.Salary);
            Console.WriteLine("{0} {1} {2} {3} {4}",pomonTiedot.Name,pomonTiedot.Profession,pomonTiedot.Salary,pomonTiedot.Car,pomonTiedot.Bonus);


            tiedot.Profession = " Principal Teacher";
            tiedot.Salary = 2200;
            Console.WriteLine("{0} {1} {2}",tiedot.Name, tiedot.Profession, tiedot.Salary);



        }
        static void TestaaAjoneuvojenKasittely()
        {
            // tehtävä 4
            /*

             */
            Pyora pyora = new Pyora("Jopo","Street", 2016, "Blue", false,"");
            Pyora pyora2 = new Pyora("Tunturi", "StreetPower", 2010, "Black", true, "Shimano");
            Vene vene = new Vene("Suvi","S900",1990,"White", 3,"Row boat");
            Vene vene2 = new Vene("Yamaha", "Model 1000", 2010, "Yellow", 5, "Motor boat");
            Vene vene3 = new Vene("Puinen hirmu", "-", 1900, "Puinen", 2, "Kajaakki");

            Console.WriteLine("{0} {1} {2} {3} {4} {5}", pyora.Nimi, pyora.Malli,pyora.Vuosimalli, pyora.Vari,pyora.Vaihteet,pyora.VaihteetNimi);
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", pyora2.Nimi, pyora2.Malli, pyora2.Vuosimalli, pyora2.Vari, pyora2.Vaihteet, pyora2.VaihteetNimi);

            Console.WriteLine("{0} {1} {2} {3} {4} {5}", vene.Nimi, vene.Malli, vene.Vuosimalli, vene.Vari, vene.Paikkoja, vene.Tyyppi);
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", vene2.Nimi, vene2.Malli, vene2.Vuosimalli, vene2.Vari, vene2.Paikkoja, vene2.Tyyppi);
            Console.WriteLine("{0} {1} {2} {3} {4} {5}", vene3.Nimi, vene3.Malli, vene3.Vuosimalli, vene3.Vari, vene3.Paikkoja, vene3.Tyyppi);
        }
        static void TestaaHylly()
        {
            // tehtävä 6
            Console.WriteLine("Hyllyssa on monta esinetta");
            Analogiset kirja = new Analogiset("Suuret seikkailut",2300,30,"Kovakantinen");
            Analogiset kirja2 = new Analogiset("Maol", 2003, 12, "Paperinen");
            Analogiset lehti = new Analogiset("Aku Ankka", 2004, 6, "Paperinen");
            Digitaaliset cdlevy = new Digitaaliset("Iskelma Klassikot", 2000, 10, "CD-levy");
            Analogiset vhs = new Analogiset("Rambo", 1980, 15, "VHS-kasetti");
            Digitaaliset DVD = new Digitaaliset("Rambo", 1980, 5, "DVD-levy");
            Digitaaliset Tabletti = new Digitaaliset("Fire HD8", 2016, 120, "Tabletti");
            Console.WriteLine("Kirja {0} {1} {2}e Se oli sellanen {3}",kirja.Nimi, kirja.Vuosi, kirja.Hinta,kirja.Kannet);
            Console.WriteLine("Laite {0} {1} {2}e Mika laite on{3}", Tabletti.Nimi, Tabletti.Vuosi, Tabletti.Hinta,Tabletti.SoitinTyyppi);
            Console.WriteLine("CD-levy {0} {1} {2}e se on {3}", cdlevy.Nimi, cdlevy.Vuosi, cdlevy.Hinta, cdlevy.SoitinTyyppi);

        }
        static void TestaaRadio()
        {
            // tehtävä 5
            Radio radio = new Radio();
            Console.WriteLine("Radio on paalla " + radio.Paalla);

            Console.WriteLine("Painetaan nappulaa radion kylessa");
            radio.Paalla = (true);
            Console.WriteLine("Radio on paalla " + radio.Paalla);

            Console.WriteLine("Taajuus on "+radio.Taajuus);
            Console.WriteLine("Kaannetaan nuppia");
            Console.Read();
            Console.Clear();
            radio.Taajuus = 2100;
            Console.WriteLine("Taajuus on {0:0.0} ", radio.Taajuus);
            Console.WriteLine("Radiosta ei vielakaan kuulu mitaan\n lisataan aanta");
            radio.Aani = 6;
            Console.WriteLine("Aani on " + radio.Aani);

            Console.WriteLine("Yli arvot (656 / 2106750)");
            radio.Taajuus = 2106750;
            radio.Aani = 656;
            Console.WriteLine("Aani {0} /  Taajuus {1:0.0} ", radio.Aani , radio.Taajuus);

            Console.WriteLine("Ali arvot (-656 / -2106750)");
            radio.Taajuus = -2106750;
            radio.Aani = -656;
            Console.WriteLine("Aani {0} Taajuus {1:0.0} ", radio.Aani, radio.Taajuus);


        }
        static void TestaaPinnaa()
        {
            //muista tehdä 7
            Console.WriteLine("Testataan pinnaa, vasymysta ja opiskelija saattaa olla kipea");
            // ei ole erikseen opettaja luokkaa, opettaja on vaan olio joka ei voi olla kipeana ;D
            Jaksaminen opetta = new Jaksaminen(100, 0);
            Opiskelija opiskelija = new Opiskelija(30, 30, false);

            Console.WriteLine("Tunnilla opettajalla on ainakin {0} pinaa ja {1} vasymysta", opetta.Pinna, opetta.Vasymys);
           Console.WriteLine("Koodia kirjittaessa opiskelija on  terve {0} ja han jaksaa mitavain koska hanen vasymys on vain {1} ja pinnaakin on viela {2}", opiskelija.OnkoTerve, opiskelija.Vasymys, opiskelija.Pinna);
            Console.Read();
            Console.Clear();
            Console.WriteLine("Huonosta koulu menestyksesta johtuen opettajalta paloi 90 pinnaa");
            opetta.Pinna -= 90;
            opetta.Vasymys += 10;
            Console.WriteLine("Tunnilla opettajalla on vain {0} pinaa ja {1} vasymysta", opetta.Pinna, opetta.Vasymys);
            if (opetta.Pinna < 20)
            {
                Console.WriteLine("Juoskaa arvosanojenne edesta");
            }

        }



    }
}
