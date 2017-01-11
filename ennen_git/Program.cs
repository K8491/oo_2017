using System;
//nimi avaruudet aina aakkos järjetyksessä
/*
 *K8491 - Kaijanniemi 9.1.2017 
 * Testi ohjelmia ja muuta
 * Toinen muutos
 */

namespace hello
{
    class Henkilo { //(luokat) substantiivit, isolla kirjaimella
        public string Nimi { get; set; } //kirjoitetaan isolla
        public int Ika { get; set; }
    }
    class Testi
    { //pakkko olla luokan sisällä
        static void Main(string[] args) //kokoelma argumentteja
        {
           // SayHello();
            //ShowNames();
            KotiTehtava();
        }

        static void KotiTehtava()
        {
            /*
           ** parannettavaa **
            lottoa ei saa arpoa ennen kuin pelaajat on antanut rivinsa.
           virheen tarkistusta. hinta lottoriville.
           pelaajan lotto rivin arvonnasta voisi bannata numeroita ;D esim jos paa rivi tai sen osa on jo arvottu / paatetty etukateen
           eli jos haluaa pakottaa generaattorin arpomaan tietysta arvo joukosta ja toisen toisesta
                ((siis ei kannata luottaa etta koodattu jarjestelma  antaa numeron tai edes antaa mahdollisuutta taysin oik riviin))

            vois jarjestella top 5 rivia jossa on eniten oik osumia jotta nakee kuinka monta kertaa pitaa lotota talla koneella etta saa potin 
            samalla jos sen voi automatisoida kunnes se lotto potti tulee varmasti

         
                */
            // Alku tulostukset
            Console.WriteLine("******* Halpa-lotto arvon-ta on alkamassa ********");
            Console.WriteLine("Kuinka montarivia laitetaan ?");

            //kuinka monta rivia pelaaja haluaa tehda otetaan talteen
            int lottoLines = Convert.ToInt32(Console.ReadLine()); // jos ostaa liian monta rivia konsoli pyyhkii pois

            // oikeiden osumien talletusta varten.
            int laskuri = 0;    // lasketaan oik osumat.
            int[] hits = new int[lottoLines+5]; // tanne talletetaan oik osumat

            // random nro talteen ottoa varten  
            Random lotto = new Random();// random numeron 
            int r = 1; // esim lottoNumber[a,r] jossa a rippuu for loopista. 
            int j = 7;
            //lotto rivit
            bool[] lotterySlots = new bool[42];  // Paa arvonta
            bool[,] lottoNumber = new bool[lottoLines,42]; // Pelaajan rivit

            // pelaajan lotto rivien arvonta
            for (int a = 0; a < lottoLines; a++) // voi myos olla ostamatta rivia
            {
                for (int i = 0; i < 7; i++) // 7 numeroa arvotaan, kun ei ole lisa numeroa (lisanumeroa ei huomioitu tassa tyossa)
                {
                    do
                    {
                        r = (lotto.Next(1, 41));    // == 1-40 numerot sallittu generoida
                        if (lottoNumber[a,r] == false)  // jos ei ole jo arvottu samaa numeroa arvonassa.
                        {
                            lottoNumber[a,r] = true;    // merkitaan arvottu numero. 
                           break;   // mennaan eteenpain loopissa 
                        }
                    } while (lottoNumber[a,r] == true); // ei valia kumpi (true/false).
                }
            }

            Console.WriteLine("seuraavaksi\n *** Lotto arvonta -K8491 *** ");

            //paa arvonta
            for (int i = 0; i < 7; i++)
            {
                // hakee numeron kunnes tulee sellainen mita ei ole viela arvottu jo
                do
                {
                    r = (lotto.Next(1, 41));
                    if (lotterySlots[r] == false)
                    {
                        lotterySlots[r] = true;
                        break;
                    }
                } while (lotterySlots[r] == true);
            }
            //tulostukset paa
            Console.WriteLine("*** PAA ARVONNAN OIKEA RIVI ****");
            for (int i = 0; i < 40; i++)
            {
                if (lotterySlots[i])
                {
                    Console.WriteLine("Numero: " + i);
                }
            }
            //tulostukset omat ja tarkistus
            Console.WriteLine("**** OMAT NUMEROT ****");
            for (int a = 0; a < lottoLines; a++) // sarjan maarat
            {
                laskuri = 0; // nollataan laskuri sarjan valissa
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("sarja " + (a+1));
                for (int i = 0; i < 40; i++) // lotto rivin kirjoittaminen ruudulle
                {
                    if (lotterySlots[i] == true && lottoNumber[a, i] == true) /// jos lottonumero osuu kohdalleen
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // numero kirjoitetaan punaisella
                        Console.WriteLine(" Numero: "+ i);
                        Console.ForegroundColor = ConsoleColor.Gray; // palautetaan perus tekstin vari
                        laskuri++; // pidetaan lukua oik osumista

                    }
                    if (lottoNumber[a, i] == true && lotterySlots[i] == false) // jos lottonumero ei osu kohdalleen
                    {
                     //   Console.ForegroundColor = ConsoleColor.Gray; //  kaytetty lahinna testissa selkeyttajana
                        Console.WriteLine(" Numero: " + i);
                    }

                } // yksi lotto rivi paattyyy

                // tulostetaan oik osum
                hits[a] = laskuri;
                laskuri = 0;
                Console.WriteLine("Oikein "+ laskuri);

                // tulostetaan parhaat rivit (top 5) ja kaikki paa voitot myos
                // tarkistetaan yli 4 oik rajattu 5 parhaaseen
                    for (int i = 0; i < 40; i++) //kaydaan lapi ja otetaan talteen
                    {

                        if (hits[i] == j && i<=5)
                        {
                            if (hits[lottoLines + i]< hits[i])
                            hits[lottoLines + i] = hits[i];
                        }
                }
                   
                


            } // sarja lotto paattyyy
              // top 5 tulostus
              //  Console.WriteLine("sarja {0} oikein {1} ", lottoLines, hits[a]); 
            for (int i = 1; i < 5; i++)
            {
                if (hits[lottoLines + i] > 0)
                {
                    Console.WriteLine("Top {0} ",i, hits[lottoLines + i]);
                    
                }
            }
        }

