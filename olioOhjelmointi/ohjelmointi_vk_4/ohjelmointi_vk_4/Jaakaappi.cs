using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK4
{
    class Tuote
    {
        public string Nimi { get; set; }
        public bool OnkoSyotava { get; set; }
        public int tuoteMaara = 0;
        public List<Tuote> Tuotteet { get; }

        public override string ToString()
        {
            return "eineks " + Nimi + "syo?" + OnkoSyotava;
        }
        public Tuote(string nimi, bool onkoSyotava, int tuoteMaara)
        {
            Tuotteet = new List<Tuote>();
        }
    }

    class Kaappi
    {

        private int tuoteMaara = 0;
        const int Maxtuote = 4;
        public List<Tuote> Tuotteet { get; }
        public void LisaaTuote(Tuote Eines)
        {
            if (tuoteMaara < Maxtuote)
            {
                Tuotteet.Add(Eines);
                tuoteMaara++;
                Console.WriteLine("eines? lisatty");
            }
            else
            {
                Console.WriteLine("Opiskelijan kaappi on taynna??");
            }
        }
        public Kaappi(Tuote tuote)
        {
            Tuotteet = new List<Tuote>();
        }



        /*Tuotteet...
         * Ruokia
         * juomia
         * lääkkeitä
         * kakkua
         * kuumaa kahvia mukissa
         * ps4 koska se on keränny nestetä
         * 
         * onko se syötävä
         * meneekö se pilalle
         * onkose aines
         * vai eines
         * ehkä vaan viilenemässä
         * 
         * /////
         * oviauki
         * valopäällä/pois
         * 
         * lämpöaste
         * lisää kylmää()
         * 
         * Ruoka aineita pitää pystyä poistamaan ja lisäämään kaappiin
         * se ei saa olla täynnä, mutta jää kaapin ei tarvitse tietää onko se täynnä
         * 
         * ruoka aineen määrä
         * to string nimi (niin kuin videossa)
         * 
         */

    }
}
