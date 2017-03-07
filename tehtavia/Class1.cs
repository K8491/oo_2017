using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehtavia
{
    class Elain
    {
      
        // tehdään koiran koppi jossa koira eläin ja se osaa haukkua
        public bool Hereilla { get; set; }
        public int Haukut { get; set; }
        public string Nimi { get; set; }
        public int Ika { get; set; }
   
       public Elain(string nimi, int ika)
        {
            try
            {
                Nimi = nimi;
                Ika = ika;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        public void Hakutaan(int haukut)
        {
            try
            {
                Hereilla = true;
                   Haukut = haukut;
             
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public override string ToString()
        {
        
                return "Koira"+Nimi+" haukuu " + Haukut + " kertaa";
            
        }
    }
}