            static void ShowNames()
        {
            // TO DO
            // Ohjelma joka kysyy käyttäjältä viisikäyttäjänimeä ja talettaane
            // ohjelma tulostaa nimet aakkosjärjestyksessä
            Console.WriteLine("Ohjelma suoritettu onnistuneesti");
            // maaritellaan taulukko
            string[] nimet = new string[5];
            // kysytaan nimet
            for (int i = 0; i <nimet.Length; i++)
            {
                Console.WriteLine("Anna nimi:");
                nimet[i] = Console.ReadLine();
            }
            // naytetaan nimet
            Console.WriteLine("Annetut nimet");
            for (int i = 0; i < nimet.Length; i++)
            {
                Console.WriteLine(nimet[i]);
            }
            // sortataan ja naytetaan
            Array.Sort(nimet);
            Console.WriteLine("Annetut nimet aakkos jarjestyksessa");
            for (int i = 0; i < nimet.Length; i++)
            {
                Console.WriteLine(nimet[i]);
            }
            // lopetus

            Console.WriteLine("Ohjelma toimii!!");
        }

        static void SayHello()
        {
            // Määritellään muuttuja
           // string nimi = "Dan Mitt";
            //luodaan oli Henkilo-luokasta
            Henkilo hlo = new Henkilo();
            hlo.Ika = 42;
            hlo.Nimi = "Max Dud";
            //konsolille
            Console.WriteLine("Terve: {0} ikäsi on: {1}", hlo.Nimi, hlo.Ika); // syottaa muuttuja arvot jarjestyksessa
        }
    }
}
