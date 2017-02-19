using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jotain
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            // hae tyontekija
            // enimi textBox
            // snimi textBox_Copy
            // nro textBox_Copy1
            // titteli textBox_Copy2
            // palkka textBox_Copy3
            try
            {
                Tyontekija tnhkj = new Tyontekija();
                List<Tyontekija> tnhkjLista = new List<Tyontekija>();

                // tnhkj.Etunimi, tnhkj.Sukunimi, tnhkj.TTNumero, tnhkj.Nimike, tnhkj.Palkka
                tnhkj.Etunimi = textBox.Text;
                tnhkj.Sukunimi = textBox_Copy.Text;
                tnhkj.TTNumero = Int32.Parse(textBox_Copy1.Text);
                tnhkj.Nimike = textBox_Copy2.Text;
                tnhkj.Palkka = float.Parse(textBox_Copy3.Text);

                tnhkjLista.Add(tnhkj);
                listBox.ItemsSource = tnhkjLista;

                textBox.Text = "";
                textBox_Copy.Text = "";
                textBox_Copy1.Text = "";
                textBox_Copy2.Text = "";
                textBox_Copy3.Text = "";
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

    }
    public class Henkilo
    {
        public string SOTU { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public DatePicker Syntymaaika { get; set; }
        public string Kokonimi { get; }
        public int Ika { get; }

        public Henkilo()
        {
        }
        public Henkilo(string sotu, string etunimi, string sukunimi, DatePicker syntymaaika, string kokonimi, int ika)
        {
            try
            {
                SOTU = sotu;
                Etunimi = etunimi;
                Sukunimi = sukunimi;
                Syntymaaika = syntymaaika;
                Kokonimi = (kokonimi = Etunimi + " " + Sukunimi);
                Ika = ika;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }


        }
        string HenkiloON(string HenkiloON)
        {
            return HenkiloON;
        }
    }
    public class Tyontekija : Henkilo
    {
        public string Nimike { get; set; }
        public int TTNumero { get; set; }
        public DatePicker AloitusPvm { get; set; }
        public float Palkka { get; set; }
        public Tyontekija()
        {
        }
        public Tyontekija(string enimi, string snimi, int tTNumero, string nimike, float palkka)
        {
            try
            {
                Etunimi = enimi;
                Sukunimi = snimi;
                TTNumero = tTNumero;
                Nimike = nimike;
                Palkka = palkka;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        float LaskePalkka(float palkka)
        {
            return palkka;
        }
        /*
        ToString() niin että se esittää työntekijänumeron, onyhtäsuurimerkin, etun
            imen, sukunimen, ja pilkun jälkeen tittelin.Siis esimerkiksi "1 = Alfred Nobel, toimitusjohtaja"
            */
        public override string ToString()
        {
            return (TTNumero + " = " + Etunimi + " " + Sukunimi + ", " + Nimike);
        }
    }
    public class Vakituinen : Tyontekija
    {
        public float KuukausiPalkka { get; }

        Vakituinen()
        {
        }
        Vakituinen(float kuukausiPalkka)
        {
            KuukausiPalkka = kuukausiPalkka;
        }
        float LaskePalkka(float palkka)
        {
            return palkka;
        }
    }
    public class Osaaikainen : Tyontekija
    {
        public float TuntiPalkka { get; set; }
        public int TehdytTunnit { get; set; }
        Osaaikainen()
        {
        }
        Osaaikainen(float tuntiPalkka, int tehdytTunnit)
        {
            try
            {
                TuntiPalkka = tuntiPalkka;
                TehdytTunnit = tehdytTunnit;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        float LaskePalkka(float palkka)
        {
            try
            {
                palkka = TuntiPalkka * TehdytTunnit;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return palkka;
        }
    }
}
