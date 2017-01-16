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
            Console.WriteLine("Kiukaan kosteus on {0}", kiuas.Kosteus);
            // mitä tapahtuu jos kosteus menee yli rajojen
            kiuas.Kosteus = 101;
            Console.WriteLine("Kiukaan kosteus on {0}", kiuas.Kosteus);
        }
    }
}
