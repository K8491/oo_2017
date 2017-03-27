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
        private int ammukset = 10;
        private int maxAmmukset = 10;
        private const int minimi = 10;
        private const int maxHeight = 345-minimi;
        private const int maxWidth = 334-minimi;
        private const int snakeWidth = 10;
        private int snakeLenght = 100;
        private int easiness = 50; //timerin ajastin aika
        private int score = 0;
        private List<Point> bonusPoints = new List<Point>(); //omena kokoelma
        private const int bonusCount = 20; //omenat
        private List<Point> snakeParts = new List<Point>();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right;
        private DispatcherTimer timer;
        private Random rnd = new Random(); // pisteiden arvontaa varten

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
            PaintSnake(startingPoint);
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

        private void IniBonusPoints()
        {
            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n); // kutsuu Paintbonus..

            }
        }
        private void PaintSnake(Point currentpoint)
        {
            Ellipse snake = new Ellipse();
            snake.Fill = Brushes.Green;
            snake.Width = snakeWidth;
            snake.Height = snakeWidth;
            Canvas.SetTop(player, currentpoint.Y);
            Canvas.SetLeft(player, currentpoint.X);
            int count = pelikentta.Children.Count;
            pelikentta.Children.Add(snake);
            snakeParts.Add(currentPosition);
            //rajoitetaan käärmeen pituutta
            //huom! bonusCount < snakeLenght
            if (count > snakeLenght)
            {
                pelikentta.Children.RemoveAt(count - snakeLenght + (bonusCount - 1));
                snakeParts.RemoveAt(count - snakeLenght);

            }
        }
        private void PaintBonus(int index)
        {

            // arvotaan omenalle piste (X,Y)
            Point point = new Point(rnd.Next(minimi, maxWidth - 10), rnd.Next(minimi, maxHeight - 10));
            for (int i = 0; i < snakeParts.Count; i++)
            {
                do
                {
                    new Point(rnd.Next(minimi, maxWidth - 10), rnd.Next(minimi, maxHeight - 10));

                } while ((Math.Abs(snakeParts[i].X - point.X) < 10 && (Math.Abs(snakeParts[i].Y - point.Y) < 10)));
                break;
            }
            //omenan piirto
            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Red;
            omena.Width = snakeWidth;
            omena.Height = snakeWidth;
            Canvas.SetTop(omena, point.Y);
            Canvas.SetLeft(omena, point.X);

            pelikentta.Children.Insert(index, omena); //koska me lisätään listassa tiettyyn pisteeseen
            bonusPoints.Insert(index, point);


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
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= 4;
                    break;
                case Direction.Right:
                    currentPosition.X += 4;
                    break;
                case Direction.Down:
                    currentPosition.Y += 4;
                    break;
                case Direction.Left:
                    currentPosition.X -= 4;
                    break;
                default:
                    break;
            }
            PaintSnake(currentPosition);
            //tormaystarkastelut 1-3
            //TT#1 tarkistetaan onko canvaasilla
            if ((currentPosition.X > maxWidth) || (currentPosition.X < minimi) ||
                (currentPosition.Y > maxHeight) || (currentPosition.Y < minimi))
                GameOver();
            // TT#2 tarkistetaan ettei pure omaa hantaansa
            for (int i = 0; i < snakeParts.Count - snakeWidth * 2; i++)
            {
                Point p = new Point(snakeParts[i].X, snakeParts[i].Y);
                if ((Math.Abs(p.X - currentPosition.X) < snakeWidth) &&
                    (Math.Abs(p.Y - currentPosition.Y) < snakeWidth))
                {
                    GameOver();
                    break;
                }
            }
            //TT#3
            // tarkistetaan osuuko omenaan
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < snakeWidth) &&
                   (Math.Abs(point.Y - currentPosition.Y) < snakeWidth))
                {

                    // syodaan omena
                    score += 10;
                    snakeLenght += 10;

                    // nopeutetaan pelia
                    if (easiness > 5)
                    {
                        easiness--;
                        timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                    }
                    else
                    {
                        snakeLenght += 5;
                        score += 10;
                    }
                    this.Title = "SnakeWPF Your score:" + score;
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
            Ampuu(currentPosition);
        }
        private void Ampuu(Point currentpos)
        {

            if (ammukset > 0)
            {
                ammukset--;
                lataus.Value = ammukset;
                Point position = Mouse.GetPosition(this.pelikentta); // tassa eventissa kaytetaan hiirta
                new Point(position.X, position.Y);
                // eventtissa luodaan uusi luoti muoto
                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.Aqua);
                l.StrokeThickness = 2.0;
                l.X1 = currentPosition.X; //luotia tehdessa saadaan tiedot
                l.Y1 = currentPosition.Y;
                l.X2 = position.X;
                l.Y2 = position.Y;
                //pelikentta.Children.Clear(); // ei saa kaytaa stackpanelia, vaan kaytetaan canvasta
                pelikentta.Children.Add(l);
            }
        }
        private void lataaAmmukset()
        {
            ammukset = maxAmmukset;
            lataus.Value = ammukset; // pitais hoitaa eventilla
            label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;  // pitais hoitaa eventilla
        }


    }
    
}

