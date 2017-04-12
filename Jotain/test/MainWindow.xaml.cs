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
    /// K8491 - WPF, C# Student project 3-4.2017
    /// about   --> Shooter/candycollecting /and umm space theme..
    /// Game logic:
    /// Main will start the timer and event handlers
    /// Timer tick will check if we bumb to something and call the painting of player on the canvas
    /// Event handlers listen to the key press and calls the shooting, loading excetera.
    /// 
    /// </summary>
    /// <TODO>
    /// // lines may move since there will be changes
/*1. Make summary great again.. never was great but yeah...
2. remember to update the git wiki repo for the project /line 26
3. Arrange the partial class thingys /line 25->
4. also arrange the logical things by use
5. init my stuff to use
6. class ammus /line 86
7. calculate the spawn of everything and the locations where they can spwn...
8. double check 7
9. Draw more shapes and colors. (bonus if the shape names are delicious and look tasty) /line 150
10. /line 164 movement logic for the "apples"
11. Make walls around the play field, bonus if the edges feel like space ships window or something
 which will fit the game type
12. Take down player name and add insult to the "fail" screen /line 315
13. make it whacky like you just droped a bass(if score is > 5000)
14. add loding and shootijng sounds
15. fix the shooting mechanics, /line 342
16. HALL OF FLAME, köhöm Tables of deliciousness: Your score > My score = You have more tasty treats. (princess is happy)
17. Make the princess??
18. Cake to the loading screen. (wait what loading screen?.. -menu??)
19. Scoret talletetaan tiedostoon (txt/csv)

    olioohjelmointia enemman ja koodi kuvaavammaksi.


maybe move through walls and teleporting like in the snake??

Issues
    // when clicking crash
    */
    /// </TODO>
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    }
    public partial class MainWindow : Window
    {// muista siirtaa peliprojektin alle gittiin
     //TODO muista laskea kaikkein olioiden raunat, ei vain yksi arvo jostain reunasta vaan koko olio
     // --||-- vs tormaystarkastus 
        int childCount = 0; // ammukset lentaa eventille
        int ccChanged = 0;
        private int ammukset = 10;
        private int maxAmmukset = 10;
        private const int minimi = 3;
        private const int maxHeight = 345 - playerWidth;
        private const int maxWidth = 334 - playerWidth;
        private const int playerWidth = 24;
        //   private int playerLenght = 24; deprivated ;D
        private int easiness = 40; //timerin ajastin aika
        private int score = 0;
        //private int omenaNRO = 0;
        private List<Point> bonusPoints = new List<Point>(); //omena kokoelma
        private const int bonusCount = 20; //omenat
        private List<Line> playerParts = new List<Line>();
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Point currentLazerPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right;
        private DispatcherTimer timer;
        private DispatcherTimer ammuksetLentaa;
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
        //

        //HOF
        Dictionary<string, int> scoreBoard =
         new Dictionary<string, int>();
        // dictionary.Add( string(Pelaaja ID), INT(pisteet));

        public MainWindow()
        {
            initmystuff();
        }
        public void initmystuff()
        {
            InitializeComponent();
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
            //piirretaan omenat ja kaarme
            IniBonusPoints();
            Paintplayer(startingPoint);
            currentPosition = startingPoint;

            // lasketaan lapset
            childCount = pelikentta.Children.Count;
            //start game
            timer.Start(); //ikaan kuin loop
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


        }
        private Point ArvoPiste(Point point)
        { // might cause crashes when spawning stuff too close
            Point position = point;
            do
            {
                point = new Point(rnd.Next(minimi, maxWidth), rnd.Next(minimi, maxHeight));

            } while ((Math.Abs(position.X - point.X + position.Y - point.Y) < 30));
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
                            lataaAmmukset();
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
        private void timer_Tick(object sender, EventArgs e) // pakolliset tapahtuman kasittelijat, ei voi olla pelkka methodi
        {
            /*
            MoveBonus(omenaNRO); // TODO muista poistaa jos omenat ei liiku 
            if (omenaNRO == bonusCount)
                omenaNRO = 0;
            omenaNRO++;
            */

            //label.Content = "Ammukset " + ammukset + "/" + maxAmmukset;
            label.Content = ccChanged + "/" + childCount;
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
            var anim = new DoubleAnimation(rnd.Next(0, 10), 4000 - score, TimeSpan.FromSeconds(18));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            pelikentta.RenderTransform = trs;
            if (score < 4000)
                Debug.Print(" Pathetic");
            else if (score < 30000)
            {
                Debug.Print(" Good Jobbu");
            }
            else if (score > 30000)
            {
                Debug.Print(" Oh look who has cheats..");
            }
            Console.ReadLine();
            // initmystuff(); //for score test debuging only...
        }
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
        private void Ampuu(Point currentpos, bool valine)
        {
            // TODO MAKE THREAD of shooting so you can have lazers mooving in the game and see em GO!.
            // (siis ilman while rakennetta)=> pitäisi päästä
            // loopista ulos ja kutsua päivitystä jolla päivitetään kentällä oleva liikkuva lazeria.
            // eli tehdään olio ammuksesta jota voidaan seurata ja paivittaa,
            //(listassa) ja se poistuu kun TTD==0 (vahenee riippuen mihin se tormaa) jolloin se poistetaan
            // keeping these out of loop
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
            // ends--
            do
            {
                key = suunta(currentpos, currentPosition); // ylikirjotetaan aina..
                                                           // pelkistetty ampuminen, ei saa enaa ampua vinottain. // arvot Current position => target position
                if (valine == true)
                {
                    key = suunta(currentpos, hiiri()); // palauttaa left, right, down, up
                }
                // TODO listataan listaan missa on kaikki ammutut luodit
                // niin etta luoti jatkaa matkaa, (luodin kohde lasketaan uudelleen palakerrallaan)

                //tarkistetaan minne ollaan ampumassa jos ei tähdätä hiirellä    rtt.Angle = 0; osoittaa alus ylos
                if (valine == false)
                { // pelaajan aluksen rotaatiosta
                    keyb = Convert.ToInt32(rtt.Angle);
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
                if (hit == false && TTD > 0)
                    if (key == Direction.Up)
                    { // ylos
                      // currentpos.Y = 0;
                        if (currentpos.Y <= playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.Y -= playerWidth;
                    }
                    else if (key == Direction.Right)
                    { // oikealle
                      // currentpos.X = maxWidth;
                        if (currentpos.X >= maxWidth - playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.X += playerWidth;
                    }
                    else if (key == Direction.Down)
                    { // alas
                      // currentpos.Y = maxHeight;
                        if (currentpos.Y >= maxWidth - playerWidth)
                        {
                            hit = true;
                        }
                        else
                            currentpos.Y += playerWidth;
                    }

                    else if (key == Direction.Left)
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
                    switch (key) //POW ja alus lentaa taakse pain
                    {
                        case Direction.Up:
                            currentPosition.Y += 1;
                            break;
                        case Direction.Right:
                            currentPosition.X -= 1;
                            break;
                        case Direction.Down:
                            currentPosition.Y -= 1;
                            break;
                        case Direction.Left:
                            currentPosition.X += 1;
                            break;
                    }
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
                    ccChanged++;
                     //txtBlock.Text = "Child: " + suunta(currentPosition, hiiri());
                    tarkistaOsuma(currentpos);
                    //tahan tulee osumisen tarkistus ammukselle, tama kohta on ammuksen piirron osassa kiinni
                    // tarkistus loppuu
                    ammuksetLentaa.Start();
                }
            } while (hit == false && TTD > 0); // && shot == false
          //  pelikentta.Children.RemoveAt(count);
            ammukset--;
            lataus.Value = ammukset;
            hit = false;
        }

        private void ammuksetLentaa_Tick(object sender, EventArgs e)
        {
            if (ccChanged > childCount)
            {
                pelikentta.Children.RemoveAt(childCount);
                ccChanged--;
            }else if(ccChanged == childCount)
            {

            }else
            {
                ammuksetLentaa.Stop();
            }

        }

        private Direction suunta(Point myXY, Point targetXY)
        {
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
                        Debug.Print(score.ToString() + "Debug mode only");
                        //    playerLenght += 10; if i were a snake i would grow

                        // nopeutetaan pelia
                        if (easiness > 5)
                        {
                            easiness--;
                            timer.Interval = new TimeSpan(0, 0, 0, 0, easiness);
                        }
                        Title = "playerWPF Your score:" + score;
                        bonusPoints.RemoveAt(n);
                        pelikentta.Children.RemoveAt(n);
                        PaintBonus(n);
                        break;
                    }
                }
                n++;
            }
        }
        private void kirjoitaListaan()

        { /* NOT implemented
            using (System.IO.StreamWriter file =
          new System.IO.StreamWriter(@"C:\Users\Public\TestFolder\WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
            */
        }
    }
}