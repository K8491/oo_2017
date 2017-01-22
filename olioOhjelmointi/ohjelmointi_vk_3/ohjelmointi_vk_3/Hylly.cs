using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ohjelmointi.VK3
{
    class Hylly
    {
        // kirjoja, lehtiä, cd-levyjä, dvd-levyjä, bluray-levyjä
        // puhelimia, tabletteja, läppäreitä

        // digitaalinen vs analoginen   -> mediatyyppi
        // onko soitin vs vaditaanko soitin  -> mediasoitin

        /* Kaikille samat
         *Nimi
         *Vuosi
         *Hinta  
         */
         // hyllyssa kaikilla tuotteila on
        string nimi; // teos tai malli
        int vuosi; // julkaisu tai valmistus vuosi
        int hinta; // rahallinen arvo

        public string Nimi { get { return nimi; } set {nimi = value;}}
        public int Vuosi { get { return vuosi; } set { vuosi = value;}}
        public int Hinta { get { return hinta; } set { hinta = value;}}

        public Hylly(string nimi, int vuosi, int hinta)
        {
            Nimi = nimi;
            Vuosi = vuosi;
            Hinta = hinta;
        }

    }
    class Digitaaliset : Hylly
    {
        string soitinTyyppi;
        public string SoitinTyyppi
        {
            get { return soitinTyyppi; }
            set { soitinTyyppi = value; }
        }

        public Digitaaliset(string nimi, int vuosi, int hinta, string tyyppi)
        : base(nimi, vuosi, hinta)
        {
             SoitinTyyppi= tyyppi ;
        }
    }
    class Analogiset : Hylly
    {
        string kannet;// tunnus merkit esim kovakantinen, tai "se vihreä"
        public string Kannet { get {return kannet;} set { kannet = value;}}

            public Analogiset(string nimi, int vuosi, int hinta,string kannet)
             : base(nimi, vuosi, hinta)
            {
            Kannet = kannet;
            }
            
        }
}
