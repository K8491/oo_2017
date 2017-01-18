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
            Console.WriteLine("Kiuas on paalla {0}",kiuas.OnkoPaalla);
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
            pesukone.vesi = 10.3F; // L
            //näytetään konsolilla
            Console.WriteLine("Pesukone on paalla {0}", pesukone.OnkoPaalla);
            Console.WriteLine("Pesukonessa  on vetta {0:F2} L", pesukone.vesi);
            Console.WriteLine("Pesukoneen vedet ovat {0} C", pesukone.VedenLampo);

            // muutetaan tietoja
            Console.WriteLine("Pesukone syottaa vetta 4 L");
            pesukone.vesi = pesukone.vesi +4;
         Console.WriteLine("Pesukoneessa on nyt {0} L", pesukone.vesi);

            // lampo muuttuu
            pesukone.VedenLampo = 44;
            Console.WriteLine("Kuumaa vetta {0} C", pesukone.VedenLampo);

        }
    }
}
