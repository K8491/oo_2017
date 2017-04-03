using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private const int maxHeight = 345 - playerWidth;
        private const int maxWidth = 334 - playerWidth;
        private const int playerWidth = 24;
        private int playerLenght = 24;
        private int easiness = 40; //timerin ajastin aika
        private int score = 0;
        //private int omenaNRO = 0;
        private List<Point> bonusPoints = new List<Point>(); //omena kokoelma
        private const int bonusCount = 20; //omenat
        private List<Line> playerParts = new List<Line>();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right;
        private DispatcherTimer timer;
        private Random rnd = new Random(); // pisteiden arvontaa varten
        //List<Ammus> AmmututAmmukset = new List<Ammus>();

        /*
        // luodit ja viholliset
        private Point lSijainti = new Point();
        */
        private Direction direction;
        private Point vSijainti = new Point();
        private int TTD = 3;
        private bool hit = false;
        private bool shot = false;
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
            MouseRightButtonDown += new MouseButtonEventHandler(MouseDownR);
            //piirretaan omenat ja kaarme
            IniBonusPoints();
            Paintplayer(startingPoint);
            currentPosition = startingPoint;

            //start game
            timer.Start(); //ikaan kuin loop

        } 
        public void initmystuff()
        {
            // EMPTY! just why do i exist?
    

        }
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
            
        }*/
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

          //  int count = pelikentta.Children.Count;

        }
        private Point ArvoPiste(Point point)
        { // might cause crashes when spawning stuff too close
            Point position = point;
            point = new Point(rnd.Next(minimi, maxWidth), rnd.Next(minimi, maxHeight));
            do
            {
                new Point(rnd.Next(minimi, maxWidth), rnd.Next(minimi, maxHeight));

            } while((Math.Abs(position.X - point.X + position.Y - point.Y) < 30));
            //(!(Math.Abs(position.X - point.X) < 30 && (Math.Abs(position.Y - point.Y) < 30)));
            return point;
        }
        private void PaintBonus(int index)
        {
            Point point = new Point();
            // arvotaan omenalle piste (X,Y)
            point = ArvoPiste(currentPosition);
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
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);
           // rnd = new Random();
        }// FIX ME 
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
                    } break;
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
            if ((currentPosition.X > maxWidth - playerWidth) || (currentPosition.X < minimi) ||
                (currentPosition.Y > maxHeight - playerLenght) || (currentPosition.Y < minimi))
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
        private void MouseDownR(object sender, MouseButtonEventArgs e)
        {
            if (ammukset < maxAmmukset)
                lataaAmmukset();
        }
        private void Ampuu(Point currentpos, bool valine)
        {
            do
            {

                Direction key = suunta(currentpos, currentPosition); // ylikirjotetaan aina..
                                                                     // pelkistetty ampuminen, ei saa enaa ampua vinottain. // arvot Current position => target position
                if (valine == true)
                {
                    key = suunta(currentpos, hiiri()); // palauttaa left, right, down, up
                }
                // TODO listataan listaan missa on kaikki ammutut luodit, talla hetkella menevaan vaan pelikentalle
                //tarkistetaan minne ollaan ampumassa jos ei tähdätä hiirellä    rtt.Angle = 0; osoittaa alus ylos
                if (valine == false)
                { // pelaajan aluksen rotaatiosta
                    int keyb = Convert.ToInt32(rtt.Angle);
                    switch (keyb)
                    {
                        case 0:
                            key = Direction.Down;
                            break;
                        case 90:
                            key = Direction.Left;
                            break;
                        case 180:
                            key = Direction.Up;
                            break;
                        case 270:
                            key = Direction.Right;
                            break;
                    }
                }
                if (hit == false && TTD > 0)
                    if (key == Direction.Down)
                    { // ylos
                      // currentpos.Y = 0;
                        if (currentpos.Y <= playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.Y -= playerWidth;
                    }
                    else if (key == Direction.Left)
                    { // oikealle
                      // currentpos.X = maxWidth;
                        if (currentpos.X >= maxWidth - playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.X += playerWidth;
                    }
                    else if (key == Direction.Up)
                    { // alas
                      // currentpos.Y = maxHeight;
                        if (currentpos.Y >= maxWidth - playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.Y += playerWidth;
                    }

                    else if (key == Direction.Right)
                    { // vasen
                      // currentpos.X = 0;
                        if (currentpos.X <= playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.X -= playerWidth;
                    }
                //tarkistetaan ammukset
                if (ammukset > 0)
                {
                    //ammus on ammuttu ja seuraavaksi tarkistus osuiko, sitten jatketaan matkaa
                    // eventtissa luodaan uusi luoti muoto

                    // Not implemented yet, because I'm lazy
                    // Ammus t = new Ammus(currentPosition, suunta(currentPosition, hiiri()));
                    // AmmututAmmukset.Add(t);

                    Line l = new Line();
                    l.Stroke = new SolidColorBrush(Colors.Aqua);
                    l.StrokeThickness = 2.0;
                    l.X1 = currentPosition.X; //luotia tehdessa saadaan tiedot
                    l.Y1 = currentPosition.Y;
                    l.X2 = currentpos.X; // direction X
                    l.Y2 = currentpos.Y; // direction Y
                    pelikentta.Children.Add(l);
                    txtBlock.Text = "Child: " + pelikentta.Children.Count + "Key: (" + key + ") X:" + l.X1 + "/" + l.X2 + "  Y: " + l.Y1 + "/" + l.Y2;
                    //txtBlock.Text = "Child: " + suunta(currentPosition, hiiri());
                    if (TTD > 0)
                    {
                        tarkistaOsuma(currentpos);
                        System.Threading.Thread.Sleep(5); //pysäyttää koko ohjelman, pitäisi tehdä oma thread ampumiselle että ei tarvitsisi muun liikkeen pysähtyä
                    }
                }
                if (shot == true)
                {
                    TTD = 3;
                    ammukset--;
                    lataus.Value = ammukset;
                }
                //tahan tulee osumisen tarkistus ammukselle, tama kohta on ammuksen piirron osassa kiinni
                // tarkistus loppuu
            } while (TTD>0 && shot==false);
        }
        private Direction suunta(Point myXY, Point targetXY)
        {
            vSijainti = hiiri(); // tallahetkella klikataan suunta minne mennaan
            double dx = myXY.X - targetXY.X+1;
            double dy = myXY.Y - targetXY.Y+1;
            if (Math.Abs(dx) > Math.Abs(dy))
                direction = (dx > 0) ? Direction.Right : Direction.Left;
            else
                direction = (dy > 0) ? Direction.Down : Direction.Up;

            return direction;
        }
        private Point hiiri()
        {
            // PC killer, smelly, code here.
        Point position = Mouse.GetPosition(this.pelikentta); //system stack overflow.....
            return position;
        } // jos halutaan tietaa hiiren sijainti
        private void lataaAmmukset()
        {
            ammukset = maxAmmukset;
            lataus.Value = ammukset; // pitais hoitaa eventilla
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;  // pitais hoitaa eventilla
        }
        private void tarkistaOsuma(Point currentpos)
        {
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if (TTD > 0)
                {

                    if (((Math.Abs(point.X - currentpos.X) < playerWidth) &&
                       (Math.Abs(point.Y - currentpos.Y) < playerWidth)))
                    {
                        TTD--;
                        // syodaan omena
                        score += 10;
                        Debug.Print(score.ToString());
                        //    playerLenght += 10; if i were a snake i would grow

                        // nopeutetaan pelia
                        if (easiness > 5)
                        {
                            easiness--;
                            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                        }
                        this.Title = "playerWPF Your score:" + score;
                        bonusPoints.RemoveAt(n);
                        pelikentta.Children.RemoveAt(n);
                        PaintBonus(n);
                        break;
                    }
                }
                n++;
            }
            shot = true;
        }
    }
}