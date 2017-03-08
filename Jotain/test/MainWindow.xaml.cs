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
namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int ammukset = 10;
        private int maxAmmukset = 10;

        System.Windows.Controls.Image img = new System.Windows.Controls.Image(); // I needed to disambiguate Image.


        public MainWindow()
        {
            InitializeComponent();
            initmystuff();
        }
        public void initmystuff()
        {
            /*
             *      var watch = System.Diagnostics.Stopwatch.StartNew();
              // the code that you want to measure comes here
              watch.Stop();
              var elapsedMs = watch.ElapsedMilliseconds;

            muista bindata eventeiks ammusten kaytto, ettei kokoajan tarvii sanoa  lataus.Value = ammukset
             * 
             * */
            List<Ammus> luodit = new List<Ammus>();
            // tahan lista jossa pelaaja on 1 ja sen jalkeen yksikerrallaan lisataan tarkeat npc:t
            //lopuksi listaan tulee loput luodut elavat oliot
            // saman lainen lista mutta tuhotuista olioista pelaajan saveen.
            Pelaaja alus = new Pelaaja(1, "Mumimuskl", "20:20");
            img.Source = new BitmapImage(new Uri("E:/olio/ohjelmointi/Jotain/test/pictures/player.png", UriKind.RelativeOrAbsolute)); // fire.png is something like 24 x 44 pixels.
            stackp.Children.Add(img);
            img.Height = 23;
            img.Width = 23;


        }
        public class Ammus
        {
            public int AmmusID { get; set; }
            public string Suunta { get; set; }
            public string AmpujanId { get; set; }
            public int AmmuksenTyyppi { get; set; }
            public int TTD { get; set; }
            public int MaxTTD { get; set; }
            public int Nopeus=4;
            public bool OnkoOlemassa { get; set; }
            Ammus(int ammusID,string suunta, string ampujanId, int ammukseTyyppi, int tTD, bool Olemassa)
            {
                AmmusID = ammusID; // avain dictionaryyn
                Suunta = suunta;
                AmpujanId = ampujanId;
                AmmuksenTyyppi= ammukseTyyppi;
                MaxTTD =5;
                TTD = tTD;
                OnkoOlemassa = Olemassa;
            }
        }
        public class Pelaaja
        {
            public int PelaajaID { get; set; }
            public string Nimi { get; set; }
            public bool OnkoHengissa { get; set; }

            public int MaxAmmukset { get; set; }
            public int Ammukset { get; set; }

            public string Sijainti { get; set; } // X,Y

            public int HP = 10;
            public int MaxHP { get; set; }

            public int HahmonKoko = 5; // tehdaan aluksi nelio kertomalla

          public Pelaaja(int Id, string nimi, string sijainti)
            {
                PelaajaID = Id;
                Nimi = nimi;
                Sijainti = sijainti;
            }
        }


        private void stackp_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (ammukset > 0)
            {
                ammukset--;
                lataus.Value = ammukset;
                label.Content = "Ammukset " + ammukset +"/"+ maxAmmukset;
              Point position =Mouse.GetPosition(this.stackp); // tassa eventissa kaytetaan hiirta
              new Point(position.X, position.Y);
                // eventtissa luodaan uusi luoti muoto
                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.Black);
                l.StrokeThickness = 2.0;
                l.X1 = 0; //luotia tehdessa saadaan tiedot
                l.Y1 = 0;
                l.X2 = position.X;
                l.Y2 = position.Y;
                l.Name = "l";
                stackp.Children.Clear(); // ei saa kaytaa stackpanelia
                stackp.Children.Add(l);
                initmystuff();

            }
        }

        private void stackp_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = Mouse.GetPosition(this.stackp);
            playerpos.Text = "X: " + position.X + "\n" + "Y: " + position.Y;
        }

        private void lataaAmmukset_Click(object sender, RoutedEventArgs e)
        {
            ammukset = maxAmmukset;
            lataus.Value = ammukset; // pitais hoitaa eventilla
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;  // pitais hoitaa eventilla
        }
    }
}

