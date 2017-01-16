using System;
using System.Linq;

namespace tehtavia
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 
                    Kaijanniemi Antti 15.1.2017             
             */
            Viikko2_20();
        }
        static void Loppu()
        {
            Console.WriteLine("Palataan valikkoon");
            Console.WriteLine("Paina Enter");
            Console.ReadLine();
        }
        static void Valikko()

        {
            Console.Title = "Valikko";
            int luku = 0;
            Console.WriteLine("anna tehtava numero (1-19)");
            luku = Convert.ToInt32(Console.ReadLine());
            switch (luku)
            {
                case 1:
                    {
                        Console.WriteLine("Viiko 2 tehtava 1");
                        Viikko2_1();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Viiko 2 tehtava 2");
                        Viikko2_2();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Viiko 2 tehtava 3");
                        Viikko2_3();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Viiko 2 tehtava 4");
                        Viikko2_4();
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Viiko 2 tehtava 5");
                        Viikko2_5();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Viiko 2 tehtava 6");
                        Viikko2_6();
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Viiko 2 tehtava 7");
                        Viikko2_7();
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Viiko 2 tehtava 8");
                        Viikko2_8();
                        break;
                    }
                case 9:
                    {
                        Console.WriteLine("Viiko 2 tehtava 9");
                        Viikko2_9();
                        break;
                    }
                case 10:
                    {
                        Console.WriteLine("Viiko 2 tehtava 10");
                        Viikko2_10();
                        break;
                    }
                case 11:
                    {
                        Console.WriteLine("Viiko 2 tehtava 11");
                        Viikko2_11();
                        break;
                    }
                case 12:
                    {
                        Console.WriteLine("Viiko 2 tehtava 12");
                        Viikko2_12();
                        break;
                    }
                case 13:
                    {
                        Console.WriteLine("Viiko 2 tehtava 13");
                        Viikko2_13();
                        break;
                    }
                case 14:
                    {
                        Console.WriteLine("Viiko 2 tehtava 14");
                        Viikko2_14();
                        break;
                    }
                case 15:
                    {
                        Console.WriteLine("Viiko 2 tehtava 15");
                        Viikko2_15();
                        break;
                    }
                case 16:
                    {
                        Console.WriteLine("Viiko 2 tehtava 16");
                        Viikko2_16();
                        break;
                    }
                case 17:
                    {
                        Console.WriteLine("Viiko 2 tehtava 17");
                        Viikko2_17();
                        break;
                    }
                case 18:
                    {
                        Console.WriteLine("Viiko 2 tehtava 18");
                        Viikko2_18();
                        break;
                    }
                case 19:
                    {
                        Console.WriteLine("Viiko 2 tehtava 19");
                        Viikko2_19();
                        break;
                    }
                case 20:
                    {
                        Console.WriteLine("Viiko 2 tehtava 20");
                        Viikko2_20();
                        break;
                    }
                default: break;
            }

        }
        static void Viikko2_1()
        {
            Console.Title = "Viikko 2 tehtava 1";
            int luku = 0;
            //tehtava 1
            Console.WriteLine("Anna luku, valilta 1-3");
            luku = Convert.ToInt32(Console.ReadLine());
            switch (luku)
            {
                case 1:
                    Console.WriteLine("Yksi");
                    break;
                case 2:
                    Console.WriteLine("Kaksi");
                    break;
                case 3:
                    Console.WriteLine("Kolme");
                    break;
                default:
                    Console.WriteLine("Joku muu luku");
                    break;
            }
            Loppu();
        }
        static void Viikko2_2()
        {
            Console.Title = "Viikko 2 tehtava 2";
            int luku = 0;

            // tehtava 2
            Console.WriteLine("Anna pistemaara");
            luku = Convert.ToInt32(Console.ReadLine());
            if (luku < 1)
            {
                luku = 0;
            }
            else if (luku <= 3)
            {
                luku = 1;
            }
            else if (luku <= 5)
            {
                luku = 2;
            }
            else if (luku <= 7)
            {
                luku = 3;
            }
            else if (luku <= 9)
            {
                luku = 4;
            }
            else if (luku <= 12)
            {
                luku = 5;
            }
            Console.WriteLine("Koulu numero on " + luku);
            Loppu();
        }
        static void Viikko2_3()
        {
            Console.Title = "Viikko 2 tehtava 3";
            // tehtava 3
            int luku1;
            int luku2;
            int luku3;

            Console.WriteLine("Anna kolme lukua");
            luku1 = Convert.ToInt32(Console.ReadLine());
            luku2 = Convert.ToInt32(Console.ReadLine());
            luku3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Summa " + (luku1 + luku2 + luku3));
            Console.WriteLine("Keski arvo " + (luku1 + luku2 + luku3) / 3);
            Loppu();
        }
        static void Viikko2_4()
        {
            Console.Title = "Viikko 2 tehtava 4";
            // tehtava 4
            int luku;
            Console.WriteLine("Anna ika");
            luku = Convert.ToInt32(Console.ReadLine());
            if (luku < 18)
            {
                Console.WriteLine("Alaikainen");
            }
            else if (luku <= 65)
            {
                Console.WriteLine("Aikuinen");
            }
            else if (luku > 65)
            {
                Console.WriteLine("Seniori");
            }
            Loppu();
        }
        static void Viikko2_5()
        {
            Console.Title = "Viikko 2 tehtava 5";
            // tehtava 5
            int luku = 0;
            Console.WriteLine("Kuinka monta sekunttia?");
            luku = Convert.ToInt32(Console.ReadLine());
            TimeSpan aika = TimeSpan.FromSeconds(luku);

            Console.WriteLine("Aika siis on {0} tunti  {1} minuutti  {2} sekuntti ", aika.Hours, aika.Minutes, aika.Seconds);
            Loppu();
        }
        static void Viikko2_6()
        {
            Console.Title = "Viikko 2 tehtava 6";
            // tehtava 6 
            int luku = 0;
            Console.WriteLine("Anna matka");
            luku = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bensaa kuluu {0:F2} litraa, kustannus {1:F2} euroa", (luku * (7.02 / 100)), ((luku * (7.02 / 100)) * 1.595));
            Loppu();
        }
        static void Viikko2_7()
        {
            Console.Title = "Viikko 2 tehtava 7";
            // tehtava 7
            int luku = 0;
            Console.WriteLine("Anna Vuosi");
            luku = Convert.ToInt32(Console.ReadLine());
            if (luku % 4 == 0 && luku % 100 > 0 || luku % 400 == 0)
            {
                Console.WriteLine("Vuosi on karkaus vuosi");
            }
            else
            {
                Console.WriteLine("Vuosi ei ole karkaus vuosi");
            }
            Loppu();
        }
        static void Viikko2_8()
        {
            Console.Title = "Viikko 2 tehtava 8";
            // tehtava 8
            int luku1 = 0;
            int luku2 = 0;
            int luku3 = 0;
            Console.WriteLine("Anna Kolme lukua");
            luku1 = Convert.ToInt32(Console.ReadLine());
            luku2 = Convert.ToInt32(Console.ReadLine());
            luku3 = Convert.ToInt32(Console.ReadLine());
            if (luku1 > luku2)
            {
                if (luku1 > luku3)
                {
                    Console.WriteLine("Luku {0} on suurin", luku1);
                }
                else
                {
                    Console.WriteLine("Luku {0} on suurin", luku3);
                }
            }
            else if (luku2 > luku3)
            {
                Console.WriteLine("Luku {0} on suurin", luku2);
            }
            else
            {
                Console.WriteLine("Luku {0} on suurin", luku3);
            }
            Loppu();
        }
        static void Viikko2_9()
        {
            Console.Title = "Viikko 2 tehtava 9";
            // tehtava 9
            int luku = 0;
            int summa = 0;
            Console.WriteLine("Anna Luku ");
            luku = Convert.ToInt32(Console.ReadLine());
            while (luku > 0)
            {
                summa = summa + luku;
                Console.WriteLine("Anna Luku (0 lopettaa yht laskemisen ");
                luku = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Lukujen summa on " + summa);

            Loppu();
        }
        static void Viikko2_10()
        {
            Console.Title = "Viikko 2 tehtava 10";
            // tehtava 10
            int[] taulukko = new int[9] { 1, 2, 33, 44, 55, 68, 77, 96, 100 };
            for (int i = 0; i < taulukko.Length; i++)
            {
                if (taulukko[i] % 2 == 0 && taulukko[i] != 0)
                {
                    Console.WriteLine("Hep " + taulukko[i]);
                }
            }
            Loppu();
        }
        static void Viikko2_11()
        {
            Console.Title = "Viikko 2 tehtava 11";
            // tehtava 11
            int luku = 0;
            Console.WriteLine("Anna Rvien maara ");
            luku = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= luku; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Loppu();
        }
        static void Viikko2_12()
        {
            Console.Title = "Viikko 2 tehtava 12";
            // tehtava 12
            int[] luku = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Anna Luku");
                luku[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Luvut ovat kaanteisessa jarjestyksessa");
            for (int i = 4; i >= 0; i--)
            {
                Console.WriteLine(luku[i]);
            }
            Loppu();
        }
        static void Viikko2_13()
        {
            Console.Title = "Viikko 2 tehtava 13";
            // tehtava 13
            int[] luku = new int[5];
            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine("Anna Luku ");
                luku[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Kokonais pisteet ovat "+(luku.Sum() - luku.Max() - luku.Min()));
            Loppu();
        }
        static void Viikko2_14()
        {
            Console.Title = "Viikko 2 tehtava 14";
            // tehtava 14
            int[] luku = new int[6];
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("Anna Arvosana (valilta 1-5) ");
                luku[Convert.ToInt32(Console.ReadLine())]++;
            }
            Console.WriteLine("Arvosanat: ");
            for (int i = 0; i <= 5; i++)
            {
                Console.Write(+i+":");
                for (int j = 0; j < luku[i]; j++)
                {
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            Loppu();
        }
        static void Viikko2_15()
        {
            Console.Title = "Viikko 2 tehtava 15";
            // tehtava 15 kuusipuu
            int luku = 0;
            Console.WriteLine("Anna Luku ");
            luku = Convert.ToInt32(Console.ReadLine());
            // vasen puoli
            for (int i = 1; i < luku-1; i++)
            {
                for (int l = luku; l > i; l--)
                {
                    Console.Write(" ");
                }
                for (int j = 1; j <= i; j++)
                {
                    if (1 < j )
                    {
                       Console.Write("*");
                    }
                    Console.Write("*");
                }
                Console.Write("\n");
            }
            for (int i = 0; i < 2; i++)
            {
                for (int l = luku; l > 1; l--)
                {
                    Console.Write(" ");
                }
                Console.Write("*\n");
            }
            Loppu();
        }
        static void Viikko2_16()
        {
            Console.Title = "Viikko 2 tehtava 16";
            // tehtava 16
            int luku = 0;
            int luku2 = 0;
            int laskuri=0;
            Random rluku = new Random();
            luku = (rluku.Next(1, 100));
            do
            {
                laskuri++;
                Console.WriteLine("Arvaa luku ");
                luku2 =Convert.ToInt32(Console.ReadLine());
                if (luku2 > luku)
                {
                    Console.WriteLine("Luku on pienempi");
                }
                else if (luku2 < luku)
                {
                    Console.WriteLine("Luku on suurempi");
                }
                else
                {
                    Console.WriteLine("Arvasit oikein "+laskuri +" Keralla");
                }
            } while (!(luku2==luku));
            Loppu();
        }
        static void Viikko2_17()
        {
            Console.Title = "Viikko 2 tehtava 17";
            // tehtava 17
            int[] luku = new int[6] { 10, 20, 30, 40, 50, 60 };
            int[] luku2 = new int[6] { 1, 5, 25, 43, 52, 45 };
            int[] arv = new int[luku.Length + luku2.Length];
            int[] arv2 = new int[luku.Length + luku2.Length];
            int j = 0; // laskuri
            arv = luku.Union(luku2).ToArray(); // yhdistetaan
            System.Array.Sort(arv); // lajitellaan
            for (int i = arv.Length-1; i > 0; i--,j++) // sijoitetaan kaanteisessa jarjestyksesssa (vaihdetaan lajittelu tyyli pienimmasta suurimpaan ympari)
            {
                arv2[j] = arv[i];
                Console.WriteLine(arv2[j]);
            }
            Loppu();
        }
        static void Viikko2_18()
        {
            Console.Title = "Viikko 2 tehtava 18";
            // tehtava 18
            string jono;
            int j = 0;
            bool onpal = false;
            Console.WriteLine("Anna Merkkiono");
            jono = Convert.ToString(Console.ReadLine());

            for (int i = jono.Length - 1; i > 0; i--, j++) // sijoitetaan kaanteisessa jarjestyksesssa (vaihdetaan lajittelu tyyli pienimmasta suurimpaan ympari)
            {
                if (jono[i] == jono[j])
                {
                    onpal = true;
                }
                else
                {
                    onpal = false;
                    break;
                }
            }
            if (onpal == false)
            {
                Console.WriteLine("Ei ole palindromi");
            }
            else
            {
                Console.WriteLine("on se palindromi");
            }
            Loppu();
        }
        static void Viikko2_19()
        {
            Console.Title = "Viikko 2 tehtava 19";
            // tehtava 19
            /*
             * Tee tekstipohjainen Hirsipuu-peli. Voit kovakoodata arvattavan s
             * anan ja toteuta looppi, jossa käyttäjältä kysytään seuraavaa kirjainta.
             *  Muista näyttää aina kirjaimen jälkeen oikein arvatut kirjaimet sanan oikealla kohdalla 
             *  (käytä esim _-alaviivaa ei arvattujen kirjainten kohdalla). Voit näyttää myös jo arvatut ei käytetyt
             *   -kirjaimet. Päätä itse milloin pelaaja joutuu hirteen.
             *   
             * */
            // hirsi sana ja pelaajan oik sana
            char[] jono = new[] { 's', 'a', 'l', 'a', 's', 'a', 'n', 'a', '#'};
            // arvatut merkit taulu
            char[] taul = new char[]{ ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ','#'};
            char[] taul2 = new char[33];
            // talteen otettava merkki
            char merkki;
            string pelaaja;
            // pelin voitto flagi
            bool arvattu = false;
            int hirsi = 0;
            // pelaajan nimi
            Console.WriteLine("Olet kavelemassa kohti hirtta, mita kirjoitetaan hautakiveesi nimeksesi?");
            pelaaja = Convert.ToString(Console.ReadLine());

            do
            {
                Console.Clear();
                switch (hirsi)
                {
                    case 0: case 1:
                        {
                            Console.WriteLine("Hirsi puu");
                            Console.WriteLine("Raajat tallella, paa paikoillaan ja olo on jees");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Hirsi pu");
                            Console.WriteLine("vasen kasi, paa ja jalat ovat paikoillaan");
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Hirsi p");
                            Console.WriteLine("paa ja jalat ovat paikoillaan");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Hirsi");
                            Console.WriteLine("kadet ovat poikki, vasen jalka poikki");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("H");
                            Console.WriteLine("Viela on mahdollisuus");
                            break;
                        }
                    case 6: default:
                        {
                            Console.WriteLine("....");
                            break;
                        }

                }
                // tulostuksia
                Console.Write("\nArvattava sana:  ");
                for (int i = 0; i < 33 ; i++)
                {
                    if(i<taul.Length-1)
                   Console.Write(taul[i]);
                }
                // tulostuksia
                Console.Write("\n{0}:n Hirsi...:  ",pelaaja);
                for (int i = 0; i < 33; i++)
                {
                    if (i < taul.Length - 1)
                        Console.Write(taul2[i]);
                }


                Console.WriteLine("\n Syota kirjain");
                merkki = Convert.ToChar(Console.ReadLine());
                for (int i = 0; i <= jono.Length ; i++)
                {
                    if (taul.Contains(merkki))
                    {
                        Console.WriteLine("Merkki: "+merkki);
                        break;
                    }
                         if (jono.Contains(merkki)||taul.Contains(merkki)&& jono.Contains(merkki))
                    {
                            for (int j = 0; j < jono.Length - 1; j++)
                            {
                                if (jono[j] == merkki && taul[j]!=merkki)
                                {
                                    taul[j] = jono[j];
                            }
                                else if (jono[j] == merkki && taul[j] == merkki)
                            {
                                j++;

                            }
                            else
                            {
                                arvattu = false;
                            }
                            }
                    }
                    else
                    {
                        taul2[hirsi] = merkki;
                        Console.WriteLine("Merkki {0} ei ole oikea", merkki);
                        hirsi++;
                        break;
                    }
                }
                for (int j = 0; j < jono.Length - 1; j++)
                {
                    if (jono[j] == taul[j])
                    {
                        arvattu = true;
                    }
                    else
                    {
                        arvattu = false;
                        break;
                    }
                }
                } while (arvattu==false&&hirsi<6) ;
            if(arvattu == true)
            {
                Console.WriteLine("Voitit pelin");
            }
         else
            {
                Console.WriteLine("Hiressa roikkuu "+pelaaja);
            }

            Loppu();
        }
        static void Viikko2_20()
        {
            // tehtava 20
            /*
             * Toteuta jokin oma villi-ideasi ja yllätä opettaja toteutuksellasi.
             * */

            Console.Title = "WHHHAAAAT??!!";
            Console.WriteLine("Viikko 2 Kotitehtavat");
            Console.WriteLine("Tehtavia 1 - 19 (+ nro 20");
            Console.WriteLine("Valitse tehtava");
            Console.WriteLine("Tai paina CTRL + C (lopettaa ohjelman)");
            Valikko();
            Console.Clear();
            Viikko2_20(); // ikuinen loop...
        }

    }// class loppuu
} // name space loppuu