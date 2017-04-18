using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace test
{
    /// <summary>
    /// Student project, WPF game
    /// based on SNAKE WPF example
    /// 
    /// targets to hit, like bounds and it's game over.
    /// or green "aliens" (totaly not apples).. to get points.
    /// or just shoot 'em with lazer.
    /// beawere targets like to move, just a little but once they are gone.
    /// no more score...
    /// </summary>

    /* TODO...
    6. class ammus  // ei tarvita
    7. calculate the spawn of everything and the locations where they can spwn...
    8. double check 7
    9. Draw more shapes and colors. (bonus if the shape names are delicious and look tasty) 
    12. Take down player name and add insult to the "fail" screen 
    14. add loading and shooting sounds

    olioohjelmointia enemman ja koodi kuvaavammaksi.

        */
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public partial class MainWindow : Window
    {
        #region initstuff
        // pelin rajoituksia (ikkunan koko yms)
        private const int bonusCount = 20; //omenat
        private const int minimi = 3;
        private const int maxHeight = 345;
        private const int maxWidth = 334;
        private const int playerWidth = 24;

        // Timerille
        private int easiness = 40; //timerin ajastin aika
        private DispatcherTimer timer;
        private DispatcherTimer ammuksetLentaa;

        // ammukset lentaa eventille
        int childCount = 0;
        int ccChanged = 0;

        // pelaaja tiedot
        string Name = "Player"; //sadaan hello ikkunasta

        // pelaajan ammukset
        private int ammukset = 10;
        private int maxAmmukset = 10;

        private int score = 0;

        //  olio listat
        private List<Point> bonusPoints = new List<Point>();
        private List<Line> playerParts = new List<Line>();
        private Dictionary<string, int> HOS = new Dictionary<string, int>();

        // Sijainti
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Point currentLazerPosition = new Point();

        // liikeen suunta 
        private Direction lastDirection = new Direction();
        private Direction currentDirection = new Direction();

        private Random rnd = new Random(); // pisteiden arvontaa varten

        // Ei pelaajan tietoja
        private Direction direction; // lazerille
        private Point vSijainti = new Point(); // hiiren osoittama suunta
        private int TTD = 3; // ammukset ei saa osua liian moneen pisteeseen kerralla #ammuksenpiirtotarkistus 1
        private bool hit = false; // TTD:n  #ammuksenpiirtotarkistus 2
        //

        //HOF
        Dictionary<string, int> scoreBoard =
         new Dictionary<string, int>();
        // dictionary.Add( string(Pelaaja ID), INT(pisteet));
        #endregion initstuff
        public MainWindow(string name)
        {
            Name = name;
            Initmystuff();
        }

        public void Initmystuff()
        {
            InitializeComponent();
            // asetetaan ajastimet
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
            timer.Tick += new EventHandler(timer_Tick);

            ammuksetLentaa = new DispatcherTimer();
            ammuksetLentaa.Interval = new TimeSpan(0, 0, 0, 0, easiness);
            ammuksetLentaa.Tick += new EventHandler(ammuksetLentaa_Tick);


                         // maaritellaan ikkunalle tapahtuman kasittelija nappaimiston kuuntelua varten
            KeyDown += new KeyEventHandler(OnButtonKeyDown);
            MouseLeftButtonDown += new MouseButtonEventHandler(MouseDown);
            MouseRightButtonDown += new MouseButtonEventHandler(MouseDownR);

                         // piirretaan osuttavat pisteet ja pelaaja
            IniBonusPoints();
            Paintplayer(startingPoint);
            currentPosition = startingPoint;

            // lasketaan lapset (pelikentalla pakosti olevat, auttaa lazerien poistossa

            // maalataan kerran rajat
            PaintBorder();
            childCount = pelikentta.Children.Count;
                         // peli lahtee kayntia
            timer.Start(); //peliloop
        }
        private void IniBonusPoints()
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n); // piirra osuttavat oliot (vain yksi talla hetkella)

            }
        }
        private void PaintBorder()
        {
            //      maxHeight = 345 - playerWidth;
            //      maxWidth = 334 - playerWidth;
            // yla osa
            Line l = new Line();
            l.Stroke = new SolidColorBrush(Colors.ForestGreen);
            l.StrokeThickness = 2.0;
            l.X1 = 0; //luotia tehdessa saadaan tiedot
            l.X2 = maxWidth; // direction X
            pelikentta.Children.Add(l);
            // ala osa
            l = new Line();
            l.Stroke = new SolidColorBrush(Colors.ForestGreen);
            l.StrokeThickness = 2.0;
            l.Y1 = maxHeight;
            l.Y2 = maxHeight;
            l.X1 = 0; //luotia tehdessa saadaan tiedot
            l.X2 = maxWidth; // direction X
            pelikentta.Children.Add(l);
            //oikea reuna
            l = new Line();
            l.Stroke = new SolidColorBrush(Colors.ForestGreen);
            l.StrokeThickness = 2.0;
            l.Y1 = 0; //luotia tehdessa saadaan tiedot
            l.Y2 = maxHeight; // direction X
            l.X1 = maxWidth;
            l.X2 = maxWidth;
            pelikentta.Children.Add(l);
            //vasen reuna
            l = new Line();
            l.Stroke = new SolidColorBrush(Colors.ForestGreen);
            l.StrokeThickness = 2.0;
            l.Y1 = 0; //luotia tehdessa saadaan tiedot
            l.Y2 = maxHeight; // direction X
            l.X1 = 0;
            l.X2 = 0;
            pelikentta.Children.Add(l);
        }
        private void Paintplayer(Point currentpoint)
        {

            Canvas.SetTop(player, currentpoint.Y);
            Canvas.SetLeft(player, currentpoint.X);


        }
        private void PaintBonus(int index)
        {
            // osuttavien tiedot
            Point point = new Point();
            point = ArvoPiste(currentPosition);
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Lime;
            omena.Width = playerWidth * 0.8;
            omena.Height = playerWidth * 0.8;
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);
            pelikentta.Children.Insert(index, omena); //koska me lisätään listassa tiettyyn pisteeseen
            bonusPoints.Insert(index, point);

        }
        private Point ArvoPiste(Point point)
        { // might cause crashes when spawning stuff too close
            Point position = point;
            do
            { // arvotaan pistetta kunnes piste on hyvaksyttava.
                point = new Point(rnd.Next(minimi, (maxWidth-playerWidth)), rnd.Next(minimi, (maxHeight-playerWidth)));

            } while ((Math.Abs(position.X - point.X + position.Y - point.Y) < 30));
            return point;
        }
        private void Ampuu(Point currentpos, bool valine)
        {

                            // keeping these out of loop..
            if (!(ammuksetLentaa.IsEnabled))
            {
                ccChanged = childCount;
                ammuksetLentaa.Start();  //timer ammuksille
            }else
            {
                ammuksetLentaa.Stop();
            }
            TTD = 3;
            Direction key = suunta(currentpos, currentPosition);
            int keyb = 0;
                             // ..ends
            do
            {               // joka kierros piirtaa yhden osan lazerista.
                key = suunta(currentpos, currentPosition); // ylikirjotetaan aina..
                                                           // pelkistetty ampuminen, ei saa enaa ampua vinottain. // arvot Current position => target position
                if (valine == true)
                {
                    key = suunta(currentpos, hiiri()); // palauttaa left, right, down, up
                }

                            //  rtt.Angle = 0; osoittaa alus ylos
                if (valine == false)
                { 
                    keyb = Convert.ToInt32(rtt.Angle); // pelaajan aluksen rotaatio kaaneetaan directioniksi
                    switch (keyb)
                    {
                        case 0:
                            key = Direction.Up;
                            break;
                        case 90:
                            key = Direction.Right;
                            break;
                        case 180:
                            key = Direction.Down;
                            break;
                        case 270:
                            key = Direction.Left;
                            break;
                    }
                }
                if (hit == false && TTD > 0)  //jos ammus saa jatkaa matkaa
                    if (key == Direction.Up)
                    { // ylos
                      // currentpos.Y = 0;
                        if (currentpos.Y == 0) // rajaa mihinka asti ammusta piirretaan
                        {
                            hit = true;
                        }
                        else
                            currentpos.Y -= playerWidth;
                           if (currentpos.Y <= 0)
                        {
                            currentpos.Y = 0;
                        }
                    }
                    else if (key == Direction.Right)
                    { // oikealle
                      // currentpos.X = maxWidth;
                        if (currentpos.X == maxWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.X += playerWidth;

                        if (currentpos.X >= maxWidth)
                        {
                            currentpos.X = maxWidth;
                        }
                    }

                    else if (key == Direction.Down)
                    { // alas
                      // currentpos.Y = 0;
                        if (currentpos.Y == maxHeight)
                        {
                            hit = true;
                        }
                        else
                            currentpos.Y += playerWidth;
                        if (currentpos.Y >= maxHeight)
                        {
                            currentpos.Y = maxHeight;
                        }
                    }
                    else if (key == Direction.Left)
                    { // vasen
                      // currentpos.X = 0;
                        if (currentpos.X == 0)
                        {
                            hit = true;
                        }
                        else
                            currentpos.X -= playerWidth;
                            if (currentpos.X <= 0)
                            {
                                currentpos.X = 0;
                            }
                    }


                //tarkistetaan ammukset
                if (ammukset > 0)
                {
                                    //ammus on ammuttu ja seuraavaksi tarkistus osuiko, sitten jatketaan matkaa
          // FIX ME.  Ammus t = new Ammus(currentPosition, suunta(currentPosition, hiiri()));

                            // piirretaan viiva lazeria esittamaan
                    Line l = new Line();
                    l.Stroke = new SolidColorBrush(Colors.Aqua);
                    l.StrokeThickness = 2.0;
                    l.X1 = currentLazerPosition.X; //luotia tehdessa saadaan tiedot
                    l.Y1 = currentLazerPosition.Y;
                    currentLazerPosition.X = currentpos.X; //luotia tehdessa saadaan tiedot
                    currentLazerPosition.Y = currentpos.Y;
                    l.X2 = currentpos.X; // direction X
                    l.Y2 = currentpos.Y; // direction Y
                    pelikentta.Children.Add(l);
                    ccChanged++; // lazerin haviamista varten oleva laskuri
                    TarkistaOsuma(currentpos);
                    // tarkistus loppuu
                    ammuksetLentaa.Start();
                }
            } while (hit == false && TTD > 0); // && shot == false
          //  pelikentta.Children.RemoveAt(count);
            ammukset--;
            lataus.Value = ammukset;
            hit = false;
        }
        private void LataaAmmukset()
        {
            ammukset = maxAmmukset;
            lataus.Value = ammukset;
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset; 
        }
        private void TarkistaOsuma(Point currentpos)
        {
            // tarkistetaan osuuko lazeri kohteeseen
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if (TTD > 0)
                {

                    if (((Math.Abs(point.X - currentpos.X) < playerWidth) &&
                       (Math.Abs(point.Y - currentpos.Y) < playerWidth)))
                    {
                        TTD--;
                        score += 10;
                        //Debug.Print(score.ToString() + "Debug mode only");
                        //    playerLenght += 10; if i were a snake i would grow more magnificent

                        // nopeutetaan pelia
                        if (easiness > 5)
                        {
                            easiness--;
                            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                        }
                        Title = Name +" "+ score;
                        bonusPoints.RemoveAt(n);
                        pelikentta.Children.RemoveAt(n);
                        PaintBonus(n);
                        break;
                    }
                }
                n++;
            }
        }
        private void MoveBonus(int omenaNRO)
        {
            // arvotaan omenalle piste (X,Y)
            //omenan liike
            // sama kuin paint bonuksessa
            Point point = new Point();
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Lime;
            omena.Width = playerWidth * 0.8;
            omena.Height = playerWidth * 0.8;

            // kaytetaan edellisia x ja y arvoja
            if (score < 400)
            {
                point.X = +bonusPoints[omenaNRO].X + (rnd.Next(-4, 4));
                point.Y = +bonusPoints[omenaNRO].Y + (rnd.Next(-4, 4));
            }
            else if (score < 800)
            {
                point.X = +bonusPoints[omenaNRO].X - (rnd.Next(-4, 4));
                point.Y = +bonusPoints[omenaNRO].Y - (rnd.Next(-4, 4));
            }
            else if (score < 2000)
            {
                point.X = +bonusPoints[omenaNRO].X + (rnd.Next(-4, 4));
                point.Y = +bonusPoints[omenaNRO].Y - (rnd.Next(-4, 4));
            }
            else
            {
                point.X = +bonusPoints[omenaNRO].X - (rnd.Next(-4, 4));
                point.Y = +bonusPoints[omenaNRO].Y + (rnd.Next(-4, 4));
            }
            // poistetaan edellinen piirros
            pelikentta.Children.RemoveAt(omenaNRO);
            bonusPoints.RemoveAt(omenaNRO);
            //piirretaan uusi
            pelikentta.Children.Insert(omenaNRO, omena); //koska me lisätään listassa tiettyyn pisteeseen
            bonusPoints.Insert(omenaNRO, point);
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);

            // jos omenat liikkuu yli rajojen.


        }
        private void GameOver()
        {
            timer.Stop();
            HOS.Add(Name, score);
            KirjoitaListaan(); // HALL OF SHAME (list of scores).
            GameOverShow();

        }
        private void GameOverShow()
        {
            txtBlock.Text = "Your score: " + score + " \n press Esc to quit";
            //animaatio joka siirtaa kanvaasin
            var trs = new TranslateTransform();
            var anim = new DoubleAnimation(rnd.Next(0, 10), 4000 - score, TimeSpan.FromSeconds(18));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            pelikentta.RenderTransform = trs;
            if (score < 4000)
                Debug.Print(" Pathetic");
            else if (score < 30000)
            {
                Debug.Print(" Good Job");
            }
            else if (score > 30000)
            {
                Debug.Print(" Good score, did you cheat??");
            }
            Console.ReadLine();
            // <- remove for fun!   initmystuff(); //for score test debuging only...
        }
        private void KirjoitaListaan()
        {
            try
            { // kirjoitetaan tiedostoon pelaajna nimi ja score
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (StreamWriter file = new StreamWriter(mydocpath + @"\HOS.txt", true))
                    foreach (var entry in HOS)
                        file.WriteLine("[{0} {1}]", Name, score);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found (FileNotFoundException)");
            }
        }
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            // muutetaan suuntaa nappaimiston painalluksen mukaan
            // mutta ei sallita 180 asteen kaannosta
            if (timer.IsEnabled || e.Key == Key.P || e.Key == Key.Escape)
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
                            LataaAmmukset();
                        break;
                    case Key.Space:
                        if (ammukset > 0)
                        {
                            currentLazerPosition = currentPosition;
                            Ampuu(currentPosition, false);
                        }
                        break;
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
        private void timer_Tick(object sender, EventArgs e)
        {
            for (int p=0; p < bonusCount ; p++)
            {
                MoveBonus(p);
            }


            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= 4;
                    rtt.Angle = 0; //rotate xaml elementti, kertoo aluksen osoittaman suunnan
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
            //tormaystarkastelut 1,2
            //TT#1 tarkistetaan onko canvaasilla
            if ((currentPosition.X > maxWidth) || (currentPosition.X < minimi) ||
                (currentPosition.Y > maxHeight) || (currentPosition.Y < minimi))
                GameOver();
            //TT#2
            // tarkistetaan osuuko omenaan
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < playerWidth) &&
                   (Math.Abs(point.Y - currentPosition.Y) < playerWidth))
                {
                    // tormataan pisteeseen
                    score += 10;
                    //    playerLenght += 10; if i were a snake i would grow

                    // nopeutetaan pelia
                    if (easiness > 5)
                    {
                        easiness--;
                        timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                    }
                    else
                    {
                        easiness = 1;
                        score += 10;
                    }
                    Title = Name + " " + score;
                    bonusPoints.RemoveAt(n);
                    pelikentta.Children.RemoveAt(n);
                    PaintBonus(n);
                    break;
                }
                n++;
            }
        } // pelin paa ajastin
        private void ammuksetLentaa_Tick(object sender, EventArgs e)
        {
            if (ccChanged > childCount)
            {
                pelikentta.Children.RemoveAt(childCount);
                ccChanged--;
            }
            else if (ccChanged == childCount)
            {
                // Please just waste RAM here.
            }
            else
            {
                ammuksetLentaa.Stop();
            }

        } // lazerien poiston ajastin
        // todo
        /*  public class Ammus
    {
        private int hypyt = 3;
        private int nopeus = 4;  // osien pituus jos lasketaan etta luntikerralla luoti kulkee suuntaansa x matkan/sek (tarkista matematiikan kaava)
        private Point sijainti = new Point();
        private Direction suunta = new Direction();
        public  Ammus(Point b, Direction c)
        {
            sijainti = b;
            suunta = c;
            }

    }*/ // never used, too smelly.
        /*  public class Pelaaja
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
              }}*/
        // hiiri poissa kaytosta
        private new void MouseDown(object sender, MouseButtonEventArgs e)
        {
            /* Mouse is broken
             * if (timer.IsEnabled)
                Ampuu(currentPosition, true);
            */
        }
        private void MouseDownR(object sender, MouseButtonEventArgs e)
        {/* mouse not enabled
            if (timer.IsEnabled)
                if (ammukset < maxAmmukset)
                lataaAmmukset();
        */
        }
        private Direction suunta(Point myXY, Point targetXY)
        {
            // muunnetaan hiiren osoittama sijainti yksinkertaiseksi suunnaksi
            vSijainti = hiiri(); // tallahetkella klikataan suunta minne mennaan
            double dx = myXY.X - targetXY.X;
            double dy = myXY.Y - targetXY.Y;
            if (Math.Abs(dx) > Math.Abs(dy))
                direction = (dx > 0) ? Direction.Left : Direction.Right;
            else
                direction = (dy > 0) ? Direction.Up : Direction.Down;
            return direction;
        }
        private Point hiiri()
        {
            // PC killer, smelly, code here.
            Point position = Mouse.GetPosition(pelikentta); //system stack overflow.....
            return position;
        } // jos halutaan tietaa hiiren sijainti
    }
}