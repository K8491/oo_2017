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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public partial class MainWindow : Window
    {
        //TODO muista laskea kaikkein olioiden raunat, ei vain yksi arvo jostain reunasta vaan koko olio
        // --||-- vs tormaystarkastus 
        private int ammukset = 10;
        private int maxAmmukset = 10;
        private const int minimi = 10;
        private const int maxHeight = 345-minimi;
        private const int maxWidth = 334-minimi;
        private const int playerWidth = 24;
        private int playerLenght = 24;
        private int easiness = 40; //timerin ajastin aika
        private int score = 0;
        private int omenaNRO = 0;
        private List<Point> bonusPoints = new List<Point>(); //omena kokoelma
        private const int bonusCount = 20; //omenat
        private List<Line> playerParts = new List<Line>();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right;
        private DispatcherTimer timer;
        private Random rnd = new Random(); // pisteiden arvontaa varten

        // luodit ja viholliset
        private double lastX;
        private double lastY;
        private Direction direction;
        private Point vSijainti = new Point();
        //

        public MainWindow()
        {
            InitializeComponent();
            initmystuff();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
            timer.Tick += new EventHandler(timer_Tick);
            // maaritellaan ikkunalle tapahtuman kasittelija nappaimiston kuuntelua varten
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            MouseLeftButtonDown += new MouseButtonEventHandler(MouseDown);
            //piirretaan omenat ja kaarme
            IniBonusPoints();
            Paintplayer(startingPoint);
            currentPosition = startingPoint;

            //start game
            timer.Start(); //ikaan kuin loop

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
          //  System.Windows.Controls.Image img = new System.Windows.Controls.Image(); // I needed to disambiguate Image.
          //  img.Source = new BitmapImage(new Uri("E:/olio/ohjelmointi/Jotain/test/pictures/player.png", UriKind.RelativeOrAbsolute)); // fire.png is something like 24 x 44 pixels.



        }  
        public class Ammus
        {
            public int AmmusID { get; set; } // listan index
            public string Suunta { get; set; }  // vektori / rtt.Angel  enumdir
            public string AmpujanId { get; set; } // tarvitaanko tietaa??
            public int AmmuksenTyyppi { get; set; } // ei tassa pelissa
            public int TTD { get; set; }  // lista int sama index kuin ammus listan ammuksessa, mutta pitaa sisallaan TTD(int) arcon
            public int MaxTTD { get; set; } // const int
            public int Nopeus=4;  // osien pituus jos lasketaan etta luntikerralla luoti kulkee suuntaansa x matkan/sek (tarkista matematiikan kaava)
            public bool OnkoOlemassa { get; set; } // ei tarvita koska TTD arvo olisi 0.
            Ammus(int ammusID,string suunta, string ampujanId, int ammukseTyyppi, int tTD, bool Olemassa)
            {
                AmmusID = ammusID; // avain dictionaryyn, ei vaan listaan
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
            public int PelaajaID { get; set; } // ei tarvita useita hahmo listan id, jos vihollisia saadaan peliin
            public string Nimi { get; set; }
            public bool OnkoHengissa { get; set; } // Hahmolistan rinalle toinen lista, tai hahmolistan sisaan kaksi arvoa. (olio lista?)

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
        private void IniBonusPoints()
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n); // kutsuu Paintbonus..

            }
        }
        private void Paintplayer(Point currentpoint)
        {

            Canvas.SetTop(player, currentpoint.Y);
            Canvas.SetLeft(player, currentpoint.X);
           
            int count = pelikentta.Children.Count;

        }
        private Point ArvoPiste(Point point)
        {
            point = new Point(rnd.Next(minimi, maxWidth - 10), rnd.Next(minimi, maxHeight - 10));
                do
                {
                   new Point(rnd.Next(minimi, maxWidth - 10), rnd.Next(minimi, maxHeight - 10));

                } while ((Math.Abs(currentPosition.X - point.X) < 24 && (Math.Abs(currentPosition.Y - point.Y) < 10)));

            return point;
        }
        private void PaintBonus(int index)
        {
            Point point = new Point();
            // arvotaan omenalle piste (X,Y)
          point =  ArvoPiste(point);
            //omenan piirto
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Lime;
            omena.Width = playerWidth * 0.8;
            omena.Height = playerWidth * 0.8;
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);
            pelikentta.Children.Insert(index, omena); //koska me lisätään listassa tiettyyn pisteeseen
            bonusPoints.Insert(index, point);
       
        }
        private void MoveBonus(int omenaNRO)
        {
            // arvotaan omenalle piste (X,Y)
            //omenan liike

                    pelikentta.Children.RemoveAt(omenaNRO);
                    bonusPoints.RemoveAt(omenaNRO);
                    // sama kuin paint bonuksessa
                    Point point = new Point();
                    Ellipse omena = new Ellipse();
                    omena.Fill = Brushes.Lime;
                    omena.Width = playerWidth * 0.8;
                    omena.Height = playerWidth * 0.8;
                    //
                    point.X += bonusPoints[omenaNRO].X + (rnd.Next(-4, 4));
                    point.Y += bonusPoints[omenaNRO].Y + (rnd.Next(-4, 4));
                    pelikentta.Children.Insert(omenaNRO, omena); //koska me lisätään listassa tiettyyn pisteeseen
                    bonusPoints.Insert(omenaNRO, point);
                    Canvas.SetTop(omena, point.Y );
                    Canvas.SetLeft(omena, point.X);
                rnd = new Random();
        }
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            // muutetaan suuntaa nappaimiston painalluksen mukaan
            // mutta ei sallita 180 asteen kaannosta
            switch (e.Key)
            {
                case Key.P:
                    if (timer.IsEnabled)
                        timer.Stop();
                    else
                        timer.Start();

                    break;
                case Key.Escape:
                    if (timer.IsEnabled)
                        GameOver();
                    else
                        this.Close();
                    break;
                case Key.R:
                    if (ammukset < maxAmmukset)
                        lataaAmmukset();
                    break;
                case Key.Space:
                    if (ammukset > 0)
                    {
                        Ampuu(currentPosition, false);
                    }break;
                case Key.Left:
                    if (lastDirection != Direction.Right)
                        currentDirection = Direction.Left;
                    break;

                case Key.Up:
                    if (lastDirection != Direction.Down)
                        currentDirection = Direction.Up;
                    break;

                case Key.Right:
                    if (lastDirection != Direction.Left)
                        currentDirection = Direction.Right;
                    break;
                case Key.Down:
                    if (lastDirection != Direction.Up)
                        currentDirection = Direction.Down;
                    break;
            }
            lastDirection = currentDirection;
        }
        private void timer_Tick(object sender, EventArgs e) // pakolliset tapahtuman kasittelijat, ei voi olla pelkka methodi
        {
            /*
            MoveBonus(omenaNRO); // TODO muista poistaa jos omenat ei liiku 
            if (omenaNRO == bonusCount)
                omenaNRO = 0;
            omenaNRO++;
            */

            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= 4;
                    rtt.Angle = 0; //rotate xaml elementti
                    break;
                case Direction.Right:
                    currentPosition.X += 4;
                    rtt.Angle = 90;
                    break;
                case Direction.Down:
                    currentPosition.Y += 4;
                    rtt.Angle = 180;
                    break;
                case Direction.Left:
                    currentPosition.X -= 4;
                    rtt.Angle = 270;
                    break;
                default:
                    break;
            }
            Paintplayer(currentPosition);
            //tormaystarkastelut 1-3
            //TT#1 tarkistetaan onko canvaasilla
            if ((currentPosition.X > maxWidth) || (currentPosition.X < minimi) ||
                (currentPosition.Y > maxHeight) || (currentPosition.Y < minimi))
                GameOver();
            // TT#2 tarkistetaan ettei pure omaa hantaansa
         /*   for (int i = 0; i < playerParts.Count - playerWidth * 2; i++)
            {
                Point p = new Point(playerParts[i].X, playerParts[i].Y);
                if ((Math.Abs(p.X - currentPosition.X) < playerWidth) &&
                    (Math.Abs(p.Y - currentPosition.Y) < playerWidth))
                {
                    GameOver();
                    break;
                }
            }*/
            //TT#3
            // tarkistetaan osuuko omenaan
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < playerWidth) &&
                   (Math.Abs(point.Y - currentPosition.Y) < playerWidth))
                {
                    // syodaan omena
                    score += 10;
                    playerLenght += 10;

                    // nopeutetaan pelia
                    if (easiness > 5)
                    {
                        easiness--;
                        timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                    }
                    else 
                    {
                        easiness= 1;
                        score += 10;
                    }
                    this.Title = "playerWPF Your score:" + score;
                    bonusPoints.RemoveAt(n);
                    pelikentta.Children.RemoveAt(n);
                    PaintBonus(n);
                    break;
                }
                n++;
            }

        }
        private void GameOver()
        {
            timer.Stop();
            //MessageBox.Show("Your Score: " + score); 
            // this.Close(); // palaa startti ikkunaan
            GameOverShow();
            
        }
        private void GameOverShow()
        {
            txtBlock.Text = "Your score: " + score + " \n press Esc to quit";
            //animaatio joka siirtaa kanvaasin
            var trs = new TranslateTransform();
            var anim = new DoubleAnimation(0, 620, TimeSpan.FromSeconds(15));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            pelikentta.RenderTransform = trs;
        }
        private new void MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ampuu(currentPosition, true);
        }
        private void Ampuu(Point currentpos, bool valine)
        {
             // TODO listataan listaan missa on kaikki ammutut luodit, talla hetkella menevaan vaan pelikentalle
            //tarkistetaan minne ollaan ampumassa jos ei tähdätä hiirellä    rtt.Angle = 0; osoittaa alus ylos
            if (valine)
            {
                currentpos = hiiri();
            }
            else
           {
                int key = Convert.ToInt16(rtt.Angle);
                if (key == 0 | key == 90 | key == 180 | key == 270)
                {
                    switch (key)
                    { 
                        case 0: // ylos
                            currentpos.Y = currentPosition .Y - 60;
                            break;
                        case 90: // oikealle
                            currentpos.X = currentPosition.X + 60;

                            break;
                        case 180: // alas
                            currentpos.Y = currentPosition.Y + 60;
                            break;

                        case 270: // vasen
                            currentpos.X = currentPosition.X - 60;
                            break;
                    }
                }
            }
            //ammutaan
            if (ammukset > 0)
            {
                ammukset--;
                lataus.Value = ammukset;

                new Point(currentpos.X, currentpos.Y);
                // eventtissa luodaan uusi luoti muoto
                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.Aqua);
                l.StrokeThickness = 2.0;
                l.X1 = currentPosition.X; //luotia tehdessa saadaan tiedot
                l.Y1 = currentPosition.Y;
                l.X2 = currentpos.X;
                l.Y2 = currentpos.Y;
               
                /* TODO
                int n = 0;
                if (n >= 2)
                {
                    //poistetaan luoteja
                        pelikentta.Children.RemoveAt();
                }
                n++;
                */ 
                pelikentta.Children.Add(l);
                txtBlock.Text = "" + pelikentta.Children.Count;
        }
        }
        private void suunta()
        {
            vSijainti = hiiri(); // tallahetkella klikataan suunta minne mennaan
            double dx = vSijainti.X - lastX;
            double dy = vSijainti.Y - lastY;
            if (Math.Abs(dx) > Math.Abs(dy))
                direction = (dx > 0) ? Direction.Right : Direction.Left;
            else
                direction = (dy > 0) ? Direction.Down : Direction.Up;

        }
        private Point hiiri()
        {
            Point position = Mouse.GetPosition(this.pelikentta);
            return position;
        } // jos halutaan tietaa hiiren sijainti
        private void lataaAmmukset()
        {
            ammukset = maxAmmukset;
            lataus.Value = ammukset; // pitais hoitaa eventilla
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;  // pitais hoitaa eventilla
        }
    }
}